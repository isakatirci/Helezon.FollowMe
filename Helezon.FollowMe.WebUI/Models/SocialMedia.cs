using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public Guid CompnayId { get; set; }
        public Guid? PersonId { get; set; }
        public int Name{ get; set; }
        public string Url { get; set; }
    }

}