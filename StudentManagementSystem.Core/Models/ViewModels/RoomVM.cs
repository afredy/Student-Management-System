using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class RoomVM
    {

        public int RoomId { get; set; }
        public string RoomCode { get; set; }
        public string RoomDetails { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public static RoomVM ConvertToModel(DataRow row)
        {
            RoomVM model = new RoomVM()
            {
                RoomId = Convert.ToInt32(row["RoomId"]),
                RoomCode = row["RoomCode"].ToString(),
                RoomDetails = row["RoomDetails"].ToString(),
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = row["DepartmentName"].ToString()
            };
            return model;
        }


    }
}
