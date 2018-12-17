//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//namespace FollowMe.Web.Models
//{
//    public sealed class NullTerm
//    {
//        public int Id { get { return 0; } }
//        public int TaxonomyId { get { return 0; } }
//        public string Name { get { return string.Empty; } }
//        public string CompanyId { get { return Guid.Empty.ToString(); } }
//        public string Color { get { return string.Empty; } }
//        public bool NoChildrenClass { get { return false; } }
//        public bool NoDragClass { get { return false; } }
//        public bool? IsPassive { get { return false; } }
//        public System.DateTime? CreatedOn { get { return DateTime.MinValue; } }
//        public string CreatedBy { get { return Guid.Empty.ToString(); } }
//        public System.DateTime? ChangedOn { get { return DateTime.MinValue; } }
//        public string ChangedBy { get { return Guid.Empty.ToString(); } }

//        private static readonly Lazy<NullTerm> lazy = new Lazy<NullTerm>(() => new NullTerm());

//        public static NullTerm Instance { get { return lazy.Value; } }

//        private NullTerm()
//        {
//        }
//    }
//}