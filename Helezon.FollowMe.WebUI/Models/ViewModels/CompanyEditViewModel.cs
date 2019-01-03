using FollowMe.Web;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//
//            ViewBag.Addresses = new List<CompanyAddress>() { new CompanyAddress() { } };
//            ViewBag.Banks = new List<CompanyBank> { new CompanyBank() };

//            ViewBag.AreaCodes = GetAreaCodes();
//            ViewBag.CurrencyTypes = _currencyTypes.Value;
//            ViewBag.ReasonWhyPassives = _reasonWhyPassives.Value;
//            ViewBag.BankNames = _bankNames.Value;
//            ViewBag.ParentCompanyTypes = _parentCompanyTypes.Value;
//            ViewBag.LogisticsCompanies = new List<LogisticsCompany> { new LogisticsCompany() };
//            ViewBag.Person_Position = new SelectList(db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.Position).ToList(), "Id", "Name");
//            ViewBag.CountryList = _addressGuideCountries.Value;


namespace Helezon.FollowMe.WebUI.Models.ViewModels
{
    public class BankViewModel {

        public string SwiftNo { get; set; }

        [Display(Name = "Bank CurrencyType")]
        public string CurrencyType { get; set; }

        [Display(Name = "Bank Name")]
        public string Name { get; set; }

        public int BankNameTermId { get; set; }

        public string BankNameTermName { get; set; }

        public int CurrencyTypeTermId { get; set; }

        public string CurrencyTypeTermName { get; set; }

        public string BranchNameCode { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string BranchCode { get; set; }

        public string BranchName { get; set; }

        public string AccountNo { get; set; }

        public string Iban { get; set; }
    }
    public class CompanyViewModel {

        public Company Company { get; set; }

        [Display(Name = "Company Root Type Name")]
        public string CompanyRootTypeName { get; set; }

        [Display(Name = "AddressTypeName")]
        public string AddressTypeName { get; set; }

        public List<Term> Sector { get; set; }

        //public List<Term> CompanyTypes { get; set; }

        public TaxonomyViewModel CompanyTypesTaxonomyViewModel { get; set; }

        public string TempReasonWhyPassiveTermId { get; set; }

        public string TempFoundingDate { get; set; }
        //Addresses = new List<CompanyAddress>()
        //Banks = new List<CompanyBank>
        public List<CompanyAddress> Addresses { get; set; }
        public List<CompanyBank> Banks { get; set; }
        public CompanyViewModel()
        {
            Addresses = new List<CompanyAddress>();
            Banks = new List<CompanyBank>();
        }
    }
    public class PersonnelViewModel {
        [StringLength(64)]
        [Required]
        [Display(Name = "Person FirstName")]
        public string FirstName { get; set; }


        [StringLength(64)]
        [Required]
        [Display(Name = "Person LastName")]
        public string LastName { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "Person Telephone")]
        public string Telephone { get; set; }


        [StringLength(150)]
        [Display(Name = "Person Interphone")]
        public string Interphone { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "Company Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(150)]
        [Display(Name = "Personel Email")]
        [DataType(DataType.EmailAddress)]
        public string PersonnelEmail { get; set; }


        [Required]
        [Display(Name = "Person Gender")]
        public int GenderTypeId { get; set; }


        [StringLength(150)]
        [Display(Name = "Person BirthDay")]
        public string BirthDay { get; set; }


        public int Position { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "Person AreaCode")]
        public string AreaCode { get; set; }
    }
    public class CompanyEditViewModelCollections
    {
        public List<PairIdName> AreaCodes { get; set; }
        public List<SelectListItem> CurrencyTypes { get; set; }
        public List<SelectListItem> ReasonWhyPassives { get; set; }
        public List<SelectListItem> BankNames { get; set; }
        public List<SelectListItem> ParentCompanyTypes { get; set; }
        public List<LogisticsCompany> LogisticsCompanies { get; set; }
        public List<CompanyAddress> PersonPositions { get; set; }
        public List<string> CountryList { get; set; }
    }
    public class CompanyEditViewModel
    {
        public CompanyEditViewModel()
        {
            Company = new CompanyViewModel();
            PersonnelBank = new BankViewModel();
            Personnel = new PersonnelViewModel();
        }
        public CompanyViewModel Company { get; set; }
        public BankViewModel PersonnelBank { get; set; }
        public PersonnelViewModel Personnel { get; set; }
        public string Operation { get; set; }
        public bool CompanyIdIsNullOrEmpty
        {
            get
            {
                return Company == null
                    || string.IsNullOrWhiteSpace(Company.Company.Id)
                    || string.CompareOrdinal(Company.Company.Id, Guid.Empty.ToString()) == 0;
            }
        }
        public bool CompanyAddressIsCenter
        {
            get
            {
                return !CompanyIdIsNullOrEmpty
                    && Company.Company.AddressTypeId.HasValue
                    && Company.Company.AddressTypeId.Value == (int)AddressType.Merkez;
            }
        }
        //	var addingNewChild = (bool)(ViewBag.IsAddingNewSubchild != null && ((bool)ViewBag.IsAddingNewSubchild));
        public bool AddingNewSubchild { get; set; }
        public CompanyEditViewModelCollections Collections { get; set; }
    }
}