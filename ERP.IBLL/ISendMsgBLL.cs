using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface ISendMsgBLL
    {
        int SendMsg(List<UserModel> userModels);
    }
}
