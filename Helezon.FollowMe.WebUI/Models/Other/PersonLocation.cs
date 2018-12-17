//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonLocation")]
//    public partial class PersonLocation
//    {
//        public Guid Id { get; set; }

//        public Guid? CompanyId { get; set; }

//        public bool IsDeleted { get; set; }

//        [StringLength(255)]
//        public string Name { get; set; }

//        [StringLength(1024)]
//        public string Desription { get; set; }

//        public Guid? PersonId { get; set; }

//        public Guid? CityId { get; set; }

//        public virtual Company Company { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
