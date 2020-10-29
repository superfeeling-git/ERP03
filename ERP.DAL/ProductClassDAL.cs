using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERP.Domain;
using ERP.IDAL;
using ERP.Utility;
using ERP.ViewModel;
using EntityFramework.Extensions;

namespace ERP.DAL
{
    public class test
    {
        public test()
        {
            ProductClassDAL productClassDAL = new ProductClassDAL();
        }
    }

    public class ProductClassDAL : IProductClassDAL<ProductClassModel>
    {
        erp__Entities db = new erp__Entities();

        public int Add<T>(T t)
        {
            db.ProductClass.Add(t.MapTo<ProductClass>());
            return db.SaveChanges();
        }

        public int Add(ProductClassModel t)
        {
            db.ProductClass.Add(t.MapTo<ProductClass>());
            return db.SaveChanges();
        }

        public int Delete<T>(int id)
        {
            return db.ProductClass.Where(m => m.ClassID == id).Delete();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return db.ProductClass.ToList().MapToList<ProductClass, T>();
        }

        public List<ProductClassModel> GetAll()
        {
            return db.ProductClass.ToList().MapToList<ProductClass, ProductClassModel>();
        }

        public T GetModel<T>(int id)
        {
            return db.ProductClass.Find(id).MapTo<T>();
        }

        public ProductClassModel GetModel(int id)
        {
            return db.ProductClass.Find(id).MapTo<ProductClassModel>();
        }

        public int Update<T>(T t)
        {
            db.Entry<ProductClass>(db.ProductClass.Find(t.MapTo<ProductClass>().ClassID)).State = EntityState.Detached;
            db.Entry<ProductClass>(t.MapTo<ProductClass>()).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Update(ProductClassModel t)
        {
            db.Entry<ProductClass>(db.ProductClass.Find(t.MapTo<ProductClass>().ClassID)).State = EntityState.Detached;
            db.Entry<ProductClass>(t.MapTo<ProductClass>()).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
