using Helezon.FollowMe.Entities.Models;
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
        public ZetaCodeKumasOrmeDokuma KumasOrmeDokuma { get; set; }
        public ZetaCodeKumasMakine KumasMakine { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; } 
        public List<ZetaCodeNormalIplik> NormalIplikler { get; set; }
        public List<ZetaCodeFanteziIplik> FanteziIplikler { get; set; }
        public Company Company { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public string PictureUrl { get; set; }
        public PairIdNameDto Ulke { get; set; }

        public KumasOrmeDokumaContainerDto()
        {
            KumasOrmeDokuma = new ZetaCodeKumasOrmeDokuma();
            KumasMakine = new ZetaCodeKumasMakine();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
            NormalIplikler = new List<ZetaCodeNormalIplik>();
            FanteziIplikler = new List<ZetaCodeFanteziIplik>();
            Company = new Company();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Ulke = new PairIdNameDto();
        }
    }
}
