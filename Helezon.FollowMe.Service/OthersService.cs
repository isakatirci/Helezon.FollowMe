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
        List<PairIdNameDto> GetAllCountry();
        HashSet<PairIdNameDto> GetAllBoyaTipi();
        HashSet<PairIdNameDto> GetAllBoyaYonu();
        PairIdNameDto GetCountryById(int id);
        //PairIdNameDto GetCountryById(int id);
        //string GetCountryNameById(int id);
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



        private static Lazy<Dictionary<int, PairIdNameDto>> _ulkeler = new Lazy<Dictionary<int, PairIdNameDto>>(() => new Dictionary<int, PairIdNameDto> {
        {1,    new PairIdNameDto { Id="1",  Name="Turkey"}},
        {2,    new PairIdNameDto { Id="2",  Name="Greece"}},
        {202,  new PairIdNameDto { Id="202",Name="Afghanistan"}},
        {73,   new PairIdNameDto { Id="73", Name="Albania"}},
        {3,    new PairIdNameDto { Id="3",  Name="Algeria"}},
        {4,    new PairIdNameDto { Id="4",  Name="American Samoa"}},
        {5,    new PairIdNameDto { Id="5",  Name="Andorra"}},
        {6,    new PairIdNameDto { Id="6",  Name="Angola"}},
        {7,    new PairIdNameDto { Id="7",  Name="Antigua And Barbuda"}},
        {8,    new PairIdNameDto { Id="8",  Name="Argentina"}},
        {9,    new PairIdNameDto { Id="9",  Name="Armenia"}},
        {10,   new PairIdNameDto { Id="10", Name="Aruba"}},
        {11,   new PairIdNameDto { Id="11", Name="Australia"}},
        {12,   new PairIdNameDto { Id="12", Name="Austria"}},
        {13,   new PairIdNameDto { Id="13", Name="Azerbaijan"}},
        {14,   new PairIdNameDto { Id="14", Name="Bahamas The"}},
        {15,   new PairIdNameDto { Id="15", Name="Bahrain"}},
        {16,   new PairIdNameDto { Id="16", Name="Bangladesh"}},
        {17,   new PairIdNameDto { Id="17", Name="Belarus"}},
        {18,   new PairIdNameDto { Id="18", Name="Belgium"}},
        {19,   new PairIdNameDto { Id="19", Name="Belize"}},
        {20,   new PairIdNameDto { Id="20", Name="Benin"}},
        {21,   new PairIdNameDto { Id="21", Name="Bermuda"}},
        {22,   new PairIdNameDto { Id="22", Name="Bhutan"}},
        {23,   new PairIdNameDto { Id="23", Name="Bolivia"}},
        {24,   new PairIdNameDto { Id="24", Name="Botswana"}},
        {25,   new PairIdNameDto { Id="25", Name="Brazil"}},
        {26,   new PairIdNameDto { Id="26", Name="Brunei"}},
        {27,   new PairIdNameDto { Id="27", Name="Bulgaria"}},
        {28,   new PairIdNameDto { Id="28", Name="Burkina Faso"}},
        {29,   new PairIdNameDto { Id="29", Name="Burundi"}},
        {30,   new PairIdNameDto { Id="30", Name="Cambodia"}},
        {31,   new PairIdNameDto { Id="31", Name="Cameroon"}},
        {32,   new PairIdNameDto { Id="32", Name="Canada"}},
        {33,   new PairIdNameDto { Id="33", Name="Cape Verde"}},
        {34,   new PairIdNameDto { Id="34", Name="Central African Republic"}},
        {35,   new PairIdNameDto { Id="35", Name="Chad"}},
        {36,   new PairIdNameDto { Id="36", Name="Chile"}},
        {37,   new PairIdNameDto { Id="37", Name="China"}},
        {38,   new PairIdNameDto { Id="38", Name="Colombia"}},
        {39,   new PairIdNameDto { Id="39", Name="Comoros"}},
        {40,   new PairIdNameDto { Id="40", Name="Congo"}},
        {41,   new PairIdNameDto { Id="41", Name="Congo The Democratic Republic Of The"}},
        {42,   new PairIdNameDto { Id="42", Name="Cook Islands"}},
        {43,   new PairIdNameDto { Id="43", Name="Costa Rica"}},
        {44,   new PairIdNameDto { Id="44", Name="Cote D'Ivoire (Ivory Coast)"}},
        {45,   new PairIdNameDto { Id="45", Name="Croatia (Hrvatska)"}},
        {46,   new PairIdNameDto { Id="46", Name="Cuba"}},
        {47,   new PairIdNameDto { Id="47", Name="Cyprus"}},
        {48,   new PairIdNameDto { Id="48", Name="Czech Republic"}},
        {49,   new PairIdNameDto { Id="49", Name="Denmark"}},
        {50,   new PairIdNameDto { Id="50", Name="Djibouti"}},
        {51,   new PairIdNameDto { Id="51", Name="Dominican Republic"}},
        {52,   new PairIdNameDto { Id="52", Name="East Timor"}},
        {53,   new PairIdNameDto { Id="53", Name="Ecuador"}},
        {54,   new PairIdNameDto { Id="54", Name="Egypt"}},
        {55,   new PairIdNameDto { Id="55", Name="El Salvador"}},
        {56,   new PairIdNameDto { Id="56", Name="Equatorial Guinea"}},
        {57,   new PairIdNameDto { Id="57", Name="Eritrea"}},
        {58,   new PairIdNameDto { Id="58", Name="Estonia"}},
        {59,   new PairIdNameDto { Id="59", Name="Ethiopia"}},
        {60,   new PairIdNameDto { Id="60", Name="Faroe Islands"}},
        {61,   new PairIdNameDto { Id="61", Name="Fiji Islands"}},
        {62,   new PairIdNameDto { Id="62", Name="Finland"}},
        {63,   new PairIdNameDto { Id="63", Name="France"}},
        {64,   new PairIdNameDto { Id="64", Name="French Guiana"}},
        {65,   new PairIdNameDto { Id="65", Name="French Polynesia"}},
        {66,   new PairIdNameDto { Id="66", Name="French Southern Territories"}},
        {67,   new PairIdNameDto { Id="67", Name="Gabon"}},
        {68,   new PairIdNameDto { Id="68", Name="Gambia The"}},
        {69,   new PairIdNameDto { Id="69", Name="Georgia"}},
        {70,   new PairIdNameDto { Id="70", Name="Germany"}},
        {71,   new PairIdNameDto { Id="71", Name="Ghana"}},
        {72,   new PairIdNameDto { Id="72", Name="Gibraltar"}},
        {74,   new PairIdNameDto { Id="74", Name="Greenland"}},
        {75,   new PairIdNameDto { Id="75", Name="Guadeloupe"}},
        {76,   new PairIdNameDto { Id="76", Name="Guam"}},
        {77,   new PairIdNameDto { Id="77", Name="Guatemala"}},
        {78,   new PairIdNameDto { Id="78", Name="Guernsey and Alderney"}},
        {79,   new PairIdNameDto { Id="79", Name="Guinea"}},
        {80,   new PairIdNameDto { Id="80", Name="Guinea-Bissau"}},
        {81,   new PairIdNameDto { Id="81", Name="Guyana"}},
        {82,   new PairIdNameDto { Id="82", Name="Haiti"}},
        {83,   new PairIdNameDto { Id="83", Name="Honduras"}},
        {84,   new PairIdNameDto { Id="84", Name="Hungary"}},
        {85,   new PairIdNameDto { Id="85", Name="Iceland"}},
        {86,   new PairIdNameDto { Id="86", Name="India"}},
        {87,   new PairIdNameDto { Id="87", Name="Indonesia"}},
        {88,   new PairIdNameDto { Id="88", Name="Iran"}},
        {89,   new PairIdNameDto { Id="89", Name="Iraq"}},
        {90,   new PairIdNameDto { Id="90", Name="Ireland"}},
        {91,   new PairIdNameDto { Id="91", Name="Israel"}},
        {92,   new PairIdNameDto { Id="92", Name="Italy"}},
        {93,   new PairIdNameDto { Id="93", Name="Jamaica"}},
        {94,   new PairIdNameDto { Id="94", Name="Japan"}},
        {95,   new PairIdNameDto { Id="95", Name="Jersey"}},
        {96,   new PairIdNameDto { Id="96", Name="Jordan"}},
        {97,   new PairIdNameDto { Id="97", Name="Kazakhstan"}},
        {98,   new PairIdNameDto { Id="98", Name="Kenya"}},
        {99,   new PairIdNameDto { Id="99", Name="Kiribati"}},
        {100,  new PairIdNameDto { Id="100", Name="Korea North"}},
        {101,  new PairIdNameDto { Id="101", Name="Korea South"}},
        {102,  new PairIdNameDto { Id="102", Name="Kuwait"}},
        {103,  new PairIdNameDto { Id="103", Name="Kyrgyzstan"}},
        {104,  new PairIdNameDto { Id="104", Name="Laos"}},
        {105,  new PairIdNameDto { Id="105", Name="Latvia"}},
        {106,  new PairIdNameDto { Id="106", Name="Lebanon"}},
        {107,  new PairIdNameDto { Id="107", Name="Lesotho"}},
        {108,  new PairIdNameDto { Id="108", Name="Liberia"}},
        {109,  new PairIdNameDto { Id="109", Name="Libya"}},
        {110,  new PairIdNameDto { Id="110", Name="Liechtenstein"}},
        {111,  new PairIdNameDto { Id="111", Name="Lithuania"}},
        {112,  new PairIdNameDto { Id="112", Name="Luxembourg"}},
        {113,  new PairIdNameDto { Id="113", Name="Macau S.A.R."}},
        {114,  new PairIdNameDto { Id="114", Name="Macedonia"}},
        {115,  new PairIdNameDto { Id="115", Name="Madagascar"}},
        {116,  new PairIdNameDto { Id="116", Name="Malawi"}},
        {117,  new PairIdNameDto { Id="117", Name="Malaysia"}},
        {118,  new PairIdNameDto { Id="118", Name="Maldives"}},
        {119,  new PairIdNameDto { Id="119", Name="Mali"}},
        {120,  new PairIdNameDto { Id="120", Name="Malta"}},
        {121,  new PairIdNameDto { Id="121", Name="Man (Isle of)"}},
        {122,  new PairIdNameDto { Id="122", Name="Marshall Islands"}},
        {123,  new PairIdNameDto { Id="123", Name="Martinique"}},
        {124,  new PairIdNameDto { Id="124", Name="Mauritania"}},
        {125,  new PairIdNameDto { Id="125", Name="Mauritius"}},
        {126,  new PairIdNameDto { Id="126", Name="Mayotte"}},
        {127,  new PairIdNameDto { Id="127", Name="Mexico"}},
        {128,  new PairIdNameDto { Id="128", Name="Micronesia"}},
        {129,  new PairIdNameDto { Id="129", Name="Moldova"}},
        {130,  new PairIdNameDto { Id="130", Name="Monaco"}},
        {131,  new PairIdNameDto { Id="131", Name="Mongolia"}},
        {132,  new PairIdNameDto { Id="132", Name="Montserrat"}},
        {133,  new PairIdNameDto { Id="133", Name="Morocco"}},
        {134,  new PairIdNameDto { Id="134", Name="Mozambique"}},
        {135,  new PairIdNameDto { Id="135", Name="Myanmar"}},
        {136,  new PairIdNameDto { Id="136", Name="Namibia"}},
        {137,  new PairIdNameDto { Id="137", Name="Nauru"}},
        {138,  new PairIdNameDto { Id="138", Name="Nepal"}},
        {139,  new PairIdNameDto { Id="139", Name="Netherlands Antilles"}},
        {140,  new PairIdNameDto { Id="140", Name="Netherlands The"}},
        {141,  new PairIdNameDto { Id="141", Name="New Caledonia"}},
        {142,  new PairIdNameDto { Id="142", Name="New Zealand"}},
        {143,  new PairIdNameDto { Id="143", Name="Nicaragua"}},
        {144,  new PairIdNameDto { Id="144", Name="Niger"}},
        {145,  new PairIdNameDto { Id="145", Name="Nigeria"}},
        {146,  new PairIdNameDto { Id="146", Name="Niue"}},
        {147,  new PairIdNameDto { Id="147", Name="Northern Mariana Islands"}},
        {148,  new PairIdNameDto { Id="148", Name="Norway"}},
        {149,  new PairIdNameDto { Id="149", Name="Oman"}},
        {150,  new PairIdNameDto { Id="150", Name="Pakistan"}},
        {151,  new PairIdNameDto { Id="151", Name="Palau"}},
        {152,  new PairIdNameDto { Id="152", Name="Palestinian Territory Occupied"}},
        {153,  new PairIdNameDto { Id="153", Name="Panama"}},
        {154,  new PairIdNameDto { Id="154", Name="Papua new Guinea"}},
        {155,  new PairIdNameDto { Id="155", Name="Paraguay"}},
        {156,  new PairIdNameDto { Id="156", Name="Peru"}},
        {157,  new PairIdNameDto { Id="157", Name="Philippines"}},
        {158,  new PairIdNameDto { Id="158", Name="Poland"}},
        {159,  new PairIdNameDto { Id="159", Name="Portugal"}},
        {160,  new PairIdNameDto { Id="160", Name="Puerto Rico"}},
        {161,  new PairIdNameDto { Id="161", Name="Qatar"}},
        {162,  new PairIdNameDto { Id="162", Name="Reunion"}},
        {163,  new PairIdNameDto { Id="163", Name="Romania"}},
        {164,  new PairIdNameDto { Id="164", Name="Russia"}},
        {165,  new PairIdNameDto { Id="165", Name="Rwanda"}},
        {166,  new PairIdNameDto { Id="166", Name="Saint Helena"}},
        {167,  new PairIdNameDto { Id="167", Name="Saint Lucia"}},
        {168,  new PairIdNameDto { Id="168", Name="Saint Pierre and Miquelon"}},
        {169,  new PairIdNameDto { Id="169", Name="Saint Vincent And The Grenadines"}},
        {170,  new PairIdNameDto { Id="170", Name="Samoa"}},
        {171,  new PairIdNameDto { Id="171", Name="San Marino"}},
        {172,  new PairIdNameDto { Id="172", Name="Sao Tome and Principe"}},
        {173,  new PairIdNameDto { Id="173", Name="Saudi Arabia"}},
        {174,  new PairIdNameDto { Id="174", Name="Senegal"}},
        {175,  new PairIdNameDto { Id="175", Name="Seychelles"}},
        {176,  new PairIdNameDto { Id="176", Name="Sierra Leone"}},
        {177,  new PairIdNameDto { Id="177", Name="Singapore"}},
        {178,  new PairIdNameDto { Id="178", Name="Slovakia"}},
        {179,  new PairIdNameDto { Id="179", Name="Slovenia"}},
        {180,  new PairIdNameDto { Id="180", Name="Smaller Territories of the UK"}},
        {181,  new PairIdNameDto { Id="181", Name="Solomon Islands"}},
        {182,  new PairIdNameDto { Id="182", Name="Somalia"}},
        {183,  new PairIdNameDto { Id="183", Name="South Africa"}},
        {184,  new PairIdNameDto { Id="184", Name="Spain"}},
        {185,  new PairIdNameDto { Id="185", Name="Sri Lanka"}},
        {186,  new PairIdNameDto { Id="186", Name="Sudan"}},
        {187,  new PairIdNameDto { Id="187", Name="SuriText"}},
        {188,  new PairIdNameDto { Id="188", Name="Svalbard And Jan Mayen Islands"}},
        {189,  new PairIdNameDto { Id="189", Name="Swaziland"}},
        {190,  new PairIdNameDto { Id="190", Name="Sweden"}},
        {191,  new PairIdNameDto { Id="191", Name="Switzerland"}},
        {192,  new PairIdNameDto { Id="192", Name="Syria"}},
        {193,  new PairIdNameDto { Id="193", Name="Taiwan"}},
        {194,  new PairIdNameDto { Id="194", Name="Tajikistan"}},
        {195,  new PairIdNameDto { Id="195", Name="Tanzania"}},
        {196,  new PairIdNameDto { Id="196", Name="Thailand"}},
        {197,  new PairIdNameDto { Id="197", Name="Togo"}},
        {198,  new PairIdNameDto { Id="198", Name="Tokelau"}},
        {199,  new PairIdNameDto { Id="199", Name="Tonga"}},
        {200,  new PairIdNameDto { Id="200", Name="TrinValuead And Tobago"}},
        {201,  new PairIdNameDto { Id="201", Name="Tunisia"}},
        {203,  new PairIdNameDto { Id="203", Name="Turkmenistan"}},
        {204,  new PairIdNameDto { Id="204", Name="Tuvalu"}},
        {205,  new PairIdNameDto { Id="205", Name="Uganda"}},
        {206,  new PairIdNameDto { Id="206", Name="Ukraine"}},
        {207,  new PairIdNameDto { Id="207", Name="United Arab Emirates"}},
        {208,  new PairIdNameDto { Id="208", Name="United Kingdom"}},
        {209,  new PairIdNameDto { Id="209", Name="United States"}},
        {210,  new PairIdNameDto { Id="210", Name="Uruguay"}},
        {211,  new PairIdNameDto { Id="211", Name="Uzbekistan"}},
        {212,  new PairIdNameDto { Id="212", Name="Vanuatu"}},
        {213,  new PairIdNameDto { Id="213", Name="Venezuela"}},
        {214,  new PairIdNameDto { Id="214", Name="Vietnam"}},
        {215,  new PairIdNameDto { Id="215", Name="Virgin Islands (British)"}},
        {216,  new PairIdNameDto { Id="216", Name="Wallis And Futuna Islands"}},
        {217,  new PairIdNameDto { Id="217", Name="Western Sahara"}},
        {218,  new PairIdNameDto { Id="218", Name="Yemen"}},
        {219,  new PairIdNameDto { Id="219", Name="Yugoslavia"}},
        {220,  new PairIdNameDto { Id="220", Name="Zambia"}},
        {221,  new PairIdNameDto { Id="221", Name="Zimbabwe"} }
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

        public List<PairIdNameDto> GetAllCountry()
        {
            return _ulkeler.Value.Values.ToList();
        }

        public HashSet<PairIdNameDto> GetAllBoyaTipi()
        {
            return _boyaTipi.Value;
        }

        public HashSet<PairIdNameDto> GetAllBoyaYonu()
        {
            return _boyaYonu.Value;
        }
        public PairIdNameDto GetCountryById(int id)
        {
            if (!_ulkeler.Value.ContainsKey(id))
                return new PairIdNameDto();
            return _ulkeler.Value[id]; 
        }


        public string GetCountryNameById(int id)
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
