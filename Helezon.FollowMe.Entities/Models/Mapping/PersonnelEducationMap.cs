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

    // PersonnelEducation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelEducationMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PersonnelEducation>
    {
        public PersonnelEducationMap()
            : this("dbo")
        {
        }

        public PersonnelEducationMap(string schema)
        {
            ToTable("PersonnelEducation", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PersonnelId).HasColumnName(@"PersonnelId").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.StudiedSchoolName).HasColumnName(@"StudiedSchoolName").HasColumnType("nvarchar").IsOptional().HasMaxLength(500);
            Property(x => x.EducationLevelId).HasColumnName(@"EducationLevelId").HasColumnType("int").IsOptional();
            Property(x => x.EducationArea).HasColumnName(@"EducationArea").HasColumnType("nvarchar").IsOptional().HasMaxLength(500);
            Property(x => x.IsPassive).HasColumnName(@"IsPassive").HasColumnType("bit").IsRequired();
            Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.ChangedOn).HasColumnName(@"ChangedOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.ChangedBy).HasColumnName(@"ChangedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
            Property(x => x.MakedPassiveOn).HasColumnName(@"MakedPassiveOn").HasColumnType("datetime2").IsOptional();
            Property(x => x.MakedPassiveBy).HasColumnName(@"MakedPassiveBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);

            // Foreign keys
            HasOptional(a => a.Person).WithMany(b => b.PersonnelEducations).HasForeignKey(c => c.PersonnelId).WillCascadeOnDelete(false); // FK_PersonnelEducation_Person
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>