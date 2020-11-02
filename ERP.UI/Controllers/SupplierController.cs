using ERP.IBLL;
using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.UI.Controllers
{
    public class SupplierController : Controller
    {
        private IDictBLL<DictModel> dictBLL;
        private IProductClassBLL<ProductClassModel> productClassBLL;
        private ISupplierBLL<SupplierModel> supplierBLL;

        public SupplierController(
            IDictBLL<DictModel> _dictBLL, 
            IProductClassBLL<ProductClassModel> _productClassBLL,
            ISupplierBLL<SupplierModel> _supplierBLL
            )
        {
            this.dictBLL = _dictBLL;
            this.productClassBLL = _productClassBLL;
            this.supplierBLL = _supplierBLL;
        }

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Dict = dictBLL.GetAll();
            ViewBag.ProductClass = productClassBLL.GetAll().Where(m=>m.Depth == 0);
            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierModel supplierModel)
        {
            return Json(supplierBLL.Add(supplierModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getBrand(int id)
        {
            return Json(productClassBLL.GetAll().Where(m => m.ParentID == id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PCAS()
        {
            return View();
        }
    }
}