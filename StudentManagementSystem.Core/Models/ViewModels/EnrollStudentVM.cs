using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class EnrollStudentVM
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string RegNo { get; set; }
        public string Date { get; set; }

        public static EnrollStudentVM ConvertToModel(DataRow row)
        {
            EnrollStudentVM model = new EnrollStudentVM()
            {
                Id = Convert.ToInt32(row["Id"]),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                StudentName = row["StudentName"].ToString(),
                Email = row["Email"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                SemesterName = row["SemesterName"].ToString(),
                CourseId = Convert.ToInt32(row["CourseId"]),
                CourseName = row["CourseName"].ToString(),
                RegNo = row["RegNo"].ToString(),
                Date = Convert.ToDateTime(row["Date"]).ToShortDateString()
            };
            return model;
        }
    }
}
