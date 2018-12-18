using FollowMe.Web.Models;
using Helezon.FollowMe.Service;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;



namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ICompanyService CompanyService;
        public readonly IUnitOfWorkAsync UnitOfWorkAsync;
        private readonly DbContext _followMeDbContext;
        public BaseController()
        {
            _followMeDbContext = new Helezon.FollowMe.Entities.Models.FollowMeDbContext("GLCEmasEntities");
            UnitOfWorkAsync = new UnitOfWork(_followMeDbContext);
            CompanyService = new CompanyService(new Repository<Helezon.FollowMe.Entities.Models.Company>(_followMeDbContext, UnitOfWorkAsync));
        }

        public class ForeingKeyIdRefreshParametres
        {
            public string tableName { get; set; }
            public string valueField { get; set; }
            public string textField { get; set; }
        }  

        //public List<Email> FillEmailList(string companyId, string entityId, EntityType entityType)
        //{

        //    var emails = new List<Email>();
        //    var i = 0;
        //    while (true)
        //    {
        //        var emailAdres = Request["group-email[" + i + "][EmailAdress]"];

        //        if (string.IsNullOrWhiteSpace(emailAdres))
        //            break;

        //        var email = new Email();
        //        email.EmailAdress = emailAdres;
        //        email.CompanyId = companyId;
        //        email.EntityId = entityId;
        //        email.EntityType = (int)entityType;
        //        email.CreatedAt = DateTime.Now;
        //        emails.Add(email);
        //        i++;
        //    }
        //    return emails;
        //}

        protected List<Tuple<int, int>> GetListNewTerms(TaxonomyType[] taxonomyTypes,string companyId)
        {         

            var listNewTerms = new List<Tuple<int, int>>();

            foreach (var item in taxonomyTypes)
            {
                var ids = Request[item.ToString() + "Id"];
                if (ids.IsNullOrWhiteSpace().Not())
                {
                    listNewTerms.AddRange(ids
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => string.CompareOrdinal(x, "0") != 0)
                        .Select(x => Tuple.Create(int.Parse(x), (int)item)));
                }

                var others = Request[item.ToString() + "NameOthers"];
                if (others.IsNullOrWhiteSpace().Not())
                {
                    var terms = others.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var newItem in terms)
                    {
                        var newTerm = new Term
                        {
                            Name = newItem.Trim(),
                            CreatedBy = User.Identity.GetUserId(),
                            CreatedOn = DateTime.UtcNow,
                            CompanyId = Guid.Empty.ToString(),
                            TaxonomyId = (int)item
                        };
                       
                        db.Term.Add(newTerm);
                        db.SaveChanges();
                        var tax = new TermTaxonomy
                        {
                            TermId = newTerm.Id,
                            Parent = 0,
                            TaxonomyId = (int)item,
                            CompanyId = Guid.Empty.ToString(),                            
                            CreatedBy = User.Identity.GetUserId(),
                            CreatedOn = DateTime.UtcNow,
                        };
                        db.TermTaxonomy.Add(tax);
                        db.SaveChanges();
                        listNewTerms.Add(Tuple.Create(newTerm.Id, (int)item));
                    }
                }
            }
            return listNewTerms;
        }
        protected void SaveEntityTerms(List<Tuple<int, int>> listNewTerms, string entityId,string companyId)
        {          

            var termRelationships = (from r in db.TermRelationship
                                     where r.EntityId == entityId
                                     select r).ToList();

            foreach (var item in termRelationships)
            {
                item.IsPassive = true;
                item.ChangedBy = User.Identity.GetUserId();
                item.ChangedOn = DateTime.UtcNow;
                db.Entry(item).State = EntityState.Modified;

            }

            var dictermRelationships = termRelationships.ToDictionary(x => x.TermId);

            foreach (var item in listNewTerms)
            {
                if (dictermRelationships.ContainsKey(item.Item1))
                {
                    dictermRelationships[item.Item1].IsPassive = false;
                    dictermRelationships[item.Item1].ChangedBy = null;
                    dictermRelationships[item.Item1].ChangedOn = null;
                }
                else
                {
                    db.TermRelationship.Add(new TermRelationship
                    {
                        EntityId = entityId,
                        CompanyId = companyId,
                        TermId = item.Item1,
                        TaxonomyId = item.Item2,
                        CreatedBy = User.Identity.GetUserId(),
                        CreatedOn = DateTime.UtcNow
                    });
                }
            }
        }

        public List<CompanyTelephone> FillTelefonListCompany(string companyId)
        {
            var telephones = new List<CompanyTelephone>();
            var i = 0;
            while (true)
            {
                var number = Request["group-telephone[" + i + "][Number]"];
                var areaCode = Request["group-telephone[" + i + "][AreaCode]"];
                var telephoneType = Request["group-telephone[" + i + "][TelephoneType]"];
                if (string.IsNullOrWhiteSpace(number))
                    break;
                var telephone = new CompanyTelephone();
                telephone.Number = number;
                telephone.AreaCode = areaCode.IsNullOrWhiteSpace() ? "Türkiye (+90)" : areaCode;
                telephone.TelephoneTypeId = int.Parse(telephoneType ?? "0");
                telephone.CompanyId = companyId;
                telephones.Add(telephone);
                i++;
            }
            return telephones;
        }


        public List<PersonnelTelephone> FillTelefonListPersonnel(string companyId)
        {
            var telephones = new List<PersonnelTelephone>();
            var i = 0;
            while (true)
            {
                var number = Request["group-telephone[" + i + "][Number]"];
                var areaCode = Request["group-telephone[" + i + "][AreaCode]"];
                var telephoneType = Request["group-telephone[" + i + "][TelephoneType]"];
                if (string.IsNullOrWhiteSpace(number))
                    break;
                var telephone = new PersonnelTelephone();
                telephone.Number = number;
                telephone.AreaCode = areaCode.IsNullOrWhiteSpace() ? "Türkiye (+90)" : areaCode;
                telephone.TelephoneTypeId = int.Parse(telephoneType ?? "0");
                telephone.CompanyId = companyId;
                telephones.Add(telephone);
                i++;
            }
            return telephones;
        }


        public List<CompanyAddress> FillAddressListCompany(string companyId)
        {
            var addresses = new List<CompanyAddress>();
            var i = 0;
            while (true)
            {
                var addressType = Request["group-address[" + i + "][AddressType]"];
                var country = Request["group-address[" + i + "][Country]"];
                var province = Request["group-address[" + i + "][Province]"];
                var district = Request["group-address[" + i + "][District]"];
                var suburbArea = Request["group-address[" + i + "][SuburbArea]"];
                var town = Request["group-address[" + i + "][Town]"];
                var zipCode = Request["group-address[" + i + "][ZipCode]"];
                var line1 = Request["group-address[" + i + "][Line1]"];
                var line2 = Request["group-address[" + i + "][Line2]"];
                if (string.IsNullOrWhiteSpace(country))
                    break;
                var address = new CompanyAddress();
                address.AddressType = addressType.AsInt();
                address.Country = country;
                address.Province = province;
                address.District = district;
                address.SuburbArea = suburbArea;
                address.Town = town;
                address.ZipCode = zipCode;
                address.Line1 = line1;
                address.Line2 = line2;
                address.CompanyId = companyId;      
                address.CreatedOn = DateTime.Now;
                addresses.Add(address);
                i++;
            }
            return addresses;
        }


        public List<PersonnelAddress> FillAddressListPersonnel(string companyId, string personnelId)
        {
            var addresses = new List<PersonnelAddress>();
            var i = 0;
            while (true)
            {
                var addressType = Request["group-address[" + i + "][AddressType]"];
                var country = Request["group-address[" + i + "][Country]"];
                var province = Request["group-address[" + i + "][Province]"];
                var district = Request["group-address[" + i + "][District]"];
                var suburbArea = Request["group-address[" + i + "][SuburbArea]"];
                var town = Request["group-address[" + i + "][Town]"];
                var zipCode = Request["group-address[" + i + "][ZipCode]"];
                var line1 = Request["group-address[" + i + "][Line1]"];
                var line2 = Request["group-address[" + i + "][Line2]"];
                if (string.IsNullOrWhiteSpace(country))
                    break;
                var address = new PersonnelAddress();
                address.PersonnelId = personnelId;
                address.AddressType = addressType.AsInt();
                address.Country = country;
                address.Province = province;
                address.District = district;
                address.SuburbArea = suburbArea;
                address.Town = town;
                address.ZipCode = zipCode;
                address.Line1 = line1;
                address.Line2 = line2;
                address.CompanyId = companyId;
                address.CreatedOn = DateTime.Now;
                addresses.Add(address);
                i++;
            }
            return addresses;
        }


        public List<CompanyBank> FillCompanyBankList(string companyId)
        {
            var banks = new List<CompanyBank>();
            var i = 0;
            while (true)
            {
                var bankName = Request["group-bank[" + i + "][BankName]"];
                var branchNameCode = Request["group-bank[" + i + "][BranchNameCode]"];
                var accountNo = Request["group-bank[" + i + "][AccountNo]"];
                var iban = Request["group-bank[" + i + "][Iban]"];
                var swiftNo = Request["group-bank[" + i + "][SwiftNo]"];
                var currencyType = Request["group-bank[" + i + "][CurrencyType]"];
                var province = Request["group-bank[" + i + "][Province]"];
                var district = Request["group-bank[" + i + "][District]"];
                var bankId = Request["group-bank[" + i + "][BankId]"];

                if (string.IsNullOrWhiteSpace(bankName) || string.IsNullOrWhiteSpace(branchNameCode) || string.IsNullOrWhiteSpace(accountNo) || string.IsNullOrWhiteSpace(currencyType))
                    break;
                var bank1 = new CompanyBank();
                var temp = bankName.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                //bank1.BankNameTermName = temp[1];
                var temp1 = branchNameCode.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                bank1.BranchCode = temp1[1].Trim();
                bank1.BranchName = temp1[0].Trim();
                bank1.AccountNo = accountNo;
                bank1.District = district;
                bank1.Province = province;
                bank1.Iban = iban;
                bank1.Id = bankId.AsInt();
                bank1.BankNameTermId = int.Parse(temp[0]);
                bank1.SwiftNo = swiftNo;
                bank1.CompanyId = companyId;
                //bank1.EntityId = entityId;
                //bank1.EntityType = (int)entityType;
                var tempCurrencyTypeParts = currencyType.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                bank1.CurrencyTypeTermId = int.Parse(tempCurrencyTypeParts[0]);
                //bank1.CurrencyTypeTermName = tempCurrencyTypeParts[1];
                //bank1.CreatedOn = DateTime.Now;
                banks.Add(bank1);
                i++;
            }
            return banks;
        }
        public List<PersonnelBank> FillPersonnelBankList(string companyId, string personnelId)
        {
            var banks = new List<PersonnelBank>();
            var i = 0;
            while (true)
            {
                var bankName = Request["group-bank[" + i + "][BankName]"];
                var branchNameCode = Request["group-bank[" + i + "][BranchNameCode]"];
                var accountNo = Request["group-bank[" + i + "][AccountNo]"];
                var iban = Request["group-bank[" + i + "][Iban]"];
                var swiftNo = Request["group-bank[" + i + "][SwiftNo]"];
                var currencyType = Request["group-bank[" + i + "][CurrencyType]"];
                var province = Request["group-bank[" + i + "][Province]"];
                var district = Request["group-bank[" + i + "][District]"];
                if (string.IsNullOrWhiteSpace(bankName) || string.IsNullOrWhiteSpace(branchNameCode) || string.IsNullOrWhiteSpace(accountNo) || string.IsNullOrWhiteSpace(currencyType))
                    break;
                var bank1 = new PersonnelBank();
                var temp = bankName.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                //bank1.BankNameTermName = temp[1];
                var temp1 = branchNameCode.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                bank1.BranchCode = temp1[1].Trim();
                bank1.BranchName = temp1[0].Trim();
                bank1.AccountNo = accountNo;
                bank1.PersonnelId = personnelId;
                bank1.Iban = iban;
                bank1.District = district;
                bank1.Province = province;
                bank1.BankNameTermId = int.Parse(temp[0]);
                bank1.SwiftNo = swiftNo;
                bank1.CompanyId = companyId;
                //bank1.EntityId = entityId;
                //bank1.EntityType = (int)entityType;
                var tempCurrencyTypeParts = currencyType.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                bank1.CurrencyTypeTermId = int.Parse(tempCurrencyTypeParts[0]);
                //bank1.CurrencyTypeTermName = tempCurrencyTypeParts[1];
                bank1.CreatedOn = DateTime.Now;
                banks.Add(bank1);
                i++;
            }
            return banks;
        }


        //public ActionResult PartialPanelEmail(List<Email> emails)
        //{
        //    return PartialView(viewName: "_PanelEmail", model: emails);
        //}

        //public ActionResult PartialPanelPersonnelTelephone(List<CompanyTelephone> telephones)
        //{
        //    return PartialView(viewName: "_PanelPersonnelTelephone", model: telephones);
        //}

        public ActionResult PartialPanelCompanyTelephone(List<CompanyTelephone> telephones)
        {
            return PartialView(viewName: "_PanelCompanyTelephone", model: telephones);
        }
        public ActionResult PartialPanelPersonnelTelephone(List<PersonnelTelephone> telephones)
        {
            return PartialView(viewName: "_PanelPersonnelTelephone", model: telephones);
        }

        public ActionResult PartialPanelPersonnelEducation(List<PersonnelEducation> education)
        {
            ViewBag.EducationLevels = db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.EducationLevel).ToList();

            return PartialView(viewName: "_PanelPersonnelEducation", model: education);
        }
        //PartialPanelPersonnelTelephone

        protected static Lazy<List<string>> CountryList = new Lazy<List<string>>(GetCountryList,true);
        protected static List<string> GetCountryList()
        {            
            using (var db = new GLCEmasModel())
            {
                return db.AddressGuide
                       .Select(x => new { x.Priority, x.Country })
                       .Distinct().OrderBy(a => a.Priority)
                       .ThenBy(x => x.Country).Select(b => b.Country).ToList();
            }           
        }


        public ActionResult PartialPanelCompanyAddress(List<CompanyAddress> addresses)
        {
            ViewBag.CountryList = CountryList.Value;

            return PartialView(viewName: "_PanelCompanyAddress", model: addresses);
        }

        public ActionResult PartialPanelPersonnelAddress(List<PersonnelAddress> addresses)
        {
            ViewBag.CountryList = CountryList.Value;

            return PartialView(viewName: "_PanelPersonnelAddress", model: addresses);
        }


        public List<SelectListItem> GetTaxonomySelectListItem(TaxonomyType taxonomy)
        {
            return (from tx in db.TermTaxonomy
                    join te in db.Term
                        on tx.TermId equals te.Id
                    where tx.TaxonomyId == (int)TaxonomyType.BankName && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)taxonomy
                    select new SelectListItem
                    {
                        Text = te.Name,
                        Value = te.Id.ToString() + "|" + te.Name,
                        //Selected = termId != 0 && termId == te.Id
                    }).ToList();
        }



        protected static Lazy<List<SelectListItem>> _bankNames = new Lazy<List<SelectListItem>>(GetBankNames);
        private static List<SelectListItem> GetBankNames()
        {
            GLCEmasModel db = new GLCEmasModel();
            return (from tx in db.TermTaxonomy
                    join te in db.Term
                        on tx.TermId equals te.Id
                    where tx.TaxonomyId == (int)TaxonomyType.BankName && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.BankName
                    select new SelectListItem
                    {
                        Text = te.Name,
                        Value = te.Id.ToString() + "|" + te.Name,
                        //Selected = termId != 0 && termId == te.Id
                    }).ToList().OrderBy(x=>x.Text).ToList();
        }

        protected static Lazy<List<SelectListItem>> _currencyTypes = new Lazy<List<SelectListItem>>(GetCurrencyTypes);
        private static List<SelectListItem> GetCurrencyTypes()
        {
            GLCEmasModel db = new GLCEmasModel();
            return (from tx in db.TermTaxonomy
                    join te in db.Term
                        on tx.TermId equals te.Id
                    where tx.TaxonomyId == (int)TaxonomyType.CurrencyType && tx.CompanyId == Guid.Empty.ToString()
                    && te.CompanyId == Guid.Empty.ToString()
                    && te.TaxonomyId == (int)TaxonomyType.CurrencyType
                    && tx.Parent == 0
                    select new SelectListItem
                    {
                        Text = te.Name,
                        Value = te.Id.ToString() + "|" + te.Name,
                        //Selected = termId != 0 && termId == te.Term_Id
                    }).ToList();
        }


        //public List<SelectListItem> GetBankNames()
        //{
        //    return (from tx in db.TermTaxonomy
        //            join te in db.Term
        //                on tx.TermId equals te.Id
        //            where tx.TaxonomyId == (int)TaxonomyType.BankName && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.BankName
        //            select new SelectListItem
        //            {
        //                Text = te.Name,
        //                Value = te.Id.ToString() + "|" + te.Name,
        //                //Selected = termId != 0 && termId == te.Id
        //            }).ToList();





        //}

        //public List<SelectListItem> GetCurrencyTypes()
        //{
        //    return (from tx in db.TermTaxonomy
        //            join te in db.Term
        //                on tx.TermId equals te.Id
        //            where tx.TaxonomyId == (int)TaxonomyType.CurrencyType && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.CurrencyType && tx.Parent == 0
        //            select new SelectListItem
        //            {
        //                Text = te.Name,
        //                Value = te.Id.ToString() + "|" + te.Name,
        //                //Selected = termId != 0 && termId == te.Term_Id
        //            }).ToList(); 
        //}


        public ActionResult PartialCompanyPanelBank(List<CompanyBank> banks)
        {
            ViewBag.BankNames = GetBankNames();
            ViewBag.CurrencyTypes = GetCurrencyTypes();

            return PartialView(viewName: "_PanelCompanyBank", model: banks);
        }

        public ActionResult PartialPersonnelPanelBank(List<PersonnelBank> banks)
        {
            ViewBag.BankNames = GetBankNames();
            ViewBag.CurrencyTypes = GetCurrencyTypes();

            return PartialView(viewName: "_PanelPersonnelBank", model: banks);
        }


        protected GLCEmasModel db = new GLCEmasModel();


        /*
         
             
                      d.parent(".form-group").find("#Province").empty();
            d.parent(".form-group").find("#District").empty();
            d.parent(".form-group").find("#SuburbAreaTown").empty();
             
             
             */

        [HttpGet]
        public JsonResult GetProvinces(string country)
        {
            var provinces = db.AddressGuide.Where(x => x.Country == country).Select(x => x.Province).Distinct().ToList()
                 .Where(x => x.IsNullOrWhiteSpace().Not())
                .ToList();
            return Json(provinces, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDistricts(string country, string province)
        {

            var districts = db.AddressGuide
                .Where(x => x.Country == country && x.Province == province)
                .Select(x => x.District).Distinct().ToList()
                 .Where(x => x.IsNullOrWhiteSpace().Not())
                .ToList();
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSuburbAreas(string country, string province, string district)
        {
            var suburbAreas = db.AddressGuide
                .Where(x => x.Country == country && x.Province == province && x.District == district)
                .Select(x => x.SuburbArea).Distinct()
                .ToList()
                .Where(x => x.IsNullOrWhiteSpace().Not())
                .ToList();
            return Json(suburbAreas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTowns(string country, string province, string district, string suburbArea)
        {
            var towns = db.AddressGuide.Where(x => x.Country == country && x.Province == province && x.District == district && x.SuburbArea == suburbArea).Select(x => x.Town).Distinct().ToList()
                 .Where(x => x.IsNullOrWhiteSpace().Not())
                .ToList();
            return Json(towns, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetZipCodes(string country, string province, string district, string suburbArea)
        {
            var zipCodes = db.AddressGuide.Where(x => x.Country == country && x.Province == province && x.District == district && x.SuburbArea == suburbArea)
                .Select(x => x.ZipCode).Distinct().ToList().Where(x => x.IsNullOrWhiteSpace().Not())
                .ToList();
            return Json(zipCodes, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetBankProvinces(string termId)
        {
            var temp = termId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(temp[0].Trim());
            var list = db.BankGuide.Where(x => x.TermId == id).Select(x => x.Province).Distinct().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBankDistrictes(string termId,string province)
        {
            var temp = termId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(temp[0].Trim());
            var list = db.BankGuide.Where(x => x.TermId == id && x.Province == province).Select(x => x.District).Distinct().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetBranchNameCodes(string termId, string province, string district)
        {
            var temp = termId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(temp[0].Trim());
            var branchNameCodes = db.BankGuide.Where(x => x.TermId == id 
            && x.Province == province
             && x.District == district).Select(x => x.BranchName + " - " + x.BranchCode).Distinct().ToList();
            return Json(branchNameCodes, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetSwiftNos(string termId, string province, string district, string branchNameCode)
        {
            var termParts = termId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (termParts.IsEmpty().Not())
            {
                var id = int.Parse(termParts[0].Trim());
                var branchParts = branchNameCode.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (branchParts.IsEmpty().Not() && branchParts.Length > 1)
                {
                    var name = branchParts[0].Trim();
                    var code = branchParts[1].Trim();
                    var branchNameCodes = db.BankGuide.Where(x => x.TermId == id && x.BranchName == name && x.BranchCode == code).Select(x => x.SwiftNo).Distinct().ToList();
                    return Json(branchNameCodes, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new List<string>(), JsonRequestBehavior.AllowGet);
        }



        public ActionResult ForeingKeyId(string iframeUrl, string modalTitle)
        {
            ViewBag.IFameUrl = iframeUrl;
            ViewBag.ModalTitle = modalTitle;
            TempData["iframeWindow"] = true;
            return PartialView();
        }



        //string dataValueField, string dataTextField);
        public ActionResult DropDownListRefresh(string tableName)
        {

            switch (tableName)
            {
                case "Company":
                    var company = db.Company.Select(x => new
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name ?? string.Empty,
                    }).ToList();
                    return Json(company, JsonRequestBehavior.AllowGet);

                //case "Discriminator":
                //    var discriminator = db.Discriminator.Select(x => new
                //    {
                //        Value = x.Id.ToString(),
                //        Text = x.Name ?? string.Empty,
                //    }).ToList();
                //    return Json(discriminator, JsonRequestBehavior.AllowGet);

                //case "Language":
                //    var language = db.Language.Select(x => new
                //    {
                //        Value = x.Id.ToString(),
                //        Text = x.CultureName ?? string.Empty,
                //    }).ToList();
                //    return Json(language, JsonRequestBehavior.AllowGet);

                //case "PersonTask":
                //    var personTask = db.PersonTask.Select(x => new
                //    {
                //        Value = x.Id.ToString(),
                //        Text = x.Name ?? string.Empty,
                //    }).ToList();
                //    return Json(personTask, JsonRequestBehavior.AllowGet);

                default:
                    break;
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Address()
        //{
        //  return View();
        //}

        public DateTime? MyConvertToDateTime(string str)
        {
            try
            {
                //test
                var substrings = str.Split(new char[] { '.', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                //if (substrings.Length < 3)
                //    return null;

                return new DateTime(int.Parse(substrings[2]), int.Parse(substrings[1]), int.Parse(substrings[0]));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string MyDateTimeToString(DateTime? taskStartDate)
        {
            try
            {
                if (!taskStartDate.HasValue)
                    return MyDateTimeStringFormat(DateTime.Now);

                return MyDateTimeStringFormat(taskStartDate.Value);
            }
            catch (Exception ex)
            {
                return MyDateTimeStringFormat(DateTime.Now);
            }
        }

        public string MyDateTimeStringFormat(DateTime dateTime)
        {
            return string.Format("{0:D2}.{1:D2}.{2:D2}", dateTime.Day, dateTime.Month, dateTime.Year);
        }

        //[{"id":1,"name":"Temp","children":[{"id":4,"name":"dfdsfsdf","children":[{"id":1,"name":"dfdsfsdf","children":[{"id":2,"name":"dfdsfsdf","children":[{"id":3,"name":"dfdsfsdf"}]}]}]}]},{"id":5,"name":"dfdsfsdf"}]
        public class NestableListItem
        {
            public int id { get; set; }
            public string name { get; set; }
            public NestableListItem[] children { get; set; }
        }


        public class NestableListItemV2
        {
            public int id { get; set; }
            public string name { get; set; }
            public string content { get; set; }
            public string[] classes { get; set; }
            public string nodrag { get; set; }
            public string nochildren { get; set; }
            public NestableListItemV2[] children { get; set; }
        }



        public List<TermTaxonomy> JsonToTermTaxonomy(string json, int taxonomy)
        {
            var nestableListItems = JsonConvert.DeserializeObject<List<NestableListItemV2>>(json);

            var termTaxonomies = new List<TermTaxonomy>();

            foreach (var item in nestableListItems)
            {
                termTaxonomies.Add(new TermTaxonomy { TermId = item.id, Parent = 0, TaxonomyId = taxonomy, Description = item.name });
                if (item.children != null)
                {
                    Traverse(item, termTaxonomies, taxonomy);
                }
            }
            return termTaxonomies;
        }

        public void Traverse(NestableListItemV2 obj, List<TermTaxonomy> termTaxonomies, int taxonomy)
        {
            foreach (var item in obj.children)
            {
                termTaxonomies.Add(new TermTaxonomy { TermId = item.id, Parent = obj.id, TaxonomyId = taxonomy, Description = item.name });
                if (item.children != null)
                {
                    Traverse(item, termTaxonomies, taxonomy);
                }
            }
        }

        public const string OPEN_LIST_TAG = "<ol class=\"dd-list\">";
        public const string CLOSE_LIST_TAG = "</ol>";
        public const string OPEN_LIST_ITEM_TAG = "<li class=\"dd-item {5} {6}\" data-name=\"{0}\" data-id=\"{1}\" data-nodrag=\"{2}\" data-nochildren=\"{3}\" data-color=\"{4}\">";
        //public const string EDIT_BUTTON = "<button data-name=\"{0}\" data-id=\"{1}\" data-nodrag=\"{2}\" class=\"btn btn-primary btn-sm pull-right\" data-nochildren=\"{3}\" type=\"button\">Edit</button>";
        public const string CLOSE_LIST_ITEM_TAG = "</li>";
        public const string LIST_ITEM_CONTENT = "<div class=\"dd-handle\" style=\"background-color:{1}\"> {0} </div>";

        public string GenerateNestedListHtmlString(List<TermTaxonomyView> nestedList)
        {
            var builder = new StringBuilder();
            List<TermTaxonomyView> parentTerms = (from a in nestedList where a.Parent == 0 select a).ToList();
            builder.Append(OPEN_LIST_TAG);
            foreach (var term in parentTerms)
            {
                builder.Append(string.Format(OPEN_LIST_ITEM_TAG, term.Name, term.TermId, term.NoDragClass ? 1 : 0, term.NoChildrenClass ? 1 : 0
                    , !string.IsNullOrWhiteSpace(term.Color) ? term.Color : "#fafafa"
                    , term.NoChildrenClass ? "dd-nochildren" : string.Empty
                    , term.NoDragClass ? "dd-nodrag" : string.Empty));

                builder.Append(string.Format(LIST_ITEM_CONTENT, term.Name, !string.IsNullOrWhiteSpace(term.Color) ? term.Color : "#fafafa"));
                //builder.Append(string.Format(EDIT_BUTTON, parentTerm.Name, parentTerm.Term_Id, parentTerm.DoDragClass ? 1 : 0, parentTerm.NoChildrenClass ? 1 : 0));
                List<TermTaxonomyView> childTerms = (from a in nestedList where a.Parent == term.TermId select a).ToList();
                if (childTerms.Count > 0)
                    AddChildTerms(term, builder, nestedList);
                builder.Append(CLOSE_LIST_ITEM_TAG);
            }
            builder.Append(CLOSE_LIST_TAG);
            return builder.ToString();
        }

        public string GenerateNewNestedListHtmlString(List<Term> newNestedList)
        {
            var builder = new StringBuilder();
            builder.Append(OPEN_LIST_TAG);
            foreach (var term in newNestedList)
            {
                builder.Append(string.Format(OPEN_LIST_ITEM_TAG, term.Name, term.Id, term.NoDragClass ? 1 : 0, term.NoChildrenClass ? 1 : 0, "#fafafa"
                    , term.NoChildrenClass ? "dd-nochildren" : string.Empty
                    , term.NoDragClass ? "dd-nodrag" : string.Empty));

                builder.Append(string.Format(LIST_ITEM_CONTENT, term.Name, !string.IsNullOrWhiteSpace(term.Color) ? term.Color : "#fafafa"));
                //builder.Append(string.Format(EDIT_BUTTON, item.Name, item.Id, string.Empty, string.Empty, 0, 0));
                builder.Append(CLOSE_LIST_ITEM_TAG);
            }
            builder.Append(CLOSE_LIST_TAG);
            return builder.ToString();
        }

        private void AddChildTerms(TermTaxonomyView childTerm, StringBuilder builder, List<TermTaxonomyView> terms)
        {
            builder.Append(OPEN_LIST_TAG);
            List<TermTaxonomyView> childTerms = (from a in terms where a.Parent == childTerm.TermId select a).ToList();
            foreach (TermTaxonomyView term in childTerms)
            {
                //builder.Append(string.Format(OPEN_LIST_ITEM_TAG, term.Name, term.Id));
                builder.Append(string.Format(OPEN_LIST_ITEM_TAG, term.Name, term.TermId, term.NoDragClass ? 1 : 0, term.NoChildrenClass ? 1 : 0
                    , !string.IsNullOrWhiteSpace(term.Color) ? term.Color : "#fafafa"
                    , term.NoChildrenClass ? "dd-nochildren" : string.Empty
                    , term.NoDragClass ? "dd-nodrag" : string.Empty));
                builder.Append(string.Format(LIST_ITEM_CONTENT, term.Name, !string.IsNullOrWhiteSpace(term.Color) ? term.Color : "#fafafa"));
                //builder.Append(string.Format(EDIT_BUTTON, term.Name, term.Term_Id, term.DoDragClass ? 1 : 0, term.NoChildrenClass ? 1 : 0));
                List<TermTaxonomyView> subChilds = (from a in terms where a.Parent == term.TermId select a).ToList();
                if (subChilds.Count > 0)
                {
                    AddChildTerms(term, builder, terms);
                }
                builder.Append(CLOSE_LIST_ITEM_TAG);
            }
            builder.Append(CLOSE_LIST_TAG);
        }

        //public ActionResult Telephone(Telephone telephone)
        //{
        //    var response = new ResponseForJson<Telephone>();

        //    foreach (ModelState modelState in ViewData.ModelState.Values)
        //    {
        //        foreach (ModelError error in modelState.Errors)
        //        {
        //            response.ErrorMessages.Add(error.ErrorMessage);
        //        }
        //    }

        //    if (!response.ErrorMessages.Any())
        //    {
        //        if (!telephone.Id.HasValue )
        //        {
        //            telephone.CreatedAt = DateTime.Now;
        //            db.Telephones.Add(telephone);
        //        }
        //        else
        //        {
        //            db.Entry(telephone).State = EntityState.Modified;
        //        }
        //        db.SaveChanges();
        //        response.Data.Add(telephone);
        //    }

        //    return Json(response, JsonRequestBehavior.AllowGet);

        //}

    }
}



//[HttpGet]
//public JsonResult ForeingKeyIdRefresh(int? countryId)
//{

//    var city = db.City.Where(x => x.CountryId == countryId)
//                        .Select(x => new
//                        {
//                            Value = x.Id.ToString(),
//                            Text = x.CityName,
//                        }).ToList();
//    return Json(city, JsonRequestBehavior.AllowGet);
//}