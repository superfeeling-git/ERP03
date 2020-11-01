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

namespace ERP.DAL
{
    public class SupplierDAL : ISupplierDAL<SupplierModel>
    {
        erp__Entities db = new erp__Entities();

        public int Add(SupplierModel t)
        {
            Supplier Model = t.MapTo<Supplier>();
            db.Entry<Supplier>(Model).State = System.Data.Entity.EntityState.Added;
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
