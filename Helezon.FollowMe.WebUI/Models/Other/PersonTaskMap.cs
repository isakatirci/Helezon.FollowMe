//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonTaskMap")]
//    public partial class PersonTaskMap
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonTaskMap()
//        {
//            Person = new HashSet<Person>();
//            PersonMessagesArea = new HashSet<PersonMessagesArea>();
//        }

//        public Guid Id { get; set; }

//        public Guid? PersonTaskId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [StringLength(50)]
//        public string Name { get; set; }

//        [StringLength(200)]
//        public string Description { get; set; }

//        public Guid? CompanyId { get; set; }

//        public virtual Company Company { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Person> Person { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonMessagesArea> PersonMessagesArea { get; set; }

//        public virtual PersonTask PersonTask { get; set; }
//    }
//}
