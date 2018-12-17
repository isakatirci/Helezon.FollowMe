//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonDepartment")]
//    public partial class PersonDepartment
//    {
//        public Guid Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        [StringLength(150)]
//        public string Name { get; set; }

//        public virtual Company Company { get; set; }
//    }
//}
