using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class KumasFanteziEditVm
    {
        public ZetaCodeKumasFantazi KumasFantazi { get; set; }
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }
        public List<ZetaCodeDto> Kumaslar { get; set; }
        public KumasFanteziEditVmCollections Collections { get; set; }
        public Company Company { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public List<Term> OrguDetaylari { get;  set; }
        public List<Term> BoyaIslemleri { get;  set; }        
        public List<ZetaCodeKumasFantezi3AdimIslemleri> KumasFantezi3AdimIslemleri { get; set; }        
        public ZetaCodeKumasMakine Makine { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }
        public ZetaCodeYikamaTalimati ZetaCodeYikamaTalimati { get; set; }
        public List<Term> AdimIslemleri { get; internal set; }
        public List<ZetaCodeDto> KumasOrmeDokumalar { get;  set; }
        public List<ZetaCodeDto> KumasFanteziler { get;  set; }
        public Term RafyeriYunanistan { get; set; }
        public Term RafyeriTurkiye { get; set; }

        public KumasFanteziEditVm()
        {
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            BoyaIslemleri = new List<Term>();
            OrguDetaylari = new List<Term>();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
            Makine = new ZetaCodeKumasMakine();
            KumasFantazi = new ZetaCodeKumasFantazi();
            Collections = new KumasFanteziEditVmCollections();
            Kumaslar = new List<ZetaCodeDto>();
            KumasFantezi3AdimIslemleri = new List<ZetaCodeKumasFantezi3AdimIslemleri>();
            ZetaCodeYikamaTalimati = new ZetaCodeYikamaTalimati();
            //ZetaCodeKumasMakine = new ZetaCodeKumasMakine();
            KumasFanteziler = new List<ZetaCodeDto>();
            KumasOrmeDokumalar = new List<ZetaCodeDto>();
            AdimIslemleri = new List<Term>();
            Ulke = new PairIdNameDto();
        }
    }
    public class KumasFanteziEditVmCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> ModelYillari { get; set; }
        public List<SelectListItem> NormalIplikler { get; set; }
        public HashSet<PairIdNameDto> TupAcikEnler { get; set; }
        public HashSet<PairIdNameDto> Elastanlar { get; set; }
        public SelectList UrunKategorileri { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> Renkler { get; set; }
        public List<SelectListItem> OrguTipleri { get; set; }
        public List<SelectListItem> OrguCesidleri { get; set; }
        public List<SelectListItem> OrguKabiliyetleri { get; set; }
        public List<SelectListItem> OrguDigerleri { get; set; }
        public List<Term> AdimIslemleri { get; set; }
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }
        public HashSet<PairIdNameDto> YikamaSekilleri { get; set; }
        public IEnumerable<SelectListItem> KumasGoruntuleri { get; set; }
        public List<ZetaCodeDto> Kumaslar { get; set; }
        public KumasFanteziEditVmCollections()
        {
            OrguTipleri = new List<SelectListItem>();
            FanteziKumaslar = new List<SelectListItem>();
            OrmeDokumaKumaslar = new List<SelectListItem>();
            OrguCesidleri = new List<SelectListItem>();
            OrguKabiliyetleri = new List<SelectListItem>();
            OrguDigerleri = new List<SelectListItem>();
            Kumaslar = new List<ZetaCodeDto>();
        }
    }
}