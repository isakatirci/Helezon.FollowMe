//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonPosition")]
//    public partial class PersonPosition
//    {
//        public Guid Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [StringLength(255)]
//        public string Name { get; set; }

//        [StringLength(1024)]
//        public string Desription { get; set; }

//        public virtual Company Company { get; set; }
//    }
//}
