//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class OnlineClients
//    {
//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string Platform { get; set; }

//        public string DeviceToken { get; set; }

//        public Guid? PersonId { get; set; }

//        [StringLength(50)]
//        public string Lang { get; set; }

//        public string IdentityId { get; set; }

//        public Guid? CompanyId { get; set; }

//        public DateTime LoginDate { get; set; }

//        public virtual Company Company { get; set; }
//    }
//}
