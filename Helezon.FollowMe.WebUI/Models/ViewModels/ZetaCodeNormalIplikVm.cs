using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public delegate List<SelectListItem> IplikNoGuideMethod(string value);
    public delegate List<SelectListItem> ElyafOraniMethod(int? value);
    public class ZetaCodeNormalIplikVm
    {
        public string Operation { get; set; }
        public ZetaCodeNormalIplikDto ZetaCodeNormalIplikDto { get; set; }
        public ZetaCodeNormalIplikViewCollections Collections { get; set; }
        public ZetaCodeNormalIplikVm()
        {
            Collections = new ZetaCodeNormalIplikViewCollections();       
            Operation = string.Empty;
            ZetaCodeNormalIplikDto = new ZetaCodeNormalIplikDto();
            ZetaCodeNormalIplikDto.IplikNo = new List<IplikNoDto>();
            ZetaCodeNormalIplikDto.IplikNo.Add(new IplikNoDto());
        }
        
        public IplikNoGuideMethod NE { get; set; }
        public IplikNoGuideMethod NM { get; set; }
        public IplikNoGuideMethod DYN { get; set; }
        public IplikNoGuideMethod FL { get; set; }
        public IplikNoGuideMethod EA { get; set; }
        public ElyafOraniMethod ElyafOrani { get; set; }
    }

    public class ZetaCodeNormalIplikViewCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; internal set; }
        public SelectList PantoneRenkleri { get; internal set; }
        public SelectList UretimTeknolojileri { get; internal set; }
        
        public SelectList Renkler { get; internal set; }
        public SelectList IplikKategorileri { get; internal set; }
    }
}