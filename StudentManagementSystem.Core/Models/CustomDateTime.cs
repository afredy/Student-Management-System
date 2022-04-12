using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class CustomDateTime
    {
        public string Date { get; set; }

        public static CustomDateTime ConvertTomodel(DataRow row)
        {
            CustomDateTime model = new CustomDateTime()
            {
                Date = Convert.ToDateTime(row["CreateDate"]).ToShortDateString()
            };
            return model;
        }
    }
}
