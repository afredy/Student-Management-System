using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int RegNo { get; set; }
        public int GradeId { get; set; }

        public static StudentResult ConvertToModel(DataRow row)
        {
            StudentResult model = new StudentResult()
            {
                Id = Convert.ToInt32(row["Id"]),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                CourseId = Convert.ToInt32(row["CourseId"]),
                RegNo = Convert.ToInt32(row["RegNo"]),
                GradeId = Convert.ToInt32(row["GradeId"])

            };
            return model;
        }
    }
}
