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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FollowMe.Web.Models
{

    // IplikNoGuide
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikNoGuideConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IplikNoGuide>
    {
        public IplikNoGuideConfiguration()
            : this("dbo")
        {
        }

        public IplikNoGuideConfiguration(string schema)
        {
            Property(x => x.Ne).IsOptional();
            Property(x => x.Nm).IsOptional();
            Property(x => x.Dny).IsOptional();
            Property(x => x.Fl).IsOptional();
            Property(x => x.Ea).IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
