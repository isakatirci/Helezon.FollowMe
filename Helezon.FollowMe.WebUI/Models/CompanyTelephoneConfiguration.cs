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

    // CompanyTelephone
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class CompanyTelephoneConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CompanyTelephone>
    {
        public CompanyTelephoneConfiguration()
            : this("dbo")
        {
        }

        public CompanyTelephoneConfiguration(string schema)
        {
            Property(x => x.Number).IsOptional().IsFixedLength();
            Property(x => x.AreaCode).IsOptional();
            Property(x => x.Interphone).IsOptional();
            Property(x => x.IsPassive).IsOptional();
            Property(x => x.CreatedOn).IsOptional();
            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.ChangedOn).IsOptional();
            Property(x => x.ChangedBy).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
