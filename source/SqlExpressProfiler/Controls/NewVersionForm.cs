using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class NewVersionForm : Form
    {
        public NewVersionForm()
        {
            InitializeComponent();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenBrowser(linkLabel.Text);
        }

        public static void ShowForm()
        {
            NewVersionForm frm = new NewVersionForm();
            frm.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}