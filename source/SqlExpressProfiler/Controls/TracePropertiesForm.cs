using System;
using System.Windows.Forms;
using AnfiniL.SqlExpressProfiler.Properties;
using SqlServerTools.Data;
using AnfiniL.SqlServerTools.Data;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class TracePropertiesForm : Form
    {
        public TracePropertiesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the name of the trace.
        /// </summary>
        /// <value>The name of the trace.</value>
        public string TraceName
        {
            get
            {
                return generalTracePropertiesControl.TraceName;
            }
        }

        /// <summary>
        /// Gets the event properties.
        /// </summary>
        /// <value>The event properties.</value>
        public TraceEventProperties[] EventProperties
        {
            get
            {
                return eventTracePropertiesControl.TraceEvents;
            }
        }

        /// <summary>
        /// Gets the filter properties.
        /// </summary>
        /// <value>The filter properties.</value>
        public FilterProperties[] FilterProperties
        {
            get
            {
                return filterTracePropertiesControl.Filters;
            }
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string ServerName
        {
            get
            {
                return generalTracePropertiesControl.ServerName;
            }
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get
            {
                return generalTracePropertiesControl.Username;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return generalTracePropertiesControl.Password;
            }
        }
        
        public bool WindowsAuthentication
        {
            get
            {
                return generalTracePropertiesControl.WindowsAuthentication;
            }
        }

        public string RawConn
        {
            get
            {
                return generalTracePropertiesControl.RawConn;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if(!generalTracePropertiesControl.TestConnection())
                return;

            Settings.Default.Save();
                
            TraceEventProperties[] events = this.EventProperties;
            if (events.Length == 0)
            {
                MessageBox.Show("Please specify events and data columns.", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}