//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonMessagesArea")]
//    public partial class PersonMessagesArea
//    {
//        public Guid Id { get; set; }

//        public Guid? PersonId { get; set; }

//        public int? EmergencyCategoryId { get; set; }

//        public Guid? MessageTypeId { get; set; }

//        public Guid? PersonQuestionAnswerMapId { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public Guid? QuestionId { get; set; }

//        public Guid? PersonTaskMapId { get; set; }

//        public bool? IsAnswered { get; set; }

//        public string Location { get; set; }

//        public string MessageBody { get; set; }

//        public bool IsPersonalMessage { get; set; }

//        [StringLength(150)]
//        public string Title { get; set; }

//        public virtual EmergencyCategory EmergencyCategory { get; set; }

//        public virtual MessageType MessageType { get; set; }

//        public virtual Person Person { get; set; }

//        public virtual PersonQuestionAnswerMap PersonQuestionAnswerMap { get; set; }

//        public virtual PersonTaskMap PersonTaskMap { get; set; }

//        public virtual Question Question { get; set; }
//    }
//}
