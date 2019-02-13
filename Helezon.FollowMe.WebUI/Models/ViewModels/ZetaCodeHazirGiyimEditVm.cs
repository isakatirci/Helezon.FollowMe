using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class HazirGiyimEditVm
    {
        public ZetaCodeHazirGiyimDto HazirGiyim { get; set; }
        public HazirGiyimEditVmCollections Collections { get; set; }
        public List<ZetaCodeDto> Kumaslar { get; set; }
        public List<ZetaCodeDto> Aksesuarlar { get; set; }
        public List<BedenOlculeriDto> BedenOlculeri { get; set; }
        public CompanyDto Company { get; set; }
        public ZetaCodeYikamaTalimatiDto YikamaTalimati { get; set; }


        public HazirGiyimEditVm()
        {
            Collections = new HazirGiyimEditVmCollections();
            HazirGiyim = new ZetaCodeHazirGiyimDto();
            Kumaslar = new List<ZetaCodeDto>();
            Aksesuarlar = new List<ZetaCodeDto>();
            Company = new CompanyDto();
            YikamaTalimati = new ZetaCodeYikamaTalimatiDto();
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

        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public HazirGiyimEditVmCollections()
        {
            Kumaslar = new List<ZetaCodeDto>();
            Aksesuarlar = new List<ZetaCodeDto>();
        }
    }
}