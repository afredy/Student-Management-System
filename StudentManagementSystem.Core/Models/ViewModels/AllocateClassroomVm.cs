using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class AllocateClassroomVm
    {

        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public int RoomId { get; set; }
        public string RoomDetails { get; set; }
        public string DayId { get; set; }
        public string DayName { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public static AllocateClassroomVm ConvertToModel(DataRow row)
        {
            AllocateClassroomVm model = new AllocateClassroomVm()
            {
                ClassId = Convert.ToInt32(row["ClassId"]),
                CourseId = Convert.ToInt32(row["CourseId"]),
                CourseCode = row["CourseCode"].ToString(),
                CourseName = row["CourseName"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                RoomId = Convert.ToInt32(row["RoomId"]),
                RoomDetails = row["RoomDetails"].ToString(),
                DayId = row["DayId"].ToString(),
                DayName = row["DayName"].ToString(),
                From = row["From"].ToString(),
                To = row["To"].ToString()
            };
            return model;
        }
    }
}
