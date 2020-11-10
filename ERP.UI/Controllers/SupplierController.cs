using ERP.IBLL;
using ERP.ViewModel;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List(SupplierQueryModel supplierQueryModel, string field, string order, int page = 1)
        {
            ViewBag.Dict = dictBLL.GetAll();
            if (Request.IsAjaxRequest())
            {
                PageListModel<SupplierModel> pageListModel = supplierBLL.PageList(page, 6, supplierQueryModel,field,order);
                return Json(new
                {
                    code = 0,
                    msg = "",
                    count = pageListModel.TotalCount,
                    data = pageListModel.PageList
                }, JsonRequestBehavior.AllowGet);

            }
            return View();
        }   

        // GET: Supplier
        public ActionResult Index(SupplierQueryModel supplierQueryModel, string field, string order, int page = 1)
        {
            ViewBag.Dict = dictBLL.GetAll();
            if (Request.IsAjaxRequest())
            { 
                PageListModel<SupplierModel> pageListModel  = supplierBLL.PageList(page, 6, supplierQueryModel, field,order);
                return Json(new
                {
                    code = 0,
                    msg = "",
                    count = pageListModel.TotalCount,
                    data = pageListModel.PageList
                },JsonRequestBehavior.AllowGet);

            }
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
        [ValidateAntiForgeryToken]
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ImportExcel()
        {
            //List<dc_Log> logs = new List<dc_Log>();

            //PropertyInfo[] propertyInfos = typeof(dc_Log).GetProperties();

            //using (FileStream file = new FileStream(Server.MapPath("/fileContents.xls"), FileMode.Open, FileAccess.Read))
            //{
            //    HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);

            //    ISheet sheet = hssfworkbook.GetSheetAt(0);

            //    IEnumerator rowList = sheet.GetRowEnumerator();

            //    while (rowList.MoveNext())
            //    {
            //        IRow row = rowList.Current as IRow;

            //        //logs.Add(new dc_Log { AddTime = row.Cells[0] });



            //        for (int i = 0; i < row.LastCellNum; i++)
            //        {
            //            ICell cell = row.Cells[i];

                        
            //        }
                    
            //    }
            //}

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OutExcel()
        {
            ////1、创建工作簿
            //HSSFWorkbook hSSFWorkbook = new HSSFWorkbook();

            ////2、创建工作表
            //ISheet sheet = hSSFWorkbook.CreateSheet("第1个工作表");

            ////string FilePath = Path.GetFullPath("../../") + "test.xls";

            ////文档摘要信息
            //DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //dsi.Company = "八维北京校区";

            //SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //si.Author = "物联网1803A";

            //hSSFWorkbook.DocumentSummaryInformation = dsi;
            //hSSFWorkbook.SummaryInformation = si;

            //dechengEntities db = new dechengEntities();

            ////准备数据
            //List<dc_Log> dc_Logs = db.dc_Log.Take(20).ToList();

            //PropertyInfo[] propertyInfos = typeof(dc_Log).GetProperties();

            //sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, propertyInfos.Length - 1));

            //IRow titleRow = sheet.CreateRow(0);

            //titleRow.Height = 40 * 20;

            //ICell titleCell = titleRow.CreateCell(0);

            //titleCell.SetCellValue("日志记录");

            //ICellStyle hSSFCellStyle = hSSFWorkbook.CreateCellStyle();

            //IFont hSSFFont = hSSFWorkbook.CreateFont();

            //hSSFFont.Color = HSSFColor.Red.Index;
            ////字号
            //hSSFFont.FontHeightInPoints = 19;

            ////水平居中
            //hSSFCellStyle.Alignment = HorizontalAlignment.Center;
            ////垂直居中
            //hSSFCellStyle.VerticalAlignment = VerticalAlignment.Center;

            ////设置单元格样式的字体
            //hSSFCellStyle.SetFont(hSSFFont);

            ////设置标头的样式
            //titleCell.CellStyle = hSSFCellStyle;

            //IRow headerRow = sheet.CreateRow(1);

            //for (int i = 0; i < propertyInfos.Length; i++)
            //{
            //    PropertyAttributes propertyAttributes = propertyInfos[i].Attributes;

            //    System.ComponentModel.DescriptionAttribute attribute = (System.ComponentModel.DescriptionAttribute)propertyInfos[i].GetCustomAttribute(typeof(System.ComponentModel.DescriptionAttribute));

            //    string description = string.Empty;
            //    if (attribute != null)
            //        description = attribute.Description;

            //    headerRow.CreateCell(i).SetCellValue(description);
            //}


            ////遍历数据行
            //for (int i = 2; i < dc_Logs.Count(); i++)
            //{
            //    //创建Excel行
            //    IRow row = sheet.CreateRow(i);

            //    row.Height = 20 * 20;

            //    //遍历所有属必
            //    for (int p = 0; p < propertyInfos.Length; p++)
            //    {
            //        //创建Excel列
            //        ICell cell = row.CreateCell(p);

            //        sheet.SetColumnWidth(p, 14 * 256);

            //        //获取列的值
            //        object obj = propertyInfos[p].GetValue(dc_Logs[i]);

            //        //写值
            //        cell.SetCellValue(obj.ToString());
            //    }
            //}

            //MemoryStream memoryStream = new MemoryStream();

            //hSSFWorkbook.Write(memoryStream);

            //return File(memoryStream.ToArray(), "application/ms-excel", "fileContents.xls");
            return null;
        }
    }
}