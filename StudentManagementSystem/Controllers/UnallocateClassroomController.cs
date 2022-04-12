using StudentManagementSystem.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class UnallocateClassroomController : Controller
    {
        private readonly UnallocateClassroomManager _unallocateClassroomManager;
        public UnallocateClassroomController()
        {
            _unallocateClassroomManager = new UnallocateClassroomManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Delete()
        {
            var delete = _unallocateClassroomManager.DeleteAllClassroom();
            return Json(delete, JsonRequestBehavior.AllowGet);
        }
    }
}