using System;
using System.Windows.Forms;
using AnfiniL.SqlExpressProfiler.Properties;
using AnfiniL.SqlServerTools;
using SqlServerTools;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class GeneralTracePropertiesControl : UserControl
    {
        IServerConnector _serverConnector;
        
        public GeneralTracePropertiesControl()
        {
            InitializeComponent();
        }

        private void GeneralTracePropertiesControl_Load(object sender, EventArgs e)
        {
            if(Program.InDesignMode) 
                return;
            
            _serverConnector = ToolsFactory.Instance.CreateServerConnector();
            
            LoadAuthenticationList();

            AddPasswordBindingToSettings();   
        }

        private void AddPasswordBindingToSettings()
        {
            if (savePasswordCheckBox.Checked)
                passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            else
            {
                Settings.Default.Password = string.Empty;
                passwordTextBox.Clear();
            }
        }

        public string TraceName
        {
            get
            {
                return traceNameTextBox.Text.Trim();
            }
        }
        
        public string ServerName
        {
            get
            {
                return serverNameComboBox.Text.Trim();
            }
        }
        
        public string Username
        {
            get
            {
                if(WindowsAuthentication)
                    return string.Empty;
                    
                return userNameComboBox.Text;
            } 
        }
        
        public string Password
        {
            get
            {
                if (WindowsAuthentication)
                    return string.Empty;
                    
                return passwordTextBox.Text;
            }
        }
        
        public bool WindowsAuthentication
        {
            get
            {
                return authenticationComboBox.SelectedIndex == 1;
            }
            set
            {
                if (value)
                    authenticationComboBox.SelectedIndex = 1;
                else
                    authenticationComboBox.SelectedIndex = 0;
            }
        }

        public string RawConn
        {
            get
            {
                if (rawConnectionStringCheckBox.Checked)
                    return RawConnectionStringTextBox.Text;
                else
                    return null;
            }
        }

        private void LoadServerList()
        {
            serverNameComboBox.DataSource = _serverConnector.GetServerList();
        }
        
        private void LoadAuthenticationList()
        {
            authenticationComboBox.Items.Add("SQL Server Authentication");
            authenticationComboBox.Items.Add("Windows Authentication");
            WindowsAuthentication = Settings.Default.LastWindowsAuth;
        }

        private void fileSelectorControl1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void serverNameComboBox_DropDown(object sender, EventArgs e)
        {
            if(serverNameComboBox.DataSource == null)
                LoadServerList();
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            if(TestConnection())
                 MessageBox.Show("Successfully connected to server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            string error;
            string serverName = serverNameComboBox.Text;
            bool result = false;

            if (rawConnectionStringCheckBox.Checked)
                result = _serverConnector.TestRawConnection(RawConnectionStringTextBox.Text, out error);
            else if (authenticationComboBox.SelectedIndex == 0)
                result = _serverConnector.TestConnection(serverName, userNameComboBox.Text, passwordTextBox.Text, out error);
            else
                result = _serverConnector.TestConnection(serverName, out error);

            if (result)
               return true; 
            else
            {
                MessageBox.Show("Error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void authenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            userNameComboBox.Enabled = passwordTextBox.Enabled = authenticationComboBox.SelectedIndex == 0;
            Settings.Default.LastWindowsAuth = WindowsAuthentication;
        }

        private void rawConnectionStringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isRaw = rawConnectionStringCheckBox.Checked;
            RawConnectionStringTextBox.Enabled = isRaw;
            label1.Visible = isRaw;
        }

        private void savePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (savePasswordCheckBox.Checked)
            {
                Settings.Default.Password = passwordTextBox.Text;
                AddPasswordBindingToSettings();
            }
            else
            {
                passwordTextBox.DataBindings.Clear();
            }
        }
    }
}
