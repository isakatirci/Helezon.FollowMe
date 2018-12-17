using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    public class TermTaxonomyView
    {
        public int? TermId { get; set; } 
        public int? Parent { get; set; } 
        public string Name { get; set; }
        public bool NoDragClass { get; set; }
        public bool NoChildrenClass { get; set; }
        public string Color { get; set; }
        public bool Disabled { get; set; }
    }
}