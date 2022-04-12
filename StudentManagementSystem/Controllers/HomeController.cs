using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private string database = @"Data Source=DESKTOP-DI7P1IN;Initial Catalog=StudentManagementSystem;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        //public JsonResult CheckLogin(string username, string password)

        //{
        //    MyConnection db = new MyConnection();
           
        //        var dataItem = db.LoginCheck.Where(x => x.Username == username && x.Password == password).SingleOrDefault();

        //        bool isLogged = true;

        //        if (dataItem != null)

        //        {

        //            FormsAuthentication.SetAuthCookie(dataItem.Username, true);

        //            var mdl = System.Web.HttpContext.Current.User.Identity.Name;

        //            isLogged = true;

        //        }

        //        else

        //        {

        //            isLogged = false;

        //        }

        //        return Json(isLogged, JsonRequestBehavior.AllowGet);

        //    }
        }

    
}