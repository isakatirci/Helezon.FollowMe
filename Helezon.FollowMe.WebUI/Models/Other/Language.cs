//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;
//    using System.Web.Mvc;

//    [Bind(Include = "Id,CompanyId,IsDeleted,IsActive,CreatedAt,CultureName,IsDefault,LanguageChar,Position")]
//    [Table("Language")]
//    public partial class Language
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Language()
//        {
//            //AboutPage = new HashSet<AboutPage>();
//            EmergencyCategory = new HashSet<EmergencyCategory>();
//            HowToWorkPage = new HashSet<HowToWorkPage>();
//            LanguageResource = new HashSet<LanguageResource>();
//            MessageType = new HashSet<MessageType>();
//            Person = new HashSet<Person>();
//            PersonDepartmentLanguage = new HashSet<PersonDepartmentLanguage>();
//            PersonPositionLanguage = new HashSet<PersonPositionLanguage>();
//            PersonTask = new HashSet<PersonTask>();
//            QuestionType = new HashSet<QuestionType>();
//        }

//        public int? Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [Required]
//        [StringLength(50)]
//        public string CultureName { get; set; }

//        public bool IsDefault { get; set; }

//        [Required]
//        [StringLength(50)]
//        public string LanguageChar { get; set; }

//        public int Position { get; set; }

//        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        //public virtual ICollection<AboutPage> AboutPage { get; set; }

//        public virtual Company Company { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<EmergencyCategory> EmergencyCategory { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<HowToWorkPage> HowToWorkPage { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<LanguageResource> LanguageResource { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<MessageType> MessageType { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Person> Person { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonDepartmentLanguage> PersonDepartmentLanguage { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonPositionLanguage> PersonPositionLanguage { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonTask> PersonTask { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<QuestionType> QuestionType { get; set; }
//    }
//}
