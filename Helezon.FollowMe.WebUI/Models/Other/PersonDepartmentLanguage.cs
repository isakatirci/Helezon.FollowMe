//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonDepartmentLanguage")]
//    public partial class PersonDepartmentLanguage
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonDepartmentLanguage()
//        {
//            Person = new HashSet<Person>();
//        }

//        public Guid Id { get; set; }

//        public int? LanguageId { get; set; }

//        [StringLength(255)]
//        public string Name { get; set; }

//        [StringLength(1024)]
//        public string Desription { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        public Guid? CompanyId { get; set; }

//        public Guid? ParentId { get; set; }

//        public virtual Language Language { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Person> Person { get; set; }
//    }
//}
