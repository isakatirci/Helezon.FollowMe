using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    public class PairIdNameDto
    {
        public string Id { get;  set; }
        public string Name { get;  set; }
    }


    public interface IOthersService
    {
        HashSet<PairIdNameDto> GetAllCountry();
        HashSet<PairIdNameDto> GetAllBoyaTipi();
        HashSet<PairIdNameDto> GetAllBoyaYonu();
        PairIdNameDto GetCountryById(string id);
        string GetCountryNameById(string id);
        HashSet<PairIdNameDto> GetAllMakineModelYillari();
        HashSet<PairIdNameDto> GetAllMakinePusYillari();
        HashSet<PairIdNameDto> GetAllMakineFinelar();
        HashSet<PairIdNameDto> GetAllMakineYedekFinelar();
        HashSet<PairIdNameDto> GetAllMakineYedekSistemler();
        HashSet<PairIdNameDto> GetAllMakineIgneSayisi();
        HashSet<PairIdNameDto> GetAllElastan();
        HashSet<PairIdNameDto> GetAllTupAcikEn();
        HashSet<PairIdNameDto> GetAllAksesuar();
        HashSet<PairIdNameDto> GetYikamaSekilleri();
        HashSet<PairIdNameDto> GetBedenKaliplari();
    }
    public class OthersService : IOthersService
    {

        //            BedenKalipIsimleri.Add(BedenKalip.Boy, "Boy");
        //            BedenKalipIsimleri.Add(BedenKalip.En, "En");
        //            BedenKalipIsimleri.Add(BedenKalip.Ense, "Ense");
        //            BedenKalipIsimleri.Add(BedenKalip.Kolboyu, "Kolboyu");
        //            BedenKalipIsimleri.Add(BedenKalip.Omuz, "Omuz");



        private static Lazy<HashSet<PairIdNameDto>> _ulkeler = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto> {
           new PairIdNameDto { Id="1", Name="Turkey"},
              new PairIdNameDto { Id="2", Name="Greece"},
            new PairIdNameDto { Id="202", Name="Afghanistan"},
            new PairIdNameDto { Id="73", Name="Albania"},
            new PairIdNameDto { Id="3", Name="Algeria"},
            new PairIdNameDto { Id="4", Name="American Samoa"},
            new PairIdNameDto { Id="5", Name="Andorra"},
            new PairIdNameDto { Id="6", Name="Angola"},
            new PairIdNameDto { Id="7", Name="Antigua And Barbuda"},
            new PairIdNameDto { Id="8", Name="Argentina"},
            new PairIdNameDto { Id="9", Name="Armenia"},
            new PairIdNameDto { Id="10", Name="Aruba"},
            new PairIdNameDto { Id="11", Name="Australia"},
            new PairIdNameDto { Id="12", Name="Austria"},
            new PairIdNameDto { Id="13", Name="Azerbaijan"},
            new PairIdNameDto { Id="14", Name="Bahamas The"},
            new PairIdNameDto { Id="15", Name="Bahrain"},
            new PairIdNameDto { Id="16", Name="Bangladesh"},
            new PairIdNameDto { Id="17", Name="Belarus"},
            new PairIdNameDto { Id="18", Name="Belgium"},
            new PairIdNameDto { Id="19", Name="Belize"},
            new PairIdNameDto { Id="20", Name="Benin"},
            new PairIdNameDto { Id="21", Name="Bermuda"},
            new PairIdNameDto { Id="22", Name="Bhutan"},
            new PairIdNameDto { Id="23", Name="Bolivia"},
            new PairIdNameDto { Id="24", Name="Botswana"},
            new PairIdNameDto { Id="25", Name="Brazil"},
            new PairIdNameDto { Id="26", Name="Brunei"},
            new PairIdNameDto { Id="27", Name="Bulgaria"},
            new PairIdNameDto { Id="28", Name="Burkina Faso"},
            new PairIdNameDto { Id="29", Name="Burundi"},
            new PairIdNameDto { Id="30", Name="Cambodia"},
            new PairIdNameDto { Id="31", Name="Cameroon"},
            new PairIdNameDto { Id="32", Name="Canada"},
            new PairIdNameDto { Id="33", Name="Cape Verde"},
            new PairIdNameDto { Id="34", Name="Central African Republic"},
            new PairIdNameDto { Id="35", Name="Chad"},
            new PairIdNameDto { Id="36", Name="Chile"},
            new PairIdNameDto { Id="37", Name="China"},
            new PairIdNameDto { Id="38", Name="Colombia"},
            new PairIdNameDto { Id="39", Name="Comoros"},
            new PairIdNameDto { Id="40", Name="Congo"},
            new PairIdNameDto { Id="41", Name="Congo The Democratic Republic Of The"},
            new PairIdNameDto { Id="42", Name="Cook Islands"},
            new PairIdNameDto { Id="43", Name="Costa Rica"},
            new PairIdNameDto { Id="44", Name="Cote D'Ivoire (Ivory Coast)"},
            new PairIdNameDto { Id="45", Name="Croatia (Hrvatska)"},
            new PairIdNameDto { Id="46", Name="Cuba"},
            new PairIdNameDto { Id="47", Name="Cyprus"},
            new PairIdNameDto { Id="48", Name="Czech Republic"},
            new PairIdNameDto { Id="49", Name="Denmark"},
            new PairIdNameDto { Id="50", Name="Djibouti"},
            new PairIdNameDto { Id="51", Name="Dominican Republic"},
            new PairIdNameDto { Id="52", Name="East Timor"},
            new PairIdNameDto { Id="53", Name="Ecuador"},
            new PairIdNameDto { Id="54", Name="Egypt"},
            new PairIdNameDto { Id="55", Name="El Salvador"},
            new PairIdNameDto { Id="56", Name="Equatorial Guinea"},
            new PairIdNameDto { Id="57", Name="Eritrea"},
            new PairIdNameDto { Id="58", Name="Estonia"},
            new PairIdNameDto { Id="59", Name="Ethiopia"},
            new PairIdNameDto { Id="60", Name="Faroe Islands"},
            new PairIdNameDto { Id="61", Name="Fiji Islands"},
            new PairIdNameDto { Id="62", Name="Finland"},
            new PairIdNameDto { Id="63", Name="France"},
            new PairIdNameDto { Id="64", Name="French Guiana"},
            new PairIdNameDto { Id="65", Name="French Polynesia"},
            new PairIdNameDto { Id="66", Name="French Southern Territories"},
            new PairIdNameDto { Id="67", Name="Gabon"},
            new PairIdNameDto { Id="68", Name="Gambia The"},
            new PairIdNameDto { Id="69", Name="Georgia"},
            new PairIdNameDto { Id="70", Name="Germany"},
            new PairIdNameDto { Id="71", Name="Ghana"},
            new PairIdNameDto { Id="72", Name="Gibraltar"},

            new PairIdNameDto { Id="74", Name="Greenland"},
            new PairIdNameDto { Id="75", Name="Guadeloupe"},
            new PairIdNameDto { Id="76", Name="Guam"},
            new PairIdNameDto { Id="77", Name="Guatemala"},
            new PairIdNameDto { Id="78", Name="Guernsey and Alderney"},
            new PairIdNameDto { Id="79", Name="Guinea"},
            new PairIdNameDto { Id="80", Name="Guinea-Bissau"},
            new PairIdNameDto { Id="81", Name="Guyana"},
            new PairIdNameDto { Id="82", Name="Haiti"},
            new PairIdNameDto { Id="83", Name="Honduras"},
            new PairIdNameDto { Id="84", Name="Hungary"},
            new PairIdNameDto { Id="85", Name="Iceland"},
            new PairIdNameDto { Id="86", Name="India"},
            new PairIdNameDto { Id="87", Name="Indonesia"},
            new PairIdNameDto { Id="88", Name="Iran"},
            new PairIdNameDto { Id="89", Name="Iraq"},
            new PairIdNameDto { Id="90", Name="Ireland"},
            new PairIdNameDto { Id="91", Name="Israel"},
            new PairIdNameDto { Id="92", Name="Italy"},
            new PairIdNameDto { Id="93", Name="Jamaica"},
            new PairIdNameDto { Id="94", Name="Japan"},
            new PairIdNameDto { Id="95", Name="Jersey"},
            new PairIdNameDto { Id="96", Name="Jordan"},
            new PairIdNameDto { Id="97", Name="Kazakhstan"},
            new PairIdNameDto { Id="98", Name="Kenya"},
            new PairIdNameDto { Id="99", Name="Kiribati"},
            new PairIdNameDto { Id="100", Name="Korea North"},
            new PairIdNameDto { Id="101", Name="Korea South"},
            new PairIdNameDto { Id="102", Name="Kuwait"},
            new PairIdNameDto { Id="103", Name="Kyrgyzstan"},
            new PairIdNameDto { Id="104", Name="Laos"},
            new PairIdNameDto { Id="105", Name="Latvia"},
            new PairIdNameDto { Id="106", Name="Lebanon"},
            new PairIdNameDto { Id="107", Name="Lesotho"},
            new PairIdNameDto { Id="108", Name="Liberia"},
            new PairIdNameDto { Id="109", Name="Libya"},
            new PairIdNameDto { Id="110", Name="Liechtenstein"},
            new PairIdNameDto { Id="111", Name="Lithuania"},
            new PairIdNameDto { Id="112", Name="Luxembourg"},
            new PairIdNameDto { Id="113", Name="Macau S.A.R."},
            new PairIdNameDto { Id="114", Name="Macedonia"},
            new PairIdNameDto { Id="115", Name="Madagascar"},
            new PairIdNameDto { Id="116", Name="Malawi"},
            new PairIdNameDto { Id="117", Name="Malaysia"},
            new PairIdNameDto { Id="118", Name="Maldives"},
            new PairIdNameDto { Id="119", Name="Mali"},
            new PairIdNameDto { Id="120", Name="Malta"},
            new PairIdNameDto { Id="121", Name="Man (Isle of)"},
            new PairIdNameDto { Id="122", Name="Marshall Islands"},
            new PairIdNameDto { Id="123", Name="Martinique"},
            new PairIdNameDto { Id="124", Name="Mauritania"},
            new PairIdNameDto { Id="125", Name="Mauritius"},
            new PairIdNameDto { Id="126", Name="Mayotte"},
            new PairIdNameDto { Id="127", Name="Mexico"},
            new PairIdNameDto { Id="128", Name="Micronesia"},
            new PairIdNameDto { Id="129", Name="Moldova"},
            new PairIdNameDto { Id="130", Name="Monaco"},
            new PairIdNameDto { Id="131", Name="Mongolia"},
            new PairIdNameDto { Id="132", Name="Montserrat"},
            new PairIdNameDto { Id="133", Name="Morocco"},
            new PairIdNameDto { Id="134", Name="Mozambique"},
            new PairIdNameDto { Id="135", Name="Myanmar"},
            new PairIdNameDto { Id="136", Name="Namibia"},
            new PairIdNameDto { Id="137", Name="Nauru"},
            new PairIdNameDto { Id="138", Name="Nepal"},
            new PairIdNameDto { Id="139", Name="Netherlands Antilles"},
            new PairIdNameDto { Id="140", Name="Netherlands The"},
            new PairIdNameDto { Id="141", Name="New Caledonia"},
            new PairIdNameDto { Id="142", Name="New Zealand"},
            new PairIdNameDto { Id="143", Name="Nicaragua"},
            new PairIdNameDto { Id="144", Name="Niger"},
            new PairIdNameDto { Id="145", Name="Nigeria"},
            new PairIdNameDto { Id="146", Name="Niue"},
            new PairIdNameDto { Id="147", Name="Northern Mariana Islands"},
            new PairIdNameDto { Id="148", Name="Norway"},
            new PairIdNameDto { Id="149", Name="Oman"},
            new PairIdNameDto { Id="150", Name="Pakistan"},
            new PairIdNameDto { Id="151", Name="Palau"},
            new PairIdNameDto { Id="152", Name="Palestinian Territory Occupied"},
            new PairIdNameDto { Id="153", Name="Panama"},
            new PairIdNameDto { Id="154", Name="Papua new Guinea"},
            new PairIdNameDto { Id="155", Name="Paraguay"},
            new PairIdNameDto { Id="156", Name="Peru"},
            new PairIdNameDto { Id="157", Name="Philippines"},
            new PairIdNameDto { Id="158", Name="Poland"},
            new PairIdNameDto { Id="159", Name="Portugal"},
            new PairIdNameDto { Id="160", Name="Puerto Rico"},
            new PairIdNameDto { Id="161", Name="Qatar"},
            new PairIdNameDto { Id="162", Name="Reunion"},
            new PairIdNameDto { Id="163", Name="Romania"},
            new PairIdNameDto { Id="164", Name="Russia"},
            new PairIdNameDto { Id="165", Name="Rwanda"},
            new PairIdNameDto { Id="166", Name="Saint Helena"},
            new PairIdNameDto { Id="167", Name="Saint Lucia"},
            new PairIdNameDto { Id="168", Name="Saint Pierre and Miquelon"},
            new PairIdNameDto { Id="169", Name="Saint Vincent And The Grenadines"},
            new PairIdNameDto { Id="170", Name="Samoa"},
            new PairIdNameDto { Id="171", Name="San Marino"},
            new PairIdNameDto { Id="172", Name="Sao Tome and Principe"},
            new PairIdNameDto { Id="173", Name="Saudi Arabia"},
            new PairIdNameDto { Id="174", Name="Senegal"},
            new PairIdNameDto { Id="175", Name="Seychelles"},
            new PairIdNameDto { Id="176", Name="Sierra Leone"},
            new PairIdNameDto { Id="177", Name="Singapore"},
            new PairIdNameDto { Id="178", Name="Slovakia"},
            new PairIdNameDto { Id="179", Name="Slovenia"},
            new PairIdNameDto { Id="180", Name="Smaller Territories of the UK"},
            new PairIdNameDto { Id="181", Name="Solomon Islands"},
            new PairIdNameDto { Id="182", Name="Somalia"},
            new PairIdNameDto { Id="183", Name="South Africa"},
            new PairIdNameDto { Id="184", Name="Spain"},
            new PairIdNameDto { Id="185", Name="Sri Lanka"},
            new PairIdNameDto { Id="186", Name="Sudan"},
            new PairIdNameDto { Id="187", Name="SuriText"},
            new PairIdNameDto { Id="188", Name="Svalbard And Jan Mayen Islands"},
            new PairIdNameDto { Id="189", Name="Swaziland"},
            new PairIdNameDto { Id="190", Name="Sweden"},
            new PairIdNameDto { Id="191", Name="Switzerland"},
            new PairIdNameDto { Id="192", Name="Syria"},
            new PairIdNameDto { Id="193", Name="Taiwan"},
            new PairIdNameDto { Id="194", Name="Tajikistan"},
            new PairIdNameDto { Id="195", Name="Tanzania"},
            new PairIdNameDto { Id="196", Name="Thailand"},
            new PairIdNameDto { Id="197", Name="Togo"},
            new PairIdNameDto { Id="198", Name="Tokelau"},
            new PairIdNameDto { Id="199", Name="Tonga"},
            new PairIdNameDto { Id="200", Name="TrinValuead And Tobago"},
            new PairIdNameDto { Id="201", Name="Tunisia"},

            new PairIdNameDto { Id="203", Name="Turkmenistan"},
            new PairIdNameDto { Id="204", Name="Tuvalu"},
            new PairIdNameDto { Id="205", Name="Uganda"},
            new PairIdNameDto { Id="206", Name="Ukraine"},
            new PairIdNameDto { Id="207", Name="United Arab Emirates"},
            new PairIdNameDto { Id="208", Name="United Kingdom"},
            new PairIdNameDto { Id="209", Name="United States"},
            new PairIdNameDto { Id="210", Name="Uruguay"},
            new PairIdNameDto { Id="211", Name="Uzbekistan"},
            new PairIdNameDto { Id="212", Name="Vanuatu"},
            new PairIdNameDto { Id="213", Name="Venezuela"},
            new PairIdNameDto { Id="214", Name="Vietnam"},
            new PairIdNameDto { Id="215", Name="Virgin Islands (British)"},
            new PairIdNameDto { Id="216", Name="Wallis And Futuna Islands"},
            new PairIdNameDto { Id="217", Name="Western Sahara"},
            new PairIdNameDto { Id="218", Name="Yemen"},
            new PairIdNameDto { Id="219", Name="Yugoslavia"},
            new PairIdNameDto { Id="220", Name="Zambia"},
            new PairIdNameDto { Id="221", Name="Zimbabwe"}
       });
        private static Lazy<HashSet<PairIdNameDto>> _boyaTipi = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
            new PairIdNameDto { Id= "1", Name= "Çile Boya" },
            new PairIdNameDto { Id= "2", Name= "Bobin boya" }
        });
        private static Lazy<HashSet<PairIdNameDto>> _boyaYonu = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "Dogrusal" },
                new PairIdNameDto { Id= "2", Name= "Dairesel" },
                new PairIdNameDto { Id= "3", Name= "Açılı" },
                new PairIdNameDto { Id= "4", Name= "Simetrik" },
                new PairIdNameDto { Id= "5", Name= "Dörtgen" }
        });
        //ELASTAN
        private static Lazy<HashSet<PairIdNameDto>> _elastan = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "%10 FULL ELASTANE" },
                new PairIdNameDto { Id= "2", Name= "%5 YARIM ELASTANE" },
                new PairIdNameDto { Id= "3", Name= "YOK" }            
        });

        private static Lazy<HashSet<PairIdNameDto>> _yikamaSekilleri = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "ELDE" },
                new PairIdNameDto { Id= "2", Name= "TERS" },
                new PairIdNameDto { Id= "3", Name= "MAKINE" }
        });

        //TUP - ACIK EN
        private static Lazy<HashSet<PairIdNameDto>> _tupAcikEn = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "ACIK EN" },
                new PairIdNameDto { Id= "2", Name= "ACIK EN/TUP" },
                new PairIdNameDto { Id= "3", Name= "TUP" }
        });
        //AKSESUAR
        private static Lazy<HashSet<PairIdNameDto>> _aksesuar = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "DIL ACICI" },
                new PairIdNameDto { Id= "2", Name= "MECLI" },
        });

        private static Lazy<HashSet<PairIdNameDto>> _bedenKaliplari = new Lazy<HashSet<PairIdNameDto>>(() => new HashSet<PairIdNameDto>() {
                new PairIdNameDto { Id= "1", Name= "Boy" },
                new PairIdNameDto { Id= "2", Name= "En" },
                new PairIdNameDto { Id= "3", Name= "Ense" },
                new PairIdNameDto { Id= "4", Name= "Kolboyu" },
                new PairIdNameDto { Id= "5", Name= "Omuz" },
        });





        public HashSet<PairIdNameDto> GetAllElastan()
        {
            return _elastan.Value;
        }
        public HashSet<PairIdNameDto> GetAllTupAcikEn()
        {
            return _tupAcikEn.Value;
        }
        public HashSet<PairIdNameDto> GetAllAksesuar()
        {
            return _aksesuar.Value;
        }

        public HashSet<PairIdNameDto> GetAllCountry()
        {
            return _ulkeler.Value;
        }

        public HashSet<PairIdNameDto> GetAllBoyaTipi()
        {
            return _boyaTipi.Value;
        }

        public HashSet<PairIdNameDto> GetAllBoyaYonu()
        {
            return _boyaYonu.Value;
        }
        public PairIdNameDto GetCountryById(string id)
        {
            return _ulkeler.Value.FirstOrDefault(x=>x.Id == id);
        }



        public string GetCountryNameById(string id)
        {
            return (GetCountryById(id) ?? new PairIdNameDto()).Name;
        }

        private static Lazy<HashSet<PairIdNameDto>> _makineModelYillar = new Lazy<HashSet<PairIdNameDto>>(() =>
        {
            var modelYillar = new HashSet<PairIdNameDto>();
            for (int i = 1970; i <= 2050; i++)
            {
                modelYillar.Add(new PairIdNameDto
                {
                    Id = i.ToString(),
                    Name = i.ToString()
                });
            }
            return modelYillar;
        });
        private static Lazy<HashSet<PairIdNameDto>> _makinePuslar = new Lazy<HashSet<PairIdNameDto>>(() =>
        {
            var set = new HashSet<PairIdNameDto>();
            for (int i = 2; i <= 60; i++)
            {
                set.Add(new PairIdNameDto
                {
                    Id = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<PairIdNameDto>> _makineFinelar = new Lazy<HashSet<PairIdNameDto>>(() =>
        {
            var set = new HashSet<PairIdNameDto>();
            for (int i = 2; i <= 90; i++)
            {
                set.Add(new PairIdNameDto
                {
                    Id = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<PairIdNameDto>> _makineYedekFinelar = new Lazy<HashSet<PairIdNameDto>>(() =>
        {
            var set = new HashSet<PairIdNameDto>();
            for (int i = 2; i <= 90; i++)
            {
                set.Add(new PairIdNameDto
                {
                    Id = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<PairIdNameDto>> _makineSistem = new Lazy<HashSet<PairIdNameDto>>(() =>
        {
            var set = new HashSet<PairIdNameDto>();
            for (int i = 2; i <= 135; i++)
            {
                set.Add(new PairIdNameDto
                {
                    Id = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        //private static Lazy<HashSet<PairIdNameDto>> _makineIgneSayisi = new Lazy<HashSet<PairIdNameDto>>(() =>
        //{
        //    var set = new ConcurrentBag<PairIdNameDto>();
        //    for (int i = 15; i <= 16965; i++)
        //    {
        //        set.Add(new PairIdNameDto
        //        {
        //            Id = i.ToString(),
        //            Name = i.ToString()
        //        });
        //    }
        //    return set.ToList();
        //});
        public HashSet<PairIdNameDto> GetAllMakineModelYillari()
        {
            return _makineModelYillar.Value;
        }

        public HashSet<PairIdNameDto> GetAllMakinePusYillari()
        {
            return _makinePuslar.Value;
        }

        public HashSet<PairIdNameDto> GetAllMakineFinelar()
        {
            throw new NotImplementedException();
        }

        public HashSet<PairIdNameDto> GetAllMakineYedekFinelar()
        {
            throw new NotImplementedException();
        }

        public HashSet<PairIdNameDto> GetAllMakineYedekSistemler()
        {
            throw new NotImplementedException();
        }

        public HashSet<PairIdNameDto> GetAllMakineIgneSayisi()
        {
            throw new NotImplementedException();
        }

        public HashSet<PairIdNameDto> GetYikamaSekilleri()
        {
           return _yikamaSekilleri.Value;
        }

        public HashSet<PairIdNameDto> GetBedenKaliplari()
        {
            return _bedenKaliplari.Value;
        }
    }
}
