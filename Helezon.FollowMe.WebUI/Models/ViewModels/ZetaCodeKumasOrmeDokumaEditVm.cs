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
        public ZetaCodeKumasOrmeDokumaDto KumasOrmeDokumaDto { get; set; }
        public ZetaCodeKumasMakineDto KumasMakineDto { get; set; }
        public ZetaCodeKumasOrmeDokumaCollections Collections { get; set; }
        public ZetaCodeKumasOrmeDokumaEditVm()
        {
            KumasOrmeDokumaDto = new ZetaCodeKumasOrmeDokumaDto();
            Collections = new ZetaCodeKumasOrmeDokumaCollections();
        }
    }
    public class ZetaCodeKumasOrmeDokumaCollections
    {
        public SelectList Sirketler { get; set; }
        public List<SelectListItem> Ulkeler { get; set; }
        public List<SelectListItem> ModelYillari { get; set; }
        
        public SelectList UrunKategorileri { get; set; }
        public List<SelectListItem> Puslar { get; internal set; }
        public List<SelectListItem> Finelar { get; internal set; }
        public List<SelectListItem> YedekFinelar { get; internal set; }
        public List<SelectListItem> Sistemler { get; internal set; }
        public List<SelectListItem> IgneSayisi { get; internal set; }

        //public List<SelectListItem> NormalIplikler { get; set; }


        //public SelectList BoyaYonu { get; internal set; }
        //public SelectList BoyaTipi { get; internal set; }

        public ZetaCodeKumasOrmeDokumaCollections()
        {

        }
    }
}