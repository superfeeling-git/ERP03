using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface ISupplierBLL<T> : IBaseAction<T>
        where T : class, new()
    {
        PageListModel<T> PageList(int PageIndex, int PageSize, SupplierQueryModel supplierQueryModel, string field, string order);
    }
}
