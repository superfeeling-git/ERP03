using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewModel
{
    public class SupplierModel
    {
        public int SupplierID { get; set; }
        public string SupplierLevel { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Contact { get; set; }
        public string TEL { get; set; }
        public string Phone { get; set; }
        public string SupplierState { get; set; }
        public string PayType { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string Contract { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public int[] ClassID { get; set; }
        //public virtual ICollection<ProductClass_SupplierModel> ProductClass_Supplier { get; set; }
    }
}
