using System;
using System.Windows.Forms;
using AnfiniL.SqlExpressProfiler.Controls;
using AnfiniL.SqlExpressProfiler.Logic;
using AnfiniL.SqlExpressProfiler.VisualStyles;
using AnfiniL.SqlServerTools.Data;
using FarsiLibrary.Win;
using SqlServerTools.Data;
using AnfiniL.SqlExpressProfiler.Properties;

namespace AnfiniL.SqlExpressProfiler
{
    public partial class MainForm : Form
    {
        private TraceManager _traceManager;
        private Trace _currentTrace;
        
        public MainForm()
        {
            InitializeComponent();

            this.menuStrip.Renderer = DefaultColorTable.GetRenderer();
            this.toolStrip.Renderer = DefaultColorTable.GetRenderer();
            this._traceManager = new TraceManager(this);
        }

        public Trace CurrentTrace
        {
            get { return _currentTrace; }
            set
            {
                _currentTrace = value;
                EnableToolStripButtons();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableToolStripButtons();
            UpdatesChecker.NewVersionIsAvailable += UpdatesChecker_NewVersionIsAvailable;
            UpdatesChecker.StartNewVersionChecking();
        }

        void UpdatesChecker_NewVersionIsAvailable(object sender, EventArgs e)
        {
            EventHandler handler = delegate {
                                       NewVersionForm.ShowForm();
                                   };
            BeginInvoke(handler);
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            StartCurrentTrace();
            EnableToolStripButtons();
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            Trace trace = CurrentTrace;
            bool result = !StopCurrentTrace();

            if (!result && trace != null)
                _traceManager.DeleteProfiler(trace.Profiler);
            
            EnableToolStripButtons();
        }

        private void pauseToolStripButton_Click(object sender, EventArgs e)
        {
            PauseCurrentTrace();
            EnableToolStripButtons();
        }

        /// <summary>
        /// Return false if login user is not DBO.
        /// </summary>
        /// <param name="tpf">a TracePropertiesForm object</param>
        /// <returns>False if login user is not DBO.</returns>
        bool permission(TracePropertiesForm tpf)
        {
            
            //System.Data.SqlClient.SqlConnection conn;
            //if (tpf.RawConn != null)
            //    conn = new System.Data.SqlClient.SqlConnection(tpf.RawConn);
            //else
            //{
            //    string str_conn = string.Format("Data Source={0};Application Name={1};Database={2};",
            //        tpf.ServerName, "sqlprofilerapp", "master");
            //    if (tpf.Username == string.Empty)
            //        str_conn += string.Format("Integrated Security={0};", true);
            //    else
            //        str_conn += string.Format("User ID={0};Password={1};", tpf.Username, tpf.Password);
            //    conn = new System.Data.SqlClient.SqlConnection(str_conn);
            //}
            //conn.Open();
            //Microsoft.SqlServer.Management.Common.ServerConnection sconn;
            //sconn = new Microsoft.SqlServer.Management.Common.ServerConnection(conn);
            //Microsoft.SqlServer.Management.Smo.Server server;
            //server = new Microsoft.SqlServer.Management.Smo.Server();
            //var a = server.Databases["master"];
            //bool rc = server.Databases["master"].DboLogin;
            //conn.Close();
            //return rc;
            
            return true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TracePropertiesForm tpf = new TracePropertiesForm();
            tpf.StartPosition = FormStartPosition.CenterScreen;

            if(tpf.ShowDialog() == DialogResult.OK)
            {
                if (!permission(tpf))
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' has no correct permission.", tpf.Username),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Trace trace = _traceManager.RunProfiler(tpf.ServerName, tpf.Username, tpf.Password, tpf.TraceName, tpf.RawConn, tpf.EventProperties, tpf.FilterProperties);

                    TraceViewControl tvc = new TraceViewControl();
                    tvc.Name = "TraceViewControl";
                    tvc.Trace = trace;
                    tvc.Dock = DockStyle.Fill;

                    FATabStripItem item = new FATabStripItem(tvc);
                    item.Title = tpf.TraceName;
                    tabStrip.AddTab(item, true);

                    tabStrip.Enabled = true;
                }
            }
        }

