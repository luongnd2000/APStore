using APStore.Models.DAO;
using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APStore.Areas.Admin.Controllers
{
    public class DiscountController : BaseController
    {
        // GET: Admin/Discount
        public ActionResult Index()
        {
            var model = new DiscountDAO().ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Discount discount)
        {
            if (ModelState.IsValid)
            {
                bool result = new DiscountDAO().Create(discount);
                if (result)
                {
                    return RedirectToAction("Index", "Discount");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi ! Không thể thêm mới khuyến mãi");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new DiscountDAO().Get(id);
            string t=model.StartDate.ToString("yyyy-MM-ddThh:mm");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Discount obj)
        {
            if (ModelState.IsValid)
            {
                bool result = new DiscountDAO().Update(obj);
                if (result)
                {
                    return RedirectToAction("Index", "Discount");
                }
                else
                {
                    ModelState.AddModelError("", $"Lỗi ! Không thể sửa khuyến mãi : \" {obj.NameDisplay}\"");
                }
            }
            return RedirectToAction("Edit", "Discount");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool result = new DiscountDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}