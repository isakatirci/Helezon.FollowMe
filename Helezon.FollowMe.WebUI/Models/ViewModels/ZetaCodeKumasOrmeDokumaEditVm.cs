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
        public ZetaCodeKumasOrmeDokumaDto KumasOrmeDokuma { get; set; }
        public ZetaCodeKumasOrmeDokumaCollections Collections { get; set; }
        public List<ZetaCodeFanteziIplikDto> ZetaCodeFanteziIplikDtos { get; set; }
        public List<ZetaCodeNormalIplikDto> ZetaCodeNormalIplikDtos { get; set; }
        public CompanyDto Company { get; set; }
        public ZetaCodeKumasMakineDto KumasMakine { get; set; }
        public ZetaCodeYikamaTalimatiDto YikamaTalimati { get; set; }

        public List<ZetaCodeDto> Iplikler { get; set; }
        public ZetaCodeKumasOrmeDokumaEditVm()
        {
            KumasOrmeDokuma = new ZetaCodeKumasOrmeDokumaDto();
            ZetaCodeFanteziIplikDtos = new List<ZetaCodeFanteziIplikDto>();
            ZetaCodeNormalIplikDtos = new List<ZetaCodeNormalIplikDto>();
            Collections = new ZetaCodeKumasOrmeDokumaCollections();
            Iplikler = new List<ZetaCodeDto>();
            Company = new CompanyDto();
            KumasMakine = new ZetaCodeKumasMakineDto();
            YikamaTalimati = new ZetaCodeYikamaTalimatiDto();

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