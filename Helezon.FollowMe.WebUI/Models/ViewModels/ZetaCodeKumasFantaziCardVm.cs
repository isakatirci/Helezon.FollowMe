using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeKumasFantaziCardVm
    {
        public string PictureEditUrl { get; set; }
        public KumasFantaziContainerDto Container { get; set; }
        public ZetaCodeKumasFantaziCardVm()
        {
            Container = new KumasFantaziContainerDto();
        }
    }

}