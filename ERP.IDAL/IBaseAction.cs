﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IDAL
{
    public interface IBaseAction<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int Add(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
        /// <summary>
        /// 获取单条实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetModel(int id);
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetAll();
    }
}
