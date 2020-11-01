using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ViewModel;

namespace ERP.IDAL
{
    public interface IProductClassDAL<T> : IBaseAction<T>
    {
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="productClassModel"></param>
        /// <returns></returns>
        int MoveClass(ProductClassModel productClassModel);
        /// <summary>
        /// 根据父ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T getModelByParentId(int id);
        /// <summary>
        /// 根据父ID判断有无子分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistsChildClass(int id);
    }
}
