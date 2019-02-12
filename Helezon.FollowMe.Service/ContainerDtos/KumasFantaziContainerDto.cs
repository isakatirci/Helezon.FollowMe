using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class KumasFantaziContainerDto
    {
        public ZetaCodeKumasFantaziDto KumasFantazi { get; set; }
        public ZetaCodeKumasMakineDto KumasMakine { get; set; }
        public ZetaCodeYikamaTalimatiDto YikamaTalimati { get; set; }
        public List<ZetaCodeKumasFanteziKumasFanteziDto> KumasFanteziler { get; set; }
        public List<ZetaCodeKumasFanteziKumasOrmeDokumaDto> KumasOrmeDokumalar { get; set; }
        public List<ZetaCodeKumasFantezi3AdimIslemleriDto> KumasFantezi3AdimIslemleri { get; set; }
        public KumasFantaziContainerDto()
        {
            KumasFantezi3AdimIslemleri = new List<ZetaCodeKumasFantezi3AdimIslemleriDto>();
            KumasOrmeDokumalar = new List<ZetaCodeKumasFanteziKumasOrmeDokumaDto>();
            KumasFanteziler = new List<ZetaCodeKumasFanteziKumasFanteziDto>();
        }
    }
}
