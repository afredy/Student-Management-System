using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherContactNo { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TeacherCredit { get; set; }


        public static Teacher ConvertToModel(DataRow row)
        {
            Teacher model = new Teacher()
            {
                TeacherId = Convert.ToInt32(row["TeacherId"]),
                TeacherName = row["TeacherName"].ToString(),
                TeacherAddress = row["TeacherAddress"].ToString(),
                TeacherEmail = row["TeacherEmail"].ToString(),
                TeacherContactNo = row["TeacherContactNo"].ToString(),
                DesignationId = Convert.ToInt32(row["DesignationId"]),
                DesignationName = row["DesignationName"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString(),
                TeacherCredit = Convert.ToInt32(row["TeacherCredit"]),
            };
            return model;
        }

    }
}
