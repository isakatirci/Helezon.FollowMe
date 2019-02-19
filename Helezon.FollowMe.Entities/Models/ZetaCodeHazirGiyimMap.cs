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

    // ZetaCodeHazirGiyim
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeHazirGiyimMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeHazirGiyim>
    {
        public ZetaCodeHazirGiyimMap()
            : this("dbo")
        {
        }

        public ZetaCodeHazirGiyimMap(string schema)
        {
            ToTable("ZetaCodeHazirGiyim", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UrunIsmi).HasColumnName(@"UrunIsmi").HasColumnType("nvarchar").IsOptional().HasMaxLength(300);
            Property(x => x.UrunKategoriId).HasColumnName(@"UrunKategoriId").HasColumnType("int").IsOptional();
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.UlkeId).HasColumnName(@"UlkeId").HasColumnType("int").IsOptional();
            Property(x => x.Master).HasColumnName(@"Master").HasColumnType("bit").IsRequired();
            Property(x => x.BlueUrunKodIsmi).HasColumnName(@"BlueUrunKodIsmi").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.BlueSiparisNo).HasColumnName(@"BlueSiparisNo").HasColumnType("int").IsOptional();
            Property(x => x.ZetaCode).HasColumnName(@"ZetaCode").HasColumnType("int").IsRequired();
            Property(x => x.PantoneId).HasColumnName(@"PantoneId").HasColumnType("int").IsOptional();
            Property(x => x.Renkid).HasColumnName(@"Renkid").HasColumnType("int").IsOptional();
            Property(x => x.RafyeriTurkiyeId).HasColumnName(@"RafyeriTurkiyeId").HasColumnType("int").IsOptional();
            Property(x => x.RafyeriYunanistanId).HasColumnName(@"RafyeriYunanistanId").HasColumnType("int").IsOptional();
            Property(x => x.ZetaCodePrevious).HasColumnName(@"ZetaCodePrevious").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.En).HasColumnName(@"En").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Boy).HasColumnName(@"Boy").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Gram).HasColumnName(@"Gram").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.KategoriId).HasColumnName(@"KategoriId").HasColumnType("int").IsOptional();
            Property(x => x.BaskiGoruntuId).HasColumnName(@"BaskiGoruntuId").HasColumnType("int").IsOptional();
            Property(x => x.YikamaTalimatiKuruTemizleme).HasColumnName(@"YikamaTalimatiKuruTemizleme").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.YikamaTalimatiYikamaSekli).HasColumnName(@"YikamaTalimatiYikamaSekli").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.YikamaTalimatiYikamaMaxDerecesi).HasColumnName(@"YikamaTalimatiYikamaMaxDerecesi").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.YikamaTalimatiUtulemeMaxDerecesi).HasColumnName(@"YikamaTalimatiUtulemeMaxDerecesi").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.YikamaTalimatiTersYikama).HasColumnName(@"YikamaTalimatiTersYikama").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.YikamaTalimatiCekemezlik).HasColumnName(@"YikamaTalimatiCekemezlik").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.YikamaTalimatiDonmezlik).HasColumnName(@"YikamaTalimatiDonmezlik").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.YikamaTalimatiYikamaAdedi).HasColumnName(@"YikamaTalimatiYikamaAdedi").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsRequired();
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
