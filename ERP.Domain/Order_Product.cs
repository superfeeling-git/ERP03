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
    
    public partial class Order_Product
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> BuyCount { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductOrder ProductOrder { get; set; }
    }
}
