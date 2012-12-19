using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AnfiniL.SqlExpressProfiler.Logic;
using SqlServerTools.Data;
using AnfiniL.SqlExpressProfiler.Properties;
using System.Collections;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class TraceViewControl : UserControl
    {
        private Trace _trace;

        public TraceViewControl()
        {
            InitializeComponent();

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        public Trace Trace
        {
            get
            {
                return _trace;
            }
            set
            {
                _trace = value;
                traceDataGridView.DataSource = value.DataTable;

                //start of patch from d4ljoyn: http://code.google.com/u/d4ljoyn/
                TraceField[] definedFields = (TraceField[])Enum.GetValues(typeof(TraceField));
                foreach (TraceField field in Enum.GetValues(typeof(TraceField)))
                {
                    foreach (AnjLab.FX.System.Pair<int,int> pair in TraceManager.GetUserTraceEvents())
                    {
                        string userEvent = definedFields[pair.B - 2].ToString();
                        if (field.ToString() == userEvent)
                        {
                            traceDataGridView.Columns.Add(Utils.NewTextBoxColumn(field.ToString(), field.ToString(), true));
                            break;
                        }
                    }
                }
                //end of patch from d4ljoyn
            }
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AutoResizeColumns")
                traceDataGridView.AutoSizeColumnsMode = Settings.Default.AutoResizeColumns
                                                            ? DataGridViewAutoSizeColumnsMode.AllCells
                                                            : DataGridViewAutoSizeColumnsMode.None;
        }

        private void traceDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!Settings.Default.EnableAutoScroll) return;

            if (traceDataGridView.CurrentCell == null) return;

            traceDataGridView.CurrentCell = traceDataGridView.Rows[e.RowIndex].Cells[traceDataGridView.CurrentCell.ColumnIndex];
        }

        private void traceDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (_trace.IsLocked || traceDataGridView.SelectedRows.Count == 0)
            {
                detailsTextBox.Clear();
                return;
            }

            StringBuilder builder = new StringBuilder();

            // If only one row is selected, then don't add the 'go' statement
            bool addGo = (traceDataGridView.SelectedRows.Count > 1);

            ArrayList sortedRows = new ArrayList(traceDataGridView.SelectedRows);
            sortedRows.Sort(new DataGridRowIndexComparer());

            // Loop through the selectes rows
            foreach (DataGridViewRow curRow in sortedRows)
            {
                DataRowView row = curRow.DataBoundItem as DataRowView;
                if (curRow.Selected && row != null && row.Row.Table.Columns.Contains(TraceField.TextData.ToString()))
                {
                    string value = row[TraceField.TextData.ToString()] as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        builder.AppendLine(value);
                        if (addGo)
                            builder.AppendLine("go\r\n");
                    }
                }
            }

            detailsTextBox.Text = builder.ToString();
        }
    }

    internal class DataGridRowIndexComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var xRow = x as DataGridViewRow;
            var yRow = y as DataGridViewRow;
            if(xRow == null || yRow == null) return 0;

            return xRow.Index.CompareTo(yRow.Index);
        }
    }
}
