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
    public class RegisterStudentManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        DepartmentSetupManager _departmentSetupManager = new DepartmentSetupManager();
        DesignationManager _designationManager = new DesignationManager();

        public List<StudentVM> GetAllStudent()
        {

            List<StudentVM> studentList = new List<StudentVM>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select ST.StudentId,ST.RegNo,ST.StudentName,ST.Email,ST.ContactNo, "
                                                + "ST.[Address], ST.[Date], D.DepartmentId, D.DepartmentName "
                                                + "from Student ST "
                                                + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId  ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    StudentVM course = StudentVM.ConvertToModel(row);
                    studentList.Add(course);
                }
            }
            return studentList;
        }

        public List<CustomSelectItem> GetStudentSelectList()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select StudentId value, RegNo text from Student ", con);
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

        public StudentVM GetAllStudentById(int studentId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select ST.StudentId,ST.RegNo,ST.StudentName,ST.Email,ST.ContactNo, "
                                                + "ST.[Address], ST.[Date], D.DepartmentId, D.DepartmentName "
                                                + "from Student ST "
                                                + "INNER JOIN Department D on D.DepartmentId = ST.DepartmentId "
                                                + "where ST.StudentId = " + studentId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return StudentVM.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }


        public int SaveStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (student.StudentId > 0)
                {
                    string query = " Update Student SET StudentName =@StudentName, RegNo= @RegNo, ContactNo= @ContactNo , Address =@Address, DepartmentId =@DepartmentId, Date=@Date,Email =@Email where StudentId =@StudentId ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                    cmd.Parameters.AddWithValue("@RegNo", student.RegNo);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                    cmd.Parameters.AddWithValue("@Date", student.Date);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = "Insert into Student(StudentName, RegNo, ContactNo, Address, DepartmentId, [Date],Email) values (@StudentName, @RegNo, @ContactNo, @Address, @DepartmentId, @Date, @Email)";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                    cmd.Parameters.AddWithValue("@RegNo", student.RegNo);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                    cmd.Parameters.AddWithValue("@Date", student.Date);
                    cmd.Parameters.AddWithValue("@Email", student.Email);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteStudent(int studentId)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from Student where StudentId = " + studentId, con);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
