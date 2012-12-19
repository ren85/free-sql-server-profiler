using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Management.Common;

namespace AnfiniL.SqlServerTools.Impl
{
    public class SqlConnInfo
    {
        private SqlConnectionInfo _info;

        public delegate IDbConnection CreateConnectionHandler();

        private CreateConnectionHandler _handler;

        public SqlConnInfo(SqlConnectionInfo info)
        {
            info.ApplicationName = ApplicationName;
            _handler = delegate
                           {
                               return info.CreateConnectionObject();
                           };
        }

        public SqlConnInfo(CreateConnectionHandler handler)
        {
            _handler = handler;
        }

        public IDbConnection CreateConnectionObject()
        {
            return _handler();
        }

        public string ApplicationName
        {
            get
            {
                return "sqlprofilerapp";
            }
        }
    }
}
