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
        public ZetaCodeKumasMakine KumasMakine { get; set; }
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
            KumasMakine = new ZetaCodeKumasMakine();
        }
    }

    public class ZetaCodeKumasMakineEditVmCollections
    {
        public HashSet<MyNameValueDto> TupAcikEnler { get; set; }
        public HashSet<MyNameValueDto> Elastanlar { get; set; }
        public ZetaCodeKumasMakineEditVmCollections()
        {
            TupAcikEnler = new HashSet<MyNameValueDto>();
            Elastanlar = new HashSet<MyNameValueDto>();
        }
    }
}