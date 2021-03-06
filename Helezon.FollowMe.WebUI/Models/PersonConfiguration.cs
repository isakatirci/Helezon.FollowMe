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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FollowMe.Web.Models
{

    // Person
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
            : this("dbo")
        {
        }

        public PersonConfiguration(string schema)
        {
            Property(x => x.Tckn).IsOptional();
            Property(x => x.Email).IsOptional();
            Property(x => x.PersonnelEmail).IsOptional();
            Property(x => x.Birthplace).IsOptional();
            Property(x => x.MaritalStatus).IsOptional();
            Property(x => x.BirthDay).IsOptional();
            Property(x => x.IsPassive).IsOptional();
            Property(x => x.CreatedOn).IsOptional();
            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.ChangedOn).IsOptional();
            Property(x => x.ChangedBy).IsOptional();
            Property(x => x.DriversLicenseNo).IsOptional();
            Property(x => x.PassportNo).IsOptional();
            Property(x => x.ForeignIdentityNo).IsOptional();
            Property(x => x.RelationshipStatusId).IsOptional();
            Property(x => x.ReligionId).IsOptional();
            Property(x => x.BloodGroupId).IsOptional();
            Property(x => x.EducationLevelId).IsOptional();
            Property(x => x.NameDay).IsOptional();
            Property(x => x.Interphone).IsOptional();
            Property(x => x.ReasonWhyPassiveId).IsOptional();
            Property(x => x.PositionId).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
