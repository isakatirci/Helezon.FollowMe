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

    // IplikKategoriKircili
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikKategoriKircili: Entity
    {
        public int Id { get; set; } // Id
        public string KircillarArasiMesafe { get; set; } // KircillarArasiMesafe (length: 10)
        public string KircilUzunlugu { get; set; } // KircilUzunlugu (length: 10)
        public string KircilYuksekligi { get; set; } // KircilYuksekligi (length: 10)
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId (Primary key)

        public IplikKategoriKircili()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
