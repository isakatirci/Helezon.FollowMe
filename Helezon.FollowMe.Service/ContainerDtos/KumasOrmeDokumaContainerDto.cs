using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class KumasOrmeDokumaContainerDto
    {
        public ZetaCodeKumasOrmeDokumaDto KumasOrmeDokuma { get; set; }
        public ZetaCodeKumasMakineDto KumasMakine { get; set; }
        public ZetaCodeYikamaTalimatiDto YikamaTalimati { get; set; }
 
        public List<ZetaCodeNormalKumasNormalIplikDto> NormalIplikler { get; set; }
        public List<ZetaCodeNormalKumasFanteziIplikDto> FanteziIplikler { get; set; }

        public KumasOrmeDokumaContainerDto()
        {
            NormalIplikler = new List<ZetaCodeNormalKumasNormalIplikDto>();
            FanteziIplikler = new List<ZetaCodeNormalKumasFanteziIplikDto>();
        }
    }
}
