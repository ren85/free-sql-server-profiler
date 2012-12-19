using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SqlServerTools.Data;
using AnfiniL.SqlServerTools.Data;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class FilterTracePropertiesControl : UserControl
    {
        private DataTable _source;
        
        public FilterTracePropertiesControl()
        {
            InitializeComponent();

            if (Program.InDesignMode) return;
            InitDataGrid();
        }
        
        public FilterProperties[] Filters
        {
            get
            {
                List<FilterProperties> filters = new List<FilterProperties>();
                foreach (DataRow dr in _source.Rows)
                {
                    if(string.IsNullOrEmpty(dr["Operator"] as string))
                        continue;
                        
                    filters.Add(GetFilterProperties(dr));
                }

                return filters.ToArray();
            }
        }

        private FilterProperties GetFilterProperties(DataRow dr)
        {
            return new FilterProperties((TraceField) dr["DataColumn"],
                                 (ComparisonOperator) Enum.Parse(typeof (ComparisonOperator), dr["Operator"] as string),
                                 dr["Value"] as string);
        }

        private void FilterTracePropertiesControl_Load(object sender, EventArgs e)
        {
            

            
        }
        
        private void InitDataGrid()
        {
            _source = new DataTable();
            _source.Columns.Add("DataColumn", typeof(TraceField));
            _source.Columns.Add("Operator", typeof(string));
            _source.Columns.Add("Value", typeof(string));

            var nonFiltrableFields = new List<TraceField>(FilterProperties.nonFilterableFields);

            foreach (TraceField tf in Enum.GetValues(typeof(TraceField)))
            {
                if (nonFiltrableFields.Contains(tf)) continue;

                DataRow row = _source.NewRow();
                row["DataColumn"] = tf;
                _source.Rows.Add(row);
            }

            List<string> operators = new List<string>();
            operators.Add(string.Empty);
            foreach (ComparisonOperator op in Enum.GetValues(typeof(ComparisonOperator)))
                operators.Add(op.ToString());

            dataGridView.Columns.Add(Utils.NewTextBoxColumn("Data column", "DataColumn", true));
            dataGridView.Columns.Add(Utils.NewComboBoxColumn("Operator", "Operator", false, operators, ""));
            dataGridView.Columns.Add(Utils.NewTextBoxColumn("Value", "Value", false));

            dataGridView.DataSource = _source;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == _source.Columns["Value"].Ordinal)
            {                
                string error = FilterProperties.CheckFilter(GetFilterProperties(_source.Rows[e.RowIndex]));
                if(!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Wrong value: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _source.Rows[e.RowIndex]["Value"] = null;
                    _source.Rows[e.RowIndex]["Operator"] = null;
                }
            }
        }
    }
}
