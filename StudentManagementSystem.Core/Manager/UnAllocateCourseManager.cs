using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Manager
{
    public class UnAllocateCourseManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";
        public int DeleteAllAssignCourse()
        {
             

            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                 SqlCommand cmd = new SqlCommand(" Delete from AssignCourse ", con);
                

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
