using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models
{
    public class CustomSelectItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public static CustomSelectItem ConvertToModel(DataRow row)
        {
            var model = new CustomSelectItem()
            {
                Value = row["Value"].ToString(),
                Text = row["Text"].ToString()
            };
            return model;
        }
    }
}
