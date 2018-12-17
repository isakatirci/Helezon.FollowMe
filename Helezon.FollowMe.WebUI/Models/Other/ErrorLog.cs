//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("ErrorLog")]
//    public partial class ErrorLog
//    {
//        [Key]
//        [Column(Order = 0)]
//        public Guid Id { get; set; }

//        public string Message { get; set; }

//        public string InnerException { get; set; }

//        [Key]
//        [Column(Order = 1)]
//        public DateTime CreatedAt { get; set; }

//        public Guid? PersonId { get; set; }
//    }
//}
