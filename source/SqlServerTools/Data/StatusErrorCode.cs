using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum StatusErrorCode
    {
        NoError        = 0,
        Unknown        = 1,
        IsInvalid      = 2,
        TraceIsInvalid = 3,
        OutOfMemory    = 4
    }
}
