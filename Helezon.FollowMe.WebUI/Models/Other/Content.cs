//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Content")]
//    public partial class Content
//    {
//        public Guid Id { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public Guid? ContentTypeId { get; set; }

//        public Guid? PersonId { get; set; }

//        public string Description { get; set; }

//        public virtual ContentType ContentType { get; set; }

//        public virtual Person Person { get; set; }
//    }
//}
