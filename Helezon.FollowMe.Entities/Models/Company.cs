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

    // Company
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class Company: Entity
    {
        public string Id { get; set; } // Id (Primary key) (length: 128)
        public string ParentId { get; set; } // ParentId (length: 128)
        public int? CompanyRootTypeId { get; set; } // CompanyRootTypeId
        public int Code { get; set; } // Code
        public string Name { get; set; } // Name (length: 256)
        public string Email { get; set; } // Email (length: 500)
        public string CompanyTitle { get; set; } // CompanyTitle (length: 512)
        public string Brand { get; set; } // Brand (length: 500)
        public string TaxNumber { get; set; } // TaxNumber (length: 10)
        public string TaxOffice { get; set; } // TaxOffice (length: 256)
        public string TradeRegisterNumber { get; set; } // TradeRegisterNumber (length: 100)
        public System.DateTime? FoundingDate { get; set; } // FoundingDate
        public bool? IsWebsiteAvailable { get; set; } // IsWebsiteAvailable
        public string Website { get; set; } // Website (length: 500)
        public int? ReasonWhyPassiveId { get; set; } // ReasonWhyPassiveId
        public string ReasonWhyPassiveTermName { get; set; } // ReasonWhyPassiveTermName (length: 500)
        public int? PersonLimit { get; set; } // PersonLimit
        public int? PersonLimitPercent { get; set; } // PersonLimitPercent
        public System.DateTime? ServiceStartDate { get; set; } // ServiceStartDate
        public System.DateTime? ServiceEndDate { get; set; } // ServiceEndDate
        public int? AddressTypeId { get; set; } // AddressTypeId
        public bool IsPassive { get; set; } // IsPassive
        public System.DateTime? CreatedOn { get; set; } // CreatedOn
        public string CreatedBy { get; set; } // CreatedBy (length: 128)
        public System.DateTime? ChangedOn { get; set; } // ChangedOn
        public string ChangedBy { get; set; } // ChangedBy (length: 128)

        // Reverse navigation

        /// <summary>
        /// Child CompanyAddresses where [CompanyAddress].[CompanyId] point to this entity (FK_CompanyAddress_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CompanyAddress> CompanyAddresses { get; set; } // CompanyAddress.FK_CompanyAddress_Company
        /// <summary>
        /// Child CompanyBanks where [CompanyBank].[CompanyId] point to this entity (FK_CompanyBank_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CompanyBank> CompanyBanks { get; set; } // CompanyBank.FK_CompanyBank_Company
        /// <summary>
        /// Child CompanyTelephones where [CompanyTelephone].[CompanyId] point to this entity (FK_CompanyTelephone_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CompanyTelephone> CompanyTelephones { get; set; } // CompanyTelephone.FK_CompanyTelephone_Company
        /// <summary>
        /// Child CompanyTerms where [CompanyTerm].[CompanyId] point to this entity (FK_CompanyTerm_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CompanyTerm> CompanyTerms { get; set; } // CompanyTerm.FK_CompanyTerm_Company
        /// <summary>
        /// Child LogisticsCompanies where [LogisticsCompany].[CompanyId] point to this entity (FK_LogisticsCompany_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<LogisticsCompany> LogisticsCompanies { get; set; } // LogisticsCompany.FK_LogisticsCompany_Company
        /// <summary>
        /// Child People where [Person].[CompanyId] point to this entity (FK_Person_Company)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Person> People { get; set; } // Person.FK_Person_Company

        public Company()
        {
            CompanyAddresses = new System.Collections.Generic.List<CompanyAddress>();
            CompanyBanks = new System.Collections.Generic.List<CompanyBank>();
            CompanyTelephones = new System.Collections.Generic.List<CompanyTelephone>();
            CompanyTerms = new System.Collections.Generic.List<CompanyTerm>();
            LogisticsCompanies = new System.Collections.Generic.List<LogisticsCompany>();
            People = new System.Collections.Generic.List<Person>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>