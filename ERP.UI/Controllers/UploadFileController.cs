using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.UI.Controllers
{
    public class UploadFileController : Controller
    {
        /// <summary>
        /// 上传文件的处理
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteFile(string path)
        {
            if (System.IO.File.Exists(Server.MapPath(path)))
            {
                System.IO.File.Delete(Server.MapPath(path));
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}