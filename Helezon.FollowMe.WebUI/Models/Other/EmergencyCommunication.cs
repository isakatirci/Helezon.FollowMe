//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("EmergencyCommunication")]
//    public partial class EmergencyCommunication
//    {
//        public Guid Id { get; set; }

//        public Guid? PersonId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [StringLength(8)]
//        public string PhonePrefix { get; set; }

//        [StringLength(32)]
//        public string Phone { get; set; }

//        [StringLength(64)]
//        public string Name { get; set; }

//        [StringLength(64)]
//        public string Affinity { get; set; }

//        [StringLength(512)]
//        public string Note { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
