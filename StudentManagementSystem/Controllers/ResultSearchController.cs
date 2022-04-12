using StudentManagementSystem.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class ResultSearchController : Controller
    {
        private readonly ResultSearchManager _resultSearchManager;
        public ResultSearchController()
        {
            _resultSearchManager = new ResultSearchManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Get(int id)
        {
            var list = _resultSearchManager.GetStudentResultsById(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}