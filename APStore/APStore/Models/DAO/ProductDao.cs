using APStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class ProductDao
    {
        APStoreEntities db = null;
        public ProductDao()
        {
            db = new APStoreEntities();
        }
        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }
        public bool Create(Product  obj)
        {
            try
            {
                db.Products.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.Products.Find(id);
                db.Products.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public bool Update(Product obj)
        {
            try
            {
                var temp = db.Products.SingleOrDefault(dis => dis.ID == obj.ID);
                if (temp != null)
                {
                    if (obj.Name != null) temp.Name = obj.Name;
                    if (obj.ImagePath != null) temp.ImagePath = obj.ImagePath;
                    if (obj.Price > 0) temp.Price = obj.Price;
                    if (obj.CategoryID > 0) temp.CategoryID = obj.CategoryID;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}