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
   public class DepartmentSetupManager
    {
        private string strConstring = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<Department> GetAllDepartment()
        {
            List<Department> depList = new List<Department>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from Department ",con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Department department = Department.ConvertToModel(row);
                    depList.Add(department);
                }
            }

            return depList;


        }
        public List<CustomSelectItem> GetDepartmentSelectList()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from view_departmentList ", con);
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

        public Department GetDepartmentById(int departmentId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from Department where DepartmentId =  " + departmentId , con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                
            }
            if (dt.Rows.Count > 0)
            {
                return Department.ConvertToModel(dt.Rows[0]);
            }
        
            return null;
        }

        public int SaveDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                if (department.DepartmentId > 0)
                {
                    string query = " Update Department SET DepartmentCode =@DepartmentCode, DepartmentName = @DepartmentName where DepartmentId = @DepartmentId  ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string querry = " Insert into Department (DepartmentCode, DepartmentName) values (@DepartmentCode, @DepartmentName) ";
                    SqlCommand cmd = new SqlCommand(querry, con);

                    cmd.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteDepartment(int departmentId)
        {
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from Department where DepartmentId = " + departmentId , con);
                cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
