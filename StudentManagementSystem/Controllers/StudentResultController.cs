using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentResultController : Controller
    {
        private readonly StudentResultManager _studentResultManager;
        public StudentResultController()
        {
            _studentResultManager = new StudentResultManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Save(StudentResult result)
        {
            var save = _studentResultManager.SaveStudentResult(result);
            return Json(save, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int id)
        {
            var delete = _studentResultManager.DeleteStudentResult(id);
            return Json(delete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getAll = _studentResultManager.GetAllStudentResult();
            return Json(getAll, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int id)
        {
            var getStudent = _studentResultManager.GetStudentResultById(id);
            return Json(getStudent, JsonRequestBehavior.AllowGet);
        }
    }
}