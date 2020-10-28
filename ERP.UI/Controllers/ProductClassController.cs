using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.ViewModel;
using ERP.IBLL;

namespace ERP.UI.Controllers
{
    public class ProductClassController : Controller
    {
        private IProductClassBLL<ProductClassModel> productClassBLL;

        public ProductClassController(IProductClassBLL<ProductClassModel> _productClassBLL)
        {
            this.productClassBLL = _productClassBLL;
        }

        /// <summary>
        /// 所有的商品分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(productClassBLL.GetAll());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ProductClassModel Model)
        {
            return Json(productClassBLL.Add(Model), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(productClassBLL.GetModel(id));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(ProductClassModel Model)
        {
            return Json(productClassBLL.Update(Model), JsonRequestBehavior.AllowGet);
        }
    }
}