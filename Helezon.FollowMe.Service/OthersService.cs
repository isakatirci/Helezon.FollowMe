using Helezon.FollowMe.Entities.Models;
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

    public class IplikNoDto
    {
        public IplikNo IplikNo { get; set; }
        public Term ElyafCinsiKalitesi { get; set; }
    }

    public class MyNameValueDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }


    public interface IOthersService
    {
        List<MyNameValueDto> GetAllCountry();
        HashSet<MyNameValueDto> GetAllBoyaTipi();
        HashSet<MyNameValueDto> GetAllBoyaYonu();
        MyNameValueDto GetCountryById(int? id);
        //MyNameValueDto GetCountryById(int id);
        //string GetCountryNameById(int id);
        HashSet<MyNameValueDto> GetAllMakineModelYillari();
        HashSet<MyNameValueDto> GetAllMakinePusYillari();
        HashSet<MyNameValueDto> GetAllMakineFinelar();
        HashSet<MyNameValueDto> GetAllMakineYedekFinelar();
        HashSet<MyNameValueDto> GetAllMakineYedekSistemler();
        HashSet<MyNameValueDto> GetAllMakineIgneSayisi();
        HashSet<MyNameValueDto> GetAllElastan();
        HashSet<MyNameValueDto> GetAllTupAcikEn();
        HashSet<MyNameValueDto> GetAllAksesuar();
        HashSet<MyNameValueDto> GetYikamaSekilleri();
        HashSet<MyNameValueDto> GetBedenKaliplari();
    }
    public class OthersService : IOthersService
    {

        //            BedenKalipIsimleri.Add(BedenKalip.Boy, "Boy");
        //            BedenKalipIsimleri.Add(BedenKalip.En, "En");
        //            BedenKalipIsimleri.Add(BedenKalip.Ense, "Ense");
        //            BedenKalipIsimleri.Add(BedenKalip.Kolboyu, "Kolboyu");
        //            BedenKalipIsimleri.Add(BedenKalip.Omuz, "Omuz");



        private static Lazy<Dictionary<int, MyNameValueDto>> _ulkeler = new Lazy<Dictionary<int, MyNameValueDto>>(() => new Dictionary<int, MyNameValueDto> {
        {1,    new MyNameValueDto { Value="1",  Name="Turkey"}},
        {2,    new MyNameValueDto { Value="2",  Name="Greece"}},
        {202,  new MyNameValueDto { Value="202",Name="Afghanistan"}},
        {73,   new MyNameValueDto { Value="73", Name="Albania"}},
        {3,    new MyNameValueDto { Value="3",  Name="Algeria"}},
        {4,    new MyNameValueDto { Value="4",  Name="American Samoa"}},
        {5,    new MyNameValueDto { Value="5",  Name="Andorra"}},
        {6,    new MyNameValueDto { Value="6",  Name="Angola"}},
        {7,    new MyNameValueDto { Value="7",  Name="Antigua And Barbuda"}},
        {8,    new MyNameValueDto { Value="8",  Name="Argentina"}},
        {9,    new MyNameValueDto { Value="9",  Name="Armenia"}},
        {10,   new MyNameValueDto { Value="10", Name="Aruba"}},
        {11,   new MyNameValueDto { Value="11", Name="Australia"}},
        {12,   new MyNameValueDto { Value="12", Name="Austria"}},
        {13,   new MyNameValueDto { Value="13", Name="Azerbaijan"}},
        {14,   new MyNameValueDto { Value="14", Name="Bahamas The"}},
        {15,   new MyNameValueDto { Value="15", Name="Bahrain"}},
        {16,   new MyNameValueDto { Value="16", Name="Bangladesh"}},
        {17,   new MyNameValueDto { Value="17", Name="Belarus"}},
        {18,   new MyNameValueDto { Value="18", Name="Belgium"}},
        {19,   new MyNameValueDto { Value="19", Name="Belize"}},
        {20,   new MyNameValueDto { Value="20", Name="Benin"}},
        {21,   new MyNameValueDto { Value="21", Name="Bermuda"}},
        {22,   new MyNameValueDto { Value="22", Name="Bhutan"}},
        {23,   new MyNameValueDto { Value="23", Name="Bolivia"}},
        {24,   new MyNameValueDto { Value="24", Name="Botswana"}},
        {25,   new MyNameValueDto { Value="25", Name="Brazil"}},
        {26,   new MyNameValueDto { Value="26", Name="Brunei"}},
        {27,   new MyNameValueDto { Value="27", Name="Bulgaria"}},
        {28,   new MyNameValueDto { Value="28", Name="Burkina Faso"}},
        {29,   new MyNameValueDto { Value="29", Name="Burundi"}},
        {30,   new MyNameValueDto { Value="30", Name="Cambodia"}},
        {31,   new MyNameValueDto { Value="31", Name="Cameroon"}},
        {32,   new MyNameValueDto { Value="32", Name="Canada"}},
        {33,   new MyNameValueDto { Value="33", Name="Cape Verde"}},
        {34,   new MyNameValueDto { Value="34", Name="Central African Republic"}},
        {35,   new MyNameValueDto { Value="35", Name="Chad"}},
        {36,   new MyNameValueDto { Value="36", Name="Chile"}},
        {37,   new MyNameValueDto { Value="37", Name="China"}},
        {38,   new MyNameValueDto { Value="38", Name="Colombia"}},
        {39,   new MyNameValueDto { Value="39", Name="Comoros"}},
        {40,   new MyNameValueDto { Value="40", Name="Congo"}},
        {41,   new MyNameValueDto { Value="41", Name="Congo The Democratic Republic Of The"}},
        {42,   new MyNameValueDto { Value="42", Name="Cook Islands"}},
        {43,   new MyNameValueDto { Value="43", Name="Costa Rica"}},
        {44,   new MyNameValueDto { Value="44", Name="Cote D'Ivoire (Ivory Coast)"}},
        {45,   new MyNameValueDto { Value="45", Name="Croatia (Hrvatska)"}},
        {46,   new MyNameValueDto { Value="46", Name="Cuba"}},
        {47,   new MyNameValueDto { Value="47", Name="Cyprus"}},
        {48,   new MyNameValueDto { Value="48", Name="Czech Republic"}},
        {49,   new MyNameValueDto { Value="49", Name="Denmark"}},
        {50,   new MyNameValueDto { Value="50", Name="Djibouti"}},
        {51,   new MyNameValueDto { Value="51", Name="Dominican Republic"}},
        {52,   new MyNameValueDto { Value="52", Name="East Timor"}},
        {53,   new MyNameValueDto { Value="53", Name="Ecuador"}},
        {54,   new MyNameValueDto { Value="54", Name="Egypt"}},
        {55,   new MyNameValueDto { Value="55", Name="El Salvador"}},
        {56,   new MyNameValueDto { Value="56", Name="Equatorial Guinea"}},
        {57,   new MyNameValueDto { Value="57", Name="Eritrea"}},
        {58,   new MyNameValueDto { Value="58", Name="Estonia"}},
        {59,   new MyNameValueDto { Value="59", Name="Ethiopia"}},
        {60,   new MyNameValueDto { Value="60", Name="Faroe Islands"}},
        {61,   new MyNameValueDto { Value="61", Name="Fiji Islands"}},
        {62,   new MyNameValueDto { Value="62", Name="Finland"}},
        {63,   new MyNameValueDto { Value="63", Name="France"}},
        {64,   new MyNameValueDto { Value="64", Name="French Guiana"}},
        {65,   new MyNameValueDto { Value="65", Name="French Polynesia"}},
        {66,   new MyNameValueDto { Value="66", Name="French Southern Territories"}},
        {67,   new MyNameValueDto { Value="67", Name="Gabon"}},
        {68,   new MyNameValueDto { Value="68", Name="Gambia The"}},
        {69,   new MyNameValueDto { Value="69", Name="Georgia"}},
        {70,   new MyNameValueDto { Value="70", Name="Germany"}},
        {71,   new MyNameValueDto { Value="71", Name="Ghana"}},
        {72,   new MyNameValueDto { Value="72", Name="Gibraltar"}},
        {74,   new MyNameValueDto { Value="74", Name="Greenland"}},
        {75,   new MyNameValueDto { Value="75", Name="Guadeloupe"}},
        {76,   new MyNameValueDto { Value="76", Name="Guam"}},
        {77,   new MyNameValueDto { Value="77", Name="Guatemala"}},
        {78,   new MyNameValueDto { Value="78", Name="Guernsey and Alderney"}},
        {79,   new MyNameValueDto { Value="79", Name="Guinea"}},
        {80,   new MyNameValueDto { Value="80", Name="Guinea-Bissau"}},
        {81,   new MyNameValueDto { Value="81", Name="Guyana"}},
        {82,   new MyNameValueDto { Value="82", Name="Haiti"}},
        {83,   new MyNameValueDto { Value="83", Name="Honduras"}},
        {84,   new MyNameValueDto { Value="84", Name="Hungary"}},
        {85,   new MyNameValueDto { Value="85", Name="Iceland"}},
        {86,   new MyNameValueDto { Value="86", Name="India"}},
        {87,   new MyNameValueDto { Value="87", Name="Indonesia"}},
        {88,   new MyNameValueDto { Value="88", Name="Iran"}},
        {89,   new MyNameValueDto { Value="89", Name="Iraq"}},
        {90,   new MyNameValueDto { Value="90", Name="Ireland"}},
        {91,   new MyNameValueDto { Value="91", Name="Israel"}},
        {92,   new MyNameValueDto { Value="92", Name="Italy"}},
        {93,   new MyNameValueDto { Value="93", Name="Jamaica"}},
        {94,   new MyNameValueDto { Value="94", Name="Japan"}},
        {95,   new MyNameValueDto { Value="95", Name="Jersey"}},
        {96,   new MyNameValueDto { Value="96", Name="Jordan"}},
        {97,   new MyNameValueDto { Value="97", Name="Kazakhstan"}},
        {98,   new MyNameValueDto { Value="98", Name="Kenya"}},
        {99,   new MyNameValueDto { Value="99", Name="Kiribati"}},
        {100,  new MyNameValueDto { Value="100", Name="Korea North"}},
        {101,  new MyNameValueDto { Value="101", Name="Korea South"}},
        {102,  new MyNameValueDto { Value="102", Name="Kuwait"}},
        {103,  new MyNameValueDto { Value="103", Name="Kyrgyzstan"}},
        {104,  new MyNameValueDto { Value="104", Name="Laos"}},
        {105,  new MyNameValueDto { Value="105", Name="Latvia"}},
        {106,  new MyNameValueDto { Value="106", Name="Lebanon"}},
        {107,  new MyNameValueDto { Value="107", Name="Lesotho"}},
        {108,  new MyNameValueDto { Value="108", Name="Liberia"}},
        {109,  new MyNameValueDto { Value="109", Name="Libya"}},
        {110,  new MyNameValueDto { Value="110", Name="Liechtenstein"}},
        {111,  new MyNameValueDto { Value="111", Name="Lithuania"}},
        {112,  new MyNameValueDto { Value="112", Name="Luxembourg"}},
        {113,  new MyNameValueDto { Value="113", Name="Macau S.A.R."}},
        {114,  new MyNameValueDto { Value="114", Name="Macedonia"}},
        {115,  new MyNameValueDto { Value="115", Name="Madagascar"}},
        {116,  new MyNameValueDto { Value="116", Name="Malawi"}},
        {117,  new MyNameValueDto { Value="117", Name="Malaysia"}},
        {118,  new MyNameValueDto { Value="118", Name="Maldives"}},
        {119,  new MyNameValueDto { Value="119", Name="Mali"}},
        {120,  new MyNameValueDto { Value="120", Name="Malta"}},
        {121,  new MyNameValueDto { Value="121", Name="Man (Isle of)"}},
        {122,  new MyNameValueDto { Value="122", Name="Marshall Islands"}},
        {123,  new MyNameValueDto { Value="123", Name="Martinique"}},
        {124,  new MyNameValueDto { Value="124", Name="Mauritania"}},
        {125,  new MyNameValueDto { Value="125", Name="Mauritius"}},
        {126,  new MyNameValueDto { Value="126", Name="Mayotte"}},
        {127,  new MyNameValueDto { Value="127", Name="Mexico"}},
        {128,  new MyNameValueDto { Value="128", Name="Micronesia"}},
        {129,  new MyNameValueDto { Value="129", Name="Moldova"}},
        {130,  new MyNameValueDto { Value="130", Name="Monaco"}},
        {131,  new MyNameValueDto { Value="131", Name="Mongolia"}},
        {132,  new MyNameValueDto { Value="132", Name="Montserrat"}},
        {133,  new MyNameValueDto { Value="133", Name="Morocco"}},
        {134,  new MyNameValueDto { Value="134", Name="Mozambique"}},
        {135,  new MyNameValueDto { Value="135", Name="Myanmar"}},
        {136,  new MyNameValueDto { Value="136", Name="Namibia"}},
        {137,  new MyNameValueDto { Value="137", Name="Nauru"}},
        {138,  new MyNameValueDto { Value="138", Name="Nepal"}},
        {139,  new MyNameValueDto { Value="139", Name="Netherlands Antilles"}},
        {140,  new MyNameValueDto { Value="140", Name="Netherlands The"}},
        {141,  new MyNameValueDto { Value="141", Name="New Caledonia"}},
        {142,  new MyNameValueDto { Value="142", Name="New Zealand"}},
        {143,  new MyNameValueDto { Value="143", Name="Nicaragua"}},
        {144,  new MyNameValueDto { Value="144", Name="Niger"}},
        {145,  new MyNameValueDto { Value="145", Name="Nigeria"}},
        {146,  new MyNameValueDto { Value="146", Name="Niue"}},
        {147,  new MyNameValueDto { Value="147", Name="Northern Mariana Islands"}},
        {148,  new MyNameValueDto { Value="148", Name="Norway"}},
        {149,  new MyNameValueDto { Value="149", Name="Oman"}},
        {150,  new MyNameValueDto { Value="150", Name="Pakistan"}},
        {151,  new MyNameValueDto { Value="151", Name="Palau"}},
        {152,  new MyNameValueDto { Value="152", Name="Palestinian Territory Occupied"}},
        {153,  new MyNameValueDto { Value="153", Name="Panama"}},
        {154,  new MyNameValueDto { Value="154", Name="Papua new Guinea"}},
        {155,  new MyNameValueDto { Value="155", Name="Paraguay"}},
        {156,  new MyNameValueDto { Value="156", Name="Peru"}},
        {157,  new MyNameValueDto { Value="157", Name="Philippines"}},
        {158,  new MyNameValueDto { Value="158", Name="Poland"}},
        {159,  new MyNameValueDto { Value="159", Name="Portugal"}},
        {160,  new MyNameValueDto { Value="160", Name="Puerto Rico"}},
        {161,  new MyNameValueDto { Value="161", Name="Qatar"}},
        {162,  new MyNameValueDto { Value="162", Name="Reunion"}},
        {163,  new MyNameValueDto { Value="163", Name="Romania"}},
        {164,  new MyNameValueDto { Value="164", Name="Russia"}},
        {165,  new MyNameValueDto { Value="165", Name="Rwanda"}},
        {166,  new MyNameValueDto { Value="166", Name="Saint Helena"}},
        {167,  new MyNameValueDto { Value="167", Name="Saint Lucia"}},
        {168,  new MyNameValueDto { Value="168", Name="Saint Pierre and Miquelon"}},
        {169,  new MyNameValueDto { Value="169", Name="Saint Vincent And The Grenadines"}},
        {170,  new MyNameValueDto { Value="170", Name="Samoa"}},
        {171,  new MyNameValueDto { Value="171", Name="San Marino"}},
        {172,  new MyNameValueDto { Value="172", Name="Sao Tome and Principe"}},
        {173,  new MyNameValueDto { Value="173", Name="Saudi Arabia"}},
        {174,  new MyNameValueDto { Value="174", Name="Senegal"}},
        {175,  new MyNameValueDto { Value="175", Name="Seychelles"}},
        {176,  new MyNameValueDto { Value="176", Name="Sierra Leone"}},
        {177,  new MyNameValueDto { Value="177", Name="Singapore"}},
        {178,  new MyNameValueDto { Value="178", Name="Slovakia"}},
        {179,  new MyNameValueDto { Value="179", Name="Slovenia"}},
        {180,  new MyNameValueDto { Value="180", Name="Smaller Territories of the UK"}},
        {181,  new MyNameValueDto { Value="181", Name="Solomon Islands"}},
        {182,  new MyNameValueDto { Value="182", Name="Somalia"}},
        {183,  new MyNameValueDto { Value="183", Name="South Africa"}},
        {184,  new MyNameValueDto { Value="184", Name="Spain"}},
        {185,  new MyNameValueDto { Value="185", Name="Sri Lanka"}},
        {186,  new MyNameValueDto { Value="186", Name="Sudan"}},
        {187,  new MyNameValueDto { Value="187", Name="SuriText"}},
        {188,  new MyNameValueDto { Value="188", Name="Svalbard And Jan Mayen Islands"}},
        {189,  new MyNameValueDto { Value="189", Name="Swaziland"}},
        {190,  new MyNameValueDto { Value="190", Name="Sweden"}},
        {191,  new MyNameValueDto { Value="191", Name="Switzerland"}},
        {192,  new MyNameValueDto { Value="192", Name="Syria"}},
        {193,  new MyNameValueDto { Value="193", Name="Taiwan"}},
        {194,  new MyNameValueDto { Value="194", Name="Tajikistan"}},
        {195,  new MyNameValueDto { Value="195", Name="Tanzania"}},
        {196,  new MyNameValueDto { Value="196", Name="Thailand"}},
        {197,  new MyNameValueDto { Value="197", Name="Togo"}},
        {198,  new MyNameValueDto { Value="198", Name="Tokelau"}},
        {199,  new MyNameValueDto { Value="199", Name="Tonga"}},
        {200,  new MyNameValueDto { Value="200", Name="TrinValuead And Tobago"}},
        {201,  new MyNameValueDto { Value="201", Name="Tunisia"}},
        {203,  new MyNameValueDto { Value="203", Name="Turkmenistan"}},
        {204,  new MyNameValueDto { Value="204", Name="Tuvalu"}},
        {205,  new MyNameValueDto { Value="205", Name="Uganda"}},
        {206,  new MyNameValueDto { Value="206", Name="Ukraine"}},
        {207,  new MyNameValueDto { Value="207", Name="United Arab Emirates"}},
        {208,  new MyNameValueDto { Value="208", Name="United Kingdom"}},
        {209,  new MyNameValueDto { Value="209", Name="United States"}},
        {210,  new MyNameValueDto { Value="210", Name="Uruguay"}},
        {211,  new MyNameValueDto { Value="211", Name="Uzbekistan"}},
        {212,  new MyNameValueDto { Value="212", Name="Vanuatu"}},
        {213,  new MyNameValueDto { Value="213", Name="Venezuela"}},
        {214,  new MyNameValueDto { Value="214", Name="Vietnam"}},
        {215,  new MyNameValueDto { Value="215", Name="Virgin Islands (British)"}},
        {216,  new MyNameValueDto { Value="216", Name="Wallis And Futuna Islands"}},
        {217,  new MyNameValueDto { Value="217", Name="Western Sahara"}},
        {218,  new MyNameValueDto { Value="218", Name="Yemen"}},
        {219,  new MyNameValueDto { Value="219", Name="Yugoslavia"}},
        {220,  new MyNameValueDto { Value="220", Name="Zambia"}},
        {221,  new MyNameValueDto { Value="221", Name="Zimbabwe"} }
       });
        private static Lazy<HashSet<MyNameValueDto>> _boyaTipi = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
            new MyNameValueDto { Value= "1", Name= "Çile Boya" },
            new MyNameValueDto { Value= "2", Name= "Bobin boya" }
        });
        private static Lazy<HashSet<MyNameValueDto>> _boyaYonu = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "Dogrusal" },
                new MyNameValueDto { Value= "2", Name= "Dairesel" },
                new MyNameValueDto { Value= "3", Name= "Açılı" },
                new MyNameValueDto { Value= "4", Name= "Simetrik" },
                new MyNameValueDto { Value= "5", Name= "Dörtgen" }
        });
        //ELASTAN
        private static Lazy<HashSet<MyNameValueDto>> _elastan = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "%10 FULL ELASTANE" },
                new MyNameValueDto { Value= "2", Name= "%5 YARIM ELASTANE" },
                new MyNameValueDto { Value= "3", Name= "YOK" }            
        });

        private static Lazy<HashSet<MyNameValueDto>> _yikamaSekilleri = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "ELDE" },
                new MyNameValueDto { Value= "2", Name= "TERS" },
                new MyNameValueDto { Value= "3", Name= "MAKINE" }
        });

        //TUP - ACIK EN
        private static Lazy<HashSet<MyNameValueDto>> _tupAcikEn = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "ACIK EN" },
                new MyNameValueDto { Value= "2", Name= "ACIK EN/TUP" },
                new MyNameValueDto { Value= "3", Name= "TUP" }
        });
        //AKSESUAR
        private static Lazy<HashSet<MyNameValueDto>> _aksesuar = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "DIL ACICI" },
                new MyNameValueDto { Value= "2", Name= "MECLI" },
        });

        private static Lazy<HashSet<MyNameValueDto>> _bedenKaliplari = new Lazy<HashSet<MyNameValueDto>>(() => new HashSet<MyNameValueDto>() {
                new MyNameValueDto { Value= "1", Name= "Boy" },
                new MyNameValueDto { Value= "2", Name= "En" },
                new MyNameValueDto { Value= "3", Name= "Ense" },
                new MyNameValueDto { Value= "4", Name= "Kolboyu" },
                new MyNameValueDto { Value= "5", Name= "Omuz" },
        });





        public HashSet<MyNameValueDto> GetAllElastan()
        {
            return _elastan.Value;
        }
        public HashSet<MyNameValueDto> GetAllTupAcikEn()
        {
            return _tupAcikEn.Value;
        }
        public HashSet<MyNameValueDto> GetAllAksesuar()
        {
            return _aksesuar.Value;
        }

        public List<MyNameValueDto> GetAllCountry()
        {
            return _ulkeler.Value.Values.ToList();
        }

        public HashSet<MyNameValueDto> GetAllBoyaTipi()
        {
            return _boyaTipi.Value;
        }

        public HashSet<MyNameValueDto> GetAllBoyaYonu()
        {
            return _boyaYonu.Value;
        }
        public MyNameValueDto GetCountryById(int? id)
        {
            if (!id.HasValue)
            {
                return new MyNameValueDto();
            }

            if (!_ulkeler.Value.ContainsKey(id.Value))
                return new MyNameValueDto();
            return _ulkeler.Value[id.Value];
        }


        public string GetCountryNameById(int id)
        {
            return (GetCountryById(id) ?? new MyNameValueDto()).Name;
        }

        private static Lazy<HashSet<MyNameValueDto>> _makineModelYillar = new Lazy<HashSet<MyNameValueDto>>(() =>
        {
            var modelYillar = new HashSet<MyNameValueDto>();
            for (int i = 1970; i <= 2050; i++)
            {
                modelYillar.Add(new MyNameValueDto
                {
                    Value = i.ToString(),
                    Name = i.ToString()
                });
            }
            return modelYillar;
        });
        private static Lazy<HashSet<MyNameValueDto>> _makinePuslar = new Lazy<HashSet<MyNameValueDto>>(() =>
        {
            var set = new HashSet<MyNameValueDto>();
            for (int i = 2; i <= 60; i++)
            {
                set.Add(new MyNameValueDto
                {
                    Value = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<MyNameValueDto>> _makineFinelar = new Lazy<HashSet<MyNameValueDto>>(() =>
        {
            var set = new HashSet<MyNameValueDto>();
            for (int i = 2; i <= 90; i++)
            {
                set.Add(new MyNameValueDto
                {
                    Value = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<MyNameValueDto>> _makineYedekFinelar = new Lazy<HashSet<MyNameValueDto>>(() =>
        {
            var set = new HashSet<MyNameValueDto>();
            for (int i = 2; i <= 90; i++)
            {
                set.Add(new MyNameValueDto
                {
                    Value = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        private static Lazy<HashSet<MyNameValueDto>> _makineSistem = new Lazy<HashSet<MyNameValueDto>>(() =>
        {
            var set = new HashSet<MyNameValueDto>();
            for (int i = 2; i <= 135; i++)
            {
                set.Add(new MyNameValueDto
                {
                    Value = i.ToString(),
                    Name = i.ToString()
                });
            }
            return set;
        });
        //private static Lazy<HashSet<MyNameValueDto>> _makineIgneSayisi = new Lazy<HashSet<MyNameValueDto>>(() =>
        //{
        //    var set = new ConcurrentBag<MyNameValueDto>();
        //    for (int i = 15; i <= 16965; i++)
        //    {
        //        set.Add(new MyNameValueDto
        //        {
        //            Id = i.ToString(),
        //            Name = i.ToString()
        //        });
        //    }
        //    return set.ToList();
        //});
        public HashSet<MyNameValueDto> GetAllMakineModelYillari()
        {
            return _makineModelYillar.Value;
        }

        public HashSet<MyNameValueDto> GetAllMakinePusYillari()
        {
            return _makinePuslar.Value;
        }

        public HashSet<MyNameValueDto> GetAllMakineFinelar()
        {
            throw new NotImplementedException();
        }

        public HashSet<MyNameValueDto> GetAllMakineYedekFinelar()
        {
            throw new NotImplementedException();
        }

        public HashSet<MyNameValueDto> GetAllMakineYedekSistemler()
        {
            throw new NotImplementedException();
        }

        public HashSet<MyNameValueDto> GetAllMakineIgneSayisi()
        {
            throw new NotImplementedException();
        }

        public HashSet<MyNameValueDto> GetYikamaSekilleri()
        {
           return _yikamaSekilleri.Value;
        }

        public HashSet<MyNameValueDto> GetBedenKaliplari()
        {
            return _bedenKaliplari.Value;
        }
    }
}
