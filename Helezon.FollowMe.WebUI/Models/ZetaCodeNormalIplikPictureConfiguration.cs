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

    // ZetaCodeNormalIplikPicture
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeNormalIplikPictureConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeNormalIplikPicture>
    {
        public ZetaCodeNormalIplikPictureConfiguration()
            : this("dbo")
        {
        }

        public ZetaCodeNormalIplikPictureConfiguration(string schema)
        {
            Property(x => x.CreatedOn).IsOptional();
            Property(x => x.CreatedBy).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
