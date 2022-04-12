using StudentManagementSystem.Core.Models;
using StudentManagementSystem.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Manager
{
    public class StudentResultManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<StudentResultVM> GetAllStudentResult()
        {

            List<StudentResultVM> resultList = new List<StudentResultVM>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select SR.Id,ST.RegNo,ST.StudentName,ST.Email,D.DepartmentId,D.DepartmentName, "
                    + "S.SemesterId, S.SemesterName, C.CourseId, C.CourseName, G.GradeId  , G.GradeName "
                    + "from StudentResult SR "
                    + "INNER JOIN Student ST on ST.StudentId = SR.RegNo "
                    + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId "
                    + "INNER JOIN Semester S on S.SemesterId = SR.SemesterId "
                    + "INNER JOIN Course C on C.CourseId = SR.CourseId "
                    + "INNER JOIN Grade G on G.GradeId = SR.GradeId", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    StudentResultVM course = StudentResultVM.ConvertToModel(row);
                    resultList.Add(course);
                }
            }
            return resultList;
        }


        public StudentResultVM GetStudentResultById(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select SR.Id,ST.RegNo,ST.StudentName,ST.Email,D.DepartmentId,D.DepartmentName, "
                    + "S.SemesterId, S.SemesterName, C.CourseId, C.CourseName, G.GradeId ,G.GradeName "
                    + "from StudentResult SR "
                    + "INNER JOIN Student ST on ST.StudentId = SR.RegNo "
                    + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId "
                    + "INNER JOIN Semester S on S.SemesterId = SR.SemesterId "
                    + "INNER JOIN Course C on C.CourseId = SR.CourseId "
                    + "INNER JOIN Grade G on G.GradeId = SR.GradeId where SR.Id = " + id, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return StudentResultVM.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }

        public int SaveStudentResult(StudentResult result)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (result.Id > 0)
                {
                    string query = " Update StudentResult SET  RegNo= @RegNo, SemesterId= @SemesterId, CourseId = @CourseId, GradeId= @GradeId where Id =@Id ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@RegNo",result.RegNo );
                    cmd.Parameters.AddWithValue("@SemesterId", result.SemesterId);
                    cmd.Parameters.AddWithValue("@CourseId", result.CourseId);
                    cmd.Parameters.AddWithValue("@GradeId", result.GradeId);
                    cmd.Parameters.AddWithValue("@Id", result.Id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into StudentResult(RegNo, SemesterId, CourseId, GradeId) values (@RegNo, @SemesterId, @CourseId, @GradeId)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@RegNo", result.RegNo);
                    cmd.Parameters.AddWithValue("@SemesterId", result.SemesterId);
                    cmd.Parameters.AddWithValue("@CourseId", result.CourseId);
                    cmd.Parameters.AddWithValue("@GradeId", result.GradeId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteStudentResult(int id)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from StudentResult where Id = " + id, con);
                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
