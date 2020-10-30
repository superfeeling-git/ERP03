using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface IProductClassBLL<T> : IBaseAction<T>
        where T : class, new()
    {
        ResultInfo MoveClass(T Model);
    }
}
