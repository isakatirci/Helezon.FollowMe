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

    // Renk
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class Renk: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string HtmlKod { get; set; } // HtmlKod (length: 50)
        public int DilId { get; set; } // DilId
        public string Ad { get; set; } // Ad (length: 50)
        public string IplikRenkKodu { get; set; } // IplikRenkKodu (length: 100)

        // Reverse navigation

        /// <summary>
        /// Child ZetaCodeFanteziIplik where [ZetaCodeFanteziIplik].[Renkid] point to this entity (FK_ZetaCodeFanteziIplik_Renk)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ZetaCodeFanteziIplik> ZetaCodeFanteziIplik { get; set; } // ZetaCodeFanteziIplik.FK_ZetaCodeFanteziIplik_Renk
        /// <summary>
        /// Child ZetaCodeNormalIplik where [ZetaCodeNormalIplik].[Renkid] point to this entity (FK_ZetaCodeNormaliplik_Renk)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ZetaCodeNormalIplik> ZetaCodeNormalIplik { get; set; } // ZetaCodeNormalIplik.FK_ZetaCodeNormaliplik_Renk

        public Renk()
        {
            ZetaCodeFanteziIplik = new System.Collections.Generic.List<ZetaCodeFanteziIplik>();
            ZetaCodeNormalIplik = new System.Collections.Generic.List<ZetaCodeNormalIplik>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
