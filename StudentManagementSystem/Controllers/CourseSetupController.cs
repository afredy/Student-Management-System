using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class CourseSetupController : Controller
    {
        private readonly CourseSetupManager _courseSetupManager;

        public CourseSetupController()
        {
            _courseSetupManager = new CourseSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Save(CourseVM course)
        {
            var courseSave = _courseSetupManager.SaveCourse(course);
            return Json(courseSave, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var allCourse = _courseSetupManager.GetAllCourseVm();
            return Json(allCourse,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get(int courseId)
        {
            var getCourseById = _courseSetupManager.GetAllCourseVmById(courseId);
            return Json(getCourseById, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int courseId)
        {
            var deleteCourse = _courseSetupManager.DeleteCourse(courseId);
            return Json(deleteCourse, JsonRequestBehavior.AllowGet);
        }

    }
}