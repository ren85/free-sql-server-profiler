using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
//using AnfiniL.FX.System;
using SqlServerTools.Data;
using AnfiniL.SqlExpressProfiler.Logic;
using AnjLab.FX.System;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public partial class EventTracePropertiesControl : UserControl
    {
        private DataTable _source;
        public EventTracePropertiesControl()
        {
            InitializeComponent();

            if (Program.InDesignMode) return;
            InitDataGrid();
        }
        
        public TraceEventProperties[] TraceEvents
        {
            get
            {
                var list = new List<TraceEventProperties>();
                var events = new List<Pair<int, int>>();
                foreach(DataRow dr in _source.Rows)
                {
                    
                    var fields = new List<TraceField>();
                    for(int i=2; i<_source.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]) && (bool)dr[i])
                        {
                            fields.Add((TraceField) Enum.Parse(typeof (TraceField), _source.Columns[i].ColumnName));
                            events.Add(Pair.New(dr.Table.Rows.IndexOf(dr), i));
                        }
                    }
                    
                    if(fields.Count == 0) continue;
                    
                    TraceEventProperties p = new TraceEventProperties();
                    p.Event = (TraceEvent)dr["Events"];
                    p.Fields = fields.ToArray();
                    list.Add(p);
                }

                TraceManager.SetUserTraceEvents(events);
                
                return list.ToArray();
            }
        }

        private void EventTracePropertiesControl_Load(object sender, EventArgs e)
        {
            

            
        }
        
        private void InitDataGrid()
        {
            _source = new DataTable();
            _source.Columns.Add("Events", typeof(TraceEvent));
            _source.Columns.Add("All", typeof(bool));

            foreach (TraceField tf in Enum.GetValues(typeof(TraceField)))
                _source.Columns.Add(tf.ToString(), typeof(bool));

            foreach (TraceEvent ev in Enum.GetValues(typeof(TraceEvent)))
            {
                DataRow dr = _source.NewRow();
                dr["Events"] = ev;
                _source.Rows.Add(dr);
            }

            foreach (var pair in TraceManager.GetUserTraceEvents())
                _source.Rows[pair.A][pair.B] = true;

            dataGridView.DataSource = _source;
            dataGridView.Columns[0].ReadOnly = true;

            for (int i = 2; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Width = 50;
            }
        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(dataGridView.CurrentCell.ColumnIndex == 1)
            {
                //select all fields
                DataRowView dr = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].DataBoundItem as DataRowView;
                if (dr == null) return;

                for (int i = 2; i < dr.Row.Table.Columns.Count; i++)
                {
                    dr[i] = dr[1];
                }
                
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.PreferredSize);
                dataGridView.InvalidateRow(dataGridView.CurrentCell.RowIndex);
            }
        }

        private void selectUnSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0; i< _source.Rows.Count; i++)
                for(int j=1; j< _source.Columns.Count; j++)
                {
                    _source.Rows[i][j] = selectUnSelectCheckBox.Checked;
                }
        }
    }
}
