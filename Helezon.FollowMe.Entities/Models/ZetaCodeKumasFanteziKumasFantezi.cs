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

    // ZetaCode_KumasFantezi_KumasFantezi
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeKumasFanteziKumasFantezi: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public int KumasFanteziId { get; set; } // KumasFanteziId
        public int KumasOtherFanteziId { get; set; } // KumasOtherFanteziId

        public ZetaCodeKumasFanteziKumasFantezi()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
