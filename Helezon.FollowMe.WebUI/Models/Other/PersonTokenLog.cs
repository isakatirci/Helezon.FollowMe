//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonTokenLog")]
//    public partial class PersonTokenLog
//    {
//        public Guid Id { get; set; }

//        public Guid DiscriminatorID { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int? CompanyCode { get; set; }

//        public Guid? Token { get; set; }

//        public DateTime? TokenDate { get; set; }

//        [StringLength(255)]
//        public string IpAddress { get; set; }

//        public Guid? Customer { get; set; }

//        public Guid? ServiceUser { get; set; }

//        public virtual Discriminator Discriminator { get; set; }
//    }
//}
