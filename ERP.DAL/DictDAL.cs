using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.IDAL;
using ERP.Utility;
using ERP.ViewModel;
using EntityFramework.Extensions;


namespace ERP.DAL
{
    public class DictDAL : IDictDAL<DictModel>
    {
        erp__Entities db = new erp__Entities();

        public int Add(DictModel t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的字典数据
        /// </summary>
        /// <returns></returns>
        public List<DictModel> GetAll()
        {
            return db.Dict.ToList().MapToList<Dict, DictModel>();
        }

        public DictModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(DictModel t)
        {
            throw new NotImplementedException();
        }
    }
}
