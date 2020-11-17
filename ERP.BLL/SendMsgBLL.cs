using ERP.IBLL;
using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL
{
    public class SendMsgBLL : ISendMsgBLL
    {
        private IUserBLL userBLL;

        public SendMsgBLL(IUserBLL _userBLL)
        {
            this.userBLL = _userBLL;
        }
        
        public int SendMsg(List<UserModel> userModels)
        {
            throw new NotImplementedException();
        }
    }
}
