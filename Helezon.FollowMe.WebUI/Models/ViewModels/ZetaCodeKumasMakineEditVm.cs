using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeKumasMakineEditVm
    {
        public ZetaCodeKumasMakineDto Makine { get; set; }
        public ZetaCodeKumasMakineEditVmCollections Collections { get; set; }
        public ZetaCodeKumasMakineEditVm()
        {
            Collections = new ZetaCodeKumasMakineEditVmCollections();
            Makine = new ZetaCodeKumasMakineDto();
        }
    }

    public class ZetaCodeKumasMakineEditVmCollections
    {
        public HashSet<PairIdNameDto> TupAcikEnler { get; set; }
        public HashSet<PairIdNameDto> Elastanlar { get; set; }
        public ZetaCodeKumasMakineEditVmCollections()
        {
            TupAcikEnler = new HashSet<PairIdNameDto>();
            Elastanlar = new HashSet<PairIdNameDto>();
        }
    }
}