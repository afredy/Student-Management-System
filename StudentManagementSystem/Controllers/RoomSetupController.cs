using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class RoomSetupController : Controller
    {
        private readonly RoomSetupManager _roomSetupManager;

        public RoomSetupController()
        {
            _roomSetupManager = new RoomSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }

     

        public JsonResult Save(Room room)
        {
            var saveRoom = _roomSetupManager.SaveRoom(room);
            return Json(saveRoom, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int roomId)
        {
            var roomDelete = _roomSetupManager.DeleteRoom(roomId);
            return Json(roomDelete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getRoom = _roomSetupManager.GetAllRoom();
            return Json(getRoom, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int roomId)
        {
            var oneRoom = _roomSetupManager.GetRoomById(roomId);
            return Json(oneRoom, JsonRequestBehavior.AllowGet);
        }
    }
}