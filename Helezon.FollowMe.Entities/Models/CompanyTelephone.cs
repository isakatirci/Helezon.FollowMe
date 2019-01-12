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

    // CompanyTelephone
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class CompanyTelephone: Entity
    {
        public int Id { get; set; } // Id (Primary key)
        public string CompanyId { get; set; } // CompanyId (length: 128)
        public int TelephoneTypeId { get; set; } // TelephoneTypeId
        public string Number { get; set; } // Number (length: 14)
        public string AreaCode { get; set; } // AreaCode
        public string Interphone { get; set; } // Interphone
        public bool? IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        // Foreign keys

        /// <summary>
        /// Parent Company pointed by [CompanyTelephone].([CompanyId]) (FK_CompanyTelephone_Company)
        /// </summary>
        public virtual Company Company { get; set; } // FK_CompanyTelephone_Company

        public CompanyTelephone()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
