//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Question")]
//    public partial class Question
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Question()
//        {
//            PersonMessagesArea = new HashSet<PersonMessagesArea>();
//            PersonQuestionAnswerMap = new HashSet<PersonQuestionAnswerMap>();
//        }

//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int? QuestionTypeId { get; set; }

//        public Guid? PersonId { get; set; }

//        public Guid? CompanyId { get; set; }

//        public virtual Company Company { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonMessagesArea> PersonMessagesArea { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonQuestionAnswerMap> PersonQuestionAnswerMap { get; set; }

//        public virtual QuestionType QuestionType { get; set; }
//    }
//}
