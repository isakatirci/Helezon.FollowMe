using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeVm
    {
        public string Id { get; set; }
        public string ZetaCode { get; set; }
    }
    public class HazirGiyimEditVm
    {
        public ZetaCodeHazirGiyimDto HazirGiyimDto { get; internal set; }
        public HazirGiyimEditVmCollections Collections { get; set; }
        public List<ZetaCodeVm> Kumaslar { get; set; }
        public List<ZetaCodeVm> Aksesuarlar { get; set; }

        public HazirGiyimEditVm()
        {
            Collections = new HazirGiyimEditVmCollections();
            HazirGiyimDto = new ZetaCodeHazirGiyimDto();
            Kumaslar = new List<ZetaCodeVm>();
            Aksesuarlar = new List<ZetaCodeVm>();
        }
    }
    public class HazirGiyimEditVmCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> BaskiGoruntuler { get; set; }
        public List<SelectListItem> YikamaSekilleri { get; set; }
        public List<SelectListItem> BedenKalipIsimleri { get; set; }
        public List<ZetaCodeVm> Kumaslar { get; set; }
        public List<ZetaCodeVm> Aksesuarlar { get; set; }

        public List<SelectListItem> Renkler { get; set; }

        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public HazirGiyimEditVmCollections()
        {
            Kumaslar = new List<ZetaCodeVm>();
            Aksesuarlar = new List<ZetaCodeVm>();
        }
    }
}