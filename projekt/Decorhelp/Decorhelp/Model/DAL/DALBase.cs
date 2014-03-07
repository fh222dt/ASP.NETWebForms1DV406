using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Decorhelp.Model.DAL
{
    public abstract class DALBase
    {
        //fält
        private static string _connectionString;

        //konstruktor
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DecorHelpConnectionString"].ConnectionString;
        }

        //metoder
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
