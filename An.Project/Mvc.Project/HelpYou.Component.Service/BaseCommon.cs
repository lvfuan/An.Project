using HelpYou.Component.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Framework.Dapper;

namespace HelpYou.Component.Service
{
    public class BaseCommon<T> : IBaseCommon<T> where T : class, new()
    {
        private static string SqlconectionString = ConfigurationManager.ConnectionStrings["HelpYouDbContext"].ToString();
        ~BaseCommon()
        {
            this.OpenSqlConnection().Dispose();
        }
        public SqlConnection OpenSqlConnection()
        {
            var sqlConnection = new SqlConnection(SqlconectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
