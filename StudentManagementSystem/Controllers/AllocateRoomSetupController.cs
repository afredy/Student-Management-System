using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class AllocateRoomSetupController : Controller
    {
        private readonly AllocateClassroomManager _allocateClassroomManager;
            public AllocateRoomSetupController()
        {
            _allocateClassroomManager = new AllocateClassroomManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        public JsonResult Save(AllocateClassroom classRoom)
        {
            var roomList = _allocateClassroomManager.SaveAllocateClassroom(classRoom);
            return Json(roomList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int classId)
        {
            var deleteClass = _allocateClassroomManager.DeleteAllocateClassroom(classId);
            return Json(deleteClass, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(int departmentId)
        {
            var AllClass = _allocateClassroomManager.GetAllAllocateClassroom(departmentId);
            return Json(AllClass, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int classId)
        {
            var GetOneClassroom = _allocateClassroomManager.GetAllAllocateClassroomById(classId);
            return Json(GetOneClassroom, JsonRequestBehavior.AllowGet);
        }



    }
}