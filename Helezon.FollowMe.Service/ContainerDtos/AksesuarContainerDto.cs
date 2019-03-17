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
        public ZetaCodeAksesuar Aksesuar { get;  set; }
        public List<ZetaCodeAksesuarKompozisyon> AksesuarKompozisyonlar { get; set; }
        public Company Company { get; set; }
        public PantoneRenk PantoneRenk { get; set; }
        public Renk Renk { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public MyNameValueDto Ulke { get; set; }
        public string PictureUrl { get; set; }
        public AksesuarContainerDto()
        {
            Aksesuar = new ZetaCodeAksesuar();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyon>();
            Company = new Company();
            PantoneRenk = new PantoneRenk();
            Renk = new Renk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Ulke = new MyNameValueDto();
        }
    }
}
