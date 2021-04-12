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
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var listCategory = new ProductCategoryDAO().ListAll();
            ViewBag.ListCategory = listCategory;
            var model = new ProductDao().ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var listProduct = new ProductDao().ListAll();
            ViewBag.ListProduct = listProduct;
            var model = new ProductDao().Get(id);
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session[Constant.UserLoginSession] = null;
            return RedirectToAction("Index", "Shop");
        }
        [ChildActionOnly]
        public ActionResult Top()
        {
            UserLogin current = (UserLogin)Session[Constant.UserLoginSession];
            if (current != null)
            {
                List<Cart> carts = new CartDAO().ListAll(current.Name);
                foreach (var item in carts)
                {
                    Product p = new ProductDao().Get(item.ProductID);
                    item.ProductNameDisplay = p.Name;
                    item.ProductImagePathDisplay = p.ImagePath;
                    item.ProductPriceDisplay = p.Price;
                    int CategoryID = p.CategoryID;
                    item.ProductCategoryDisplay = new ProductCategoryDAO().Get(CategoryID).Name;
                }
                ViewBag.Carts = carts;
                ViewBag.Count = carts.Count;
            }
            return PartialView(current);
        }
    }
}