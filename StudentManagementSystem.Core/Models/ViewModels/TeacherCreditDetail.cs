using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Models.ViewModels
{
    public class TeacherCreditDetail
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int TeacherCredit { get; set; }
        public int CreditTaken { get; set; }
        public int RemainingCredit { get; set; }

        public static TeacherCreditDetail ConvertToModel(DataRow row)
        {
            TeacherCreditDetail model = new TeacherCreditDetail()
            {
                TeacherId = Convert.ToInt32(row["TeacherId"]),
                TeacherCredit = Convert.ToInt32(row["TeacherCredit"]),
                CreditTaken = Convert.ToInt32(row["CreditTaken"]),
                RemainingCredit = Convert.ToInt32(row["RemainingCredit"]),
                TeacherName = row["TeacherName"].ToString(),

            };
            return model;
        }

    }
}
