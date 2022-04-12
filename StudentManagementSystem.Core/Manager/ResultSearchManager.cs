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
    public class ResultSearchManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";
        public List<SearchResult> GetStudentResultsById(int id)
        {
            List<SearchResult> resultList = new List<SearchResult>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select SR.RegNo,S.StudentName,S.Email,D.DepartmentName, "
                    +"C.CourseCode,C.CourseName,G.GradeName "
                    +"from StudentResult SR "
                    +"INNER JOIN Course C on C.CourseId = SR.CourseId "
                    +"INNER JOIN Department D on D.DepartmentId = C.DepartmentId "
                    +"INNER JOIN Student S on S.StudentId = SR.RegNo "
                    + "INNER JOIN Grade G on G.GradeId = SR.GradeId where SR.RegNo = " + id, con); 
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    SearchResult list = SearchResult.ConvertToModel(row);
                    resultList.Add(list);
                }
            }
            return resultList;
        }
    }
}
