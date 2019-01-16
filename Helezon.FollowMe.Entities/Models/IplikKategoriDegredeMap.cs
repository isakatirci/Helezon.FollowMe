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

    // IplikKategoriDegrede
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class IplikKategoriDegredeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IplikKategoriDegrede>
    {
        public IplikKategoriDegredeMap()
            : this("dbo")
        {
        }

        public IplikKategoriDegredeMap(string schema)
        {
            ToTable("IplikKategoriDegrede", schema);
            HasKey(x => x.ZetaCodeNormalIplikId);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.BoyamaProsesi).HasColumnName(@"BoyamaProsesi").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.ZetaCodeNormalIplikId).HasColumnName(@"ZetaCodeNormalIplikId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.BoyaTipi).HasColumnName(@"BoyaTipi").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.BoyaYonu).HasColumnName(@"BoyaYonu").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);

            // Foreign keys
            HasRequired(a => a.ZetaCodeNormalIplik).WithOptional(b => b.IplikKategoriDegrede).WillCascadeOnDelete(false); // FK_IplikKategoriDegrede_ZetaCodeNormalIplik
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>