// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Helezon.FollowMe.Entities.Models
{
    using Repository.Pattern.Ef6;

    // ZetaCodeHazirGiyim
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeHazirGiyim: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public int? UrunKategoriId { get; set; } // UrunKategoriId
        public string CompanyId { get; set; } // CompanyId (length: 128)
        public int? UlkeId { get; set; } // UlkeId
        public bool Master { get; set; } // Master
        public string BlueUrunKodIsmi { get; set; } // BlueUrunKodIsmi (length: 200)
        public int? BlueSiparisNo { get; set; } // BlueSiparisNo
        public int ZetaCode { get; set; } // ZetaCode
        public int? PantoneId { get; set; } // PantoneId
        public int? Renkid { get; set; } // Renkid
        public int? RafyeriTurkiyeId { get; set; } // RafyeriTurkiyeId
        public int? RafyeriYunanistanId { get; set; } // RafyeriYunanistanId
        public string ZetaCodePrevious { get; set; } // ZetaCodePrevious (length: 200)
        public string En { get; set; } // En (length: 10)
        public string Boy { get; set; } // Boy (length: 10)
        public string Gram { get; set; } // Gram (length: 10)
        public int? KategoriId { get; set; } // KategoriId
        public int? BaskiGoruntuId { get; set; } // BaskiGoruntuId
        public string YikamaTalimatiKuruTemizleme { get; set; } // YikamaTalimatiKuruTemizleme (length: 50)
        public string YikamaTalimatiYikamaSekli { get; set; } // YikamaTalimatiYikamaSekli (length: 50)
        public string YikamaTalimatiYikamaMaxDerecesi { get; set; } // YikamaTalimatiYikamaMaxDerecesi (length: 50)
        public string YikamaTalimatiUtulemeMaxDerecesi { get; set; } // YikamaTalimatiUtulemeMaxDerecesi (length: 50)
        public string YikamaTalimatiTersYikama { get; set; } // YikamaTalimatiTersYikama (length: 50)
        public string YikamaTalimatiCekemezlik { get; set; } // YikamaTalimatiCekemezlik (length: 10)
        public string YikamaTalimatiDonmezlik { get; set; } // YikamaTalimatiDonmezlik (length: 10)
        public string YikamaTalimatiYikamaAdedi { get; set; } // YikamaTalimatiYikamaAdedi (length: 10)
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        public ZetaCodeHazirGiyim()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
