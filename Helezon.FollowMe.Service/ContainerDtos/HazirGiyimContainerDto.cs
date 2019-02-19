using Helezon.FollowMe.Entities.Models;
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
        public ZetaCodeHazirGiyim HazirGiyim { get; set; }

        public Company Company { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public Renk Renk { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public string PictureUrl { get; set; }
        public string PictureEditUrl { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }

        public List<ZetaCodeDto> KumasOrmeDokumalar { get; set; }
        public List<ZetaCodeDto> KumasFanteziler { get; set; }
        public List<ZetaCodeDto> Aksesuarlar { get; set; }

        public HazirGiyimContainerDto()
        {
            HazirGiyim = new ZetaCodeHazirGiyim();
            Company = new Company();
            Renk = new Renk();
            PantoneRenk = new PantoneRenk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Ulke = new PairIdNameDto();
        }
    }
}
