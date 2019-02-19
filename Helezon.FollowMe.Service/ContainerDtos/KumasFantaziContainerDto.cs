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
        public ZetaCodeKumasFantazi KumasFantazi { get; set; }
        public ZetaCodeKumasMakine KumasMakine { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }
        public List<ZetaCodeKumasFantazi> KumasFanteziler { get; set; }
        public List<ZetaCodeKumasOrmeDokuma> KumasOrmeDokumalar { get; set; }
        public List<ZetaCodeKumasFantezi3AdimIslemleri> KumasFantezi3AdimIslemleri { get; set; }
        public string PictureUrl { get; set; }
        public Company Company { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }

        public KumasFantaziContainerDto()
        {
            KumasFantezi3AdimIslemleri = new List<ZetaCodeKumasFantezi3AdimIslemleri>();
            KumasOrmeDokumalar = new List<ZetaCodeKumasOrmeDokuma>();
            KumasFanteziler = new List<ZetaCodeKumasFantazi>();
            Company = new Company();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Ulke = new PairIdNameDto();
            KumasFantazi = new ZetaCodeKumasFantazi();
            KumasMakine = new ZetaCodeKumasMakine();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
        }
    }
}
