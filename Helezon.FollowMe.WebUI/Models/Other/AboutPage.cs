//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("AboutPage")]
//    public partial class AboutPage
//    {
//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        public string Body { get; set; }

//        public Guid? CompanyId { get; set; }

//        public int? LanguageId { get; set; }

//        public bool? IsDeleted { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        public virtual Company Company { get; set; }

//        public virtual Language Language { get; set; }
//    }
//}
