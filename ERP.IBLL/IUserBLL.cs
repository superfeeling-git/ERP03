using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ViewModel;

namespace ERP.IBLL
{
    public interface IUserBLL
    {
        int Create(UserModel userModel);
        List<UserModel> GetUsers();
    }
}
