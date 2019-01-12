using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    public class IdNameDto
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
    }


    public interface IOthersService
    {
        HashSet<IdNameDto> GetAllCountry();
        HashSet<IdNameDto> GetAllBoyaTipi();
        HashSet<IdNameDto> GetAllBoyaYonu();
        IdNameDto GetCountryById(string id);
        string GetCountryNameById(string id);
    }
    public class OthersService : IOthersService
    {
        private static Lazy<HashSet<IdNameDto>> _ulkeler = new Lazy<HashSet<IdNameDto>>(() => new HashSet<IdNameDto> {
           new IdNameDto { Id="1", Name="Turkey"},
              new IdNameDto { Id="2", Name="Greece"},
            new IdNameDto { Id="202", Name="Afghanistan"},
            new IdNameDto { Id="73", Name="Albania"},
            new IdNameDto { Id="3", Name="Algeria"},
            new IdNameDto { Id="4", Name="American Samoa"},
            new IdNameDto { Id="5", Name="Andorra"},
            new IdNameDto { Id="6", Name="Angola"},
            new IdNameDto { Id="7", Name="Antigua And Barbuda"},
            new IdNameDto { Id="8", Name="Argentina"},
            new IdNameDto { Id="9", Name="Armenia"},
            new IdNameDto { Id="10", Name="Aruba"},
            new IdNameDto { Id="11", Name="Australia"},
            new IdNameDto { Id="12", Name="Austria"},
            new IdNameDto { Id="13", Name="Azerbaijan"},
            new IdNameDto { Id="14", Name="Bahamas The"},
            new IdNameDto { Id="15", Name="Bahrain"},
            new IdNameDto { Id="16", Name="Bangladesh"},
            new IdNameDto { Id="17", Name="Belarus"},
            new IdNameDto { Id="18", Name="Belgium"},
            new IdNameDto { Id="19", Name="Belize"},
            new IdNameDto { Id="20", Name="Benin"},
            new IdNameDto { Id="21", Name="Bermuda"},
            new IdNameDto { Id="22", Name="Bhutan"},
            new IdNameDto { Id="23", Name="Bolivia"},
            new IdNameDto { Id="24", Name="Botswana"},
            new IdNameDto { Id="25", Name="Brazil"},
            new IdNameDto { Id="26", Name="Brunei"},
            new IdNameDto { Id="27", Name="Bulgaria"},
            new IdNameDto { Id="28", Name="Burkina Faso"},
            new IdNameDto { Id="29", Name="Burundi"},
            new IdNameDto { Id="30", Name="Cambodia"},
            new IdNameDto { Id="31", Name="Cameroon"},
            new IdNameDto { Id="32", Name="Canada"},
            new IdNameDto { Id="33", Name="Cape Verde"},
            new IdNameDto { Id="34", Name="Central African Republic"},
            new IdNameDto { Id="35", Name="Chad"},
            new IdNameDto { Id="36", Name="Chile"},
            new IdNameDto { Id="37", Name="China"},
            new IdNameDto { Id="38", Name="Colombia"},
            new IdNameDto { Id="39", Name="Comoros"},
            new IdNameDto { Id="40", Name="Congo"},
            new IdNameDto { Id="41", Name="Congo The Democratic Republic Of The"},
            new IdNameDto { Id="42", Name="Cook Islands"},
            new IdNameDto { Id="43", Name="Costa Rica"},
            new IdNameDto { Id="44", Name="Cote D'Ivoire (Ivory Coast)"},
            new IdNameDto { Id="45", Name="Croatia (Hrvatska)"},
            new IdNameDto { Id="46", Name="Cuba"},
            new IdNameDto { Id="47", Name="Cyprus"},
            new IdNameDto { Id="48", Name="Czech Republic"},
            new IdNameDto { Id="49", Name="Denmark"},
            new IdNameDto { Id="50", Name="Djibouti"},
            new IdNameDto { Id="51", Name="Dominican Republic"},
            new IdNameDto { Id="52", Name="East Timor"},
            new IdNameDto { Id="53", Name="Ecuador"},
            new IdNameDto { Id="54", Name="Egypt"},
            new IdNameDto { Id="55", Name="El Salvador"},
            new IdNameDto { Id="56", Name="Equatorial Guinea"},
            new IdNameDto { Id="57", Name="Eritrea"},
            new IdNameDto { Id="58", Name="Estonia"},
            new IdNameDto { Id="59", Name="Ethiopia"},
            new IdNameDto { Id="60", Name="Faroe Islands"},
            new IdNameDto { Id="61", Name="Fiji Islands"},
            new IdNameDto { Id="62", Name="Finland"},
            new IdNameDto { Id="63", Name="France"},
            new IdNameDto { Id="64", Name="French Guiana"},
            new IdNameDto { Id="65", Name="French Polynesia"},
            new IdNameDto { Id="66", Name="French Southern Territories"},
            new IdNameDto { Id="67", Name="Gabon"},
            new IdNameDto { Id="68", Name="Gambia The"},
            new IdNameDto { Id="69", Name="Georgia"},
            new IdNameDto { Id="70", Name="Germany"},
            new IdNameDto { Id="71", Name="Ghana"},
            new IdNameDto { Id="72", Name="Gibraltar"},

            new IdNameDto { Id="74", Name="Greenland"},
            new IdNameDto { Id="75", Name="Guadeloupe"},
            new IdNameDto { Id="76", Name="Guam"},
            new IdNameDto { Id="77", Name="Guatemala"},
            new IdNameDto { Id="78", Name="Guernsey and Alderney"},
            new IdNameDto { Id="79", Name="Guinea"},
            new IdNameDto { Id="80", Name="Guinea-Bissau"},
            new IdNameDto { Id="81", Name="Guyana"},
            new IdNameDto { Id="82", Name="Haiti"},
            new IdNameDto { Id="83", Name="Honduras"},
            new IdNameDto { Id="84", Name="Hungary"},
            new IdNameDto { Id="85", Name="Iceland"},
            new IdNameDto { Id="86", Name="India"},
            new IdNameDto { Id="87", Name="Indonesia"},
            new IdNameDto { Id="88", Name="Iran"},
            new IdNameDto { Id="89", Name="Iraq"},
            new IdNameDto { Id="90", Name="Ireland"},
            new IdNameDto { Id="91", Name="Israel"},
            new IdNameDto { Id="92", Name="Italy"},
            new IdNameDto { Id="93", Name="Jamaica"},
            new IdNameDto { Id="94", Name="Japan"},
            new IdNameDto { Id="95", Name="Jersey"},
            new IdNameDto { Id="96", Name="Jordan"},
            new IdNameDto { Id="97", Name="Kazakhstan"},
            new IdNameDto { Id="98", Name="Kenya"},
            new IdNameDto { Id="99", Name="Kiribati"},
            new IdNameDto { Id="100", Name="Korea North"},
            new IdNameDto { Id="101", Name="Korea South"},
            new IdNameDto { Id="102", Name="Kuwait"},
            new IdNameDto { Id="103", Name="Kyrgyzstan"},
            new IdNameDto { Id="104", Name="Laos"},
            new IdNameDto { Id="105", Name="Latvia"},
            new IdNameDto { Id="106", Name="Lebanon"},
            new IdNameDto { Id="107", Name="Lesotho"},
            new IdNameDto { Id="108", Name="Liberia"},
            new IdNameDto { Id="109", Name="Libya"},
            new IdNameDto { Id="110", Name="Liechtenstein"},
            new IdNameDto { Id="111", Name="Lithuania"},
            new IdNameDto { Id="112", Name="Luxembourg"},
            new IdNameDto { Id="113", Name="Macau S.A.R."},
            new IdNameDto { Id="114", Name="Macedonia"},
            new IdNameDto { Id="115", Name="Madagascar"},
            new IdNameDto { Id="116", Name="Malawi"},
            new IdNameDto { Id="117", Name="Malaysia"},
            new IdNameDto { Id="118", Name="Maldives"},
            new IdNameDto { Id="119", Name="Mali"},
            new IdNameDto { Id="120", Name="Malta"},
            new IdNameDto { Id="121", Name="Man (Isle of)"},
            new IdNameDto { Id="122", Name="Marshall Islands"},
            new IdNameDto { Id="123", Name="Martinique"},
            new IdNameDto { Id="124", Name="Mauritania"},
            new IdNameDto { Id="125", Name="Mauritius"},
            new IdNameDto { Id="126", Name="Mayotte"},
            new IdNameDto { Id="127", Name="Mexico"},
            new IdNameDto { Id="128", Name="Micronesia"},
            new IdNameDto { Id="129", Name="Moldova"},
            new IdNameDto { Id="130", Name="Monaco"},
            new IdNameDto { Id="131", Name="Mongolia"},
            new IdNameDto { Id="132", Name="Montserrat"},
            new IdNameDto { Id="133", Name="Morocco"},
            new IdNameDto { Id="134", Name="Mozambique"},
            new IdNameDto { Id="135", Name="Myanmar"},
            new IdNameDto { Id="136", Name="Namibia"},
            new IdNameDto { Id="137", Name="Nauru"},
            new IdNameDto { Id="138", Name="Nepal"},
            new IdNameDto { Id="139", Name="Netherlands Antilles"},
            new IdNameDto { Id="140", Name="Netherlands The"},
            new IdNameDto { Id="141", Name="New Caledonia"},
            new IdNameDto { Id="142", Name="New Zealand"},
            new IdNameDto { Id="143", Name="Nicaragua"},
            new IdNameDto { Id="144", Name="Niger"},
            new IdNameDto { Id="145", Name="Nigeria"},
            new IdNameDto { Id="146", Name="Niue"},
            new IdNameDto { Id="147", Name="Northern Mariana Islands"},
            new IdNameDto { Id="148", Name="Norway"},
            new IdNameDto { Id="149", Name="Oman"},
            new IdNameDto { Id="150", Name="Pakistan"},
            new IdNameDto { Id="151", Name="Palau"},
            new IdNameDto { Id="152", Name="Palestinian Territory Occupied"},
            new IdNameDto { Id="153", Name="Panama"},
            new IdNameDto { Id="154", Name="Papua new Guinea"},
            new IdNameDto { Id="155", Name="Paraguay"},
            new IdNameDto { Id="156", Name="Peru"},
            new IdNameDto { Id="157", Name="Philippines"},
            new IdNameDto { Id="158", Name="Poland"},
            new IdNameDto { Id="159", Name="Portugal"},
            new IdNameDto { Id="160", Name="Puerto Rico"},
            new IdNameDto { Id="161", Name="Qatar"},
            new IdNameDto { Id="162", Name="Reunion"},
            new IdNameDto { Id="163", Name="Romania"},
            new IdNameDto { Id="164", Name="Russia"},
            new IdNameDto { Id="165", Name="Rwanda"},
            new IdNameDto { Id="166", Name="Saint Helena"},
            new IdNameDto { Id="167", Name="Saint Lucia"},
            new IdNameDto { Id="168", Name="Saint Pierre and Miquelon"},
            new IdNameDto { Id="169", Name="Saint Vincent And The Grenadines"},
            new IdNameDto { Id="170", Name="Samoa"},
            new IdNameDto { Id="171", Name="San Marino"},
            new IdNameDto { Id="172", Name="Sao Tome and Principe"},
            new IdNameDto { Id="173", Name="Saudi Arabia"},
            new IdNameDto { Id="174", Name="Senegal"},
            new IdNameDto { Id="175", Name="Seychelles"},
            new IdNameDto { Id="176", Name="Sierra Leone"},
            new IdNameDto { Id="177", Name="Singapore"},
            new IdNameDto { Id="178", Name="Slovakia"},
            new IdNameDto { Id="179", Name="Slovenia"},
            new IdNameDto { Id="180", Name="Smaller Territories of the UK"},
            new IdNameDto { Id="181", Name="Solomon Islands"},
            new IdNameDto { Id="182", Name="Somalia"},
            new IdNameDto { Id="183", Name="South Africa"},
            new IdNameDto { Id="184", Name="Spain"},
            new IdNameDto { Id="185", Name="Sri Lanka"},
            new IdNameDto { Id="186", Name="Sudan"},
            new IdNameDto { Id="187", Name="SuriText"},
            new IdNameDto { Id="188", Name="Svalbard And Jan Mayen Islands"},
            new IdNameDto { Id="189", Name="Swaziland"},
            new IdNameDto { Id="190", Name="Sweden"},
            new IdNameDto { Id="191", Name="Switzerland"},
            new IdNameDto { Id="192", Name="Syria"},
            new IdNameDto { Id="193", Name="Taiwan"},
            new IdNameDto { Id="194", Name="Tajikistan"},
            new IdNameDto { Id="195", Name="Tanzania"},
            new IdNameDto { Id="196", Name="Thailand"},
            new IdNameDto { Id="197", Name="Togo"},
            new IdNameDto { Id="198", Name="Tokelau"},
            new IdNameDto { Id="199", Name="Tonga"},
            new IdNameDto { Id="200", Name="TrinValuead And Tobago"},
            new IdNameDto { Id="201", Name="Tunisia"},

            new IdNameDto { Id="203", Name="Turkmenistan"},
            new IdNameDto { Id="204", Name="Tuvalu"},
            new IdNameDto { Id="205", Name="Uganda"},
            new IdNameDto { Id="206", Name="Ukraine"},
            new IdNameDto { Id="207", Name="United Arab Emirates"},
            new IdNameDto { Id="208", Name="United Kingdom"},
            new IdNameDto { Id="209", Name="United States"},
            new IdNameDto { Id="210", Name="Uruguay"},
            new IdNameDto { Id="211", Name="Uzbekistan"},
            new IdNameDto { Id="212", Name="Vanuatu"},
            new IdNameDto { Id="213", Name="Venezuela"},
            new IdNameDto { Id="214", Name="Vietnam"},
            new IdNameDto { Id="215", Name="Virgin Islands (British)"},
            new IdNameDto { Id="216", Name="Wallis And Futuna Islands"},
            new IdNameDto { Id="217", Name="Western Sahara"},
            new IdNameDto { Id="218", Name="Yemen"},
            new IdNameDto { Id="219", Name="Yugoslavia"},
            new IdNameDto { Id="220", Name="Zambia"},
            new IdNameDto { Id="221", Name="Zimbabwe"}
       });
        private static Lazy<HashSet<IdNameDto>> _boyaTipi = new Lazy<HashSet<IdNameDto>>(() => new HashSet<IdNameDto>() {
            new IdNameDto { Id= "1", Name= "Çile Boya" },
            new IdNameDto { Id= "2", Name= "Bobin boya" }
        });
        private static Lazy<HashSet<IdNameDto>> _boyaYonu = new Lazy<HashSet<IdNameDto>>(() => new HashSet<IdNameDto>() {
                new IdNameDto { Id= "1", Name= "Dogrusal" },
                new IdNameDto { Id= "2", Name= "Dairesel" },
                new IdNameDto { Id= "3", Name= "Açılı" },
                new IdNameDto { Id= "4", Name= "Simetrik" },
                new IdNameDto { Id= "5", Name= "Dörtgen" }
        });

        public HashSet<IdNameDto> GetAllCountry()
        {
            return _ulkeler.Value;
        }

        public HashSet<IdNameDto> GetAllBoyaTipi()
        {
            return _boyaTipi.Value;
        }

        public HashSet<IdNameDto> GetAllBoyaYonu()
        {
            return _boyaYonu.Value;
        }
        public IdNameDto GetCountryById(string id)
        {
            return _ulkeler.Value.FirstOrDefault(x=>x.Id == id);
        }

        public string GetCountryNameById(string id)
        {
            return (GetCountryById(id) ?? new IdNameDto()).Name;
        }
    }
}
