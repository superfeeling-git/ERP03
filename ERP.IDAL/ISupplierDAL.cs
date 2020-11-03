using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IDAL
{
    public interface ISupplierDAL<T> : IBaseAction<T>
    {
        int Add(T Entity, out int NewID);
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="supplierQueryModel"></param>
        /// <returns></returns>
        PageListModel<T> PageList(int PageIndex, int PageSize, SupplierQueryModel supplierQueryModel);
        /// <summary>
        /// 获取供应商最新编号
        /// </summary>
        /// <returns></returns>
        T getMaxCode();
    }
}
