//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Country")]
//    public partial class Country
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Country()
//        {
//            City = new HashSet<City>();
//        }

//        public int Id { get; set; }

//        [StringLength(50)]
//        public string CountryName { get; set; }

//        public bool IsDeleted { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<City> City { get; set; }
//    }
//}
