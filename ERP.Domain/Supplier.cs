//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.ProductClass_Supplier = new HashSet<ProductClass_Supplier>();
            this.ProductOrder = new HashSet<ProductOrder>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductClass_Supplier> ProductClass_Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
