using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
   public class AssignCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }


        public static AssignCourse ConvertToModel(DataRow row)
        {
            AssignCourse model = new AssignCourse()
            {
                Id = Convert.ToInt32(row["Id"]),
                TeacherId = Convert.ToInt32(row["TeacherId"]),
                TeacherName = row["TeacherName"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                SemesterName = row["SemesterName"].ToString(),
                CourseId = Convert.ToInt32(row["CourseId"]),
                CourseName = row["CourseName"].ToString(),
                CourseCode = row["CourseCode"].ToString(),

            };
            return model;
        }
    }
}
