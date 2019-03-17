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
    public class HazirGiyimEditVm
    {
        public ZetaCodeHazirGiyim HazirGiyim { get; set; }
        public HazirGiyimEditVmCollections Collections { get; set; }
        public List<ZetaCodeDto> Kumaslar { get; set; }
        public List<ZetaCodeDto> Aksesuarlar { get; set; }
        public List<BedenOlculeri> BedenOlculeri { get; set; }
        public Company Company { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }

        public PairIdNameDto Ulke { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public Term UrunKategori { get; set; }
        

        public HazirGiyimEditVm()
        {
            Ulke = new PairIdNameDto();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            UrunKategori = new Term();
            Collections = new HazirGiyimEditVmCollections();
            HazirGiyim = new ZetaCodeHazirGiyim();
            Kumaslar = new List<ZetaCodeDto>();
            Aksesuarlar = new List<ZetaCodeDto>();
            Company = new Company();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
        }
    }
    public class HazirGiyimEditVmCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> BaskiGoruntuler { get; set; }
        public HashSet<PairIdNameDto> YikamaSekilleri { get; set; }
        public List<SelectListItem> BedenKalipIsimleri { get; set; }
        public List<ZetaCodeDto> Kumaslar { get; set; }
        public List<ZetaCodeDto> Aksesuarlar { get; set; }
        public List<SelectListItem> Renkler { get; set; }

        public HazirGiyimEditVmCollections()
        {
            Kumaslar = new List<ZetaCodeDto>();
            Aksesuarlar = new List<ZetaCodeDto>();
        }
    }
}