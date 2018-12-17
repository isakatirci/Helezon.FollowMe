//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonTravel")]
//    public partial class PersonTravel
//    {
//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string StartTime { get; set; }

//        [StringLength(50)]
//        public string FinishTime { get; set; }

//        [StringLength(50)]
//        public string Country { get; set; }

//        [StringLength(50)]
//        public string City { get; set; }

//        public Guid? PersonId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
