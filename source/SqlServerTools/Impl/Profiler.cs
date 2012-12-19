using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AnfiniL.SqlServerTools.Impl;
using Microsoft.SqlServer.Management.Common;
using SqlServerTools.Data;
using System.Data.SqlClient;
using SqlServerTools.Exceptions;
using System.Threading;
using System.Data;
using AnfiniL.SqlServerTools.Data;

namespace SqlServerTools.Impl
{
    class Profiler : IProfiler
    {
        private Timer             getTraceTimer;
        private SqlConnInfo connInfo;
        private int               traceId = 0;
        private string            traceFilePath;
        private TraceStatus       traceStatus;
        private List<string>      traceFields = new List<string>();

        private static int TraceCounter = 0;

        public Profiler()
        {
            traceId = TraceCounter++;
        }

        public event EventHandler<TraceEventArgs> TraceEvent;

        public string TraceFilePath
        {
            get
            {
                return traceFilePath;
            }
        }

        public TimeSpan RefreshInterval
        {
            get
            {
                return new TimeSpan(0, 0, 1);
            }
        }

        public int TraceId
        {
            get { return traceId; }
        }

        public TraceStatus Status
        {
            get { return traceStatus; }
        }

        public Profiler(SqlConnInfo connInfo)
        {
            this.connInfo = connInfo;
            //this.connInfo.ApplicationName = "SP" + this.GetType().ToString().GetHashCode();
        }

        public CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath, DateTime? stopTime)
        {
            return this.Initialize(traceOptions, traceFilePath, null, stopTime);
        }

