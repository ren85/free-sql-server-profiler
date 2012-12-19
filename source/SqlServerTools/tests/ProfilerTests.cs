using System;
using System.Data;
using System.IO;
using System.Threading;
using AnfiniL.SqlServerTools.Impl;
using Microsoft.SqlServer.Management.Common;
using NUnit.Framework;
using SqlServerTools.Data;
using SqlServerTools.Impl;

namespace SqlServerTools.tests
{
    [TestFixture]
    public class ProfilerTests
    {
        ManualResetEvent re = new ManualResetEvent(false);
        string path = @"testunit.trc";
        Profiler profiler;

        [SetUp]
        public void Setup()
        {
            SqlConnectionInfo ci = new SqlConnectionInfo(@".");
            profiler = new Profiler(new SqlConnInfo(ci));
            profiler.Initialize(TraceOptions.FileRollover, path);
        }

        [TearDown]
        public void TearDown()
        {
            profiler.Close();
            File.Delete(profiler.TraceFilePath);
        }

        [Test]
        public void Test1()
        {
            TraceField[] traceFields = new TraceField[] {TraceField.ApplicationName, TraceField.TextData, TraceField.StartTime, TraceField.Reads, TraceField.LoginSID};

            profiler.AddTraceEvent(TraceEvent.RPCCompleted, traceFields);
            profiler.AddTraceEvent(TraceEvent.RPCStarting, traceFields);
            profiler.AddTraceEvent(TraceEvent.SQLBatchCompleted, traceFields);
            profiler.AddTraceEvent(TraceEvent.SQLBatchStarting, traceFields);

            profiler.AddTraceFilter(TraceField.TextData, LogicalOperator.AND, ComparisonOperator.NotEqual, "sdsd");

            profiler.TraceEvent += new EventHandler<TraceEventArgs>(profiler_TraceEvent);
            profiler.Start();

            re.WaitOne(new TimeSpan(0,0, 10), true);
            profiler.Stop();
        }

        void profiler_TraceEvent(object sender, TraceEventArgs e)
        {
            foreach (DataRow row in e.EventsTable.Rows)
            {
                string result = "";
                foreach (object o in row.ItemArray)
                    result += " " + o.ToString();
                Console.WriteLine(result);
            }
        }

    }
}
