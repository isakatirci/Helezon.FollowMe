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

        public ZetaCodeFanteziIplik FanteziIplik { get; set; }
        public Company Company { get; set; }
        public List<ZetaCodeNormalIplik> NormalIplikler { get; set; }
        public List<Term> AnaIplikKategorileri { get;  set; }
        public string PictureUrl { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public Renk Renk { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public MyNameValueDto Ulke { get; set; }
        public Term IplikKategosi { get; set; }
        
        public FanteziIplikContainerDto()
        {
            Ulke = new MyNameValueDto();
            PantoneRenk = new PantoneRenk();
            Renk = new Renk();
            IplikKategosi = new Term();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            FanteziIplik = new ZetaCodeFanteziIplik();
            Company = new Company();
            NormalIplikler = new List<ZetaCodeNormalIplik>();
            AnaIplikKategorileri = new List<Term>();
        }
    }
}
