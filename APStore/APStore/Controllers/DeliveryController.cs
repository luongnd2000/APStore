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
    public class DeliveryController : Controller
    {
        // GET: Delivery
        static string previousUrl = "";
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            if (Session[Constant.UserLoginSession] != null)
            {
                RedirectToAction("Index","Shop");
            }
            previousUrl = Request.UrlReferrer.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeliveryDetail obj)
        {
            if (Session[Constant.UserLoginSession] != null)
            {
                RedirectToAction("Index", "Shop");
            }
            if (ModelState.IsValid)
            {
                UserLogin current= (UserLogin)Session[Constant.UserLoginSession];
                obj.UserName=current.Name;
                bool result = new DeliveryDAO().Create(obj);

                if (result)
                {
                    return Redirect(previousUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi database! Không thể thêm địa chỉ.");
                }
            }
                return View();
        }
    }
}