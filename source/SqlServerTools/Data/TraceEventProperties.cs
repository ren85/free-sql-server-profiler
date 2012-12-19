namespace SqlServerTools.Data
{
    public class TraceEventProperties
    {
        private TraceEvent _event;
        private TraceField[] _fields;

        public TraceEvent Event
        {
            get { return _event; }
            set { _event = value; }
        }

        public TraceField[] Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
    }
}
