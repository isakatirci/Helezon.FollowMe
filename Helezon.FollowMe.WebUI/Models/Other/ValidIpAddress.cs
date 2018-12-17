//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("ValidIpAddress")]
//    public partial class ValidIpAddress
//    {
//        public Guid Id { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        [StringLength(255)]
//        public string IpAddress { get; set; }

//        public Guid? CompanyId { get; set; }

//        public virtual Company Company { get; set; }
//    }
//}
