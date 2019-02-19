using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeKumasMakineEditVm
    {
        public ZetaCodeKumasMakine Makine { get; set; }
        public Term MakineMarkasi { get; set; }
        public Term MakineModeli { get; set; }
        public List<Term> Aksesuarlar { get; set; }
        //
        public ZetaCodeKumasMakineEditVmCollections Collections { get; set; }
        public ZetaCodeKumasMakineEditVm()
        {
            Collections = new ZetaCodeKumasMakineEditVmCollections();
            MakineMarkasi = new Term();
            MakineModeli = new Term();
            Aksesuarlar = new List<Term>();
            Makine = new ZetaCodeKumasMakine();
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