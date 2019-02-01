﻿using System;
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
        public ZetaCodeAksesuarDto AksesuarDto { get; internal set; }
        public ZetaCodeAksesuarEditVmCollections Collections { get; set; }
        public List<ZetaCodeAksesuarKompozisyonDto> AksesuarKompozisyonlar { get; set; }
        public AksesuarEditVm()
        {
            Collections = new ZetaCodeAksesuarEditVmCollections();
            AksesuarDto = new ZetaCodeAksesuarDto();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyonDto>();
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