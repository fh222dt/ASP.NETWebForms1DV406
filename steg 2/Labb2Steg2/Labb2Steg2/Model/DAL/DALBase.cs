using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Labb2Steg2.Model.DAL
{
    public abstract class DALBase
    {
        //fält
        private static string _connectionString;

        //konstruktor
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ContactConnectionString"].ConnectionString;
        }

        //metoder
        protected SqlConnection CreateConnection()
        {
            //var conn = CreateConnection();

            //return conn;
            return new SqlConnection(_connectionString);
        }
    }
}