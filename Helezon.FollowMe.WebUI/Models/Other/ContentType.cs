//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("ContentType")]
//    public partial class ContentType
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public ContentType()
//        {
//            Content = new HashSet<Content>();
//        }

//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string TitleCode { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int? LanguageId { get; set; }

//        public Guid? ParentId { get; set; }

//        public Guid? CompanyId { get; set; }

//        public virtual Company Company { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Content> Content { get; set; }
//    }
//}
