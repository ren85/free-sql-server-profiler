using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public static class Utils
    {
        public static DataGridViewColumn NewTextBoxColumn(string name, string propertyName, bool readOnly)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = propertyName;
            c.Name = name;
            c.ReadOnly = readOnly;
            return c;
        }

        public static DataGridViewColumn NewComboBoxColumn(string name, string propertyName, bool readOnly, object dataSource, string displayMember)
        {
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.DisplayMember = displayMember;
            c.DataSource = dataSource;
            c.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            c.DataPropertyName = propertyName;
            c.Name = name;
            c.ReadOnly = readOnly;           
            return c;
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process p = new Process();
                ProcessStartInfo info = new ProcessStartInfo(url);
                p.StartInfo = info;
                p.Start();
            }
            catch
            {
            }
        }
    }
}
