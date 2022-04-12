using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseCredit { get; set; }
        public string Discription { get; set; }
        public int DepartmentId  { get; set; }
        public string DepartmentName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }

        public static CourseVM ConvertToModel(DataRow row)
        {
            CourseVM model = new CourseVM()
            {
                CourseId = Convert.ToInt32(row["CourseId"]),
                CourseCode = row["CourseCode"].ToString(),
                CourseName = row["CourseName"].ToString(),
                CourseCredit = row["CourseCredit"].ToString(),
                Discription = row["Discription"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                SemesterName = row["SemesterName"].ToString(),
            };
            return model;
        }
    }
}
