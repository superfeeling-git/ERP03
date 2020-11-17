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


    public class TestBLL : IUserBLL
    {
        public int Create(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        
        public List<UserModel> GetUsers()
        {
            return new List<UserModel> {
                new UserModel{ UserID = 1, UserName = "张三", Password = Guid.NewGuid().ToString() },
                new UserModel{ UserID = 2, UserName = "李四", Password = Guid.NewGuid().ToString() },
                new UserModel{ UserID = 3, UserName = "王五", Password = Guid.NewGuid().ToString() }
            };
        }
    }
}
