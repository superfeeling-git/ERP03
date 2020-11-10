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
using System.Runtime.Remoting.Messaging;

namespace ERP.DAL
{
    public class ProductClassDAL : IProductClassDAL<ProductClassModel>
    {
        erp__Entities db = new erp__Entities();

        public int Add(ProductClassModel t)
        {
            db.ProductClass.Add(t.MapTo<ProductClass>());
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            return db.ProductClass.Where(m=>m.ClassID == id).Delete();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool ExistsChildClass(int id)
        {
            return db.ProductClass.Any(m => m.ParentID == id);
        }

        public List<ProductClassModel> GetAll()
        {
            return db.ProductClass.ToList().MapToList<ProductClass, ProductClassModel>();
        }

        public ProductClassModel GetModel(int id)
        {
            return db.ProductClass.Find(id).MapTo<ProductClassModel>();
        }

        public ProductClassModel getModelByParentId(int id)
        {
            return db.ProductClass.FirstOrDefault(m => m.ParentID == id).MapTo<ProductClassModel>();
        }

        public int MoveClass(ProductClassModel productClassModel)
        {
            return db.ProductClass.Where(m => m.ClassID == productClassModel.ClassID).Update(m => new ProductClass { Depth = productClassModel.Depth, ParentID = productClassModel.ParentID, ParentPath = productClassModel.ParentPath });
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(ProductClassModel t)
        {
            db.Entry<ProductClass>(t.MapTo<ProductClass>()).State = EntityState.Modified;
            return db.SaveChanges();
            //return db.ProductClass.Where(m => m.ClassID == t.ClassID).Update(m => new ProductClass { ClassName = t.ClassName, ClassIntro = t.ClassIntro });
        }
    }
}
