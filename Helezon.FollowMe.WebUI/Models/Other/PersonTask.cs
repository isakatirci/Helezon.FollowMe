//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;
//    using System.Web.Mvc;

//    [Bind(Include = "Id,CompanyId,IsDeleted,IsActive,CreatedAt,Name,Description,LanguageId")]
//    [Table("PersonTask")]
//    public partial class PersonTask
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonTask()
//        {
//            Person = new HashSet<Person>();
//            PersonTaskMap = new HashSet<PersonTaskMap>();
//        }

//        public Guid? Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [StringLength(255)]
//        public string Name { get; set; }

//        [StringLength(1024)]
//        public string Description { get; set; }

//        public int? LanguageId { get; set; }

//        public virtual Company Company { get; set; }

//        public virtual Language Language { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Person> Person { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonTaskMap> PersonTaskMap { get; set; }
//    }
//}
