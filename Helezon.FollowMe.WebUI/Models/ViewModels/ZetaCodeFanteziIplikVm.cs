using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeFanteziIplikVm
    {
        public ZetaCodeFanteziIplikDto ZetaCodeFanteziIplikDto { get; internal set; }
        public ZetaCodeFanteziIplikViewCollections Collections { get; set; }
        public ZetaCodeFanteziIplikVm()
        {
            Collections = new ZetaCodeFanteziIplikViewCollections();
            ZetaCodeFanteziIplikDto = new ZetaCodeFanteziIplikDto();
        }
    }
    public class ZetaCodeFanteziIplikViewCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public SelectList IplikKategorileri { get; set; }
        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeFanteziIplikViewCollections()
        {
        
        }
    }
}