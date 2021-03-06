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

    // CompanyAddress
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class CompanyAddressMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CompanyAddress>
    {
        public CompanyAddressMap()
            : this("dbo")
        {
        }

        public CompanyAddressMap(string schema)
        {
            ToTable("CompanyAddress", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.AddressType).HasColumnName(@"AddressType").HasColumnType("int").IsOptional();
            Property(x => x.Province).HasColumnName(@"Province").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.District).HasColumnName(@"District").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Line1).HasColumnName(@"Line1").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Line2).HasColumnName(@"Line2").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.ZipCode).HasColumnName(@"ZipCode").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.SuburbArea).HasColumnName(@"SuburbArea").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Town).HasColumnName(@"Town").HasColumnType("nvarchar(max)").IsOptional();
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
