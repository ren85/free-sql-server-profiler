using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using Microsoft.SqlServer.Management.Common;
using ServerType=Microsoft.SqlServer.Management.Common.ServerType;

namespace AnfiniL.SqlServerTools.Impl
{
    class ServerConnector : IServerConnector
    {
        #region IServerConnector Members

        public string[] GetServerList()
        {
            List<string> result = new List<string>();
            foreach(DataRow row in SmoApplication.EnumAvailableSqlServers().Rows)
            {
                result.Add(row["Name"] as string);
            }
            return result.ToArray();
        }

        public bool TestConnection(string serverName, string userName, string password, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName, userName, password), out error);
        }

        public bool TestConnection(string serverName, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName), out error);
        }

        public bool TestRawConnection(string rawConnectionString, out string error)
        {
            return TestServerConnection(new ServerConnection(new SqlConnection(rawConnectionString)), out error);
        }

        private static bool TestServerConnection(ServerConnection sc, out string error)
        {
            try
            {
                sc.ConnectTimeout = 20;//20 seconds
                sc.Connect();
                if(sc.ServerVersion.Major < 9)
                {
                    error = "Unable to profile SQL Server with version less than 9.0 (SQL Server 2005)";
                    return false;
                }

                error = string.Empty;
                return true;
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }
        }

        #endregion
    }
}
