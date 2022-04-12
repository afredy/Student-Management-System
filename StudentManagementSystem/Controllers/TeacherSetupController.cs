using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class TeacherSetupController : Controller
    {
        private readonly TeacherSetupManager _teacherSetupManager;

        public TeacherSetupController()
        {
            _teacherSetupManager = new TeacherSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Save(Teacher teacher)
        {
            var saveTeacher = _teacherSetupManager.SaveTeacher(teacher);
            return Json(saveTeacher, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int teacherId)
        {
            var teacherDelete = _teacherSetupManager.DeleteTeacher(teacherId);
            return Json(teacherDelete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getAllTeacher = _teacherSetupManager.GetAllTeacher();
            return Json(getAllTeacher, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int teacherId)
        {
            var getTeacher = _teacherSetupManager.GetAllTeacherById(teacherId);
            return Json(getTeacher, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherCreditDetailById(int teacherId)
        {
            var getTeacher = _teacherSetupManager.GetTeacherCreditDetailById(teacherId);
            return Json(getTeacher, JsonRequestBehavior.AllowGet);
        }

    }
}