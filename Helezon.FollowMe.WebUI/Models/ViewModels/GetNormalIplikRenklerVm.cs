using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class GetNormalIplikRenklerVm
    {
        public ZetaCodeNormalIplikDto NormalIplikDto { get; set; }
        public GetNormalIplikRenklerVm()
        {
            NormalIplikDto = new ZetaCodeNormalIplikDto();
        }
    }

    public class GetFanteziIplikRenklerVm
    {
        public ZetaCodeFanteziIplikDto FantezilIplikDto { get; set; }
        public GetFanteziIplikRenklerVm()
        {
            FantezilIplikDto = new ZetaCodeFanteziIplikDto();
        }
    }
}