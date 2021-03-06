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

    // IplikNo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikNo: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public int ZetaCodeNormalIplikId { get; set; } // ZetaCodeNormalIplikId
        public int? ElyafCinsiKalitesi { get; set; } // ElyafCinsiKalitesi
        public int? ElyafOrani { get; set; } // ElyafOrani
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        public IplikNo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
