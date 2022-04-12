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
    public class SemesterSetupManager
    {
        private string dbcon = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<Semester> GetAllSemester()
        {
            List<Semester> semesterList = new List<Semester>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(dbcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from Semester ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Semester semester = Semester.ConvertToModel(row);
                    semesterList.Add(semester);
                }
                
            }
            return semesterList;

        }

        public List<CustomSelectItem> GetSemesterSelectList()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(dbcon))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from view_semestertList ", con);
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

        public Semester GetSemesterById(int semesterId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(dbcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from Semester where SemesterId = " + semesterId, con );
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                
                    return Semester.ConvertToModel(dt.Rows[0]);
            
            }
            return null;
        }
        public int SaveSemester(Semester semester)
        {
            using (SqlConnection con = new SqlConnection(dbcon))
            {
                con.Open();
                if (semester.SemesterId > 0)
                {
                    string query = " Update Semester SET SemesterName = @SemesterName where SemesterId = @SemesterId ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@SemesterName", semester.SemesterName);
                    cmd.Parameters.AddWithValue("@SemesterId", semester.SemesterId);
                    return cmd.ExecuteNonQuery();
                }

                else
                {
                    string queery = " Insert into Semester (SemesterName) values(@SemesterName) ";
                    SqlCommand cmd = new SqlCommand(queery, con);

                    cmd.Parameters.AddWithValue("@SemesterName", semester.SemesterName);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteSemester(int semesterId)
        {
            using (SqlConnection con = new SqlConnection(dbcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" delete from Semester where SemesterId =  " +semesterId , con);
                cmd.Parameters.AddWithValue("@SemesterId",semesterId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
