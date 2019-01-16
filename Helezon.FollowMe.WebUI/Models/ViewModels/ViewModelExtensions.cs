using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public static class ViewModelExtensions
    {
        private static string ZetaCodeFormat(string zetaCode) {

            return string.Format("Z - {0}", zetaCode.ToString().PadLeft(4, '0'));
        }
        public static string ZetaCodeFormat(this ZetaCodeFanteziIplikDto fanteziIplik)
        {
            return ZetaCodeFormat(fanteziIplik.ZetaCode.ToString());
        }
        public static string ZetaCodeFormat(this ZetaCodeNormalIplikDto fanteziIplik)
        {
            return ZetaCodeFormat(fanteziIplik.ZetaCode.ToString());
        }
    }
    
}