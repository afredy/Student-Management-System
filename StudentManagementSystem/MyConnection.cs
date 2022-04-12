using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManagementSystem
{
    public class MyConnection
    {
        public SqlConnection con;
        public MyConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }


    }
}