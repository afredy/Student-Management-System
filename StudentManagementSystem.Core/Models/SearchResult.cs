using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class SearchResult
    {
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
       // public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string GradeName { get; set; }

        public static SearchResult ConvertToModel(DataRow row)
        {
            SearchResult model = new SearchResult()
            {


                RegNo = row["RegNo"].ToString(),
                StudentName = row["StudentName"].ToString(),
                Email = row["Email"].ToString(),
                //DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                CourseCode = row["CourseCode"].ToString(),
                CourseName = row["CourseName"].ToString(),
                GradeName = row["GradeName"].ToString(),
            };
            return model;
        }
    }
}
