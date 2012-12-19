using System;
using System.Collections.Generic;
using System.Text;
using SqlServerTools.Data;

namespace AnfiniL.SqlServerTools.Data
{
    public class FilterProperties
    {
        private TraceField _field;
        private ComparisonOperator _op;
        private string _value;

        public FilterProperties(TraceField field, ComparisonOperator op, string value)
        {
            _field = field;
            _op = op;
            _value = value;
        }
        
        public TraceField Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public ComparisonOperator Operator
        {
            get { return _op; }
            set { _op = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public object TypedValue
        {
            get
            {
                if (Array.IndexOf(IntFields, _field) > -1 )
                {
                    int value;
                    if (int.TryParse(_value, out value))
                        return value;
                    else
                        return 0;
                } 
                else if (Array.IndexOf(LongFields, _field) > -1)
                {
                    long value;
                    if (long.TryParse(_value, out value))
                        return value;
                    else
                        return 0;
                } 
                if (Array.IndexOf(VarBinaryFields, _field) > -1)
                {
                    return Encoding.ASCII.GetBytes(_value);
                }
                else
                    return _value;
            }
        }

        private static readonly TraceField[] IntFields = {
                                             TraceField.DatabaseID, 
                                             TraceField.ObjectID,
                                             TraceField.ClientProcessID,
                                             TraceField.SPID,
                                             TraceField.EventClass
                                         };

        private static readonly TraceField[] LongFields = {
                                             TraceField.TransactionID,
                                             TraceField.Duration,
                                             TraceField.Reads,
                                             TraceField.Writes,
                                             TraceField.CPU
                                         };

        private static readonly TraceField[] VarBinaryFields = {
                                                            TraceField.LoginSID
                                         };

        public static TraceField[] nonFilterableFields =
            {
                TraceField.BinaryData,
                TraceField.EventClass,
                TraceField.LoginSID,
                TraceField.ServerName
            };

        public static string CheckFilter(FilterProperties fp)
        {
            if (Array.IndexOf(IntFields, fp.Field) > -1)
            {
                int val;
                if (!int.TryParse(fp.Value, out val))
                    return "The value should be an integer";
                if (OnlyStringOperator(fp))
                    return "The operator is not correct for this field";
            }
            else if (Array.IndexOf(LongFields, fp.Field) > -1)
            {
                long val;
                if (!long.TryParse(fp.Value, out val))
                    return "The value should be a bigint";
                if (OnlyStringOperator(fp))
                    return "The operator is not correct for this field";
            }
            
            return string.Empty;
        }

        private static bool OnlyStringOperator(FilterProperties fp)
        {
            return fp.Operator == ComparisonOperator.Like || fp.Operator == ComparisonOperator.NotLike;
        }

        public bool CheckFilter()
        {
            if ((Operator == ComparisonOperator.Like || Operator == ComparisonOperator.NotLike)
                && string.IsNullOrEmpty(Value))
                Value = "%";

            return true;
        }
    }
}
