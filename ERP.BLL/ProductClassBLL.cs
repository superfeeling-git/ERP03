using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using ERP.IBLL;
using ERP.ViewModel;

namespace ERP.BLL
{
    public class ProductClassBLL : IProductClassBLL<ProductClassModel>
    {
        private IProductClassDAL<ProductClassModel> productClassDAL;

        /// <summary>
        /// 存储递归之后的分类
        /// </summary>
        List<ProductClassModel> ProductClassOrder = new List<ProductClassModel>();

        List<ProductClassModel> ProductClassList = new List<ProductClassModel>();

        public ProductClassBLL(IProductClassDAL<ProductClassModel> _productClassDAL)
        {
            this.productClassDAL = _productClassDAL;
            ProductClassList = productClassDAL.GetAll();
        }

        public int Add(ProductClassModel Model)
        {
            //顶级分类
            if (Model.ParentID == 0)
            {
                Model.ParentID = 0;
                Model.Depth = 0;
                Model.ParentPath = "0";
            }
            else
            {
                ProductClassModel parentModel = ProductClassList.First(m => m.ClassID == Model.ParentID);

                Model.Depth = parentModel.Depth + 1;
                Model.ParentPath = $"{parentModel.ParentPath },{Model.ClassID}";
            }

            return productClassDAL.Add(Model);
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductClassModel> GetAll()
        {
            foreach (var item in ProductClassList.Where(m => m.Depth == 0))
            {
                ProductClassOrder.Add(item);
                getSubClass(item);
            }

            return ProductClassOrder;
        }

        #region 递归
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="item"></param>
        private void getSubClass(ProductClassModel item)
        {
            foreach (var cate in ProductClassList.Where(m => m.ParentID == item.ClassID))
            {
                ProductClassOrder.Add(cate);
                getSubClass(cate);
            }
        }
        #endregion

        public ProductClassModel GetModel(int id)
        {
            return productClassDAL.GetModel(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Update(ProductClassModel Model)
        {
            //顶级分类
            if (Model.ParentID == 0)
            {
                Model.ParentID = 0;
                Model.Depth = 0;
                Model.ParentPath = "0";
            }
            else
            {
                ProductClassModel parentModel = ProductClassList.First(m => m.ClassID == Model.ParentID);

                Model.Depth = parentModel.Depth + 1;
                Model.ParentPath = $"{parentModel.ParentPath },{Model.ClassID}";
            }

            return productClassDAL.Update(Model);
        }
    }
}
