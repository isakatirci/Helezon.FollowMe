using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class HazirGiyimContainerDto
    {
        public ZetaCodeHazirGiyimDto HazirGiyim { get; set; }
        public List<ZetaCodeDto> KumasOrmeDokumalar { get; set; }
        public List<ZetaCodeDto> KumasFanteziler { get; set; }
        public List<ZetaCodeDto> Aksesuarlar { get; set; }
    }
}
