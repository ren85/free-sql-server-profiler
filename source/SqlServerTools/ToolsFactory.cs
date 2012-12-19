using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SqlServerTools.Impl;
using AnfiniL.SqlServerTools;
using AnfiniL.SqlServerTools.Impl;
using Microsoft.SqlServer.Management.Common;

namespace SqlServerTools
{
    public class ToolsFactory
    {
        static readonly ToolsFactory instance = new ToolsFactory();

        public static ToolsFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public IProfiler CreateProfiler(string serverName, string userName, string password, string rawConnection)
        {
            SqlConnectionInfo ci;
            if (rawConnection == null)
            {
                ci = new SqlConnectionInfo(serverName);
                ci.UserName = userName;
                ci.Password = password;
                if (userName == string.Empty)
                    ci.UseIntegratedSecurity = true;

                return new Profiler(new SqlConnInfo(ci));
            }
            else
            {
                return new Profiler(new SqlConnInfo(delegate { return new SqlConnection(rawConnection); }));
            }
        }
        
        public IServerConnector CreateServerConnector()
        {
            return new ServerConnector();
        }
    }
}
