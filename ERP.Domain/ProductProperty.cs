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
    
    public partial class ProductProperty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductProperty()
        {
            this.Product_ProductProperty = new HashSet<Product_ProductProperty>();
        }
    
        public int ProductPropertyID { get; set; }
        public string ProductPropertyCode { get; set; }
        public string ProductPropertyName { get; set; }
        public string ProductPropertyIntro { get; set; }
        public Nullable<int> ProductPropertyOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_ProductProperty> Product_ProductProperty { get; set; }
    }
}
