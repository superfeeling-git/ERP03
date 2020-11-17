using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.ViewModel;
using ERP.IBLL;

namespace ERP.UI.Controllers
{
    public class UserController : Controller
    {
        private IUserBLL userBLL;
        private ISendMsgBLL sendMsgBLL;
        public UserController(IUserBLL _userBLL, ISendMsgBLL _sendMsgBLL)
        {
            this.userBLL = _userBLL;
            this.sendMsgBLL = _sendMsgBLL;
        }

        // GET: User
        public ActionResult Index()
        {
            sendMsgBLL.SendMsg(userBLL.GetUsers());
            return null;
        }
    }
}