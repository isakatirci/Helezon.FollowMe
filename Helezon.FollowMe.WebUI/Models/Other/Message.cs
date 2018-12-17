//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Message")]
//    public partial class Message
//    {
//        public Guid Id { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        public DateTime? SendDate { get; set; }

//        public string MessageBody { get; set; }

//        public string PhotoPath { get; set; }

//        public string Location { get; set; }

//        [StringLength(255)]
//        public string Title { get; set; }

//        [StringLength(255)]
//        public string Description { get; set; }

//        public Guid? PersonId { get; set; }

//        public bool? SendMyself { get; set; }

//        public bool? IsFireExtinguishUsed { get; set; }

//        public bool? IsCallEmergencyTeam { get; set; }

//        [StringLength(50)]
//        public string Answer { get; set; }

//        public bool IsJobSecurityMessage { get; set; }

//        public bool IsRead { get; set; }

//        [StringLength(50)]
//        public string CategoryName { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
