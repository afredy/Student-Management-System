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
    public class DaySetupManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";
        public List<CustomSelectItem> GetDaySelectList()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select Id value, DayName text from Day ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CustomSelectItem obj = CustomSelectItem.ConvertToModel(row);
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
