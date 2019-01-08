using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.DataTransferObjects
{
    public partial class ZetaCodeNormalIplikDto
    {
        public string ZetaCodeFormat { get {

                return string.Format("Z - {0}", this.ZetaCode.ToString().PadLeft(4, '0'));
            }
        }

        private string _renkIdFormat;
        public string RenkIdFormat
        {
            get
            {

                return _renkIdFormat?.Split('|')[0];
            }
            set {

                _renkIdFormat = value;
            }
        }
        public string ZetaCodeNormalIplikSirketName { get; set; }
        public string IplikKategosiName { get; set; }
        public string RafyeriYunanistanName { get; set; }
        public string RafyeriTurkiyeName { get; set; }
       public string UlkeAdi { get; set; }
        public string UretimTeknolojisiName { get; set; }
        public string PictureEditUrl { get; set; }
        public string PictureUrl { get; set; }

    }

    public partial class IplikNoDto
    {
        public string ElyafCinsiKalitesiName { get; set; }
    }
}
