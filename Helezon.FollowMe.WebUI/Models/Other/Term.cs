//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;
//    using System.Web.Mvc;

//    //[Bind(Include = "Id,Name,Slug,TermGroup")]
//    [Table("Term")]
//    public partial class Term
//    {
//        [Key]
//        public int Id { get; set; }

//        public Guid CompanyId { get; set; }

//        public int TaxonomyId { get; set; }

//        [StringLength(200)]
//        public string Name { get; set; }

//        [StringLength(200)]
//        public string Slug { get; set; }

//        public int? TermGroup { get; set; }

//        public DateTime CreatedAt { get; set; }
//    }
//}
