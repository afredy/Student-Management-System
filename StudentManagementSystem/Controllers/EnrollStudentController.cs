using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class EnrollStudentController : Controller
    {
        private readonly EnrollStudentManager _enrollStudentManager;
        public EnrollStudentController()
        {
            _enrollStudentManager = new EnrollStudentManager();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public JsonResult Save(EnrollStudent student)
        {
            var save = _enrollStudentManager.SaveStudentRoll(student);
            return Json(save, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int id)
        {
            var delete = _enrollStudentManager.DeleteStudentRoll(id);
            return Json(delete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(int departmentId)
        {
            var getAll = _enrollStudentManager.GetAllEnrollStudent(departmentId);
            return Json(getAll, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int id)
        {
            var getStudent = _enrollStudentManager.GetEnrollStudentById(id);
            return Json(getStudent, JsonRequestBehavior.AllowGet);
        }
    }
}