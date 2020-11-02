using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using ERP.IBLL;
using ERP.ViewModel;

namespace ERP.BLL
{
    public class SupplierBLL : ISupplierBLL<SupplierModel>
    {
        private ISupplierDAL<SupplierModel> supplierDAL;

        public SupplierBLL(ISupplierDAL<SupplierModel> _supplierDAL)
        {
            this.supplierDAL = _supplierDAL;
        }

        public int Add(SupplierModel Model)
        {
            return supplierDAL.Add(Model);
        }

        public TResult Delete<TResult>(int id) where TResult : ResultInfo, new()
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

        public int Update(SupplierModel Model)
        {
            throw new NotImplementedException();
        }
    }
}
