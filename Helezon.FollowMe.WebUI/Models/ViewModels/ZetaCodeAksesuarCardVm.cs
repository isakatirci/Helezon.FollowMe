using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeAksesuarCardVm
    {
        public ZetaCodeAksesuar Aksesuar { get; internal set; }
        public Company Company { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public Renk Renk { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public string PictureUrl { get; set; }
        public string PictureEditUrl { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public List<ZetaCodeAksesuarKompozisyon> AksesuarKompozisyonlar { get; set; }

        public ZetaCodeAksesuarCardVm()
        {
            Aksesuar = new ZetaCodeAksesuar();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyon>();
            Company = new Company();
            Renk = new Renk();
            PantoneRenk = new PantoneRenk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Ulke = new PairIdNameDto();
        }
    }
}