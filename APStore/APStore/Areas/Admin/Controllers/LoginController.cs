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
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            var sess = (AdminLogin)Session[Constant.AdminLoginSession];
            if (sess != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminLogin login)
        {
            if (ModelState.IsValid)
            {
                LoginStatus result = new AdminLoginDAO().Login(login);
                switch (result)
                {
                    case LoginStatus.Success:
                        AdminLogin sessionlogin = new AdminLogin();
                        sessionlogin = new AdminLoginDAO().GetLogin(login.LoginName);
                        Session.Add(Constant.AdminLoginSession, sessionlogin);
                        return RedirectToAction("Index", "Home");
                    case LoginStatus.UserNameFail:
                        ModelState.AddModelError("", "Không tồn tại User : "+login.LoginName);
                        break;
                    case LoginStatus.PasswordFail:
                    default:
                        ModelState.AddModelError("", "Mật khẩu không đúng!!");
                        break;
                }
            }
            return View("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}