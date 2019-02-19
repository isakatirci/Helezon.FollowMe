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
    public class AksesuarEditVm
    {
        public ZetaCodeAksesuar Aksesuar { get;  set; }
        public ZetaCodeAksesuarEditVmCollections Collections { get; set; }
        public List<ZetaCodeAksesuarKompozisyon> AksesuarKompozisyonlar { get; set; }
        public PairIdNameDto Ulke { get;  set; }
        public Company Company { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public AksesuarEditVm()
        {
            Collections = new ZetaCodeAksesuarEditVmCollections();
            Ulke = new PairIdNameDto();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Aksesuar = new ZetaCodeAksesuar();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyon>();
            Company = new Company();
        }
    }
    public class ZetaCodeAksesuarEditVmCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> Renkler { get; set; }
        public List<Term> UrunKompozisyonlar { get; set; }
        
        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeAksesuarEditVmCollections()
        {
        
        }
    }
}