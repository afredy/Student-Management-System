using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Manager
{
   public class DateTimeManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public CustomDateTime GetServerDate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" SELECT GETDATE() ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return CustomDateTime.ConvertTomodel(dt.Rows[0]);
            }
            return null;
        }
    }
}
