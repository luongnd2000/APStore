using APStore.Common;
using APStore.Models.DAO;
using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APStore.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            var sess = (UserLogin)Session[Constant.UserLoginSession];
            if (sess != null)
            {
                return RedirectToAction("Index", "Shop");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin obj)
        {
            if (ModelState.IsValid)
            {
                LoginStatus result = new UserLoginDAO().Login(obj);
                switch (result)
                {
                    case LoginStatus.Success:
                        UserLogin sessionlogin = new UserLogin();
                        sessionlogin = new UserLoginDAO().GetLogin(obj.Name);
                        Session.Add(Constant.UserLoginSession, sessionlogin);
                        return RedirectToAction("Index", "Shop");
                    case LoginStatus.UserNameFail:
                        ModelState.AddModelError("", "Không tồn tại User : " + obj.Name);
                        break;
                    case LoginStatus.PasswordFail:
                    default:
                        ModelState.AddModelError("", "Mật khẩu không đúng!");
                        break;
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            var sess = (UserLogin)Session[Constant.UserLoginSession];
            if (sess != null)
            {
                return RedirectToAction("Index", "Shop");
            }
            return View();
        }
        [HttpPost] 
        public ActionResult Register(UserLogin obj)
        {
            if (ModelState.IsValid)
            {
                bool result = new UserLoginDAO().Register(obj);
                if (result)
                {
                    UserLogin sessionlogin = new UserLogin();
                    sessionlogin = new UserLoginDAO().GetLogin(obj.Name);
                    Session.Add(Constant.UserLoginSession, sessionlogin);
                    return RedirectToAction("Index", "Shop");
                }
                else
                {
                    ModelState.AddModelError("", "Đã có user "+obj.Name);
                }
            }
            return View();
        }
    }
}