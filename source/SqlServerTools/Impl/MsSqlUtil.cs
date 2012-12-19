using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SqlServerTools.Impl
{
    class MsSqlUtil
    {
        public static SqlCommand NewStoredProcedure(string name)
        {
            SqlCommand cmd = new SqlCommand(name);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public static SqlCommand NewQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        public static int ExecuteStoredProcedure(SqlCommand cmd, IDbConnection conn)
        {
            SqlParameter ret = MsSqlUtil.AddReturnParam(cmd);
            cmd.Connection = (SqlConnection)conn;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(ret.Value);
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable ExecuteAsDataTable(SqlCommand cmd, IDbConnection conn)
        {            
            cmd.Connection = (SqlConnection)conn;
            conn.Open();
            try
            {
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                return table;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object ExecuteScalar(SqlCommand cmd, IDbConnection conn)
        {
            cmd.Connection = (SqlConnection)conn;
            conn.Open();

            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void AddInParam<T>(SqlCommand cmd, string name, T value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            if (value != null)
            {
                if (System.Text.RegularExpressions.Regex.Match(value.ToString(), @"^\d+").Success)
                    param.DbType = DbType.Int32;
                param.Value = value;
            }
            else
            {
                param.DbType = MapType(typeof(T));
                param.IsNullable = true;
                param.Value = DBNull.Value;
            }

            cmd.Parameters.Add(param);
        }

        public static SqlParameter AddOutParam<T>(SqlCommand cmd, string name, T value)
            where T : new()
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Output;
            if (value != null)
                param.Value = value;
            else
                param.DbType = MapType(typeof(T));
            cmd.Parameters.Add(param);
            return param;
        }

        private static SqlParameter AddReturnParam(SqlCommand cmd)
        {
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);
            return param;
        }

        private static DbType MapType(Type T)
        {
            if (typeof(DateTime).Equals(T) || typeof(DateTime?).Equals(T))
                return DbType.DateTime;
            else
                return DbType.String;
        }
    }
}
