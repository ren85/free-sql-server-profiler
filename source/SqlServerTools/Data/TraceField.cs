using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum TraceField
    {
        TextData        = 1,
        BinaryData      = 2,
        DatabaseID      = 3,
        TransactionID   = 4,
        NTUserName      = 6,
        NTDomainName    = 7,
        HostName        = 8,
        ClientProcessID = 9,
        ApplicationName = 10,
        LoginName       = 11,
        SPID            = 12,
        Duration        = 13,
        StartTime       = 14,
        EndTime         = 15,
        Reads           = 16,
        Writes          = 17,
        CPU             = 18,
        ObjectID        = 22,
        ServerName      = 26,
        EventClass      = 27,
        ProviderName    = 46,
        LoginSID        = 41
    }
}
