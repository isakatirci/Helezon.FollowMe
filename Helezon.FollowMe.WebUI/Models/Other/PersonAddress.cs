//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonAddress")]
//    public partial class PersonAddress
//    {
//        public Guid Id { get; set; }

//        public Guid? PersonId { get; set; }

//        public Guid? AddressTypeId { get; set; }

//        [StringLength(10)]
//        public string ZipCode { get; set; }

//        [StringLength(120)]
//        public string AddressLine1 { get; set; }

//        [StringLength(120)]
//        public string AddressLine2 { get; set; }

//        public DateTime? CreatedAt { get; set; }

//        public bool IsActive { get; set; }

//        public bool IsDeleted { get; set; }
//    }
//}
