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
    public class CourseSetupManager
    {
        DepartmentSetupManager _departmentSetupManager = new DepartmentSetupManager();
        SemesterSetupManager _semesterSetupManager = new SemesterSetupManager();
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<CustomSelectItem> GetAllDepartmentDropdownList()
        {
            List<CustomSelectItem> depList = new List<CustomSelectItem>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                _departmentSetupManager.GetDepartmentSelectList();
                SqlCommand cmd = new SqlCommand(" Select DepartmentId value, DepartmentName Text from Department ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CustomSelectItem dept = CustomSelectItem.ConvertToModel(row);
                    depList.Add(dept);
                }
            }
            return depList;
        }

        public List<CustomSelectItem> GetAllSemesterDropdownList()
        {
            List<CustomSelectItem> depList = new List<CustomSelectItem>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                _semesterSetupManager.GetSemesterSelectList();
                SqlCommand cmd = new SqlCommand(" Select SemesterId value, SemesterName Text from Semester" , con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CustomSelectItem dept = CustomSelectItem.ConvertToModel(row);
                    depList.Add(dept);
                }
            }
            return depList;
        }

        public List<CourseVM> GetAllCourseVm()
        {
            List<CourseVM> courseList = new List<CourseVM>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_CourseList ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CourseVM course = CourseVM.ConvertToModel(row);
                    courseList.Add(course);
                }
            }
            return courseList;
        }


        public CourseVM GetAllCourseVmById(int courseId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_CourseList where CourseId = " + courseId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return CourseVM.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }
        public List<CustomSelectItem> GetCourseSelectList(int departmentId)
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from view_CourseDropdownList where DepartmentId =  " + departmentId, con);
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
        public List<CustomSelectItem> GetCourseSelectListMassSelection()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select CourseId Value, CourseName Text from Course", con);
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
        public int SaveCourse(CourseVM course)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (course.CourseId > 0)
                {
                    string query = " Update Course SET CourseCode =@CourseCode, CourseName= @CourseName, CourseCredit= @CourseCredit , Discription =@Discription, DepartmentId =@DepartmentId, SemesterId=@SemesterId where CourseId =@CourseId ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseCredit", course.CourseCredit);
                    cmd.Parameters.AddWithValue("@Discription", course.Discription);
                    cmd.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                    cmd.Parameters.AddWithValue("@SemesterId", course.SemesterId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into Course( CourseCode, CourseName, CourseCredit, Discription, DepartmentId, SemesterId) values (@CourseCode, @CourseName, @CourseCredit, @Discription, @DepartmentId, @SemesterId)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseCredit", course.CourseCredit);
                    cmd.Parameters.AddWithValue("@Discription", course.Discription);
                    cmd.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                    cmd.Parameters.AddWithValue("@SemesterId", course.SemesterId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteCourse(int courseId)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from Course where CourseId = " + courseId , con);
                cmd.Parameters.AddWithValue("@CourseId",courseId);

                return cmd.ExecuteNonQuery();
            }
        }


    }


}

