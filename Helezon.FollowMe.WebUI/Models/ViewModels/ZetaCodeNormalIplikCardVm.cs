using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeNormalIplikCardVm
    {
        public ZetaCodeNormalIplikDto ZetaCodeNormalIplikDto { get; set; }
        public List<TermDto> ParentIplikCategories { get; internal set; }
        public List<Tuple<string, string>> IplikKategoriDetay { get; internal set; }

        public ZetaCodeNormalIplikCardVm()
        {
            IplikKategoriDetay = new List<Tuple<string, string>>();
        }
    }
}