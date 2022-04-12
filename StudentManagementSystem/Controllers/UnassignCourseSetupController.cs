using StudentManagementSystem.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class UnassignCourseSetupController : Controller
    {
        private readonly UnAllocateCourseManager _unAllocateCourseManager;
        public UnassignCourseSetupController()
        {
            _unAllocateCourseManager = new UnAllocateCourseManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Delete()
        {
            var delete = _unAllocateCourseManager.DeleteAllAssignCourse();
            return Json(delete,JsonRequestBehavior.AllowGet);
        }
    }
}