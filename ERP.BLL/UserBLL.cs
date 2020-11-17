#define Debug
using ERP.IBLL;
using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL
{
#if !Debug
    public class UserBLL : IUserBLL
    {
        public int Create(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsers()
        {
            return new List<UserModel> {
                new UserModel{ UserID = 1, UserName = "zhangsan", Password = Guid.NewGuid().ToString() },
                new UserModel{ UserID = 2, UserName = "lisi", Password = Guid.NewGuid().ToString() },
                new UserModel{ UserID = 3, UserName = "wangwu", Password = Guid.NewGuid().ToString() }
            };
        }
    }
#endif
}
