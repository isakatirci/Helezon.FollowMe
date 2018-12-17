//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("CompanyType")]
//    public partial class CompanyType
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public CompanyType()
//        {
//            Company = new HashSet<Company>();
//        }

//        public int Id { get; set; }

//        [StringLength(50)]
//        public string Name { get; set; }

//        [StringLength(50)]
//        public string Description { get; set; }

//        public bool IsDeleted { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Company> Company { get; set; }
//    }
//}
