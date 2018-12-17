using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models.ViewModels
{
    public class TermViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string NoDragClass { get; set; }
        public string NoChildrenClass { get; set; }
    }
}