        private void tabStrip_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if(e.ChangeType == FATabStripItemChangeTypes.SelectionChanged)
            {
                CurrentTrace = GetCurrentTrace();
                EnableToolStripButtons();
            }
        }
        
        private void EnableToolStripButtons()
        {
            startToolStripButton.Enabled = CurrentTrace != null && CurrentTrace.Profiler.Status != TraceStatus.Started && CurrentTrace.Profiler.Status != TraceStatus.Closed;
            pauseToolStripButton.Enabled = CurrentTrace != null && CurrentTrace.Profiler.Status != TraceStatus.Stopped && CurrentTrace.Profiler.Status != TraceStatus.Closed;
            stopToolStripButton.Enabled = CurrentTrace != null && CurrentTrace.Profiler.Status != TraceStatus.Stopped && CurrentTrace.Profiler.Status != TraceStatus.Closed;
        }
        
        #region private methods

        /// <summary>
        /// Gets the current trace.
        /// </summary>
        /// <returns></returns>
        /// <value>The current trace.</value>
        private Trace GetCurrentTrace()
        {
            if (tabStrip.SelectedItem == null)
                return null;

            TraceViewControl tvc = tabStrip.SelectedItem.Controls["TraceViewControl"] as TraceViewControl;
            if (tvc == null)
                return null;

            return tvc.Trace;
        }
        
        private void SetCurrentTrace(Trace trace)
        {
            if (tabStrip.SelectedItem == null)
                return;

            TraceViewControl tvc = tabStrip.SelectedItem.Controls["TraceViewControl"] as TraceViewControl;
            if (tvc == null)
                return;
                
            tvc.Trace = trace;
            CurrentTrace = trace;
        }
        
        private void StartCurrentTrace()
        {
            if (CurrentTrace == null) return;
            
            if(CurrentTrace.Profiler.Status == TraceStatus.Closed)
            {
                SetCurrentTrace(_traceManager.RunProfiler(CurrentTrace.Profiler));
                return;
            }

            StatusErrorCode errorCode = CurrentTrace.Profiler.Start();
            if (errorCode != StatusErrorCode.NoError)
            {
                MessageBox.Show("Can't start trace: " + errorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool StopCurrentTrace()
        {
            if (CurrentTrace == null) return true;

            StatusErrorCode errorCode = CurrentTrace.Profiler.Stop();
            if (errorCode != StatusErrorCode.TraceIsInvalid)
            {
                if (errorCode != StatusErrorCode.NoError)
                {
                    MessageBox.Show("Can't stop trace: " + errorCode, "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                errorCode = CurrentTrace.Profiler.Close();
                if (errorCode != StatusErrorCode.NoError)
                {
                    MessageBox.Show("Can't close trace: " + errorCode, "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }

            CurrentTrace = null;
            
            return true;
        }
        
        private void PauseCurrentTrace()
        {
            if (CurrentTrace == null) return;

            StatusErrorCode errorCode = CurrentTrace.Profiler.Stop();
            if(errorCode == StatusErrorCode.TraceIsInvalid)
            {
                MessageBox.Show("Could not find the trace. Please close the trace and start a new.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (errorCode != StatusErrorCode.NoError)
            {
                MessageBox.Show("Can't pause trace: " + errorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void tabStrip_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            Trace trace = CurrentTrace;
            bool result = !StopCurrentTrace();
            e.Cancel = result;
            
            if(!result && trace != null)
                _traceManager.DeleteProfiler(trace.Profiler);
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (FATabStripItem item in tabStrip.Items)
            {
                TraceViewControl tvc = item.Controls[0] as TraceViewControl;
                if (tvc != null)
                {
                    Trace trace = tvc.Trace;
                    trace.Profiler.Stop();
                    trace.Profiler.Close();

                    if (trace != null)
                    {
                        _traceManager.DeleteProfiler(trace.Profiler);
                    }
                    trace = null;
                }
            }
            Settings.Default.Save();
            UpdatesChecker.NewVersionIsAvailable += UpdatesChecker_NewVersionIsAvailable;
            
        }

        private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.EnableAutoScroll = autoScrollToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            Trace trace = CurrentTrace;
            if(trace != null)
            {
                trace.ClearTrace();
            }
        }

        private void autoResizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoResizeColumns = autoResizeColumnsToolStripMenuItem.Checked;
        }
        
    }
}
