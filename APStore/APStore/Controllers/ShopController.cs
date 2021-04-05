using APStore.Models.DAO;
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

      
    }
}