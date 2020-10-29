using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface IDictBLL<T> : IBaseAction<T>
        where T : class, new()
    {
    }
}
