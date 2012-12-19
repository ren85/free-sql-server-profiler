namespace AnfiniL.SqlExpressProfiler.Controls
{
    partial class GeneralTracePropertiesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.authenticationLabel = new System.Windows.Forms.Label();
            this.authenticationComboBox = new System.Windows.Forms.ComboBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.traceNameLabel = new System.Windows.Forms.Label();
            this.traceNameTextBox = new System.Windows.Forms.TextBox();
            this.saveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.setMaximumSizeLabel = new System.Windows.Forms.Label();
            this.setMaximumSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enableFileRolloverCheckBox = new System.Windows.Forms.CheckBox();
            this.saveToTableCheckBox = new System.Windows.Forms.CheckBox();
            this.saveToTableTextBox = new System.Windows.Forms.TextBox();
            this.setMaximimRowsCheckBox = new System.Windows.Forms.CheckBox();
            this.maximumRowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveToTableButton = new System.Windows.Forms.Button();
            this.RawConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.rawConnectionStringCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveToFileFileSelectorControl = new Attech.FlightMonitor.UI.Controls.FileSelectorControl();
            this.horizontalRule1 = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.traceOptionsHorizontalRule = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.serverConnectionHorizontalRule = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameComboBox = new System.Windows.Forms.ComboBox();
            this.serverNameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.setMaximumSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRowsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(4, 24);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(70, 13);
            this.serverNameLabel.TabIndex = 13;
            this.serverNameLabel.Text = "Server name:";
            // 
            // authenticationLabel
            // 
            this.authenticationLabel.AutoSize = true;
            this.authenticationLabel.Location = new System.Drawing.Point(4, 51);
            this.authenticationLabel.Name = "authenticationLabel";
            this.authenticationLabel.Size = new System.Drawing.Size(78, 13);
            this.authenticationLabel.TabIndex = 14;
            this.authenticationLabel.Text = "Authentication:";
            // 
            // authenticationComboBox
            // 
            this.authenticationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authenticationComboBox.FormattingEnabled = true;
            this.authenticationComboBox.Location = new System.Drawing.Point(118, 48);
            this.authenticationComboBox.Name = "authenticationComboBox";
            this.authenticationComboBox.Size = new System.Drawing.Size(277, 21);
            this.authenticationComboBox.TabIndex = 1;
            this.authenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.authenticationComboBox_SelectedIndexChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(21, 78);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(61, 13);
            this.userNameLabel.TabIndex = 15;
            this.userNameLabel.Text = "User name:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(26, 105);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "Password:";
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testConnectionButton.Location = new System.Drawing.Point(468, 157);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(93, 23);
            this.testConnectionButton.TabIndex = 4;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // traceNameLabel
            // 
            this.traceNameLabel.AutoSize = true;
            this.traceNameLabel.Location = new System.Drawing.Point(4, 209);
            this.traceNameLabel.Name = "traceNameLabel";
            this.traceNameLabel.Size = new System.Drawing.Size(67, 13);
            this.traceNameLabel.TabIndex = 18;
            this.traceNameLabel.Text = "Trace name:";
            // 
            // traceNameTextBox
            // 
            this.traceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.traceNameTextBox.Location = new System.Drawing.Point(118, 206);
            this.traceNameTextBox.Name = "traceNameTextBox";
            this.traceNameTextBox.Size = new System.Drawing.Size(444, 20);
            this.traceNameTextBox.TabIndex = 5;
            this.traceNameTextBox.Text = "newTrace";
            // 
            // saveToFileCheckBox
            // 
            this.saveToFileCheckBox.AutoSize = true;
            this.saveToFileCheckBox.Enabled = false;
            this.saveToFileCheckBox.Location = new System.Drawing.Point(7, 252);
            this.saveToFileCheckBox.Name = "saveToFileCheckBox";
            this.saveToFileCheckBox.Size = new System.Drawing.Size(82, 17);
            this.saveToFileCheckBox.TabIndex = 20;
            this.saveToFileCheckBox.Text = "Save to file:";
            this.saveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // setMaximumSizeLabel
            // 
            this.setMaximumSizeLabel.AutoSize = true;
            this.setMaximumSizeLabel.Enabled = false;
            this.setMaximumSizeLabel.Location = new System.Drawing.Point(115, 280);
            this.setMaximumSizeLabel.Name = "setMaximumSizeLabel";
            this.setMaximumSizeLabel.Size = new System.Drawing.Size(115, 13);
            this.setMaximumSizeLabel.TabIndex = 22;
            this.setMaximumSizeLabel.Text = "Set maximum size (MB)";
            // 
            // setMaximumSizeNumericUpDown
            // 
            this.setMaximumSizeNumericUpDown.Enabled = false;
            this.setMaximumSizeNumericUpDown.Location = new System.Drawing.Point(234, 277);
            this.setMaximumSizeNumericUpDown.Name = "setMaximumSizeNumericUpDown";
            this.setMaximumSizeNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.setMaximumSizeNumericUpDown.TabIndex = 8;
            this.setMaximumSizeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setMaximumSizeNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // enableFileRolloverCheckBox
            // 
            this.enableFileRolloverCheckBox.AutoSize = true;
            this.enableFileRolloverCheckBox.Enabled = false;
            this.enableFileRolloverCheckBox.Location = new System.Drawing.Point(118, 303);
            this.enableFileRolloverCheckBox.Name = "enableFileRolloverCheckBox";
            this.enableFileRolloverCheckBox.Size = new System.Drawing.Size(112, 17);
            this.enableFileRolloverCheckBox.TabIndex = 23;
            this.enableFileRolloverCheckBox.Text = "Enable file rollover";
            this.enableFileRolloverCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveToTableCheckBox
            // 
            this.saveToTableCheckBox.AutoSize = true;
            this.saveToTableCheckBox.Enabled = false;
            this.saveToTableCheckBox.Location = new System.Drawing.Point(6, 336);
            this.saveToTableCheckBox.Name = "saveToTableCheckBox";
            this.saveToTableCheckBox.Size = new System.Drawing.Size(92, 17);
            this.saveToTableCheckBox.TabIndex = 21;
            this.saveToTableCheckBox.Text = "Save to table:";
            this.saveToTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveToTableTextBox
            // 
            this.saveToTableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToTableTextBox.Enabled = false;
            this.saveToTableTextBox.Location = new System.Drawing.Point(118, 334);
            this.saveToTableTextBox.Name = "saveToTableTextBox";
            this.saveToTableTextBox.Size = new System.Drawing.Size(419, 20);
            this.saveToTableTextBox.TabIndex = 9;
            // 
            // setMaximimRowsCheckBox
            // 
            this.setMaximimRowsCheckBox.AutoSize = true;
            this.setMaximimRowsCheckBox.Enabled = false;
            this.setMaximimRowsCheckBox.Location = new System.Drawing.Point(118, 363);
            this.setMaximimRowsCheckBox.Name = "setMaximimRowsCheckBox";
            this.setMaximimRowsCheckBox.Size = new System.Drawing.Size(182, 17);
            this.setMaximimRowsCheckBox.TabIndex = 0;
            this.setMaximimRowsCheckBox.Text = "Set maximum rows (in thousands)";
            this.setMaximimRowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // maximumRowsNumericUpDown
            // 
            this.maximumRowsNumericUpDown.Enabled = false;
            this.maximumRowsNumericUpDown.Location = new System.Drawing.Point(300, 360);
            this.maximumRowsNumericUpDown.Name = "maximumRowsNumericUpDown";
            this.maximumRowsNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.maximumRowsNumericUpDown.TabIndex = 11;
            this.maximumRowsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveToTableButton
            // 
            this.saveToTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToTableButton.Enabled = false;
            this.saveToTableButton.Image = global::AnfiniL.SqlExpressProfiler.Properties.Resources.s_h_cuelist;
            this.saveToTableButton.Location = new System.Drawing.Point(539, 333);
            this.saveToTableButton.Name = "saveToTableButton";
            this.saveToTableButton.Size = new System.Drawing.Size(24, 22);
            this.saveToTableButton.TabIndex = 10;
            this.saveToTableButton.Text = "button1";
            this.saveToTableButton.UseVisualStyleBackColor = true;
            // 
            // RawConnectionStringTextBox
            // 
            this.RawConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RawConnectionStringTextBox.Enabled = false;
            this.RawConnectionStringTextBox.Location = new System.Drawing.Point(118, 131);
            this.RawConnectionStringTextBox.Name = "RawConnectionStringTextBox";
            this.RawConnectionStringTextBox.Size = new System.Drawing.Size(445, 20);
            this.RawConnectionStringTextBox.TabIndex = 24;
            // 
            // rawConnectionStringCheckBox
            // 
            this.rawConnectionStringCheckBox.AutoSize = true;
            this.rawConnectionStringCheckBox.Location = new System.Drawing.Point(8, 133);
            this.rawConnectionStringCheckBox.Name = "rawConnectionStringCheckBox";
            this.rawConnectionStringCheckBox.Size = new System.Drawing.Size(81, 17);
            this.rawConnectionStringCheckBox.TabIndex = 25;
            this.rawConnectionStringCheckBox.Text = "Raw String:";
            this.rawConnectionStringCheckBox.UseVisualStyleBackColor = true;
            this.rawConnectionStringCheckBox.CheckedChanged += new System.EventHandler(this.rawConnectionStringCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(5, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Note: add \';Application Name=sqlprofilerapp\' to your connection string to filter " +
                "profiler internal activities";
            this.label1.Visible = false;
            // 
            // saveToFileFileSelectorControl
            // 
            this.saveToFileFileSelectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToFileFileSelectorControl.Enabled = false;
            this.saveToFileFileSelectorControl.FileName = "";
            this.saveToFileFileSelectorControl.Filter = "";
            this.saveToFileFileSelectorControl.Location = new System.Drawing.Point(118, 250);
            this.saveToFileFileSelectorControl.Name = "saveToFileFileSelectorControl";
            this.saveToFileFileSelectorControl.Size = new System.Drawing.Size(443, 21);
            this.saveToFileFileSelectorControl.TabIndex = 7;
            this.saveToFileFileSelectorControl.Load += new System.EventHandler(this.fileSelectorControl1_Load);
            // 
            // horizontalRule1
            // 
            this.horizontalRule1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalRule1.Location = new System.Drawing.Point(3, 231);
            this.horizontalRule1.Name = "horizontalRule1";
            this.horizontalRule1.Size = new System.Drawing.Size(572, 14);
            this.horizontalRule1.TabIndex = 19;
            this.horizontalRule1.Text = "Saving";
            // 
            // traceOptionsHorizontalRule
            // 
            this.traceOptionsHorizontalRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.traceOptionsHorizontalRule.Location = new System.Drawing.Point(3, 186);
            this.traceOptionsHorizontalRule.Name = "traceOptionsHorizontalRule";
            this.traceOptionsHorizontalRule.Size = new System.Drawing.Size(572, 14);
            this.traceOptionsHorizontalRule.TabIndex = 17;
            this.traceOptionsHorizontalRule.Text = "Trace Options";
            // 
            // serverConnectionHorizontalRule
            // 
            this.serverConnectionHorizontalRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverConnectionHorizontalRule.Location = new System.Drawing.Point(3, 3);
            this.serverConnectionHorizontalRule.Name = "serverConnectionHorizontalRule";
            this.serverConnectionHorizontalRule.Size = new System.Drawing.Size(572, 14);
            this.serverConnectionHorizontalRule.TabIndex = 12;
            this.serverConnectionHorizontalRule.Text = "Server Connection";
            // 
            // savePasswordCheckBox
            // 
            this.savePasswordCheckBox.AutoSize = true;
            this.savePasswordCheckBox.Checked = global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default.SavePassword;
            this.savePasswordCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default, "SavePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.savePasswordCheckBox.Location = new System.Drawing.Point(402, 105);
            this.savePasswordCheckBox.Name = "savePasswordCheckBox";
            this.savePasswordCheckBox.Size = new System.Drawing.Size(99, 17);
            this.savePasswordCheckBox.TabIndex = 26;
            this.savePasswordCheckBox.Text = "Save password";
            this.savePasswordCheckBox.UseVisualStyleBackColor = true;
            this.savePasswordCheckBox.CheckedChanged += new System.EventHandler(this.savePasswordCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(118, 102);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(277, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default.Password;
            // 
            // userNameComboBox
            // 
            this.userNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.userNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.userNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default, "LastUserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.userNameComboBox.FormattingEnabled = true;
            this.userNameComboBox.Location = new System.Drawing.Point(118, 75);
            this.userNameComboBox.Name = "userNameComboBox";
            this.userNameComboBox.Size = new System.Drawing.Size(277, 21);
            this.userNameComboBox.TabIndex = 2;
            this.userNameComboBox.Text = global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default.LastUserName;
            // 
            // serverNameComboBox
            // 
            this.serverNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serverNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.serverNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default, "LastServerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.serverNameComboBox.FormattingEnabled = true;
            this.serverNameComboBox.Location = new System.Drawing.Point(118, 21);
            this.serverNameComboBox.Name = "serverNameComboBox";
            this.serverNameComboBox.Size = new System.Drawing.Size(277, 21);
            this.serverNameComboBox.TabIndex = 0;
            this.serverNameComboBox.Text = global::AnfiniL.SqlExpressProfiler.Properties.Settings.Default.LastServerName;
            this.serverNameComboBox.DropDown += new System.EventHandler(this.serverNameComboBox_DropDown);
            // 
            // GeneralTracePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.savePasswordCheckBox);
            this.Controls.Add(this.rawConnectionStringCheckBox);
            this.Controls.Add(this.RawConnectionStringTextBox);
            this.Controls.Add(this.maximumRowsNumericUpDown);
            this.Controls.Add(this.setMaximimRowsCheckBox);
            this.Controls.Add(this.saveToTableButton);
            this.Controls.Add(this.saveToTableTextBox);
            this.Controls.Add(this.saveToTableCheckBox);
            this.Controls.Add(this.enableFileRolloverCheckBox);
            this.Controls.Add(this.setMaximumSizeNumericUpDown);
            this.Controls.Add(this.setMaximumSizeLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.saveToFileFileSelectorControl);
            this.Controls.Add(this.saveToFileCheckBox);
            this.Controls.Add(this.horizontalRule1);
            this.Controls.Add(this.traceNameTextBox);
            this.Controls.Add(this.traceNameLabel);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.traceOptionsHorizontalRule);
            this.Controls.Add(this.userNameComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.authenticationComboBox);
            this.Controls.Add(this.authenticationLabel);
            this.Controls.Add(this.serverNameComboBox);
            this.Controls.Add(this.serverNameLabel);
            this.Controls.Add(this.serverConnectionHorizontalRule);
            this.Name = "GeneralTracePropertiesControl";
            this.Size = new System.Drawing.Size(578, 424);
            this.Load += new System.EventHandler(this.GeneralTracePropertiesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setMaximumSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRowsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Attech.FlightMonitor.UI.Controls.HorizontalRule serverConnectionHorizontalRule;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.ComboBox serverNameComboBox;
        private System.Windows.Forms.Label authenticationLabel;
        private System.Windows.Forms.ComboBox authenticationComboBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ComboBox userNameComboBox;
        private System.Windows.Forms.Button testConnectionButton;
        private Attech.FlightMonitor.UI.Controls.HorizontalRule traceOptionsHorizontalRule;
        private System.Windows.Forms.Label traceNameLabel;
        private System.Windows.Forms.TextBox traceNameTextBox;
        private Attech.FlightMonitor.UI.Controls.HorizontalRule horizontalRule1;
        private System.Windows.Forms.CheckBox saveToFileCheckBox;
        private Attech.FlightMonitor.UI.Controls.FileSelectorControl saveToFileFileSelectorControl;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label setMaximumSizeLabel;
        private System.Windows.Forms.NumericUpDown setMaximumSizeNumericUpDown;
        private System.Windows.Forms.CheckBox enableFileRolloverCheckBox;
        private System.Windows.Forms.CheckBox saveToTableCheckBox;
        private System.Windows.Forms.TextBox saveToTableTextBox;
        private System.Windows.Forms.Button saveToTableButton;
        private System.Windows.Forms.CheckBox setMaximimRowsCheckBox;
        private System.Windows.Forms.NumericUpDown maximumRowsNumericUpDown;
        private System.Windows.Forms.TextBox RawConnectionStringTextBox;
        private System.Windows.Forms.CheckBox rawConnectionStringCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox savePasswordCheckBox;
    }
}
