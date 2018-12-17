//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonLoginLog")]
//    public partial class PersonLoginLog
//    {
//        public Guid Id { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int? CompanyCode { get; set; }

//        [StringLength(255)]
//        public string Username { get; set; }

//        [StringLength(255)]
//        public string Password { get; set; }

//        [StringLength(255)]
//        public string IpAddress { get; set; }

//        public DateTime? LoginDate { get; set; }

//        public Guid? CompanyId { get; set; }
//    }
//}
