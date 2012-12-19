using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public interface IConnectionInfo
    {
        string ServerName { get;set;}
        string Username { get;set;}
        string Password { get;set;}
        string Database { get;set;}
    }
}
