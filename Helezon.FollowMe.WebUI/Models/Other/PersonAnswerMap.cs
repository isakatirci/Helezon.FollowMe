//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonAnswerMap")]
//    public partial class PersonAnswerMap
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonAnswerMap()
//        {
//            PersonAnswer = new HashSet<PersonAnswer>();
//        }

//        public int Id { get; set; }

//        [StringLength(50)]
//        public string Answer { get; set; }

//        public bool IsDeleted { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonAnswer> PersonAnswer { get; set; }
//    }
//}
