using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class AksesuarEditVm
    {
        public ZetaCodeAksesuarDto Aksesuar { get; internal set; }
        public ZetaCodeAksesuarEditVmCollections Collections { get; set; }
        public List<ZetaCodeAksesuarKompozisyonDto> AksesuarKompozisyonlar { get; set; }
        public CompanyDto Company { get; set; }
        public AksesuarEditVm()
        {
            Collections = new ZetaCodeAksesuarEditVmCollections();
            Aksesuar = new ZetaCodeAksesuarDto();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyonDto>();
            Company = new CompanyDto();
        }
    }
    public class ZetaCodeAksesuarEditVmCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> Renkler { get; set; }
        public List<TermDto> UrunKompozisyonlar { get; set; }
        
        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeAksesuarEditVmCollections()
        {
        
        }
    }
}