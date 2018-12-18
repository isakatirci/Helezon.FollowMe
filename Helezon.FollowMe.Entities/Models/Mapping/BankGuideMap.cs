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


namespace Helezon.FollowMe.Entities.Models.Mapping
{

    // BankGuide
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class BankGuideMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BankGuide>
    {
        public BankGuideMap()
            : this("dbo")
        {
        }

        public BankGuideMap(string schema)
        {
            ToTable("BankGuide", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.TermId).HasColumnName(@"TermId").HasColumnType("int").IsOptional();
            Property(x => x.BankName).HasColumnName(@"BankName").HasColumnType("nvarchar").IsRequired().HasMaxLength(150);
            Property(x => x.Province).HasColumnName(@"Province").HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(x => x.District).HasColumnName(@"District").HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(x => x.BranchName).HasColumnName(@"BranchName").HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(x => x.BranchCode).HasColumnName(@"BranchCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(x => x.SwiftNo).HasColumnName(@"SwiftNo").HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsOptional();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.ChangedOn).HasColumnName(@"ChangedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.ChangedBy).HasColumnName(@"ChangedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>