//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("PersonQuestion")]
//    public partial class PersonQuestion
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public PersonQuestion()
//        {
//            PersonAnswer = new HashSet<PersonAnswer>();
//        }

//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string TitleCode { get; set; }

//        [StringLength(50)]
//        public string Title { get; set; }

//        public bool IsDeleted { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<PersonAnswer> PersonAnswer { get; set; }
//    }
//}
