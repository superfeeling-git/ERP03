//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductProperty = new HashSet<ProductProperty>();
            this.ShoppingProduct = new HashSet<ShoppingProduct>();
        }
    
        public int ProductId { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public Nullable<decimal> BuyPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public string Unit { get; set; }
        public string Spec { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
    
        public virtual ProductClass ProductClass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductProperty> ProductProperty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingProduct> ShoppingProduct { get; set; }
    }
}
