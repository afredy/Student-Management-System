using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class RegisterStudentController : Controller
    {
        private readonly RegisterStudentManager _registerStudentManager;
        public RegisterStudentController()
        {
            _registerStudentManager = new RegisterStudentManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Save(Student student)
        {
            var saveStd = _registerStudentManager.SaveStudent(student);
            return Json(saveStd, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int studentId)
        {
            var DeleteStd = _registerStudentManager.DeleteStudent(studentId);
            return Json(DeleteStd, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getAll = _registerStudentManager.GetAllStudent();
            return Json(getAll, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int studentId)
        {
            var get = _registerStudentManager.GetAllStudentById(studentId);
            return Json(get, JsonRequestBehavior.AllowGet);
        }
    }
}