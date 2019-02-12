using Helezon.FollowMe.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.ContainerDtos
{
    public class NormalIplikContainerDto
    {
        public ZetaCodeNormalIplikDto NormalIplik { get; set; }
        public IplikKategoriDegredeDto Degrede { get; set; }//IplikKategoriFlam
        public IplikKategoriFlamDto Flam { get; set; }
        public IplikKategoriKirciliDto Kircili { get; set; }
        public IplikKategoriKrepDto Krep { get; set; }
        public IplikKategoriNopeliDto Nopeli { get; set; }
        public IplikKategoriSimDto Sim { get; set; }
        public List<IplikNoDto> IplikNolar { get; set; }
        public CompanyDto Company { get; set; }
    }
}
