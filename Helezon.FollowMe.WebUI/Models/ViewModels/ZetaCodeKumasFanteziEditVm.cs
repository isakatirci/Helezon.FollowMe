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
        public ZetaCodeKumasFantaziDto KumasFantaziDto { get; set; }
        public ZetaCodeKumasMakineDto KumasMakineDto { get; set; }
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }        
        public KumasFanteziEditVmCollections Collections { get; set; }
        public SelectList AdimIslemleri { get; set; }

        public KumasFanteziEditVm()
        {
            KumasFantaziDto = new ZetaCodeKumasFantaziDto();

            Collections = new KumasFanteziEditVmCollections();
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
        public List<TermDto> AdimIslemleri { get; set; }
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }
        //
        public List<SelectListItem> YikamaSekilleri { get; set; }

        //
        //
        public IEnumerable<SelectListItem> KumasGoruntuleri { get; set; }


        //public List<SelectListItem> NormalIplikler { get; set; }


        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public KumasFanteziEditVmCollections()
        {
            OrguTipleri = new List<SelectListItem>();
            FanteziKumaslar = new List<SelectListItem>();
            OrmeDokumaKumaslar = new List<SelectListItem>();
            OrguCesidleri = new List<SelectListItem>();
            OrguKabiliyetleri = new List<SelectListItem>();
            OrguDigerleri = new List<SelectListItem>();
        }
    }
}