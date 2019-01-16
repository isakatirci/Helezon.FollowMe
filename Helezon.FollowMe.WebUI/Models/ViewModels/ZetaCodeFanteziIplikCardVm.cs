using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeFanteziIplikCardVm
    {
        public ZetaCodeFanteziIplikDto ZetaCodeFanteziIplikDto { get; set; }
        public List<TermDto> ParentIplikCategories { get; internal set; }
        //public List<Tuple<string, string>> IplikKategoriDetay { get; internal set; }

        public string PictureEditUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Renkler { get; set; }

        public ZetaCodeFanteziIplikCardVm()
        {
            //IplikKategoriDetay = new List<Tuple<string, string>>();
        }
    }
}