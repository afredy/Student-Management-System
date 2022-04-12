using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class AssignCourseSetupController : Controller
    {
        private readonly AssignCourseSetupManager _assignCourseSetupManager;
        public AssignCourseSetupController()
        {
            _assignCourseSetupManager = new AssignCourseSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public JsonResult Save(AssignCourse course)
        {
            var saveAsCourse = _assignCourseSetupManager.SaveAssignCourse(course);
            return Json(saveAsCourse, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int id)
        {
            var assignCourseDelete = _assignCourseSetupManager.DeleteAssignCourse(id);
            return Json(assignCourseDelete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(int departmentId)
        {
            var getAllAssignCourse = _assignCourseSetupManager.GetAllCourse(departmentId);
            return Json(getAllAssignCourse, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int id)
        {
            var getAssignCourse = _assignCourseSetupManager.GetAllAssignCourseById(id);
            return Json(getAssignCourse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreditDetails(int id)
        {
            var creditdetails = _assignCourseSetupManager.GetCreditDetails(id);
            return Json(creditdetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseDetails(int id)
        {
            var courseDetails = _assignCourseSetupManager.GetCourseDetails(id);
            return Json(courseDetails, JsonRequestBehavior.AllowGet);
        }

    }
}