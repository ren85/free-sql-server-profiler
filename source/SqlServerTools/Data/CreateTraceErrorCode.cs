using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum CreateTraceErrorCode
    {
        NoError = 0,
        Unknown = 1,
        InvalidOptions = 2,
        InsufficientRights = 3
    }
}
