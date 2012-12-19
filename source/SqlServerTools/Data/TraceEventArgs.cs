using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SqlServerTools.Data
{
    public class TraceEventArgs : EventArgs
    {
        private DataTable eventsTable;

        public TraceEventArgs()
            : base()
        {
        }

        public TraceEventArgs(DataTable eventsTable)
            : base()
        {
            this.eventsTable = eventsTable;
        }

        public DataTable EventsTable
        {
            get
            {
                return eventsTable;
            }
        }
    }
}
