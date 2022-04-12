using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Core.Models;
using System.Data;
using System.Data.SqlClient;
using StudentManagementSystem.Core.Models.ViewModels;

namespace StudentManagementSystem.Core.Manager
{
    public class TeacherSetupManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        DepartmentSetupManager _departmentSetupManager = new DepartmentSetupManager();
        DesignationManager _designationManager = new DesignationManager();

        public List<Teacher> GetAllTeacher()
        {

            List<Teacher> courseList = new List<Teacher>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_TeacherList ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Teacher course = Teacher.ConvertToModel(row);
                    courseList.Add(course);
                }
            }
            return courseList;
        }

        public List<CustomSelectItem> GetTeacherSelectList(int departmentId)
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from view_TeacherDropDownList WHERE DepartmentId = '" + departmentId + "'  ", con);
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

        public TeacherCreditDetail GetTeacherCreditDetailById(int teacherId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_TeacherRemainingCredit where teacherId = " + teacherId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return TeacherCreditDetail.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }

        public Teacher GetAllTeacherById(int teacherId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from view_TeacherList where teacherId = " + teacherId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return Teacher.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }


        public int SaveTeacher(Teacher teacher)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (teacher.TeacherId > 0)
                {
                    string query = " Update Teacher SET TeacherName =@TeacherName, TeacherAddress= @TeacherAddress, TeacherEmail= @TeacherEmail , TeacherContactNo =@TeacherContactNo, DesignationId =@DesignationId, DepartmentId=@DepartmentId,TeacherCredit = @TeacherCredit where TeacherId =@TeacherId ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                    cmd.Parameters.AddWithValue("@TeacherAddress", teacher.TeacherAddress);
                    cmd.Parameters.AddWithValue("@TeacherEmail", teacher.TeacherEmail);
                    cmd.Parameters.AddWithValue("@TeacherContactNo", teacher.TeacherContactNo);
                    cmd.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
                    cmd.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
                    cmd.Parameters.AddWithValue("@TeacherCredit", teacher.TeacherCredit);
                    cmd.Parameters.AddWithValue("@TeacherId", teacher.TeacherId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into Teacher(TeacherName, TeacherAddress, TeacherEmail, TeacherContactNo, DesignationId, DepartmentId,TeacherCredit) values (@TeacherName, @TeacherAddress, @TeacherEmail, @TeacherContactNo, @DesignationId, @DepartmentId,@TeacherCredit)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                    cmd.Parameters.AddWithValue("@TeacherAddress", teacher.TeacherAddress);
                    cmd.Parameters.AddWithValue("@TeacherEmail", teacher.TeacherEmail);
                    cmd.Parameters.AddWithValue("@TeacherContactNo", teacher.TeacherContactNo);
                    cmd.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
                    cmd.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
                    cmd.Parameters.AddWithValue("@TeacherCredit", teacher.TeacherCredit);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteTeacher(int teacherId)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from Teacher where TeacherId = " + teacherId, con);
                cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                return cmd.ExecuteNonQuery();
            }
        }




    }
}
