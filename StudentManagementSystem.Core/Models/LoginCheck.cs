using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class LoginCheck
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static LoginCheck ConvertToModel(DataRow row)
        {
            LoginCheck model = new LoginCheck()
            {
                UserId = Convert.ToInt32(row["UserId"]),
                UserName = row["UserName"].ToString(),
                Password = row["Password"].ToString()
            };
            return model;
        }
    }
}
