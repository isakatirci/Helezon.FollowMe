using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web.Controllers
{
    public class PairIdName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Utils
    {
        public static Dictionary<CompanyRootType, string> CompanyTypeNames = new Dictionary<CompanyRootType, string>();
        public static Dictionary<Tuple<EntityType, TelephoneType>, string> TelephoneTypeNames = new Dictionary<Tuple<EntityType, TelephoneType>, string>();
        public static Dictionary<Tuple<EntityType, AddressType>, string> AddressTypeNames = new Dictionary<Tuple<EntityType, AddressType>, string>();

        public static Dictionary<BloodGroup, string> BloodGroupNames = new Dictionary<BloodGroup, string>();        //
        public static Dictionary<TaxonomyType, string> TaxonomyNames = new Dictionary<TaxonomyType, string>();
        public static Dictionary<TaxonomyType, string> TaxonomyNamesZCode = new Dictionary<TaxonomyType, string>();
        public static Dictionary<EntityType, string> ObjectTypeNames = new Dictionary<EntityType, string>();
        public static Dictionary<FormFieldType, string> FormFieldTypeNames = new Dictionary<FormFieldType, string>();        //
        public static Dictionary<GenderType, string> GenderTypeNames = new Dictionary<GenderType, string>();
        public static Dictionary<ColorType, Tuple<string, string>> ColorTypeNames = new Dictionary<ColorType, Tuple<string, string>>();
        public static List<Tuple<int, string>> AreaCodes = new List<Tuple<int, string>>();
        public static List<PairIdName> DisplayAreaCodes = new List<PairIdName>();
        public static List<SelectListItem> SelectListItemRequired = new List<SelectListItem>();
        public static List<SelectListItem> SelectListItemRepeated = new List<SelectListItem>();


        protected static Lazy<List<PairIdName>> _areaCodes = new Lazy<List<PairIdName>>(FillAreaCodes);
        private static List<PairIdName> FillAreaCodes()
        {
            if (DisplayAreaCodes.Any())
                return DisplayAreaCodes;

            DisplayAreaCodes.AddRange(AreaCodes.Select(x => new PairIdName { Id = x.Item2 + " (+" + x.Item1 + ")", Name = " (+" + x.Item1 + ")" }));

            return DisplayAreaCodes;
        }

        public static List<PairIdName> GetAreaCodes()
        {
            return _areaCodes.Value;
        }

        protected static Lazy<List<PairIdName>> _areaCodesWithCountry = new Lazy<List<PairIdName>>(FillAreaCodesWithCountry);
        private static List<PairIdName> FillAreaCodesWithCountry()
        {
            //if (DisplayAreaCodes.Any())
            //    return DisplayAreaCodes;
            return AreaCodes.Select(x => new PairIdName { Id = x.Item2 + " (+" + x.Item1 + ")", Name = x.Item2 + " (+" + x.Item1 + ")" }).ToList();
        }

        public static List<PairIdName> GetAreaCodesWithCountry()
        {
            return _areaCodesWithCountry.Value;
        }

        static Utils()
        {

            SelectListItemRequired.Add(new SelectListItem { Text = "Required", Value = "true" });
            SelectListItemRequired.Add(new SelectListItem { Text = "Not Required", Value = "false" });

            SelectListItemRepeated.Add(new SelectListItem { Text = "Repeated", Value = "true" });
            SelectListItemRepeated.Add(new SelectListItem { Text = "Not Repeated", Value = "false" });


            //CompanyTypeNames.Add(CompanyType.Demo, "Demo");
            //CompanyTypeNames.Add(CompanyType.Gercek, "Gerçek");
            CompanyTypeNames.Add(CompanyRootType.Red, "Red");
            CompanyTypeNames.Add(CompanyRootType.Blue, "Blue");
            CompanyTypeNames.Add(CompanyRootType.Zetaa, "Zetaa");
            CompanyTypeNames.Add(CompanyRootType.Others, "Others");



            AddressTypeNames.Add(Tuple.Create(EntityType.Company, AddressType.Merkez), "Merkez");
            AddressTypeNames.Add(Tuple.Create(EntityType.Company, AddressType.YurtIciOfis), "Yurt İçi Ofis");
            AddressTypeNames.Add(Tuple.Create(EntityType.Company, AddressType.YurtDisiOfis), "Yurt Dışı Ofis");
            AddressTypeNames.Add(Tuple.Create(EntityType.Company, AddressType.Depo), "Depo");
            AddressTypeNames.Add(Tuple.Create(EntityType.Company, AddressType.Boyahane), "Boyahane");
            AddressTypeNames.Add(Tuple.Create(EntityType.Person, AddressType.Home), "Home");



            GenderTypeNames.Add(GenderType.Male, "Bay");
            GenderTypeNames.Add(GenderType.Female, "Bayan");

            ColorTypeNames.Add(ColorType.Blue, Tuple.Create("Blue", "#3598dc"));
            ColorTypeNames.Add(ColorType.Red, Tuple.Create("Red", "#e7505a"));
            ColorTypeNames.Add(ColorType.Green, Tuple.Create("Green", "#32c5d2"));
            ColorTypeNames.Add(ColorType.Purple, Tuple.Create("Purple", "#8E44AD"));


            FormFieldTypeNames.Add(FormFieldType.Text, "Kısa Cevap");
            FormFieldTypeNames.Add(FormFieldType.TextArea, "Açıklama");
            FormFieldTypeNames.Add(FormFieldType.SelectSingle, "Tekli Seçim");
            FormFieldTypeNames.Add(FormFieldType.SelectMultiple, "Çoklu Seçim");
            FormFieldTypeNames.Add(FormFieldType.Number, "Sayı");
            FormFieldTypeNames.Add(FormFieldType.Decimal, "OndalikliSayi");
            FormFieldTypeNames.Add(FormFieldType.Date, "Tarih");
            //FormFieldTypeNames.Add(FormFieldType.MultiFieldSet, "Çoklu Cevap");
            FormFieldTypeNames.Add(FormFieldType.YesOrNo, "Evet yada Hayır");
            FormFieldTypeNames.Add(FormFieldType.SubFormTitle, "Alt Form Başlığı");


            //FormFieldTypeNames.Add(FormFieldType.Repeated, "Tekrarlı");

            TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyFax), "FIRMA FAX");
            TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyMobil), "FIRMA CEP");
            TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyOffice), "FIRMA TELEFON");
            TelephoneTypeNames.Add(Tuple.Create(EntityType.Person, TelephoneType.PersonHome), "EV");
            TelephoneTypeNames.Add(Tuple.Create(EntityType.Person, TelephoneType.PersonMobil), "BIREYSEL CEP");
            TelephoneTypeNames.Add(Tuple.Create(EntityType.Person, TelephoneType.PersonOffice), "IS CEP");

            //TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyFax), "FAX NUMBER");
            //TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyMobil), "PHONE NUMBER");
            //TelephoneTypeNames.Add(Tuple.Create(EntityType.Company, TelephoneType.CompanyOffice), "Office");
            //TelephoneTypeNames.Add(Tuple.Create(EntityType.Person, TelephoneType.PersonHome), "PersonHome");
            //TelephoneTypeNames.Add(Tuple.Create(EntityType.Person, TelephoneType.PersonMobil), "PersonMobil");


            BloodGroupNames.Add(BloodGroup.ABRhPozitif, "AB Rh Negatif");
            BloodGroupNames.Add(BloodGroup.ABRhNegatif, "AB Rh Negatif");
            BloodGroupNames.Add(BloodGroup.ARhPozitif, "A Rh Pozitif");
            BloodGroupNames.Add(BloodGroup.ARhNegatif, "A Rh Negatif");
            BloodGroupNames.Add(BloodGroup.BRhPozitif, "B Rh Pozitif");
            BloodGroupNames.Add(BloodGroup.BRhNegatif, "B Rh Negatif");
            BloodGroupNames.Add(BloodGroup.ORhPozitif, "O Rh Pozitif");
            BloodGroupNames.Add(BloodGroup.ORhNegatif, "O Rh Negatif");

            /*rehber taksonomiden iptal edilecekler. 
             * "departman", 
             * "region", 
             * "sektor",
             * authority", 
             * "company category",
             * "person category",
             * "social media",
             * "nationality", 
             * "job experience",
             * "product type"      
             */

            //TaxonomyNames.Add(TaxonomyType.Department, "Department");
            TaxonomyNames.Add(TaxonomyType.Position, "Position");
            //TaxonomyNames.Add(TaxonomyType.Region, "Region");
            //TaxonomyNames.Add(TaxonomyType.Sector, "Sector");
            //TaxonomyNames.Add(TaxonomyType.Authority, "Authority");
            TaxonomyNames.Add(TaxonomyType.CurrencyType, "Currency Type");

            //TaxonomyNames.Add(TaxonomyType.CompanyCategory, "Company Category");
            TaxonomyNames.Add(TaxonomyType.CompanyType, "Company Type");
            //TaxonomyNames.Add(TaxonomyType.PersonCategory, "Person Category");
            //TaxonomyNames.Add(TaxonomyType.SocialMedia, "Social Media");
            //TaxonomyNames.Add(TaxonomyType.Nationality, "Nationality");
            //TaxonomyNames.Add(TaxonomyType.JobExperience, "Job Experience");
            TaxonomyNames.Add(TaxonomyType.Religion, "Religion");
            TaxonomyNames.Add(TaxonomyType.ReleaseReason, "Release Reason");
            TaxonomyNames.Add(TaxonomyType.Hobby, "Hobby");
            //TaxonomyNames.Add(TaxonomyType.ProductType, "Product Type");
            TaxonomyNames.Add(TaxonomyType.BankName, "Bank Name");
            TaxonomyNames.Add(TaxonomyType.ReasonWhyPassive, "Reason Why Passive");
            TaxonomyNames.Add(TaxonomyType.ReasonWhyPassiveForPersonnel, "Why Passive Personnel");
            TaxonomyNames.Add(TaxonomyType.Language, "Language");
            TaxonomyNames.Add(TaxonomyType.RelationshipStatus, "Relationship Status");
            TaxonomyNames.Add(TaxonomyType.EducationLevel, "Education Level");
            TaxonomyNames.Add(TaxonomyType.ComputerSkills, "Computer Skills");
            TaxonomyNames.Add(TaxonomyType.BloodGroup, "Blood Group");

            TaxonomyNamesZCode.Add(TaxonomyType.IplikKategorileriNormal, "İplik Kategorileri Normal");
            TaxonomyNamesZCode.Add(TaxonomyType.IplikKategorileriFantazi, "İplik Kategorileri Fantazi");

            TaxonomyNamesZCode.Add(TaxonomyType.KumasKategorileri, "Kumaş Kategorileri");



            //TaxonomyNamesZCode.Add(TaxonomyType.IplikNo, "İplik No");
            TaxonomyNamesZCode.Add(TaxonomyType.ElyafCinsiveKalitesi, "Elyaf Cinsi ve Kalitesi");
            //TaxonomyNamesZCode.Add(TaxonomyType.ElyafOrani, "Elyaf Oranı");
            //TaxonomyNamesZCode.Add(TaxonomyType.ElyafKalitesi, "Elyaf Kalitesi");
            TaxonomyNamesZCode.Add(TaxonomyType.UretimTeknolojisi, "Üretim Teknolojisi");
            TaxonomyNamesZCode.Add(TaxonomyType.IplikRengi, "İplik Rengi");
            TaxonomyNamesZCode.Add(TaxonomyType.PantoneRenkKodu, "Pantone Renk Kodu");
            TaxonomyNamesZCode.Add(TaxonomyType.RafYeriIplikTurkiye, "Raf Yeri Türkiye");
            TaxonomyNamesZCode.Add(TaxonomyType.RafYeriIplikYunanistan, "Raf Yeri Yunanistan");


            //
            //

            /*
            
              CompanyCategory,
    CompanyType,
    PersonCategory,
    SocialMedia,
    Nationality,
    JobExperience,
    Religion,
    ReleaseReason,
    Hobby

     */



            ObjectTypeNames.Add(EntityType.Person, "Person");
            ObjectTypeNames.Add(EntityType.Company, "Company");
            AreaCodes.Add(Tuple.Create(1, "ABD"));
            AreaCodes.Add(Tuple.Create(93, "Afganistan"));
            AreaCodes.Add(Tuple.Create(49, "Almanya"));
            AreaCodes.Add(Tuple.Create(684, "Amerikan Samoa"));
            AreaCodes.Add(Tuple.Create(376, "Andorra"));
            AreaCodes.Add(Tuple.Create(244, "Angola"));
            AreaCodes.Add(Tuple.Create(1264, "Anguilla"));
            AreaCodes.Add(Tuple.Create(1268, "Antigua"));
            AreaCodes.Add(Tuple.Create(54, "Arjantin"));
            AreaCodes.Add(Tuple.Create(355, "Arnavutluk"));
            AreaCodes.Add(Tuple.Create(297, "Aruba"));
            AreaCodes.Add(Tuple.Create(247, "Asension"));
            AreaCodes.Add(Tuple.Create(61, "Avustralya"));
            AreaCodes.Add(Tuple.Create(43, "Avusturya"));
            AreaCodes.Add(Tuple.Create(994, "Azerbaycan"));
            AreaCodes.Add(Tuple.Create(351, "Azor-Mader Adaları"));
            AreaCodes.Add(Tuple.Create(971, "BAE"));
            AreaCodes.Add(Tuple.Create(1242, "Bahama"));
            AreaCodes.Add(Tuple.Create(973, "Bahreyn"));
            AreaCodes.Add(Tuple.Create(880, "Bangladeş"));
            AreaCodes.Add(Tuple.Create(1246, "Barbados"));
            AreaCodes.Add(Tuple.Create(685, "Batı Samoa"));
            AreaCodes.Add(Tuple.Create(32, "Belçika"));
            AreaCodes.Add(Tuple.Create(501, "Belize"));
            AreaCodes.Add(Tuple.Create(229, "Benin"));
            AreaCodes.Add(Tuple.Create(1441, "Bermuda"));
            AreaCodes.Add(Tuple.Create(375, "Beyaz Rusya"));
            AreaCodes.Add(Tuple.Create(591, "Bolivya"));
            AreaCodes.Add(Tuple.Create(387, "Bosna Hersek"));
            AreaCodes.Add(Tuple.Create(267, "Botsvana"));
            AreaCodes.Add(Tuple.Create(55, "Brezılya"));
            AreaCodes.Add(Tuple.Create(1284, "British Virgin Adaları"));
            AreaCodes.Add(Tuple.Create(673, "Bruney"));
            AreaCodes.Add(Tuple.Create(359, "Bulgaristan"));
            AreaCodes.Add(Tuple.Create(226, "Burkina Faso"));
            AreaCodes.Add(Tuple.Create(95, "Burma"));
            AreaCodes.Add(Tuple.Create(257, "Burundi"));
            AreaCodes.Add(Tuple.Create(975, "Butan"));
            AreaCodes.Add(Tuple.Create(235, "Cad"));
            AreaCodes.Add(Tuple.Create(350, "Cebelitarık"));
            AreaCodes.Add(Tuple.Create(420, "Çek Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(213, "Cezayir"));
            AreaCodes.Add(Tuple.Create(253, "Cibuti"));
            AreaCodes.Add(Tuple.Create(86, "Çin"));
            AreaCodes.Add(Tuple.Create(682, "Cook Adası"));
            AreaCodes.Add(Tuple.Create(45, "Danimarka"));
            AreaCodes.Add(Tuple.Create(246, "Diego Garsia"));
            AreaCodes.Add(Tuple.Create(1767, "Dominik"));
            AreaCodes.Add(Tuple.Create(1809, "Dominik Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(593, "Ekvator"));
            AreaCodes.Add(Tuple.Create(240, "Ekvator Gine"));
            AreaCodes.Add(Tuple.Create(503, "El Salvador"));
            AreaCodes.Add(Tuple.Create(62, "Endonezya"));
            AreaCodes.Add(Tuple.Create(291, "Erıtre"));
            AreaCodes.Add(Tuple.Create(374, "Ermenistan"));
            AreaCodes.Add(Tuple.Create(372, "Estonya"));
            AreaCodes.Add(Tuple.Create(251, "Etiyopya"));
            AreaCodes.Add(Tuple.Create(500, "Falkland Adaları"));
            AreaCodes.Add(Tuple.Create(298, "Faroe Adaları"));
            AreaCodes.Add(Tuple.Create(212, "Fas"));
            AreaCodes.Add(Tuple.Create(679, "Fiji"));
            AreaCodes.Add(Tuple.Create(225, "Fildişi Sahili"));
            AreaCodes.Add(Tuple.Create(63, "Filipinler"));
            AreaCodes.Add(Tuple.Create(358, "Finlandiya"));
            AreaCodes.Add(Tuple.Create(33, "Fransa"));
            AreaCodes.Add(Tuple.Create(594, "Fransız Guyanası"));
            AreaCodes.Add(Tuple.Create(689, "Fransız Polenazyası"));
            AreaCodes.Add(Tuple.Create(241, "Gabon"));
            AreaCodes.Add(Tuple.Create(220, "Gambia"));
            AreaCodes.Add(Tuple.Create(233, "Gana"));
            AreaCodes.Add(Tuple.Create(224, "Gine"));
            AreaCodes.Add(Tuple.Create(245, "Gine Bissau"));
            AreaCodes.Add(Tuple.Create(1473, "Grenada"));
            AreaCodes.Add(Tuple.Create(299, "Grönland"));
            AreaCodes.Add(Tuple.Create(590, "Guadalup"));
            AreaCodes.Add(Tuple.Create(1671, "Guam"));
            AreaCodes.Add(Tuple.Create(502, "Guatemala"));
            AreaCodes.Add(Tuple.Create(27, "Güney Afrika Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(82, "Güney Kore"));
            AreaCodes.Add(Tuple.Create(995, "Gürcistan"));
            AreaCodes.Add(Tuple.Create(592, "Güyana"));
            AreaCodes.Add(Tuple.Create(509, "Haiti"));
            AreaCodes.Add(Tuple.Create(91, "Hindistan"));
            AreaCodes.Add(Tuple.Create(385, "Hırvatistan"));
            AreaCodes.Add(Tuple.Create(31, "Hollanda"));
            AreaCodes.Add(Tuple.Create(599, "Hollanda Antilleri"));
            AreaCodes.Add(Tuple.Create(504, "Honduras"));
            AreaCodes.Add(Tuple.Create(852, "Hongkong"));
            AreaCodes.Add(Tuple.Create(964, "Irak"));
            AreaCodes.Add(Tuple.Create(44, "İngiltere"));
            AreaCodes.Add(Tuple.Create(98, "İran"));
            AreaCodes.Add(Tuple.Create(353, "İrlanda"));
            AreaCodes.Add(Tuple.Create(34, "İspanya"));
            AreaCodes.Add(Tuple.Create(972, "İsrail"));
            AreaCodes.Add(Tuple.Create(46, "İsveç"));
            AreaCodes.Add(Tuple.Create(41, "İsviçre"));
            AreaCodes.Add(Tuple.Create(39, "İtalya"));
            AreaCodes.Add(Tuple.Create(354, "İzlanda"));
            AreaCodes.Add(Tuple.Create(1876, "Jamaika"));
            AreaCodes.Add(Tuple.Create(81, "Japonya"));
            AreaCodes.Add(Tuple.Create(855, "Kamboçya"));
            AreaCodes.Add(Tuple.Create(237, "Kamerun"));
            AreaCodes.Add(Tuple.Create(1, "Kanada"));
            AreaCodes.Add(Tuple.Create(238, "Kap Verd"));
            AreaCodes.Add(Tuple.Create(974, "Katar"));
            AreaCodes.Add(Tuple.Create(1345, "Kayman Adaları"));
            AreaCodes.Add(Tuple.Create(7, "Kazakistan"));
            AreaCodes.Add(Tuple.Create(254, "Kenya"));
            AreaCodes.Add(Tuple.Create(357, "Kıbrıs"));
            AreaCodes.Add(Tuple.Create(996, "Kırgızistan"));
            AreaCodes.Add(Tuple.Create(686, "Kırıbatı"));
            AreaCodes.Add(Tuple.Create(57, "Kolombiya"));
            AreaCodes.Add(Tuple.Create(269, "Komor Adaları"));
            AreaCodes.Add(Tuple.Create(242, "Kongo"));
            AreaCodes.Add(Tuple.Create(506, "Kosta Rika"));
            AreaCodes.Add(Tuple.Create(53, "Küba"));
            AreaCodes.Add(Tuple.Create(965, "Kuveyt"));
            AreaCodes.Add(Tuple.Create(850, "Kuzey Kore"));
            AreaCodes.Add(Tuple.Create(856, "Lao Dem. Halk Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(266, "Lesotho"));
            AreaCodes.Add(Tuple.Create(371, "Letonya"));
            AreaCodes.Add(Tuple.Create(231, "Liberya"));
            AreaCodes.Add(Tuple.Create(218, "Libya"));
            AreaCodes.Add(Tuple.Create(41, "Lihtenstayn"));
            AreaCodes.Add(Tuple.Create(370, "Litvanya"));
            AreaCodes.Add(Tuple.Create(961, "Lübnan"));
            AreaCodes.Add(Tuple.Create(352, "Lüksemburg"));
            AreaCodes.Add(Tuple.Create(36, "Macaristan"));
            AreaCodes.Add(Tuple.Create(261, "Madagaskar"));
            AreaCodes.Add(Tuple.Create(853, "Makao"));
            AreaCodes.Add(Tuple.Create(389, "Makedonya"));
            AreaCodes.Add(Tuple.Create(265, "Malavi"));
            AreaCodes.Add(Tuple.Create(960, "Maldiv Adaları"));
            AreaCodes.Add(Tuple.Create(60, "Malezya"));
            AreaCodes.Add(Tuple.Create(223, "Mali"));
            AreaCodes.Add(Tuple.Create(356, "Malta"));
            AreaCodes.Add(Tuple.Create(1670, "Mariyan Adaları"));
            AreaCodes.Add(Tuple.Create(692, "Malsar Adaları"));
            AreaCodes.Add(Tuple.Create(596, "Martinik"));
            AreaCodes.Add(Tuple.Create(52, "Meksika"));
            AreaCodes.Add(Tuple.Create(236, "Merkezi Afrika Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(691, "Mikronezya"));
            AreaCodes.Add(Tuple.Create(20, "Mısır"));
            AreaCodes.Add(Tuple.Create(976, "Moğolistan"));
            AreaCodes.Add(Tuple.Create(373, "Moldovya"));
            AreaCodes.Add(Tuple.Create(377, "Monaco"));
            AreaCodes.Add(Tuple.Create(1664, "Montserrat"));
            AreaCodes.Add(Tuple.Create(230, "Moris Adaları"));
            AreaCodes.Add(Tuple.Create(222, "Moritanya"));
            AreaCodes.Add(Tuple.Create(258, "Mozambik"));
            AreaCodes.Add(Tuple.Create(7504915, "Nakhodka"));
            AreaCodes.Add(Tuple.Create(750492, "Nakhodka"));
            AreaCodes.Add(Tuple.Create(264, "Namibya"));
            AreaCodes.Add(Tuple.Create(674, "Nauru Adası"));
            AreaCodes.Add(Tuple.Create(977, "Nepal"));
            AreaCodes.Add(Tuple.Create(227, "Nijer"));
            AreaCodes.Add(Tuple.Create(234, "Nijerya"));
            AreaCodes.Add(Tuple.Create(505, "Nikaragua"));
            AreaCodes.Add(Tuple.Create(683, "Niue Adaları"));
            AreaCodes.Add(Tuple.Create(672, "Norfolk Adaları"));
            AreaCodes.Add(Tuple.Create(47, "Norveç"));
            AreaCodes.Add(Tuple.Create(998, "Özbekistan"));
            AreaCodes.Add(Tuple.Create(92, "Pakistan"));
            AreaCodes.Add(Tuple.Create(680, "Palau"));
            AreaCodes.Add(Tuple.Create(507, "Panama"));
            AreaCodes.Add(Tuple.Create(675, "Papua Yeni Gine"));
            AreaCodes.Add(Tuple.Create(595, "Paraguay"));
            AreaCodes.Add(Tuple.Create(51, "Peru"));
            AreaCodes.Add(Tuple.Create(48, "Polonya"));
            AreaCodes.Add(Tuple.Create(351, "Portekiz"));
            AreaCodes.Add(Tuple.Create(1787, "Porto Riko"));
            AreaCodes.Add(Tuple.Create(750996, "Radius"));
            AreaCodes.Add(Tuple.Create(262, "Reunyon"));
            AreaCodes.Add(Tuple.Create(40, "Romanya"));
            AreaCodes.Add(Tuple.Create(250, "Ruanda"));
            AreaCodes.Add(Tuple.Create(7, "Rusya Federasyonu"));
            AreaCodes.Add(Tuple.Create(750440, "Sakhalin"));
            AreaCodes.Add(Tuple.Create(7504416, "Sakhalin"));
            AreaCodes.Add(Tuple.Create(750442, "Sakhalin"));
            AreaCodes.Add(Tuple.Create(750443, "Sakhalin"));
            AreaCodes.Add(Tuple.Create(378, "San Marıno"));
            AreaCodes.Add(Tuple.Create(239, "Sao Tome & Principe"));
            AreaCodes.Add(Tuple.Create(221, "Senegal"));
            AreaCodes.Add(Tuple.Create(248, "Seysel"));
            AreaCodes.Add(Tuple.Create(232, "Sierra Leone"));
            AreaCodes.Add(Tuple.Create(56, "Tili"));
            AreaCodes.Add(Tuple.Create(65, "Singapur"));
            AreaCodes.Add(Tuple.Create(421, "Slovak Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(386, "Slovenya"));
            AreaCodes.Add(Tuple.Create(677, "Solomon Adaları"));
            AreaCodes.Add(Tuple.Create(252, "Somali"));
            AreaCodes.Add(Tuple.Create(94, "Sri Lanka"));
            AreaCodes.Add(Tuple.Create(290, "St.Helena"));
            AreaCodes.Add(Tuple.Create(1869, "St.Kittis & Nevis"));
            AreaCodes.Add(Tuple.Create(1758, "St.Lucia"));
            AreaCodes.Add(Tuple.Create(5995, "St.Marten"));
            AreaCodes.Add(Tuple.Create(508, "St.Piyer & Mikelon"));
            AreaCodes.Add(Tuple.Create(1784, "St.Vincent & Grenada"));
            AreaCodes.Add(Tuple.Create(249, "Sudan"));
            AreaCodes.Add(Tuple.Create(597, "Surinam"));
            AreaCodes.Add(Tuple.Create(963, "Suriye"));
            AreaCodes.Add(Tuple.Create(966, "Suudi Arabistan"));
            AreaCodes.Add(Tuple.Create(268, "Svaziland"));
            AreaCodes.Add(Tuple.Create(7, "Tacikistan"));
            AreaCodes.Add(Tuple.Create(255, "Tanzanya"));
            AreaCodes.Add(Tuple.Create(7843, "Tataristan"));
            AreaCodes.Add(Tuple.Create(7513, "Tatincom"));
            AreaCodes.Add(Tuple.Create(66, "Tayland"));
            AreaCodes.Add(Tuple.Create(886, "Tayvan"));
            AreaCodes.Add(Tuple.Create(228, "Togo"));
            AreaCodes.Add(Tuple.Create(690, "Tokelan"));
            AreaCodes.Add(Tuple.Create(676, "Tonga"));
            AreaCodes.Add(Tuple.Create(1868, "Trinidad & Tobago"));
            AreaCodes.Add(Tuple.Create(216, "Tunus"));
            AreaCodes.Add(Tuple.Create(90, "Türkiye"));
            AreaCodes.Add(Tuple.Create(993, "Türkmenistan"));
            AreaCodes.Add(Tuple.Create(1649, "Turks & Caicos Adaları"));
            AreaCodes.Add(Tuple.Create(688, "Tuvalu"));
            AreaCodes.Add(Tuple.Create(1340, "U.S. Virgin Adası"));
            AreaCodes.Add(Tuple.Create(256, "Uganda"));
            AreaCodes.Add(Tuple.Create(380, "Ukrayna"));
            AreaCodes.Add(Tuple.Create(968, "Umman"));
            AreaCodes.Add(Tuple.Create(598, "Uraguay"));
            AreaCodes.Add(Tuple.Create(962, "Ürdün"));
            AreaCodes.Add(Tuple.Create(681, "Vallis Fununa Adaları"));
            AreaCodes.Add(Tuple.Create(58, "Venezuela"));
            AreaCodes.Add(Tuple.Create(84, "Vietnam"));
            AreaCodes.Add(Tuple.Create(967, "Yemen Arap Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(969, "Yemen Halk Cumhuriyeti"));
            AreaCodes.Add(Tuple.Create(678, "Yeni Hebritler"));
            AreaCodes.Add(Tuple.Create(687, "Yeni Kaledonya"));
            AreaCodes.Add(Tuple.Create(64, "Yeni Zelenda"));
            AreaCodes.Add(Tuple.Create(381, "Yugoslavya"));
            AreaCodes.Add(Tuple.Create(30, "Yunanistan"));
            AreaCodes.Add(Tuple.Create(243, "Zaire"));
            AreaCodes.Add(Tuple.Create(260, "Zambiya"));
            AreaCodes.Add(Tuple.Create(259, "Zanzibar"));
            AreaCodes.Add(Tuple.Create(263, "Zimbabve"));
        }

        public static string Normalize(string str)
        {
            //return string.Join(string.Empty, str.Normalize(NormalizationForm.FormD).Where(k => char.GetUnicodeCategory(k) != UnicodeCategory.NonSpacingMark));
            return str.Replace("İ", "I")
            .Replace("ı", "i")
            .Replace("Ğ", "G")
            .Replace("ğ", "g")
            .Replace("Ö", "O")
            .Replace("ö", "o")
            .Replace("Ü", "U")
            .Replace("ü", "u")
            .Replace("Ş", "S")
            .Replace("ş", "s")
            .Replace("Ç", "C")
            .Replace("ç", "c")
            .Replace(" ", "_"); ;
        }

        public static string NormalizeWithNoSpace(string str)
        {
            return Normalize(str).Replace(" ", string.Empty);
        }

        public static IEnumerable<SelectListItem> GetTelephoneTypes(int? telephoneType, EntityType entityType)
        {
            TelephoneType type = telephoneType.HasValue ? (TelephoneType)telephoneType : TelephoneType.Others;

            var temp= TelephoneTypeNames.Where(x => x.Key.Item1 == entityType).Select(x => new SelectListItem()
            {
                Value = ((int)x.Key.Item2).ToString(),
                Text = x.Value,
                Selected = telephoneType.HasValue && x.Key.Item2 == type
            }).ToList();
            return temp;
        }


        public static IEnumerable<SelectListItem> GetAddressTypes(int? addressType, EntityType entityType, bool exceptCenterAddress = false)
        {
            AddressType type = addressType.HasValue ? (AddressType)addressType : AddressType.Others;        

            var temp= AddressTypeNames.Where(x => x.Key.Item1 == entityType).Select(x => new SelectListItem()
            {
                Value = ((int)x.Key.Item2).ToString(),
                Text = x.Value,
                Selected = addressType.HasValue && x.Key.Item2 == type
            }).ToList();

            if (exceptCenterAddress)
            {
                temp.Remove(temp.First(x => x.Value == ((int)AddressType.Merkez).ToString()));
            }

            return temp;
        }


        //public static IEnumerable<SelectListItem> GetAddressTypes(int? addressType=null , EntityType entityType)
        //{
        //    AddressType type = addressType.HasValue ? (AddressType)addressType : AddressType.Others;

        //    return AddressTypeNames.Select(x => new SelectListItem()
        //    {
        //        Value = ((int)x.Key).ToString(),
        //        Text = x.Value,
        //        Selected = addressType.HasValue && x.Key == type
        //    });
        //}

        public static IEnumerable<SelectListItem> GetGenderTypes(int? genderType = null)
        {
            GenderType type = genderType.HasValue ? (GenderType)genderType : GenderType.None;

            return GenderTypeNames.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                Selected = genderType.HasValue && x.Key == type
            });
        }

        public static IEnumerable<SelectListItem> GetColorTypes(int? colorType = null)
        {
            ColorType type = colorType.HasValue ? (ColorType)colorType : ColorType.None;

            return ColorTypeNames.Select(x => new SelectListItem()
            {
                Value = x.Value.Item2,
                Text = x.Value.Item1,
                Selected = colorType.HasValue && x.Key == type
            });
        }



        public static IEnumerable<SelectListItem> GetCompanyTypes(int? companyType = null)
        {
            CompanyRootType type = companyType.HasValue ? (CompanyRootType)companyType : CompanyRootType.None;

            return CompanyTypeNames.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                Selected = companyType.HasValue && x.Key == type
            });
        }

        public static SelectList GetSelectListForRepeated(bool? isRequired = null)
        {
            return new SelectList(SelectListItemRepeated, "Value", "Text", isRequired.HasValue && isRequired.Value ? "true" : "false");
        }
        public static SelectList GetSelectListForRequired(bool? isRequired = null)
        {
            return new SelectList(SelectListItemRequired, "Value", "Text", isRequired.HasValue && isRequired.Value ? "true" : "false");
        }

        public static IEnumerable<SelectListItem> GetSelectListYesOrNo(string yesOrNo)
        {
            var selectListYesOrNo = new List<SelectListItem>();
            selectListYesOrNo.Add(new SelectListItem { Text = "Yes", Value = "true", Selected = !string.IsNullOrWhiteSpace(yesOrNo) && yesOrNo == "true" });
            selectListYesOrNo.Add(new SelectListItem { Text = "No", Value = "false", Selected = !string.IsNullOrWhiteSpace(yesOrNo) && yesOrNo == "false" });
            return selectListYesOrNo;
        }


        public static IEnumerable<SelectListItem> GetFormFieldTypes(int? formFieldType = null)
        {
            FormFieldType type = formFieldType.HasValue ? (FormFieldType)formFieldType : FormFieldType.None;

            var temp = FormFieldTypeNames.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                Selected = formFieldType.HasValue && x.Key == type
            });

            return temp;
        }

        public static IEnumerable<SelectListItem> GetBloodGroups(int? bloodGroup)
        {
            BloodGroup group = bloodGroup.HasValue ? (BloodGroup)bloodGroup : BloodGroup.None;

            return BloodGroupNames.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                Selected = bloodGroup.HasValue && x.Key == group
            });
        }



        private static readonly Lazy<IEnumerable<SelectListItem>> taxonomyNames 
            =  new Lazy<IEnumerable<SelectListItem>>(() => FillTaxonomyNames());

        private static readonly Lazy<IEnumerable<SelectListItem>> taxonomyNamesZCode
           = new Lazy<IEnumerable<SelectListItem>>(() => FillTaxonomyNamesZCode());
        private static IEnumerable<SelectListItem> FillTaxonomyNames()
        {
          return TaxonomyNames.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                //Selected = taxonomyType.HasValue && x.Key == type
            });
        }

        public static IEnumerable<SelectListItem> GetTaxonomyNames(int? taxonomyType = null)
        {
            var list = taxonomyNames.Value;
            var value = taxonomyType.HasValue ? taxonomyType.ToString() : string.Empty;
            foreach (var item in list)            
                item.Selected = item.Value == value;

            list = list.OrderBy(x => x.Text).ToList();

            return list;
        }

        private static IEnumerable<SelectListItem> FillTaxonomyNamesZCode()
        {
            return TaxonomyNamesZCode.Select(x => new SelectListItem()
            {
                Value = ((int)x.Key).ToString(),
                Text = x.Value,
                //Selected = taxonomyType.HasValue && x.Key == type
            });
        }

        public static IEnumerable<SelectListItem> GetTaxonomyNamesZCode(int? taxonomyType = null)
        {
            var list = taxonomyNamesZCode.Value;
            var value = taxonomyType.HasValue ? taxonomyType.ToString() : string.Empty;
            foreach (var item in list)
                item.Selected = item.Value == value;

            list = list.OrderBy(x => x.Text).ToList();

            return list;
        }

        public static string GetTaxonomyName(int taxonomyType)
        {
            var type = (TaxonomyType)taxonomyType;
            if (TaxonomyNames.ContainsKey((TaxonomyType)taxonomyType))            
                return TaxonomyNames[type];            
            return string.Empty;
        }

        //private static readonly Lazy<Dictionary<int, string>> _taxonomyEnumNames 
        //                    = new Lazy<Dictionary<int, string>>(() => FillTaxonomyEnumNames());

        //public string GetTaxonomyEnumName(int taxonomyType)
        //{
        //    if (_taxonomyEnumNames.Value.ContainsKey(taxonomyType))            
        //        return _taxonomyEnumNames.Value[taxonomyType];
            
        //    return string.Empty;

        //}
        //private static Dictionary<int, string> FillTaxonomyEnumNames()
        //{
        //    var dictionary = new Dictionary<int, string>();
        //    foreach (TaxonomyType mood in Enum.GetValues(typeof(TaxonomyType)))
        //        dictionary.Add((int)mood, mood.ToString());
        //    return dictionary;
        //}
    }
}

namespace FollowMe.Web
{

    public enum CompanyRootType
    {
        None,
        Red = 2,
        Blue = 1,
        Zetaa = 3,
        Others = 11
        //Demo,
        //Gercek
    }

    public enum CompanyBlueType
    {
        None,
        Iplikci = 22,
        Kumas = 18,
        Aksesuarci = 23,
        HazirGiyimci = 24
        //Demo,
        //Gercek
    }

    public enum CompanyRedType
    {
        None,
        Iplikci = 77,
        Kumasci = 79,
        HazirGiyimci = 80,
        Aksesuarci = 81
        //Demo,
        //Gercek
    }

    public enum CompanyRedIplikciType
    {
        None,
        Uretici = 172,
        Ithalatci = 173,
        Tedarikci = 174,
        Boyahanesi = 175
        //Demo,
        //Gercek
    }

    public enum CompanyRedKumasciType
    {
        None,
        Uretici = 176,
        Ithalatci = 177,
        Tedarikci = 178,
        Boyahanesi = 179
        //Demo,
        //Gercek
    }
    public enum CompanyRedHazirGiyimciType
    {
        None,
        Ureticisi = 184,
        Ithalatcisi = 185,
        Tedarikcisi = 186,
        Boyahanesi = 187
        //Demo,
        //Gercek
    }

    public enum CompanyRedAksesuarciType
    {
        None,
        Ureticisi = 180,
        Ithalatci = 181,
        Boyahanesi = 182,
        Tedarikcisi = 183
        //Demo,
        //Gercek
    }

    //public enum CompanyOthersHizmetSaglayicilar
    //{
    //    None,
    //    Muhasebe,
    //    Lojistik,
    //    GumruklemeHzmt,
    //    Avukatlik,
    //    Renklam,
    //    Banka
    //}
    //public enum CompanyOthersUrunSaglayicilar
    //{
    //    None,
    //    Gida,
    //    Arac,

    //}
    //public enum CompanyOthersResmiDevletKurumlar
    //{
    //    None
    //}
    //public enum CompanyOthersDigerSektorler
    //{
    //    None
    //}



    public enum CompanyZetaaType
    {
        None,
        Merkez = 166,
        YurtDisiOfis = 167,
        YurtIciOfis = 168,
        Depo = 170
        //Demo,
        //Gercek
    }
    public enum CompanyOthersType
    {
        None,
        HizmetSaglayicilar = 188,
        UrunSaglayicilar = 189,
        ResmiveDevletKurumlari = 190,
        DigerSektorler = 89
        //Demo,
        //Gercek
    }

    public enum CompanyOthersHizmetSaglayicilar
    {
        None,
        Muhasebe,
        Lojistik,
        GumruklemeHizmeti,
        Avukatlik,
        Renklam,
        Banka
    }
    public enum CompanyOthersUrunSaglayicilar
    {
        None,
        Gida,
        Arac,
        KonaklamaveUlasim,
        SigortaPolice,
        Kurumlar,
        SaglikveBakim,
        Ofis
    }
    public enum CompanyOthersResmiveDevletKurumlari
    {
        None,
        Noter,
        MaliMusavir,
        TercumeBurolari
    }
    public enum CompanyOthersDigerSektorler
    {
        None,
        KagitSektoru,
        PlastikSektoru
    }

    public enum CompanyBlueIplikciType
    {
        None,
        Uretici = 25,
        Ithalatci = 27,
        Tedarikci = 15,
        Boyahane = 28
        //Demo,
        //Gercek
    }
    public enum CompanyBlueKumasType
    {
        None,
        Uretici = 14,
        Tedarikci = 26,
        Ithalatci = 17,
        Boyahane = 19
        //Demo,
        //Gercek
    }
    public enum CompanyBlueAksesuarciType
    {
        None,
        Uretici = 29,
        Tedarikci = 30,
        Ithalatci = 31,
        Boyahane = 32
        //Demo,
        //Gercek
    }
    public enum CompanyBlueHazirGiyimciType
    {
        None,
        Ureticisi = 33,
        Tedarikcisi = 34,
        Ithalatcisi = 35,
        Boyahanesi = 36
        //Demo,
        //Gercek
    }

    //public enum CompanyRedType
    //{
    //    None,
    //    Iplikci = 77,
    //    Gelinlikci = 78,
    //    Kumas = 79,
    //    HaziGiyim = 80,
    //    Aksesuar = 81,
    //    Boyahane = 16
    //    //Demo,
    //    //Gercek
    //}

    //public enum CompanyOtherType
    //{
    //    None,
    //    Personel = 95,
    //    Company = 96   
    //    //Demo,
    //    //Gercek
    //}
    //public enum CompanyZetaaType
    //{
    //    None,
    //    Personel = 95,
    //    Company = 96
    //    //Demo,
    //    //Gercek
    //}



    public enum TelephoneType
    {
        Others,
        CompanyFax,
        CompanyMobil,
        CompanyOffice,
        //Demo,
        //Gercek       
        PersonMobil,
        PersonHome,
        PersonOffice
    }


    //
    //merkez, yurtiçiofis, yurtdışı ofis, depo, boyan

    public enum AddressType
    {
        Others,
        Home,
        Merkez,
        YurtIciOfis,
        YurtDisiOfis,
        Depo,
        Boyahane
    }

    public enum BloodGroup
    {
        None,
        ABRhPozitif,
        ABRhNegatif,
        ARhPozitif,
        ARhNegatif,
        BRhPozitif,
        BRhNegatif,
        ORhPozitif,
        ORhNegatif
    }
    public enum EntityType
    {
        None,
        Person,
        Company,
        ZetaCodeNormalIplik
    }

    public enum GenderType
    {
        None,
        Male,
        Female
    }

    public enum ColorType
    {
        None,
        Blue,
        Red,
        Green,
        Purple
    }

    public enum FormFieldType
    {
        None,
        Text,
        TextArea,
        Number,
        Decimal,
        Date,
        SelectSingle,
        SelectMultiple,
        MultiFieldSet,
        YesOrNo,
        SubFormTitle
        //Repeated,
        //Header,
    }

    public enum JsonObjectTypes
    {
        None,
        CompanyDisabledField,
        CompanyEnabledField
    }

    public enum TaxonomyType
    {
        None,
        Department,
        Position,
        Region,
        Sector,
        Authority,
        CurrencyType,
        CompanyCategory,
        CompanyType,
        PersonCategory,
        SocialMedia,
        Nationality,
        JobExperience,
        Religion,
        ReleaseReason,
        Hobby,
        ProductType,
        BankName,
        ReasonWhyPassive,
        Language,
        RelationshipStatus,
        BloodGroup,
        EducationLevel,
        ComputerSkills,
        ReasonWhyPassiveForPersonnel,
        IplikKategorileriNormal,
        KumasKategorileri,
        IplikNo,
        ElyafCinsiveKalitesi,
        ElyafOrani,
        ElyafKalitesi,
        UretimTeknolojisi,
        IplikRengi,
        PantoneRenkKodu,
        RafYeriIplikTurkiye,
        RafYeriIplikYunanistan,
        IplikKategorileriFantazi,
        //CompanySubType,
    }

}