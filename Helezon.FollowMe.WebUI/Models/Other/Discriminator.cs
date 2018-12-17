//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;
//    using System.Web.Mvc;

//    [Bind(Include = "Id,CompanyId,IsDeleted,IsActive,CreatedAt,Name,Desription")]
//    [Table("Discriminator")]
//    public partial class Discriminator
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Discriminator()
//        {
//            Person = new HashSet<Person>();
//            PersonTokenLog = new HashSet<PersonTokenLog>();
//        }

//        public Guid? Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [Required]
//        [StringLength(255)]
//        public string Name { get; set; }

//        [StringLength(1024)]
//        public string Desription { get; set; }

//        public virtual Company Company { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Person> Person { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonTokenLog> PersonTokenLog { get; set; }
//    }
//}
