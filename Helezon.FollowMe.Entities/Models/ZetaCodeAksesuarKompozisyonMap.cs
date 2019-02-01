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

    // ZetaCodeAksesuarKompozisyon
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeAksesuarKompozisyonMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeAksesuarKompozisyon>
    {
        public ZetaCodeAksesuarKompozisyonMap()
            : this("dbo")
        {
        }

        public ZetaCodeAksesuarKompozisyonMap(string schema)
        {
            ToTable("ZetaCodeAksesuarKompozisyon", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UrunKompozisyonId).HasColumnName(@"UrunKompozisyonId").HasColumnType("int").IsOptional();
            Property(x => x.YuzdeOrani).HasColumnName(@"YuzdeOrani").HasColumnType("int").IsOptional();
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsRequired();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.ChangedOn).HasColumnName(@"ChangedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.ChangedBy).HasColumnName(@"ChangedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.AksesuarId).HasColumnName(@"AksesuarId").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Company).WithMany(b => b.ZetaCodeAksesuarKompozisyon).HasForeignKey(c => c.CompanyId).WillCascadeOnDelete(false); // FK_ZetaCodeAksesuarKompozisyon_Company
            HasOptional(a => a.ZetaCodeAksesuar).WithMany(b => b.ZetaCodeAksesuarKompozisyon).HasForeignKey(c => c.AksesuarId).WillCascadeOnDelete(false); // FK_ZetaCodeAksesuarKompozisyon_ZetaCodeAksesuar
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
