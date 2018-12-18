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

    // PersonnelTelephone
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelTelephoneMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PersonnelTelephone>
    {
        public PersonnelTelephoneMap()
            : this("dbo")
        {
        }

        public PersonnelTelephoneMap(string schema)
        {
            ToTable("PersonnelTelephone", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.PersonnelId).HasColumnName(@"PersonnelId").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.TelephoneTypeId).HasColumnName(@"TelephoneTypeId").HasColumnType("int").IsRequired();
            Property(x => x.Number).HasColumnName(@"Number").HasColumnType("nchar").IsOptional().IsFixedLength().HasMaxLength(14);
            Property(x => x.AreaCode).HasColumnName(@"AreaCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.Interphone).HasColumnName(@"Interphone").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsOptional();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.ChangedOn).HasColumnName(@"ChangedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.ChangedBy).HasColumnName(@"ChangedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);

            // Foreign keys
            HasOptional(a => a.Person).WithMany(b => b.PersonnelTelephones).HasForeignKey(c => c.PersonnelId).WillCascadeOnDelete(false); // FK_PersonnelTelephone_Person
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
