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

    // ZetaCode_NormalKumas_NormalIplik
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeNormalKumasNormalIplikMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeNormalKumasNormalIplik>
    {
        public ZetaCodeNormalKumasNormalIplikMap()
            : this("dbo")
        {
        }

        public ZetaCodeNormalKumasNormalIplikMap(string schema)
        {
            ToTable("ZetaCode_NormalKumas_NormalIplik", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NormalKumasId).HasColumnName(@"NormalKumasId").HasColumnType("int").IsRequired();
            Property(x => x.NormalIplikId).HasColumnName(@"NormalIplikId").HasColumnType("int").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
