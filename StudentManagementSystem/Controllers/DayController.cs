using StudentManagementSystem.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class DayController : Controller
    {
        private readonly DaySetupManager _daySetupManager;
        public DayController()
        {
            _daySetupManager = new DaySetupManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            var list = _daySetupManager.GetDaySelectList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}