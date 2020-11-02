using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.IDAL;
using ERP.Utility;
using ERP.ViewModel;
using EntityFramework.Extensions;
using AutoMapper;

namespace ERP.DAL
{
    public class SupplierDAL : ISupplierDAL<SupplierModel>
    {
        erp__Entities db = new erp__Entities();

        public int Add(SupplierModel Model)
        {
            #region 获取最新ID的方式
            //Supplier Entity = Model.MapTo<Supplier>();
            //db.Entry<Supplier>(Entity).State = System.Data.Entity.EntityState.Added;
            //db.SaveChanges();
            //foreach (var item in Model.ClassID)
            //{
            //    db.ProductClass_Supplier.Add(new ProductClass_Supplier { ClassID = item, SupplierID = Entity.SupplierID });
            //}
            //db.SaveChanges();
            #endregion

            #region 中间表方式
            /*
            Supplier supplier = Model.MapTo<Supplier>();

            List<ProductClass_Supplier> productClass_Suppliers = new List<ProductClass_Supplier>();

            foreach (var item in Model.ClassID)
            {
                productClass_Suppliers.Add(new ProductClass_Supplier { ClassID = item });
            }

            supplier.ProductClass_Supplier = productClass_Suppliers;

            db.Supplier.Add(supplier);

            db.SaveChanges();
            */
            #endregion

            List<ProductClass_SupplierModel> productClass_SupplierModels = new List<ProductClass_SupplierModel>();

            foreach (var item in Model.ClassID)
            {
                productClass_SupplierModels.Add(new ProductClass_SupplierModel { ClassID = item });
            }

            Model.ProductClass_Supplier = productClass_SupplierModels;

            MapperConfiguration config = new MapperConfiguration(m => 
            {
                m.CreateMap<SupplierModel, Supplier>();
                m.CreateMap<ProductClass_SupplierModel, ProductClass_Supplier>();
            });

            IMapper mapper = config.CreateMapper();
            Supplier supplier = mapper.Map<SupplierModel, Supplier>(Model);

            db.Supplier.Add(supplier);

            db.SaveChanges();

            return Model.SupplierID;
        }

        public int Add(SupplierModel Entity, out int NewID)
        {
            Supplier Model = Entity.MapTo<Supplier>();
            db.Entry<Supplier>(Model).State = System.Data.Entity.EntityState.Added;
            int row = db.SaveChanges();
            NewID = Model.SupplierID;
            return row;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SupplierModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SupplierModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(SupplierModel t)
        {
            throw new NotImplementedException();
        }
    }
}
