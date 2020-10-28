using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using System.Reflection;
using System.Web;

namespace ERP.DALFactory
{
    public class EFFactory
    {
        private static string nameSpace = "ERP.DAL";

        public static IAdminDAL CreateAdmin()
        {
            return (IAdminDAL)CreateObject(nameSpace, $"{nameSpace}.AdminDAL");
        }

        #region CreateObject
        /// <summary>
        /// 不使用缓存创建
        /// </summary>
        /// <param name="AssemblyPath"></param>
        /// <param name="classNamespace"></param>
        /// <returns></returns>
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch(System.Exception ex)
            {
                string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        /// <summary>
        /// 使用缓存创建
        /// </summary>
        /// <param name="AssemblyPath"></param>
        /// <param name="classNamespace"></param>
        /// <returns></returns>
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch(System.Exception ex)
                {
                    string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion
    }

    #region 缓存操作类
    /// <summary>
    /// 缓存操作类
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
    }
    #endregion
}
