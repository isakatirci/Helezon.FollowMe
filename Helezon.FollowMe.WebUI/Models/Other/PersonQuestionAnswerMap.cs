//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonQuestionAnswerMap")]
//    public partial class PersonQuestionAnswerMap
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonQuestionAnswerMap()
//        {
//            PersonMessagesArea = new HashSet<PersonMessagesArea>();
//        }

//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        public bool IsDeleted { get; set; }

//        public bool IsActive { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public Guid? PersonId { get; set; }

//        public Guid? CompanyId { get; set; }

//        public Guid? QuestionId { get; set; }

//        public virtual Company Company { get; set; }

//        public virtual Person Person { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonMessagesArea> PersonMessagesArea { get; set; }

//        public virtual Question Question { get; set; }
//    }
//}
