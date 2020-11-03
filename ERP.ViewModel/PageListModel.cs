using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewModel
{
    public class PageListModel<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 分页数据
        /// </summary>
        public List<T> PageList { get; set; }
    }
}
