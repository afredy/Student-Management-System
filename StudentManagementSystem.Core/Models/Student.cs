using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Date { get; set; }
        

        public static Student ConvertToModel(DataRow row)
        {
            Student model = new Student()
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                StudentName = row["StudentName"].ToString(),
                Email = row["Email"].ToString(),
                RegNo = row["RegNo"].ToString(),
                ContactNo = row["ContactNo"].ToString(),
                Address = row["Address"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                Date = Convert.ToDateTime(row["Date"]).ToShortDateString()
        };
            return model;
        }
    }
}
