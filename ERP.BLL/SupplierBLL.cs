using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Utility;
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
            Model.AddTime = DateTime.Now;

            SupplierModel Entity = supplierDAL.getMaxCode();
            if (Entity == null)
                Model.SupplierCode = "GYA001";
            else
                Model.SupplierCode = "GY".Generator(Entity.SupplierCode.Replace("GY",""));

            return supplierDAL.Add(Model);
        }

        public TResult Delete<TResult>(int id) where TResult : ResultInfo, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="supplierQueryModel"></param>
        /// <returns></returns>
        public PageListModel<SupplierModel> PageList(int PageIndex, int PageSize, SupplierQueryModel supplierQueryModel, string field, string order)
        {
            return supplierDAL.PageList(PageIndex, PageSize, supplierQueryModel, field, order);
        }

        public int Update(SupplierModel Model)
        {
            throw new NotImplementedException();
        }
    }
}
