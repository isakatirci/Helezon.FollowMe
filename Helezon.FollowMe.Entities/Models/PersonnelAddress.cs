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
    using FollowMe.Entities.Models.Mapping;
    using Repository.Pattern.Ef6;

    // PersonnelAddress
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PersonnelAddress: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string CompanyId { get; set; } // CompanyId (length: 128)
        public string PersonnelId { get; set; } // PersonnelId (length: 128)
        public int? AddressType { get; set; } // AddressType
        public string Province { get; set; } // Province (length: 500)
        public string District { get; set; } // District (length: 500)
        public string Country { get; set; } // Country (length: 500)
        public string Line1 { get; set; } // Line1 (length: 500)
        public string Line2 { get; set; } // Line2 (length: 500)
        public string ZipCode { get; set; } // ZipCode (length: 500)
        public string SuburbArea { get; set; } // SuburbArea (length: 500)
        public string Town { get; set; } // Town (length: 500)
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [PersonnelAddress].([PersonnelId]) (FK_PersonnelAddress_Person)
        /// </summary>
        public virtual Person Person { get; set; } // FK_PersonnelAddress_Person

        public PersonnelAddress()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>