using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.ContainerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class ZetaCodeHazirGiyimCardVm
    {
        public HazirGiyimContainerDto Container { get; set; }

        public ZetaCodeHazirGiyimCardVm()
        {
            Container = new HazirGiyimContainerDto();
        }
    }
}