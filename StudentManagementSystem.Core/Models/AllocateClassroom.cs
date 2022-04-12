using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class AllocateClassroom
    {

        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public string DayId{ get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public static AllocateClassroom ConvertToModel(DataRow row)
        {
            AllocateClassroom model = new AllocateClassroom()
            {
                ClassId = Convert.ToInt32(row["ClassId"]),
                CourseId = Convert.ToInt32(row["CourseId"]),
                RoomId = Convert.ToInt32(row["RoomId"]),
                DayId = row["DayId"].ToString(),
                From = row["From"].ToString(),
                To = row["To"].ToString()
            };
            return model;
        }







    }
}
