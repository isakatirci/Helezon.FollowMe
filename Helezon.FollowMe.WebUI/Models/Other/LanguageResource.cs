//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("LanguageResource")]
//    public partial class LanguageResource
//    {
//        public Guid Id { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [Required]
//        [StringLength(500)]
//        public string ResourceName { get; set; }

//        [StringLength(500)]
//        public string ResourceValue { get; set; }

//        public int? LanguageId { get; set; }

//        public virtual Language Language { get; set; }
//    }
//}
