using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeNormalIplikCardVm
    {
        public NormalIplikContainerDto Container { get; set; }     
     
        public string PictureEditUrl { get; set; }      

        public ZetaCodeNormalIplikCardVm()
        {
            Container = new NormalIplikContainerDto();
        }
    }
}