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

    // IplikKategoriSim
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikKategoriSim: Entity
    {
        public int Id { get; set; } // Id
        public string SimKesimBoyutu { get; set; } // SimKesimBoyutu (length: 200)
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId (Primary key)

        public IplikKategoriSim()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
