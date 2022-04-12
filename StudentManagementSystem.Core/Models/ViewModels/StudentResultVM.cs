using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class StudentResultVM
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string RegNo { get; set; }

        public static StudentResultVM ConvertToModel(DataRow row)
        {

            StudentResultVM model = new StudentResultVM()
            {
                Id = Convert.ToInt32(row["Id"]),
                StudentName = row["StudentName"].ToString(),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                SemesterName = row["SemesterName"].ToString(),
                Email = row["Email"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                CourseId = Convert.ToInt32(row["CourseId"]),
                CourseName = row["CourseName"].ToString(),
                GradeId = Convert.ToInt32(row["GradeId"]),
                GradeName = row["GradeName"].ToString(),
                RegNo = row["RegNo"].ToString(),
            };
            return model;
        }
    }
}
