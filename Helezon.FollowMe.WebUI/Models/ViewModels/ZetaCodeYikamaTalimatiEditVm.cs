using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{

    public class ZetaCodeYikamaTalimatiEditVm
    {
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }
        public ZetaCodeYikamaTalimatiEditVmCollections Collections { get; set; }
        public ZetaCodeYikamaTalimatiEditVm()
        {
            Collections = new ZetaCodeYikamaTalimatiEditVmCollections();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
        }
    }

    public class ZetaCodeYikamaTalimatiEditVmCollections
    {
        public HashSet<MyNameValueDto> YikamaSekilleri { get; set; }
        public ZetaCodeYikamaTalimatiEditVmCollections()
        {
            YikamaSekilleri = new HashSet<MyNameValueDto>();
        }
        //public HashSet<PairIdNameDto> TupAcikEnler { get; set; }
        //public HashSet<PairIdNameDto> Elastanlar { get; set; }
        //public ZetaCodeKumasMakineEditVmCollections()
        //{
        //    TupAcikEnler = new HashSet<PairIdNameDto>();
        //    Elastanlar = new HashSet<PairIdNameDto>();
        //}
    }
}