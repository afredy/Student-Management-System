using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Date { get; set; }
        public string DepartmentName { get; set; }


        public static StudentVM ConvertToModel(DataRow row)
        {
            StudentVM model = new StudentVM()
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                StudentName = row["StudentName"].ToString(),
                Email = row["Email"].ToString(),
                RegNo = row["RegNo"].ToString(),
                ContactNo = row["ContactNo"].ToString(),
                Address = row["Address"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                Date = Convert.ToDateTime(row["Date"]).ToShortDateString()
            };
            return model;
        }
    }
}
