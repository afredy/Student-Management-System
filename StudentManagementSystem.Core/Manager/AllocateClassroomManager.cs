using StudentManagementSystem.Core.Models;
using StudentManagementSystem.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Manager
{
    public class AllocateClassroomManager
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<AllocateClassroomVm> GetAllAllocateClassroom(int departmentId)
        {

            List<AllocateClassroomVm> courseList = new List<AllocateClassroomVm>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select AC.classId, AC.CourseId, AC.RoomId, R.RoomDetails,"
                                               + "AC.[DayId], AC.[From], AC.[To], C.CourseCode , C.CourseName, D.[DayName], Dt.DepartmentId "
                                                 + "from [dbo].[AllocateClassRoomDetails] AC "
                                                   + "INNER JOIN Course C on C.CourseId = AC.CourseId "
                                                    + "INNER JOIN Day D on D.Id = AC.DayId "
                                                    + "INNER JOIN Room R on R.RoomId = AC.RoomId "
                                                    + "INNER JOIN Department Dt on Dt.DepartmentId = R.DepartmentId "
                                                    + "where Dt.DepartmentId = " + departmentId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AllocateClassroomVm course = AllocateClassroomVm.ConvertToModel(row);
                    courseList.Add(course);
                }
            }
            return courseList;
        }


        public AllocateClassroom GetAllAllocateClassroomById(int classId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select * from AllocateClassRoomDetails where ClassId = " + classId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                return AllocateClassroom.ConvertToModel(dt.Rows[0]);

            }
            return null;
        }
        public int SaveAllocateClassroom(AllocateClassroom classRoom)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                if (classRoom.ClassId > 0)
                {
                    string query = " Update AllocateClassRoomDetails SET  CourseId =@CourseId, RoomId =@RoomId, DayId =@DayId, From =@From, To =@To where ClassId =@ClassId ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@CourseId",classRoom.CourseId);
                    cmd.Parameters.AddWithValue("@RoomId",classRoom.RoomId);
                    cmd.Parameters.AddWithValue("@DayId",classRoom.DayId);
                    cmd.Parameters.AddWithValue("@From",classRoom.From);
                    cmd.Parameters.AddWithValue("@To",classRoom.To);
                    cmd.Parameters.AddWithValue("@ClassId",classRoom.ClassId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string queery = " Insert into AllocateClassRoomDetails( CourseId,RoomId,DayId,[From],[To] ) values ( @CourseId, @RoomId, @DayId, @From, @To) ";
                    SqlCommand cmd = new SqlCommand(queery, con);


                    cmd.Parameters.AddWithValue("@CourseId ",classRoom.CourseId);
                    cmd.Parameters.AddWithValue("@RoomId ",classRoom.RoomId);
                    cmd.Parameters.AddWithValue("@DayId ",classRoom.DayId);
                    cmd.Parameters.AddWithValue("@From ",classRoom.From);
                    cmd.Parameters.AddWithValue("@To ",classRoom.To);

                     return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteAllocateClassroom(int classId)
        {
            using (SqlConnection con = new SqlConnection(database))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from AllocateClassRoomDetails where ClassId = " + classId, con);
                cmd.Parameters.AddWithValue("@ClassId", classId);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
