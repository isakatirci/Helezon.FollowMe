using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public static class ViewModelExtensions
    {
        public static string ZetaCodeFormat(this ZetaCodeFanteziIplikDto fanteziIplik)
        {
            return string.Format("Z - {0}", fanteziIplik.ZetaCode.ToString().PadLeft(4, '0'));
        }
    }
}