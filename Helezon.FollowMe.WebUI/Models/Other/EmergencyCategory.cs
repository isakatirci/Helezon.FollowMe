//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("EmergencyCategory")]
//    public partial class EmergencyCategory
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public EmergencyCategory()
//        {
//            PersonMessagesArea = new HashSet<PersonMessagesArea>();
//        }

//        public int Id { get; set; }

//        [StringLength(50)]
//        public string Name { get; set; }

//        [StringLength(50)]
//        public string Description { get; set; }

//        public bool IsDeleted { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public bool IsActive { get; set; }

//        public int? LanguageId { get; set; }

//        public Guid? CompanyId { get; set; }

//        public virtual Company Company { get; set; }

//        public virtual Language Language { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonMessagesArea> PersonMessagesArea { get; set; }
//    }
//}
