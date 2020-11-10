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
using System.Linq.Dynamic;

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

            Supplier supplier = Model.MapTo<Supplier>();

            List<ProductClass_Supplier> productClass_Suppliers = new List<ProductClass_Supplier>();

            foreach (var item in Model.ClassID)
            {
                productClass_Suppliers.Add(new ProductClass_Supplier { ClassID = item });
            }

            supplier.ProductClass_Supplier = productClass_Suppliers;

            db.Supplier.Add(supplier);

            db.SaveChanges();

            #endregion

            /*
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
            */

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

        public SupplierModel getMaxCode()
        {
            var Entity = db.Supplier.OrderByDescending(m => m.SupplierID).FirstOrDefault();
            return Entity.MapTo<SupplierModel>();
        }

        public SupplierModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public PageListModel<SupplierModel> PageList(int PageIndex, int PageSize, SupplierQueryModel supplierQueryModel, string field, string order)
        {
            var query = db.Supplier.Join(db.Dict, a => a.SupplierLevel, b => b.DictCode, (a, b) => new { a,b })
                .Join(db.Dict,d => d.a.SupplierState  ,b => b.DictCode, (d,b) => new SupplierModel {
                    SupplierID = d.a.SupplierID,
                    Phone = d.a.Phone,
                    SupplierLevel = d.b.DictName,
                    AddTime = d.a.AddTime,
                    SupplierCode = d.a.SupplierCode,
                    Contact = d.a.Contact,
                    SupplierState = b.DictName,
                    SupplierName = d.a.SupplierName
                });


            if (!string.IsNullOrWhiteSpace(supplierQueryModel.SupplierName))
                query = query.Where(m => m.SupplierName.Contains(supplierQueryModel.SupplierName));
            if (!string.IsNullOrWhiteSpace(supplierQueryModel.Phone))
                query = query.Where(m => m.Phone == supplierQueryModel.Phone);
            if (!string.IsNullOrWhiteSpace(supplierQueryModel.Contact))
                query = query.Where(m => m.Contact == supplierQueryModel.Contact);
            if (!string.IsNullOrWhiteSpace(supplierQueryModel.State))
                query = query.Where(m => m.SupplierState == supplierQueryModel.State);

            //要返回的数据封装
            PageListModel<SupplierModel> pageListModel = new PageListModel<SupplierModel>();

            pageListModel.TotalCount = query.Count();

            if(string.IsNullOrWhiteSpace(field))
                pageListModel.PageList = query.OrderBy(m=>m.AddTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            else
                pageListModel.PageList = query.OrderBy($"{field} {order}").Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            return pageListModel;
        }

        public int Update(SupplierModel t)
        {
            throw new NotImplementedException();
        }
    }
}
