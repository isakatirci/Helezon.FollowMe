using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeKumasFantaziCardVm
    {
        public ZetaCodeKumasFantaziDto ZetaCodeKumasFantaziDto { get; set; }
        public string PictureUrl { get; set; }
        public string PictureEditUrl { get; set; }
        public List<TermDto> ParentUrunKategoriler { get; set; }
        public ZetaCodeKumasFantaziCardVm()
        {
            ZetaCodeKumasFantaziDto = new ZetaCodeKumasFantaziDto();
            ParentUrunKategoriler = new List<TermDto>();
            ParentUrunKategoriler.Add(new TermDto());
        }
    }

}