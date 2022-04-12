using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }

        public static Semester ConvertToModel(DataRow row)
        {
            Semester model = new Semester()
            {
                SemesterId = Convert.ToInt32(row["SemesterId"]),
                SemesterName = row["SemesterName"].ToString(),

            };
        return model;
        }
        
    }
}
