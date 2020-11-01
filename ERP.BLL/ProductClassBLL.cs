using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using ERP.IBLL;
using ERP.ViewModel;
using System.Net.Http.Headers;

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
                Model.ParentPath = $"{parentModel.ParentPath },{parentModel.ClassID}";
            }

            return productClassDAL.Add(Model);
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
            return productClassDAL.Update(Model);
        }

        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResultInfo MoveClass(ProductClassModel Model)
        {
            //获取原始分类
            ProductClassModel originalClassModel = productClassDAL.GetModel(Model.ClassID);
            if (Model.ParentID == 0 && originalClassModel.ParentID == 0)
            {
                return new ResultInfo { ErrorCode = 1, Msg = "已经是顶级分类" };
            }

            //顶级分类
            if (Model.ParentID == 0)
            {
                Model.ParentID = 0;
                Model.Depth = 0;
                Model.ParentPath = "0";

                productClassDAL.MoveClass(Model);

                //更新子分类
                UpdateChildClass(Model);
            }
            else
            {
                //获取目标分类
                ProductClassModel targetClassModel = productClassDAL.GetModel(Model.ParentID);
                if ($",{targetClassModel.ParentPath},".Contains($",{Model.ClassID},"))
                {
                    return new ResultInfo { ErrorCode = 2, Msg = "所属不能为下级栏目" };
                }

                ProductClassModel parentModel = ProductClassList.First(m => m.ClassID == Model.ParentID);

                Model.Depth = parentModel.Depth + 1;
                Model.ParentPath = $"{parentModel.ParentPath },{Model.ClassID}";

                //更新子分类
                productClassDAL.MoveClass(Model);

                //更新子分类
                UpdateChildClass(Model);
            }
            return new ResultInfo { };
        }

        /// <summary>
        /// 更新子分类
        /// </summary>
        private void UpdateChildClass(ProductClassModel productClassModel)
        {
            //替换所有的子分类
            IEnumerable<ProductClassModel> childClass = productClassDAL.GetAll().Where(m => m.ParentID == productClassModel.ClassID);
            foreach (var item in childClass)
            {
                item.Depth = productClassModel.Depth + 1;
                item.ParentPath = $"{productClassModel.ParentPath},{productClassModel.ClassID}";
                productClassDAL.MoveClass(item);
                UpdateChildClass(item);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult Delete<TResult>(int id) where TResult : ResultInfo, new()
        {
            if(productClassDAL.ExistsChildClass(id))
            {
                return new TResult { ErrorCode = 1, Msg = "还存在子分类" };
            }

            productClassDAL.Delete(id);
            return new TResult { ErrorCode = 0, Msg = "删除成功" };
        }
    }
}
