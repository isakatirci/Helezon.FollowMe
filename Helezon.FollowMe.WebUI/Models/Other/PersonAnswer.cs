//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonAnswer")]
//    public partial class PersonAnswer
//    {
//        public Guid Id { get; set; }

//        public Guid? PersonQuestionId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int? PersonAnswerMapId { get; set; }

//        public Guid? PersonId { get; set; }

//        public virtual PersonAnswerMap PersonAnswerMap { get; set; }

//        public virtual PersonQuestion PersonQuestion { get; set; }
//    }
//}
