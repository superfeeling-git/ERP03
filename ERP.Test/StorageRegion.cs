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
    
    public partial class StorageRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StorageRegion()
        {
            this.StorageLocation = new HashSet<StorageLocation>();
        }
    
        public int RegionID { get; set; }
        public Nullable<int> StorageId { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<int> AdminId { get; set; }
    
        public virtual Storage Storage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StorageLocation> StorageLocation { get; set; }
    }
}
