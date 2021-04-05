using APStore.Models.DAO;
using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APStore.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var model = new ProductDao().ListAll();
            foreach (var item in model)
            {
                item.CategoryNameDisplay = new ProductCategoryDAO().Get(item.CategoryID).Name;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            var dao = new ProductCategoryDAO();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[1];
                if (file != null)
                {
                    string rootFile = "/Upload/Image/";
                    string fileName = "Product_Image_" + Guid.NewGuid() + file.FileName;
                    string path = Path.Combine(Server.MapPath(rootFile), fileName);
                    file.SaveAs(path);
                    obj.ImagePath = rootFile + fileName;
                }
                bool result = new ProductDao().Create(obj);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi database! Không thể thêm sản phẩm.");
                }
            }
            return View();
        }
        public ActionResult Detail(int id)
        {

            SetViewBag(id);
            var model = new ProductDao().Get(id);
            model.CategoryNameDisplay = new ProductCategoryDAO().Get(model.CategoryID).Name;
            return View(model);
        }
        public void SetViewBag(int? selectedID = null)
        {
            ViewBag.CategoryID = new SelectList(new ProductCategoryDAO().ListAll(), "ID", "Name", selectedID);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool result = new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag(id);
            var model = new ProductDao().Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files[0] != null)
                {
                    var file = Request.Files[0];
                    string rootFile = "/Upload/Image/";
                    string fileName = "Product_Image_" + Guid.NewGuid() + file.FileName;
                    string path = Path.Combine(Server.MapPath(rootFile), fileName);
                    file.SaveAs(path);
                    obj.ImagePath = rootFile + fileName;
                }

                bool result = new ProductDao().Update(obj);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", $"Lỗi ! Không thể sửa sản phẩm : \" {obj.Name}\"");
                }
            }
            SetViewBag(obj.ID);
            return View(obj);
        }

    }
}