using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Attech.FlightMonitor.UI.Controls
{
    public partial class FileSelectorControl : UserControl
    {
        string _filter = string.Empty;

        public FileSelectorControl()
        {
            InitializeComponent();
        }

        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
            }
        }

        public string FileName
        {
            get
            {
                return pathTextBox.Text;
            }
            set
            {
                pathTextBox.Text = value;
            }
        }
        
        public void Clear()
        {
            pathTextBox.Clear();
        }
        
        public bool ValidatePath()
        {
            return File.Exists(FileName);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = _filter;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = ofd.FileName;
            }
        }

        [Category("Action")]
        public event EventHandler FileChanged;

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FileChanged != null)
                FileChanged(this, e);
        }


    }
}
