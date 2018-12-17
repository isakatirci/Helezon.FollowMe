//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("NotificationMessage")]
//    public partial class NotificationMessage
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public NotificationMessage()
//        {
//            Notifications = new HashSet<Notifications>();
//        }

//        public Guid Id { get; set; }

//        [StringLength(50)]
//        public string Message { get; set; }

//        public bool? IsDeleted { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Notifications> Notifications { get; set; }
//    }
//}
