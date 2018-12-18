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

    // PersonnelTerm
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelTermMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PersonnelTerm>
    {
        public PersonnelTermMap()
            : this("dbo")
        {
        }

        public PersonnelTermMap(string schema)
        {
            ToTable("PersonnelTerm", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TaxonomyId).HasColumnName(@"TaxonomyId").HasColumnType("int").IsRequired();
            Property(x => x.TermId).HasColumnName(@"TermId").HasColumnType("int").IsRequired();
            Property(x => x.PersonnelId).HasColumnName(@"PersonnelId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsOptional();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.PassiveOn).HasColumnName(@"PassiveOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.PassiveBy).HasColumnName(@"PassiveBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonnelTerms).HasForeignKey(c => c.PersonnelId).WillCascadeOnDelete(false); // FK_PersonnelTerm_Person
            HasRequired(a => a.Term).WithMany(b => b.PersonnelTerms).HasForeignKey(c => c.TermId).WillCascadeOnDelete(false); // FK_PersonnelTerm_Term
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
