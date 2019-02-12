using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class FanteziIplikContainerDto
    {
        public ZetaCodeFanteziIplikDto FanteziIplik { get; set; }
        public CompanyDto Company { get; set; }
        public List<ZetaCodeNormalIplikDto> NormalIplikler { get; set; }
    }
}
