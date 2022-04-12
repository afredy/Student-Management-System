using StudentManagementSystem.Core.Manager;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentSetupController : Controller
    {
        private readonly DepartmentSetupManager _departmentSetupManager;

        public DepartmentSetupController()
        {
            _departmentSetupManager = new DepartmentSetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Department department) 
        {
            var saveDepartment = _departmentSetupManager.SaveDepartment(department);
            return Json(saveDepartment, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int departmentId)
        {
            var depDelete = _departmentSetupManager.DeleteDepartment(departmentId);
            return Json(depDelete, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var getAllDepartment = _departmentSetupManager.GetAllDepartment();
            return Json(getAllDepartment,JsonRequestBehavior.AllowGet);

        }
        public JsonResult Get(int departmentId)
        {
            var getDepById = _departmentSetupManager.GetDepartmentById(departmentId);
            return Json(getDepById, JsonRequestBehavior.AllowGet);
        }
    }
}