        public CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath, int maxFileSize)
        {
            return this.Initialize(traceOptions, traceFilePath, maxFileSize, null);
        }

        public CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath)
        {
            return this.Initialize(traceOptions, traceFilePath, null, null);
        }


        public CreateTraceErrorCode Initialize(TraceOptions traceOprions)
        {
            return Initialize(traceOprions, null, null, null);
        }

        public CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFile, int? maxFileSize, DateTime? stopTime)
        {
            string file = traceFile;
            int fileIndex = 0;
            string masterFileName = GetMasterDatabaseFullPath();
            if (!string.IsNullOrEmpty(masterFileName))
            {
              while (TraceExists(masterFileName + "." + file + ".trc"))
              {
                file = traceFile + fileIndex++;
              }

              return InitTrace(traceOptions, masterFileName + "." + file, maxFileSize, stopTime);
            }
            else
            {
              return CreateTraceErrorCode.InsufficientRights;
            }
        }

        private bool TraceExists(string tracePath)
        {
            SqlCommand cmd = MsSqlUtil.NewQuery("select count(*) from sys.traces where path = @tracePath");
            MsSqlUtil.AddInParam(cmd, "@tracePath", tracePath);
            int count = (int)MsSqlUtil.ExecuteScalar(cmd, connInfo.CreateConnectionObject());
            return count > 0;
        }

        private string GetMasterDatabaseFullPath()
        {
          // Bernd Linde - Using the Views in 2005 to enable also public logins to trace
          // Reference: http://msdn.microsoft.com/en-us/library/ms174397(SQL.90).aspx
            SqlCommand cmd = MsSqlUtil.NewQuery("use master\r\n\r\nselect top 1 rtrim([physical_name])\r\n  from sys.database_files\r\n where file_id = 1");
            string masterFullPath = string.Empty;
            masterFullPath = MsSqlUtil.ExecuteScalar(cmd, connInfo.CreateConnectionObject()) as string;
            return masterFullPath;
        }

        private CreateTraceErrorCode InitTrace(TraceOptions traceOptions, string traceFilePath, int? maxFileSize, DateTime? stopTime)
        {
            SqlCommand cmd = MsSqlUtil.NewStoredProcedure("sp_trace_create");
            SqlParameter tId = MsSqlUtil.AddOutParam(cmd, "@traceid", traceId);
            MsSqlUtil.AddInParam(cmd, "@options", (int)traceOptions);
            MsSqlUtil.AddInParam(cmd, "@tracefile", traceFilePath);
            if(maxFileSize != null)
                MsSqlUtil.AddInParam(cmd, "@maxfilesize", maxFileSize);
            if(stopTime != null)
                MsSqlUtil.AddInParam(cmd, "@stoptime", stopTime);
            
            int result = MsSqlUtil.ExecuteStoredProcedure(cmd, connInfo.CreateConnectionObject());
            traceId = Convert.ToInt32(tId.Value);
            this.traceFilePath = traceFilePath + ".trc";

            //Add filter to filter profiler stored procedures
            AddTraceFilter(TraceField.ApplicationName, LogicalOperator.AND, ComparisonOperator.NotEqual, connInfo.ApplicationName);

            return (CreateTraceErrorCode)result;
        }

        public AddTraceEventErrorCode AddTraceEvent(TraceEvent traceEvent, params TraceField[] traceFields)
        {
            if (traceId == 0)
                throw new NotInitializedProfilerException();

            foreach (TraceField field in traceFields)
            {
                SqlCommand cmd = MsSqlUtil.NewStoredProcedure("sp_trace_setevent");
                MsSqlUtil.AddInParam(cmd, "@traceid", traceId);
                MsSqlUtil.AddInParam(cmd, "@eventid", (int)traceEvent);
                MsSqlUtil.AddInParam(cmd, "@columnid", (int)field);
                MsSqlUtil.AddInParam(cmd, "@on", true);
                MsSqlUtil.ExecuteStoredProcedure(cmd, connInfo.CreateConnectionObject());

                if(!this.traceFields.Contains(field.ToString()))
                    this.traceFields.Add(field.ToString());
            }

            return AddTraceEventErrorCode.NoError;
        }

        public AddTraceFilterErrorCode AddTraceFilter<T>(TraceField traceField, LogicalOperator logicalOp, ComparisonOperator compOp, T value)
        {
            if (traceId == 0)
                throw new NotInitializedProfilerException();

            SqlCommand cmd = MsSqlUtil.NewStoredProcedure("sp_trace_setfilter");
            MsSqlUtil.AddInParam(cmd, "@traceid", traceId);
            MsSqlUtil.AddInParam(cmd, "@columnid", (int)traceField);
            MsSqlUtil.AddInParam(cmd, "@logical_operator", (int)logicalOp);
            MsSqlUtil.AddInParam(cmd, "@comparison_operator", (int)compOp);            
            MsSqlUtil.AddInParam(cmd, "@value", value);
            return (AddTraceFilterErrorCode)MsSqlUtil.ExecuteStoredProcedure(cmd, connInfo.CreateConnectionObject());
        }

        public StatusErrorCode Start()
        {
            StatusErrorCode result =  SetTraceStatus(TraceStatus.Started);
            if (result == StatusErrorCode.NoError)
            {
                getTraceTimer = new Timer(new TimerCallback(GetTraceTable), null, new TimeSpan(0,0,0), RefreshInterval);
            }
            return result;
        }

        private StatusErrorCode SetTraceStatus(TraceStatus status)
        {
            if (traceId == 0)
                throw new NotInitializedProfilerException();

            StatusErrorCode code = StatusErrorCode.IsInvalid;

            try
            {
                SqlCommand cmd = MsSqlUtil.NewStoredProcedure("sp_trace_setstatus");
                MsSqlUtil.AddInParam(cmd, "@traceid", traceId);
                MsSqlUtil.AddInParam(cmd, "@status", status);
                code = (StatusErrorCode) MsSqlUtil.ExecuteStoredProcedure(cmd, connInfo.CreateConnectionObject());
                if (code == StatusErrorCode.NoError)
                    this.traceStatus = status;
            }
            catch (SqlException exc)
            {
                if (exc.Message.Contains("Could not find the requested trace"))
                {
                    return StatusErrorCode.TraceIsInvalid;
                }

                //throw;
            }

            return code;
        }

        public StatusErrorCode Stop()
        {
            getTraceTimer.Dispose();
            return SetTraceStatus(TraceStatus.Stopped);
        }

        public StatusErrorCode Close()
        {
            return SetTraceStatus(TraceStatus.Closed);
        }

        void OnTraceEvent(DataTable eventsTable)
        {
            if(TraceEvent != null)
                TraceEvent(this, new TraceEventArgs(eventsTable));
        }

        object syncObj = new object();
        int lastRowNum = 0;

        void GetTraceTable(object sender)
        {
            if (traceId == 0)
                return;

            try
            {
                if (Monitor.TryEnter(syncObj))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = string.Format("select * from (select ROW_NUMBER() OVER (order by StartTime) as RowNum, {0} from fn_trace_gettable(@filename, default)) as dt where RowNum > @lastrownum", this.traceFields.Count == 0 ? "*" : string.Join(",", traceFields.ToArray()));
                    MsSqlUtil.AddInParam(cmd, "@filename", traceFilePath);
                    MsSqlUtil.AddInParam(cmd, "@lastrownum", lastRowNum);
                    DataTable table = MsSqlUtil.ExecuteAsDataTable(cmd, connInfo.CreateConnectionObject());
                    
                    if(table.Rows.Count > 0)
                        lastRowNum = Convert.ToInt32(table.Compute("max(RowNum)", string.Empty));

                    Monitor.Exit(syncObj);

                    OnTraceEvent(table);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (traceStatus == TraceStatus.Started)
                Stop();
            if(traceStatus == TraceStatus.Stopped)
                Close();
        }

        #endregion

        public IProfiler Copy()
        {
            Profiler copy = new Profiler(this.connInfo);
            copy.traceFilePath = this.traceFilePath;
            return copy;
        }

    }
}
