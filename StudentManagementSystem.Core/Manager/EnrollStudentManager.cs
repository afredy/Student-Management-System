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
    public class EnrollStudentManager
    {

        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<EnrollStudentVM> GetAllEnrollStudent(int departmentId)
        {

            List<EnrollStudentVM> studentList = new List<EnrollStudentVM>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select ES.Id,ST.RegNo,ST.StudentName,ST.Email,D.DepartmentId,D.DepartmentName, "
                    + "S.SemesterId,S.SemesterName,C.CourseId,C.CourseName,ES.Date "
                    + "from EnrollStudent ES "
                    + "INNER JOIN Student ST on ST.StudentId = ES.RegId "
                    + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId "
                    + "INNER JOIN Semester S on S.SemesterId = ES.SemesterId "
                    + "INNER JOIN Course C on C.CourseId = ES.CourseId "
                    + "where D.DepartmentId = " + departmentId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EnrollStudentVM course = EnrollStudentVM.ConvertToModel(row);
                    studentList.Add(course);
                }
            }
            return studentList;
        }


        public EnrollStudentVM GetEnrollStudentById(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select ES.Id,ST.RegNo,ST.StudentName,ST.Email, "
                   + "D.DepartmentId,D.DepartmentName,S.SemesterId,S.SemesterName, "
                   + "C.CourseId, C.CourseName, ES.Date "
                   + "from EnrollStudent ES "
                   + "INNER JOIN Student ST on ST.StudentId = ES.RegId "
                   + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId "
                   + "INNER JOIN Semester S on S.SemesterId = ES.SemesterId "
                   + "INNER JOIN Course C on C.CourseId = ES.CourseId where ES.Id = " + id, con); 
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return EnrollStudentVM.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }

        public int SaveStudentRoll(EnrollStudent student)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (student.Id > 0)
                {
                    string query = " Update EnrollStudent SET  SemesterId= @SemesterId, CourseId= @CourseId, RegId = @RegId, Date= @Date where Id =@Id ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@SemesterId", student.SemesterId);
                    cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@RegId", student.RegId);
                    cmd.Parameters.AddWithValue("@Date", student.Date);
                    cmd.Parameters.AddWithValue("@Id", student.Id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into EnrollStudent(SemesterId, CourseId, RegId, Date) values (@SemesterId, @CourseId, @RegId, @Date)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@SemesterId", student.SemesterId);
                    cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@RegId", student.RegId);
                    cmd.Parameters.AddWithValue("@Date", student.Date);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteStudentRoll(int id)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from EnrollStudent where Id = " + id, con);
                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery();
            }
        }







    }
}
