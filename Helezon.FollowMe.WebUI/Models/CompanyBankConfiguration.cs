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

    // CompanyBank
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class CompanyBankConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CompanyBank>
    {
        public CompanyBankConfiguration()
            : this("dbo")
        {
        }

        public CompanyBankConfiguration(string schema)
        {
            Property(x => x.Province).IsOptional();
            Property(x => x.District).IsOptional();
            Property(x => x.BranchCode).IsOptional();
            Property(x => x.BranchName).IsOptional();
            Property(x => x.AccountNo).IsOptional();
            Property(x => x.Iban).IsOptional();
            Property(x => x.SwiftNo).IsOptional();
            Property(x => x.CurrencyTypeTermName).IsOptional();
            Property(x => x.BankNameTermName).IsOptional();
            Property(x => x.CreatedOn).IsOptional();
            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.ChangedOn).IsOptional();
            Property(x => x.ChangedBy).IsOptional();
            Property(x => x.MakedPassiveOn).IsOptional();
            Property(x => x.MakedPassiveBy).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>