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
    public class DictBLL : IDictBLL<DictModel>
    {
        private IDictDAL<DictModel> dictDAL;

        public DictBLL(IDictDAL<DictModel> _dictDAL)
        {
            this.dictDAL = _dictDAL;
        }

        public int Add(DictModel Model)
        {
            throw new NotImplementedException();
        }

        public TResult Delete<TResult>(int id) where TResult : ResultInfo, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<DictModel> GetAll()
        {
            return dictDAL.GetAll();
        }

        public DictModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(DictModel Model)
        {
            throw new NotImplementedException();
        }
    }
}
