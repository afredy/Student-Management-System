using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class EnrollStudent
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int RegId { get; set; }
        public string Date { get; set; }

        public static EnrollStudent ConvertToModel(DataRow row)
        {
            EnrollStudent model = new EnrollStudent()
            {
                Id = Convert.ToInt32(row["Id"]),
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                CourseId = Convert.ToInt32(row["CourseId"]),
                RegId = Convert.ToInt32(row["RegId"]),
                Date = Convert.ToDateTime(row["Date"]).ToShortDateString()
            };
            return model;
        }
    }
}
