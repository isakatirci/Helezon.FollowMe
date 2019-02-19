using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeKumasOrmeDokumaCardVm
    {
        public KumasOrmeDokumaContainerDto Container { get; set; }  
        public string PictureEditUrl { get; set; }
        public ZetaCodeKumasOrmeDokumaCardVm()
        {
            Container = new KumasOrmeDokumaContainerDto();
        }
    }
}