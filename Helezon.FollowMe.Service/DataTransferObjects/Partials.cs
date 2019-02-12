using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.DataTransferObjects
{
    public partial class ZetaCodeKumasMakineDto
    {
        public TermDto MakineMarkasi { get; set; }
        public TermDto MakineModeli { get; set; }
        public List<TermDto> Aksesuarlar { get; set; }
        partial void InitializePartial()
        {
            Aksesuarlar = new List<TermDto>();
            AksesuarIds = string.Empty;
        }

    }

    public partial class ZetaCodeHazirGiyimDto
    {
        public TermDto RafyeriTurkiye { get; set; }
        public TermDto RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public TermDto UrunKategori { get; set; }
        
        public string ZetaCodeFormatli
        {
            get
            {

                return string.Format("Z - {0}", this.ZetaCode.ToString().PadLeft(4, '0'));
            }
        }
        partial void InitializePartial()
        {
            RafyeriTurkiye = new TermDto();
            RafyeriYunanistan = new TermDto();
        }
    }
    public partial class ZetaCodeAksesuarDto
    {
        public TermDto RafyeriTurkiye { get; set; }
        public TermDto RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public string ZetaCodeFormatli
        {
            get
            {

                return string.Format("Z - {0}", this.ZetaCode.ToString().PadLeft(4, '0'));
            }
        }
        partial void InitializePartial()
        {
            RafyeriTurkiye = new TermDto();
            RafyeriYunanistan = new TermDto();
        }
    }
    public partial class ZetaCodeFanteziIplikDto
    {
        public TermDto IplikKategosi { get; set; }
        public TermDto RafyeriTurkiye { get; set; }
        public TermDto RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public string ZetaCodeFormatli
        {
            get
            {

                return string.Format("Z - {0}", this.ZetaCode.ToString().PadLeft(4, '0'));
            }
        }
        partial void InitializePartial()
        {
            IplikKategosi = new TermDto();
            RafyeriTurkiye = new TermDto();
            RafyeriYunanistan = new TermDto();
        }
    }

    public partial class ZetaCodeKumasFantaziDto
    {
        public TermDto MakineModeli { get; set; }
        public TermDto MakineMarkasi { get; set; }
        public List<TermDto> Aksesuarlar { get; set; }
        public List<TermDto> BoyaIslemleri { get; set; }
        public List<TermDto> OrguDetaylari { get; set; }

        public List<ZetaCodeKumasFantaziDto> KumasOrmeDokumalar { get; set; }
        public List<ZetaCodeKumasOrmeDokumaDto> KumasFanteziler { get; set; }       

        partial void InitializePartial()
        {
            MakineModeli = new TermDto();
            MakineMarkasi = new TermDto();
            RafyeriTurkiye = new TermDto();
            KumasOrmeDokumalar = new List<ZetaCodeKumasFantaziDto>();
            KumasFanteziler = new List<ZetaCodeKumasOrmeDokumaDto>();
            RafyeriYunanistan = new TermDto();
            BoyaIslemleri = new List<TermDto>();
            OrguDetaylari = new List<TermDto>();
            Aksesuarlar = new List<TermDto>();
        }
    }

    public partial class ZetaCodeKumasOrmeDokumaDto
    {
        public TermDto KumasGoruntu { get; set; }
        public TermDto KoleksiyonKategori { get; set; }
        public TermDto RafyeriTurkiye { get; set; }
        public TermDto RafyeriYunanistan { get; set; }
        public string ZetaCodeFormatli { get; set; }
        public TermDto UrunKategorisi { get; set; }
        public PairIdNameDto Ulke { get; set; }
        public List<TermDto> BoyaIslemleri { get; set; }
        public List<TermDto> OrguDetaylari { get; set; }
        public List<TermDto> Aksesuarlar { get; set; }
        public TermDto MakineModeli { get; set; }
        public TermDto MakineMarkasi { get; set; }

        partial void InitializePartial()
        {
            KumasGoruntu = new TermDto();
            MakineModeli = new TermDto();
            MakineMarkasi = new TermDto();
            KoleksiyonKategori = new TermDto();
            RafyeriTurkiye = new TermDto();
            RafyeriYunanistan = new TermDto();
            BoyaIslemleri = new List<TermDto>();
            OrguDetaylari = new List<TermDto>();
            Aksesuarlar = new List<TermDto>();
        }
    }
    public partial class ZetaCodeNormalIplikDto
    {
        public PairIdNameDto Ulke { get; set; }

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

        //"iplik ürün ismi" şu bilgilerden oluşur: iplik no/kategori 2 - üretim teknolojisi/elyaf cinsi-kalitesi-parlaklığı/kategori 3. ekte tarifi
        //not: parlaklık sadece üretim teknolojisinde polyesterin en alt yaprağında var
        //tek veri girişi örnek: DNY 300 FL 096L - HAM TEKSTURE - %100 PES NORMAL YARIMAT
        //2 veri girişi örnek : NE 30 - MELANGE RING - 65/35 POLYVISCON - FLAM
        public TermDto UretimTeknolojisi { get; set; }
        public TermDto IplikKategosi { get; set; }


        public string ZetaCodeNormalIplikSirketName { get; set; }
        public string IplikKategosiName { get; set; }
        public string RafyeriYunanistanName { get; set; }
        public string RafyeriTurkiyeName { get; set; }
        //public string UlkeAdi { get; set; }
        public string UretimTeknolojisiName { get; set; }
        public string PictureEditUrl { get; set; }
        public string PictureUrl { get; set; }

    }

    public partial class ZetaCodeKumasFantaziDto
    {
        public string ZetaCodeFormatli { get; set; }
        public TermDto UrunKategorisi { get; set; }
        public TermDto RafyeriTurkiye { get; set; }
        public TermDto RafyeriYunanistan { get; set; }
        public PairIdNameDto Ulke { get; set; }

    }
 

    //IplikKategoriDegrede

    public partial class IplikKategoriDegredeDto
    {

        //public string BoyamaProsesiFormat { get; set; } // BoyamaProsesi
    }

   // IplikKategoriFlam

    public partial class IplikKategoriFlamDto
    {
        //public string FlamlarArasindakiMesafeFormat { get; set; } // FlamlarArasindakiMesafe
        //public string FlamUzunluguFormat { get; set; } // FlamUzunlugu
        //public string FlamYuksekligiFormat { get; set; } // FlamYuksekligi

    }

    // IplikKategoriKircili

    public partial class IplikKategoriKirciliDto
    {
        //public string KircillarArasiMesafeFormat { get; set; } // KircillarArasiMesafe
        //public string KircilUzunluguFormat { get; set; } // KircilUzunlugu
        //public string KircilYuksekligiFormat { get; set; } // KircilYuksekligi

    }

    // IplikKategoriKrep

    public partial class IplikKategoriKrepDto
    {
        //public string TurSayisiFormat { get; set; } // TurSayisi
        //public string BukumYonuFormat { get; set; } // BukumYonu (length: 50)

    }

    // IplikKategoriNopeli

    public partial class IplikKategoriNopeliDto
    {
        //public string NoktalarArasiMesafeFormat { get; set; } // NoktalarArasiMesafe
        //public string NoktaUzunluguFormat { get; set; } // NoktaUzunlugu
        //public string NoktaYuksekligiFormat { get; set; } // NoktaYuksekligi
    }

    // IplikKategoriSim

    public partial class IplikKategoriSimDto
    {
       // public string SimKesimBoyutuFormat { get; set; } // SimKesimBoyutu

    }

    public partial class IplikNoDto
    {
        public string ElyafCinsiKalitesiName { get; set; }
    }
}
