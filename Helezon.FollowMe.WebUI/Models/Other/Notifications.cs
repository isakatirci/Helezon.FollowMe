//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class Notifications
//    {
//        public Guid Id { get; set; }

//        public Guid? NotificationMessageId { get; set; }

//        public Guid? PersonId { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        [StringLength(150)]
//        public string Description { get; set; }

//        public bool IsDeleted { get; set; }

//        public DateTime? SendDate { get; set; }

//        public virtual NotificationMessage NotificationMessage { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
