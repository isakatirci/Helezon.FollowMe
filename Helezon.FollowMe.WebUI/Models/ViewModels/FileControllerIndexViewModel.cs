using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class FileControllerIndexViewModel
    {
        public string ReturnUrl { get; set; }
        public string Entitytype { get; set; }
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageBaseData { get; set; }
    }
}