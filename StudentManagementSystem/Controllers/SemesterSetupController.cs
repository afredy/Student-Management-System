using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
   
    public class SemesterSetupController : Controller
    {
        private readonly SemesterSetupManager _semesterSetupManager;

        public SemesterSetupController()
        {
            _semesterSetupManager = new SemesterSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Semester semester)
        {
            var saveSemester = _semesterSetupManager.SaveSemester(semester);
            return Json(saveSemester, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int semesterId)
        {
            var semDelete = _semesterSetupManager.DeleteSemester(semesterId);
            return Json(semDelete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getAllSemester = _semesterSetupManager.GetAllSemester();
            return Json(getAllSemester, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int semesterId)
        {
            var getSemester = _semesterSetupManager.GetSemesterById(semesterId);
            return Json(getSemester, JsonRequestBehavior.AllowGet);
        }
    }
}