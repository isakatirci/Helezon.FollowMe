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

    // ZetaCodeFanteziIplik
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ZetaCodeFanteziIplikMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ZetaCodeFanteziIplik>
    {
        public ZetaCodeFanteziIplikMap()
            : this("dbo")
        {
        }

        public ZetaCodeFanteziIplikMap(string schema)
        {
            ToTable("ZetaCodeFanteziIplik", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>