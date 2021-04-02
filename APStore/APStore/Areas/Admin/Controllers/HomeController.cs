using APStore.Common;
using APStore.Models.DAO;
using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APStore.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session[Constant.AdminLoginSession] = null;
            return RedirectToAction("Index","Login");
        }
        [ChildActionOnly]
        public ActionResult TopSide()
        {
            AdminLogin currentLogin = (AdminLogin) Session[Constant.AdminLoginSession];
            return PartialView(currentLogin);
        }
        [ChildActionOnly]
        public ActionResult LeftSide()
        {
            AdminLogin currentLogin = (AdminLogin)Session[Constant.AdminLoginSession];
            return PartialView(currentLogin);
        }
    }
}
