using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum TraceEvent
    {
        RPCCompleted      = 10,
        RPCStarting       = 11,
        SQLBatchCompleted = 12,
        SQLBatchStarting  = 13,
        AuditLogin        = 14,
        AuditLogout       = 15,
        LockReleased      = 23,
        LockAcquired      = 24,
        LockDeadlock      = 25,
        LockCancel        = 26,
        LockTimeout       = 27,
        SQLStmtStarting   = 40,
        SQLStmtCompleted  = 41,
        SPStarting        = 42,
        SPCompleted       = 43,
        SPStmtStarting    = 44,
        SPStmtCompleted   = 45,
        SQLTransaction    = 50,
        ScanStarted       = 51,
        ScanStopped       = 52,
        CursorOpen        = 53,
        TransactionLog    = 54,
        LockDeadlockChain = 59,
        LockEscalation    = 60,
        ExecutionWarnings = 67,
        SQLFullTextQuery  = 123,
        DeadlockGraph     = 148,
        SQLStmtRecompile  = 166,
        TMBeginTranStarting     = 181,
        TMBeginTranCompleted    = 182,
        TMPromoteTranStarting   = 183,
        TMPromoteTranCompleted  = 184,
        TMCommitTranStarting    = 185,
        TMCommitTranCompleted   = 186,
        TMRollbackTranStarting  = 187,
        TMRollbackTranCompleted = 188,
        TMSaveTranstarting      = 191,
        TMSaveTrancompleted     = 192
        
    }
}
