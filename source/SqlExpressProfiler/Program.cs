using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using AnfiniL.SqlExpressProfiler.Controls;

namespace AnfiniL.SqlExpressProfiler
{
    public static class Program
    {
        public static bool InDesignMode = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InDesignMode = false;

            Application.ThreadException += Application_ThreadException;

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception exc)
            {
                LogException(exc);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogException(e.Exception);
        }

        private static void LogException(Exception exc)
        {
            string version = UpdatesChecker.CurrentAssemblyVersion.ToString();
            NewIssueForm form = new NewIssueForm();
            form.IssueText = string.Format("version: {0}{2}exception: {1} ", version, exc, Environment.NewLine);
            form.Show();
        }
    }
}