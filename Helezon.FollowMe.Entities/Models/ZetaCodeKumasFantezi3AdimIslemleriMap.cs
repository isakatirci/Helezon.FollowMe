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

    // ZetaCodeKumasFantezi3AdimIslemleri
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeKumasFantezi3AdimIslemleriMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeKumasFantezi3AdimIslemleri>
    {
        public ZetaCodeKumasFantezi3AdimIslemleriMap()
            : this("dbo")
        {
        }

        public ZetaCodeKumasFantezi3AdimIslemleriMap(string schema)
        {
            ToTable("ZetaCodeKumasFantezi3AdimIslemleri", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.FantaziKumasId).HasColumnName(@"FantaziKumasId").HasColumnType("int").IsRequired();
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsRequired();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsRequired();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.ChangedOn).HasColumnName(@"ChangedOn").HasColumnType("datetime2").IsRequired();
            Property(x => x.ChangedBy).HasColumnName(@"ChangedBy").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.DesenKodu).HasColumnName(@"DesenKodu").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.DesemRengi1).HasColumnName(@"DesemRengi1").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.DesemRengi2).HasColumnName(@"DesemRengi2").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.DesemRengi3).HasColumnName(@"DesemRengi3").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x._3AdimIslemlerId).HasColumnName(@"_3AdimIslemlerId").HasColumnType("int").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
