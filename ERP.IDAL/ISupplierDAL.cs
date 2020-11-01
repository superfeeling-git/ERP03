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
    }
}
