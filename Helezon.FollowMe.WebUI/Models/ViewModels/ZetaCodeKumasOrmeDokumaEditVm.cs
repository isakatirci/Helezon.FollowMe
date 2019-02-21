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
    public class ZetaCodeKumasOrmeDokumaEditVm
    {
        public ZetaCodeKumasOrmeDokuma KumasOrmeDokuma { get; set; }
        public ZetaCodeKumasOrmeDokumaCollections Collections { get; set; }
        public List<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; }
        public List<ZetaCodeNormalIplik> ZetaCodeNormalIplik { get; set; }
        public Company Company { get; set; }
        public ZetaCodeKumasMakine KumasMakine { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }
        public List<Term> Aksesuarlar { get; set; }
        public List<Term> OrguDetaylari { get; set; }
        public List<Term> BoyaIslemleri { get; set; }

        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        //

        public List<ZetaCodeDto> Iplikler { get; set; }
        public ZetaCodeKumasOrmeDokumaEditVm()
        {
            KumasOrmeDokuma = new ZetaCodeKumasOrmeDokuma();
            ZetaCodeFanteziIplik = new List<ZetaCodeFanteziIplik>();
            ZetaCodeNormalIplik = new List<ZetaCodeNormalIplik>();
            Collections = new ZetaCodeKumasOrmeDokumaCollections();
            Iplikler = new List<ZetaCodeDto>();
            Company = new Company();
            KumasMakine = new ZetaCodeKumasMakine();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
            Aksesuarlar = new List<Term>();
            Ulke = new PairIdNameDto();
            OrguDetaylari = new List<Term>();
            BoyaIslemleri = new List<Term>();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();

        }
    }
    public class ZetaCodeKumasOrmeDokumaCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> ModelYillari { get; set; }

        public List<SelectListItem> NormalIplikler { get; set; }
        public List<SelectListItem> FanteziIplikler { get; set; }


        public HashSet<PairIdNameDto> TupAcikEnler { get; set; }
        public HashSet<PairIdNameDto> Elastanlar { get; set; }
        public HashSet<PairIdNameDto> YikamaSekilleri { get; set; }

        public SelectList UrunKategorileri { get; set; }

        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> Renkler { get; set; }

        public List<SelectListItem> OrguTipleri { get; set; }
        public List<SelectListItem> OrguCesidleri { get; set; }
        public List<SelectListItem> OrguKabiliyetleri { get; set; }
        public List<SelectListItem> OrguDigerleri { get; set; }
        //
        //
        public IEnumerable<SelectListItem> KumasGoruntuleri { get; set; }
        public List<ZetaCodeDto> Iplikler { get; set; }


        //public List<SelectListItem> NormalIplikler { get; set; }


        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeKumasOrmeDokumaCollections()
        {
            OrguTipleri = new List<SelectListItem>();
            OrguCesidleri = new List<SelectListItem>();
            OrguKabiliyetleri = new List<SelectListItem>();
            OrguDigerleri = new List<SelectListItem>();
            Iplikler = new List<ZetaCodeDto>();
        }
    }
}