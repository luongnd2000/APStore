using APStore.Models.DAO;
using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APStore.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var model = new ProductCategoryDAO().ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                bool result = new ProductCategoryDAO().Create(category);
                if (result)
                {
                    return RedirectToAction("Index","ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", $"Lỗi ! Không thể thêm danh mục\" {category.Name}\"");
                }
            }
            return View("Create");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool result = new ProductCategoryDAO().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet] 
        public ActionResult Edit(int id)
        {
            var model = new ProductCategoryDAO().Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                bool result = new ProductCategoryDAO().Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", $"Lỗi ! Không thể Sửa danh mục\" {category.Name}\"");
                }
            }
            return View("Edit");
        }
    }
}