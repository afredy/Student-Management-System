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
   public class AssignCourseSetupManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<AssignCourse> GetAllCourse(int departmentId)
        {

            List<AssignCourse> courseList = new List<AssignCourse>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_CourseAssignDetails where DepartmentId = " + departmentId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AssignCourse course = AssignCourse.ConvertToModel(row);
                    courseList.Add(course);
                }
            }
            return courseList;
        }

       
        public AssignCourse GetAllAssignCourseById(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_CourseAssignDetails where Id = " + id, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return AssignCourse.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }

        public AssignCourse GetCreditDetails(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select TeacherCredit,remainingCredit from view_CourseAssignDetails where Id = " + id, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return AssignCourse.ConvertToModel(dt.Rows[0]);
            }
            return null;
        }
        public AssignCourse GetCourseDetails(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select CourseName,CourseCredit from view_CourseAssignDetails where Id = " + id, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return AssignCourse.ConvertToModel(dt.Rows[0]);
            }
            return null;
        }
        public int SaveAssignCourse(AssignCourse course)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (course.Id > 0)
                {
                    string query = " Update AssignCourse SET  TeacherId= @TeacherId, CourseId= @CourseId where Id =@Id ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.Parameters.AddWithValue("@Id", course.Id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into AssignCourse(TeacherId,CourseId) values (@TeacherId,@CourseId)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteAssignCourse(int id)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from AssignCourse where Id = " + id, con);
                cmd.Parameters.AddWithValue("@Id", id);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
