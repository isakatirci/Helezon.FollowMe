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

    // PersonnelPicture
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelPicture: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 200)
        public string Extension { get; set; } // Extension (length: 50)
        public bool IsFeatured { get; set; } // IsFeatured
        public string PersonnelId { get; set; } // PersonnelId (length: 128)
        public string CompanyId { get; set; } // CompanyId (length: 128)
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [PersonnelPicture].([PersonnelId]) (FK_PersonnelImage_Person)
        /// </summary>
        public virtual Person Person { get; set; } // FK_PersonnelImage_Person

        public PersonnelPicture()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
