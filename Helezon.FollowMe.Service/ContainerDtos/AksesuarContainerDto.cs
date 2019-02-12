using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class AksesuarContainerDto
    {
        public ZetaCodeAksesuarDto Aksesuar { get; internal set; }
        public List<ZetaCodeAksesuarKompozisyonDto> AksesuarKompozisyonlar { get; set; }
        public CompanyDto Company { get; set; }
        public AksesuarContainerDto()
        {
            Aksesuar = new ZetaCodeAksesuarDto();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyonDto>();
            Company = new CompanyDto();
        }
    }
}
