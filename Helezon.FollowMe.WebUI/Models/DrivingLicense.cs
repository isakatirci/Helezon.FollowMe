using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    //https://www.tugem.com.tr/ehliyet-siniflari-ve-kapsamlari
    public class DrivingLicense
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Warrant { get; set; }
        public int Age { get; set; }
        public string Scope { get; set; }
        public int Duration { get; set; }
    }
}