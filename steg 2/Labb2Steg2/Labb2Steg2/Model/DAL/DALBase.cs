using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Labb2Steg2.Model.DAL
{
    abstract class DALBase
    {
        //fält
        private static string _connectionString;

        //konstruktor
        private static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ContactConfigurationString"].ConnectionString;
        }

        //metoder
        protected SqlConnection CreateConnection()
        {
            var conn = CreateConnection();

            return conn;
        }
    }
}