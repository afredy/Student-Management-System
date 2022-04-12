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
   public class RoomSetupManager
    {

        private string strConstring = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<RoomVM> GetAllRoom()
        {
            List<RoomVM> RoomList = new List<RoomVM>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" select R.RoomId,R.RoomCode,R.RoomDetails,R.DepartmentId,D.DepartmentName "
                                                  + " from Room R " 
                                                  + " INNER JOIN Department D on D.DepartmentId = R.DepartmentId ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RoomVM room = RoomVM.ConvertToModel(row);
                    RoomList.Add(room);
                }
            }

            return RoomList;


        }
        public List<CustomSelectItem> GeRoomSelectList()
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select RoomId value, RoomCode text from Room ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CustomSelectItem obj = CustomSelectItem.ConvertToModel(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public Room GetRoomById(int roomId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Room where roomId =  " + roomId, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            if (dt.Rows.Count > 0)
            {
                return Room.ConvertToModel(dt.Rows[0]);
            }

            return null;
        }
        public List<CustomSelectItem> GetRoomSelectList(int departmentId)
        {

            List<CustomSelectItem> list = new List<CustomSelectItem>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConstring))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select RoomId value, RoomCode text from Room WHERE DepartmentId = '" + departmentId + "'  ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CustomSelectItem obj = CustomSelectItem.ConvertToModel(row);
                    list.Add(obj);
                }
            }
            return list;
        }
        public int SaveRoom(Room room)
        {
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                if (room.RoomId > 0)
                {
                    string query = " Update Room SET RoomCode =@RoomCode, RoomDetails = @RoomDetails,DepartmentId =@DepartmentId where RoomId = @RoomId  ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@RoomCode", room.RoomCode);
                    cmd.Parameters.AddWithValue("@RoomDetails", room.RoomDetails);
                    cmd.Parameters.AddWithValue("@DepartmentId", room.DepartmentId);
                    cmd.Parameters.AddWithValue("@RoomId", room.RoomId);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    string querry = " Insert into Room(RoomCode, RoomDetails, DepartmentId) values (@RoomCode, @RoomDetails, @DepartmentId) ";
                    SqlCommand cmd = new SqlCommand(querry, con);

                    cmd.Parameters.AddWithValue("@RoomCode", room.RoomCode);
                    cmd.Parameters.AddWithValue("@RoomDetails",room.RoomDetails);
                    cmd.Parameters.AddWithValue("@DepartmentId", room.DepartmentId);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteRoom(int roomId)
        {
            using (SqlConnection con = new SqlConnection(strConstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" Delete from Room where RoomId = " + roomId, con);
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                return cmd.ExecuteNonQuery();
            }
        }


    }
}
