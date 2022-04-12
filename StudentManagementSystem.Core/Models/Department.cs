using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public static Department ConvertToModel(DataRow row)
        {
            Department model = new Department()
            {

                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentCode = row["DepartmentCode"].ToString(),
                DepartmentName = row["DepartmentName"].ToString(),
            };
            return model;
        }

    };
}
