using System;
using System.Collections.Generic;
using System.Text;
using SqlServerTools;
using System.Data;
using SqlServerTools.Data;
using AnfiniL.SqlServerTools.Data;

namespace AnfiniL.SqlExpressProfiler.Logic
{
  public class Trace
  {
    private IProfiler _profiler;
    private DataTable _dataTable;
    private string _traceName;
    private TraceEventProperties[] _traceEvents;
    private FilterProperties[] _traceFilters;
    private bool _isLocked;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trace"/> class.
    /// </summary>
    public Trace()
    {

    }

    public TraceEventProperties[] TraceEvents
    {
      get { return _traceEvents; }
      set { _traceEvents = value; }
    }

    public FilterProperties[] TraceFilters
    {
      get { return _traceFilters; }
      set { _traceFilters = value; }
    }

    public string TraceName
    {
      get { return _traceName; }
      set { _traceName = value; }
    }

    /// <summary>
    /// Gets or sets the last start no.
    /// The value is used when calculating the selected rows id relative to the grid
    /// </summary>
    /// <value>The last start no.</value>
    public int LastStartNo { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Trace"/> class.
    /// </summary>
    /// <param name="profiler">The profiler.</param>
    /// <param name="table">The table.</param>
    public Trace(IProfiler profiler, DataTable table, string traceName)
    {
        this._profiler = profiler;
        this._dataTable = table;
        this._traceName = traceName;
    }

    /// <summary>
    /// Gets or sets the profiler.
    /// </summary>
    /// <value>The profiler.</value>
    public IProfiler Profiler
    {
      get { return _profiler; }
      set { _profiler = value; }
    }

    /// <summary>
    /// Gets or sets the data table.
    /// </summary>
    /// <value>The data table.</value>
    public DataTable DataTable
    {
      get { return _dataTable; }
      set { _dataTable = value; }
    }

    public bool IsLocked
    {
      get { return _isLocked; }
    }

    /// <summary>
    /// Clears the trace.
    /// </summary>
    public void ClearTrace()
    {
      _isLocked = true;
      DataRow[] maxRow = DataTable.Select("RowNum = Max(RowNum)");
      LastStartNo = maxRow.Length > 0 ? Convert.ToInt32(maxRow[0][0]) : 0;
      
      _dataTable.Clear();
      _isLocked = false;
    }
  }
}
