﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class erp__Entities : DbContext
    {
        public erp__Entities()
            : base("name=erp__Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dict> Dict { get; set; }
        public virtual DbSet<DictType> DictType { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<PresencenOrder_Product> PresencenOrder_Product { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_ProductProperty> Product_ProductProperty { get; set; }
        public virtual DbSet<ProductClass> ProductClass { get; set; }
        public virtual DbSet<ProductClass_Supplier> ProductClass_Supplier { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<ProductPresencenOrder> ProductPresencenOrder { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<StorageRegion> StorageRegion { get; set; }
        public virtual DbSet<StorageType> StorageType { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_User> Role_User { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
    }
}