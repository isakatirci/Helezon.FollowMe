using FollowMe.Web.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    public partial class LogisticsCompany
    {
        [NotMapped]
        public string LogisticsCompanyName { get; set; }
    }
    public class CompanyMetadata
    {
        [WebsiteValidation(comparisonProperty: "IsWebsiteAvailable", ErrorMessage = "Web Site Giriniz")]
        //[Remote(action: "TestAction", controller: "Company", ErrorMessage = "Deneme Yanılma.")]
        public string Website { get; set; }
    }
    [MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {

        partial void InitializePartial() {

            this.IsWebsiteAvailable = true;
            CompanyTypesTaxonomyViewModel = new TaxonomyViewModel(TaxonomyType.CompanyType);
        }
        //
        [NotMapped]
        [Display(Name = "Company Root Type Name")]
        public string CompanyRootTypeName { get; set; }

        [NotMapped]
        [Display(Name = "AddressTypeName")]
        public string AddressTypeName { get; set; }

        [NotMapped]
        public List<Term> ProductType { get; set; }
        [NotMapped]
        public List<Term> Sector { get; set; }
        [NotMapped]
        public List<Term> CompanyTypes { get; set; }
        [NotMapped]
        public TaxonomyViewModel CompanyTypesTaxonomyViewModel { get; set; }
        [NotMapped]
        [StringLength(64)]
        [Required]
        [Display(Name = "Person FirstName")]
        public string Person_FirstName { get; set; }

        [NotMapped]
        [StringLength(64)]
        [Required]
        [Display(Name = "Person LastName")]
        public string Person_LastName { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Required]
        [Display(Name = "Person Telephone")]
        public string Person_Telephone { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Display(Name = "Person Interphone")]
        public string Person_Interphone { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Required]
        [Display(Name = "Company Email")]
        [DataType(DataType.EmailAddress)]
        public string Person_Email { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Display(Name = "Personel Email")]
        [DataType(DataType.EmailAddress)]
        public string Person_PersonnelEmail { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Person Gender")]
        public int Person_GenderTypeId { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Display(Name = "Person BirthDay")]
        public string Person_BirthDay { get; set; }

        [NotMapped]
        public int Person_Position { get; set; }

        [NotMapped]
        [StringLength(150)]
        [Required]
        [Display(Name = "Person AreaCode")]
        public string Person_AreaCode { get; set; }

        

        [NotMapped]
        public string Person_Bank_SwiftNo { get; set; }

        [NotMapped]
        [Display(Name = "Bank CurrencyType")]
        public string Person_Bank_CurrencyType { get; set; }
        [NotMapped]
        [Display(Name = "Bank Name")]
        public string Person_Bank_Name { get; set; }
        [NotMapped]
        public int Person_Bank_BankNameTermId { get; set; }
        [NotMapped]
        public string Person_Bank_BankNameTermName { get; set; }
        [NotMapped]
        public int Person_Bank_CurrencyTypeTermId { get; set; }
        [NotMapped]
        public string Person_Bank_CurrencyTypeTermName { get; set; }
        [NotMapped]
        public string Person_Bank_BranchNameCode { get; set; }
        [NotMapped]
        public string Person_Bank_Province { get; set; }
        [NotMapped]
        public string Person_Bank_District { get; set; }
        [NotMapped]
        public string Person_Bank_BranchCode { get; set; }
        [NotMapped]
        public string Person_Bank_BranchName { get; set; }
        [NotMapped]
        public string Person_Bank_AccountNo { get; set; }
        [NotMapped]
        public string Person_Bank_Iban { get; set; }
        [NotMapped]
        public string TempReasonWhyPassiveTermId { get; set; }

        [NotMapped]
        public string TempFoundingDate { get; set; }        
    }

    public partial class CompanyAddress
    {
        [NotMapped]
        public List<string> ProvinceList { get; set; }
        [NotMapped]

        public List<string> SuburbAreaList { get; set; }
        [NotMapped]

        public List<string> DistrictList { get; set; }
        [NotMapped]

        public List<string> TownList { get; set; }
        [NotMapped]

        public List<string> ZipCodeList { get; set; }

        partial void InitializePartial()
        {
            ProvinceList = new List<string>();
            SuburbAreaList = new List<string>();
            DistrictList = new List<string>();
            TownList = new List<string>();
            ZipCodeList = new List<string>();
        }
    }

    public partial class PersonnelAddress
    {
        [NotMapped]
        public List<string> ProvinceList { get; set; }
        [NotMapped]

        public List<string> SuburbAreaList { get; set; }
        [NotMapped]

        public List<string> DistrictList { get; set; }
        [NotMapped]

        public List<string> TownList { get; set; }
        [NotMapped]

        public List<string> ZipCodeList { get; set; }

        partial void InitializePartial()
        {
            ProvinceList = new List<string>();
            SuburbAreaList = new List<string>();
            DistrictList = new List<string>();
            TownList = new List<string>();
            ZipCodeList = new List<string>();
        }
    }


    public partial class PersonnelEducation {
        [NotMapped]
        public string EducationLevelName { get; set; }
    }
    public partial class Person
    {
        [NotMapped]
        public List<List<string>> TelephoneListRotated { get; set; }
        //
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string BloodGroupName { get; set; }
        [NotMapped]
        public List<Term> Languages { get; set; }
        [NotMapped]
        public List<Term> Region { get; set; }
        [NotMapped]
        public List<Term> Departments { get; set; }
        [NotMapped]
        public List<Term> Positions { get; set; }
        [NotMapped]
        public List<Term> Authorities { get; set; }

        [NotMapped]
        public List<Term> PersonCategory { get; set; }

        [NotMapped]
        public List<Term> Nationality { get; set; }

        [NotMapped]
        public List<Term> JobExperience { get; set; }

        [NotMapped]
        public List<Term> Religion { get; set; }

        [NotMapped]
        public List<Term> RelationshipStatus { get; set; }
        [NotMapped]
        public List<Term> ComputerSkills { get; set; }        //

        [NotMapped]
        public List<Term> Hobby { get; set; }
        [NotMapped]

        public string BirthDayString { get; set; } // BirthDay

        [NotMapped]
        public string OfficeTelephone { get; set; } // BirthDay
        
        [NotMapped]
        public string JstreeSelectNodeScript { get; set; } // BirthDay
        [NotMapped]
        public string AjaxTreeFillScript { get; set; }
        [NotMapped]
        public string ChangedJstreeScript { get; set; }
        [NotMapped]
        public string RelationshipStatusName { get;  set; }
        [NotMapped]
        public string ReligionName { get;  set; }
        [NotMapped]
        public List<PersonnelEducation> EducationList { get; internal set; }

        partial void InitializePartial()
        {
            JstreeSelectNodeScript = string.Empty;
            BirthDayString = string.Empty;
            AjaxTreeFillScript = string.Empty;
            ChangedJstreeScript = string.Empty;
            Languages = new List<Term>();
            Region = new List<Term>();
            Departments = new List<Term>();
            Positions = new List<Term>();
            Authorities = new List<Term>();
            PersonCategory = new List<Term>();
            Nationality = new List<Term>();
            JobExperience = new List<Term>();
            Religion = new List<Term>();
            Hobby = new List<Term>();
            TelephoneListRotated = new List<List<string>>();
        }

    }




    public partial class CompanyBank 
    {        
        [NotMapped]
        public List<string> ProvinceList { get; set; }
        [NotMapped]
        public List<string> DistrictList { get; set; }
        [NotMapped]
        public TermRelationship CurrencyType { get; set; }
        [NotMapped]
        public List<string> BranchNameCodeList { get; set; }
        [NotMapped]
        public List<string> SwiftNoList { get; set; }
    }

    public partial class PersonnelBank
    {
        [NotMapped]
        public TermRelationship CurrencyType { get; set; }
        [NotMapped]
        public List<string> BranchNameCodeList { get; set; }
        [NotMapped]
        public List<string> SwiftNoList { get; set; }
        [NotMapped]
        public List<string> ProvinceList { get; set; }
        [NotMapped]
        public List<string> DistrictList { get; set; }
    }
}