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

    // ZetaCode_HazirGiyim_KumasOrmeDokuma
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeHazirGiyimKumasOrmeDokumaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeHazirGiyimKumasOrmeDokuma>
    {
        public ZetaCodeHazirGiyimKumasOrmeDokumaMap()
            : this("dbo")
        {
        }

        public ZetaCodeHazirGiyimKumasOrmeDokumaMap(string schema)
        {
            ToTable("ZetaCode_HazirGiyim_KumasOrmeDokuma", schema);
            HasKey(x => new { x.HazirGiyimId, x.KumasOrmeDokumaId });

            Property(x => x.HazirGiyimId).HasColumnName(@"HazirGiyimId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.KumasOrmeDokumaId).HasColumnName(@"KumasOrmeDokumaId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
