using APStore.Common;
using APStore.Models.DAO;
using APStore.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace APStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            UserLogin current = (UserLogin)Session[Constant.UserLoginSession];
            if (current != null)
            {
                List<Cart> carts = new CartDAO().ListAll(current.Name);
                
                List<DeliveryDetail> deliverys = new DeliveryDAO().ListAll(current.Name);
                if (deliverys.Count > 0)
                {
                    ViewBag.DeliveryID = new SelectList(deliverys, "ID", "Name");
                }
                foreach (var item in carts)
                {
                    Product p = new ProductDao().Get(item.ProductID);
                    item.ProductNameDisplay = p.Name;
                    item.ProductImagePathDisplay = p.ImagePath;
                    item.ProductPriceDisplay = p.Price;
                    item.TotalPriceDisplay = p.Price*(decimal)item.Quantities;
                    int CategoryID = p.CategoryID;
                    item.ProductCategoryDisplay = new ProductCategoryDAO().Get(CategoryID).Name;
                }
                return View(carts);
            }
            return RedirectToAction("Index", "Shop");
        }
        public JsonResult AddProduct(int id, int quantities)
        {
            if (Session[Constant.UserLoginSession] == null)
            {
                return Json("NotLogin");
            }
            UserLogin userlogin = (UserLogin)Session[Constant.UserLoginSession];
            Cart cart = new Cart();
            cart.UserName = userlogin.Name;
            try
            {
                cart.ProductID = int.Parse(Request["ID"]);
                cart.Quantities = int.Parse(Request["Quantities"]);
            }
            catch (Exception)
            {
                return Json("");
            }
            bool result = new CartDAO().AddProduct(cart);
            if (result)
            {
                var product = new ProductDao().Get(cart.ProductID);
                cart.ProductImagePathDisplay = product.ImagePath;
                cart.ProductNameDisplay = product.Name;
                cart.ProductPriceDisplay = product.Price;
                cart.ProductCategoryDisplay = new ProductCategoryDAO().Get(product.CategoryID).Name;
                string jsonResult = JsonConvert.SerializeObject(cart);
                return Json(jsonResult);
            }
            else
            {
                return Json("");
            }
        }
        public JsonResult DeleteProduct()
        {
            UserLogin currentlogin = (UserLogin)Session[Constant.UserLoginSession];
            int ProductID = int.Parse(Request["ID"]);
            bool result = new CartDAO().Delete(ProductID, currentlogin.Name);
            return Json(result ? "true" : "");
        }
    }
}