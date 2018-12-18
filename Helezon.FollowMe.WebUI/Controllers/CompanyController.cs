using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FollowMe.Web.Models;
using FollowMe.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class CompanyController : BaseController
    {
        public string Test()
        {
            return CompanyService.FistCompanyName();
        }
        private static TaxonomyType[] TaxonomyTypeForCompany = new TaxonomyType[] {
                 TaxonomyType.ProductType
               , TaxonomyType.CompanyType     
            };
        // GET: Company
        public ActionResult Index()
        {
            return View(db.Company.ToList());
        }
        // GET: Company/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company account = db.Company.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }    


        [HttpPost]
        public JsonResult CofirmCode(int code, int companyRootType)
        {
            int returnValue = FindCode(code, (CompanyRootType)companyRootType);
            return Json(returnValue, JsonRequestBehavior.AllowGet);
        }
        private int FindCode(int code, CompanyRootType rootType)
        {
            var returnValue = 0;
            var existingCodes = (from c in db.Company
                                     //orderby c.Code ascending
                                 where c.CompanyRootTypeId == (int)rootType
                                 select c.Code).ToList().Distinct();

            IEnumerable<int> all = null;
            switch (rootType)
            {
                case CompanyRootType.None:
                    return 0;
                case CompanyRootType.Red:
                    all = Enumerable.Range(1210, 8789);
                    break;
                case CompanyRootType.Blue:
                    all = Enumerable.Range(112, 1097);
                    break;
                case CompanyRootType.Zetaa:
                    return 111;
                case CompanyRootType.Others:
                    all = Enumerable.Range(10001, 89998);
                    break;
                default:
                    return 0;
            }

            if (!existingCodes.Any())
            {
                if (all.Contains(code))
                {
                    returnValue = code;
                }
                else
                {
                    returnValue = all.Min();
                }
            }
            else
            {
                var excepts = all.Except(existingCodes);
                if (!existingCodes.Contains(code))
                {
                    if (all.Contains(code))
                    {
                        returnValue = code;
                    }
                    else
                    {
                        returnValue = excepts.Min();
                    }
                }
                else
                {
                    returnValue = excepts.Min();
                }
            }
            return returnValue;
        }
        // GET: Company/Create
        public ActionResult Edit(string id,string operation = "")
        {
            var isAddingSubchild = operation.IsNullOrWhiteSpace().Not() && string.CompareOrdinal(operation, "addsubchild") == 0;
            if (isAddingSubchild)
            {
                ViewBag.IsAddingNewSubchild = true;
            }
            ViewBag.Addresses = new List<CompanyAddress>() { new CompanyAddress() { } };
            ViewBag.Banks = new List<CompanyBank> { new CompanyBank() };
            ViewBag.AreaCodes = GetAreaCodes();
            ViewBag.CurrencyTypes = _currencyTypes.Value;
            ViewBag.ReasonWhyPassives = _reasonWhyPassives.Value;
            ViewBag.BankNames = _bankNames.Value;
            ViewBag.ParentCompanyTypes = _parentCompanyTypes.Value;
            ViewBag.LogisticsCompanies = new List<LogisticsCompany> { new LogisticsCompany()};


            ViewBag.CountryList = _addressGuideCountries.Value;

            var logistics = db.Company.Where(x => x.CompanyRootTypeId == (int)CompanyRootType.Others)
                .Select(x=>new  {Id = x.Id ,Name = x.Name })
                .ToList().Select(x => new LogisticsCompany
                {
                    LogisticsCompanyId = x.Id,
                    LogisticsCompanyName = x.Name

                }).ToList();


            //if (!logistics.Any())
            //    logistics.Add(new LogisticsCompany());


            ViewBag.LogisticsCompanyList = logistics;

            var company = new Company();

            if (id.IsNullOrWhiteSpace())
            {               
                company.Code = FindCode(-1, CompanyRootType.Blue);
                return View(company);
            }

            company = db.Company.Find(id);
            if (company != null)
            {
                if (!isAddingSubchild)
                {
                    var nullString = "null";
                    company.Person_FirstName = nullString;
                    company.Person_LastName = nullString;
                    company.Person_Telephone = "(777) 777-7777";
                    company.Person_Interphone = "9999";
                    company.Person_AreaCode = "Angola (+244)";
                    company.Person_Email = "test@test.com";
                    company.Person_GenderTypeId = 1;
                    company.Person_BirthDay = nullString;
                    company.Person_Position = nullString;
                }
    
                EntityTermServices termServicesCompany = new EntityTermServices(db, company.Id, company.Id);
                company.CompanyRootTypeName = termServicesCompany.GetTermByTermId(company.CompanyRootTypeId).Name;
                company.CompanyTypes = termServicesCompany.GetTermListForCompanyType();
                company.ProductType = termServicesCompany.GetTermListForProductType();
                company.CompanyTypesTaxonomyViewModel = new TaxonomyViewModel(TaxonomyType.CompanyType) { TermList = company.CompanyTypes };

                if (company.ReasonWhyPassiveId.HasValue && company.ReasonWhyPassiveId.Value > 0)
                {
                    company.TempReasonWhyPassiveTermId = company.ReasonWhyPassiveId.Value + "|" + company.ReasonWhyPassiveTermName;
                }
                

                ViewBag.Telephones = db.CompanyTelephone.Where(x => x.CompanyId == company.Id).ToList();
                company.TempFoundingDate = MyDateTimeToString(company.FoundingDate);



                var temp = db.CompanyBank.Where(x => x.CompanyId == company.Id && !x.IsPassive).ToList();

                if (!temp.Any())
                {
                    ViewBag.Banks = new List<CompanyBank> { new CompanyBank() };
                }
                else
                {
                    ViewBag.Banks = temp;
                }
                if (temp != null && temp.Any())
                {
                    foreach (var bank in temp)
                    {
                        bank.SwiftNoList = db.BankGuide.Where(x => x.TermId == bank.BankNameTermId && x.BranchName == bank.BranchName && x.BranchCode == bank.BranchCode).Select(x => x.SwiftNo).Distinct().ToList();
                        bank.BranchNameCodeList = db.BankGuide.Where(x => x.TermId == bank.BankNameTermId).Select(x => x.BranchName + " - " + x.BranchCode).Distinct().ToList();
                        bank.ProvinceList = db.BankGuide.Where(x => x.TermId == bank.BankNameTermId).Select(x => x.Province).Distinct().ToList();
                        bank.DistrictList = db.BankGuide.Where(x => x.TermId == bank.BankNameTermId && x.Province == bank.Province).Select(x => x.District).Distinct().ToList();
                        bank.CurrencyTypeTermName = (db.Term.FirstOrDefault(x => x.Id == bank.CurrencyTypeTermId) ?? new Term()).Name;
                        bank.BankNameTermName = (db.Term.FirstOrDefault(x => x.Id == bank.BankNameTermId) ?? new Term()).Name;

                    }
                }
                //ViewBag.Emails = db.Email.Where(x => x.CompanyId == company.Id && x.EntityId == company.Id && x.EntityType == (int)EntityType.Company).ToList();
                var logistics1 = db.LogisticsCompany.Where(x => x.CompanyId == company.Id).ToList();

                if (!logistics1.Any())
                    logistics1.Add(new LogisticsCompany());


                ViewBag.LogisticsCompanies = logistics1;
                var addresses = db.CompanyAddress.Where(x => x.CompanyId == company.Id).ToList();
                ViewBag.Addresses = addresses;
                if (addresses != null && addresses.Any())
                {
                    foreach (var address in addresses)
                    {
                        address.ProvinceList = db.AddressGuide.Where(x => x.Country == address.Country).Select(x => x.Province).Distinct().ToList();
                        address.DistrictList = db.AddressGuide.Where(x => x.Country == address.Country && x.Province == address.Province).Select(x => x.District).Distinct().ToList();
                        address.SuburbAreaList = db.AddressGuide.Where(x => x.Country == address.Country && x.Province == address.Province && x.District == address.District).Select(x => x.SuburbArea).Distinct().ToList();
                        address.TownList = db.AddressGuide.Where(x => x.Country == address.Country && x.Province == address.Province && x.District == address.District && x.SuburbArea == address.SuburbArea).Select(x => x.Town).Distinct().ToList();
                        address.ZipCodeList = db.AddressGuide.Where(x => x.Country == address.Country && x.Province == address.Province && x.District == address.District && x.SuburbArea == address.SuburbArea && x.Town == address.Town).Select(x => x.ZipCode).Distinct().ToList();
                    }
                }
                else
                {
                    ViewBag.Addresses = new List<CompanyAddress>() { new CompanyAddress() };
                }
                return View(company);
            }
            else {
                company = new Company();
                company.Code = FindCode(-1, CompanyRootType.Blue);
                return View(company);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    var keys = Request.Form.Keys;
                    Company existingCompany = null;
                    var isExistingCompany = false;
                    if (company.Id.IsNullOrWhiteSpace().Not() && company.Id != Guid.Empty.ToString())
                        existingCompany = db.Company.SingleOrDefault(x => x.Id == company.Id);


                    if (existingCompany != null)
                    {
                        company.CreatedOn = existingCompany.CreatedOn;
                        company.CreatedBy = existingCompany.CreatedBy;
                        company.Code = existingCompany.Code;
                        db.Entry(existingCompany).State = EntityState.Detached;
                        existingCompany = null;
                        isExistingCompany = true;
                    }
                    else
                    {
                        if (Request["ParentId"] == null)
                        {
                            company.Code = FindCode(company.Code, (CompanyRootType)company.CompanyRootTypeId);

                        }
                        else
                        {
                            company.ParentId = Request["ParentId"];
                            //company.Code = 0;
                        }
                        company.CreatedBy = User.Identity.GetUserId();
                        company.CreatedOn = DateTime.UtcNow;
                    }           


                    company.FoundingDate = MyConvertToDateTime(company.TempFoundingDate);

                    var TempReasonWhyPassiveTermId = Request["TempReasonWhyPassiveTermId"];

                    if (!string.IsNullOrWhiteSpace(TempReasonWhyPassiveTermId))
                    {
                        var parts = TempReasonWhyPassiveTermId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        company.ReasonWhyPassiveId = parts[0].AsInt();
                        company.ReasonWhyPassiveTermName = parts[1];
                    }

                    if (company.Id.IsNullOrWhiteSpace() || company.Id.Equals(Guid.Empty))
                    {
                        company.Id = Guid.NewGuid().ToString();
                        //company.CreatedAt = DateTime.Now;
                        db.Company.Add(company);
                    }
                    else
                    {
                        //db.Configuration.ValidateOnSaveEnabled = false;
                        db.Entry(company).State = EntityState.Modified;
                    }
                   
                    db.SaveChanges();
                    //db.Configuration.ValidateOnSaveEnabled = true;

                    SaveEntityTerms(GetListNewTerms(TaxonomyTypeForCompany,company.Id), company.Id, company.Id);


                    if (isExistingCompany.Not())
                    {
                        var newPersonnel = new Person();
                        //newPersonnel.IsAuthorized = true;
                        newPersonnel.Id = Guid.NewGuid().ToString();
                        newPersonnel.CreatedOn = DateTime.UtcNow;
                        newPersonnel.CreatedBy = User.Identity.GetUserId();
                        newPersonnel.FirstName = company.Person_FirstName;
                        newPersonnel.LastName = company.Person_LastName;
                        newPersonnel.GenderTypeId = company.Person_GenderTypeId;
                        //existingPerson.OfficeTelephone = company.Person_Telephone;
                        //existingPerson.Interphone = company.Person_Interphone;
                        newPersonnel.Email = company.Person_Email;
                        newPersonnel.PersonnelEmail = company.Person_PersonnelEmail;
                        newPersonnel.BirthDay = company.Person_BirthDay.ToDateTime();
                        newPersonnel.CompanyId = company.Id;
                        newPersonnel.Interphone = company.Person_Interphone;
                        db.Entry<Person>(newPersonnel).State = EntityState.Added;
                        db.SaveChanges();

                        if (company.Person_Telephone.IsNullOrWhiteSpace().Not())
                        {
                            db.PersonnelTelephone.Add(new PersonnelTelephone
                            {
                                Number = company.Person_Telephone,
                                CreatedOn = DateTime.UtcNow,
                                CreatedBy = User.Identity.GetUserId(),
                                PersonnelId = newPersonnel.Id,
                                //Interphone = company.Person_Interphone,
                                TelephoneTypeId = (int)TelephoneType.PersonMobil,
                                AreaCode = company.Person_AreaCode,
                                CompanyId = newPersonnel.CompanyId
                            });
                            db.SaveChanges();
                        }

                        if (company.Person_Position.IsNullOrWhiteSpace().Not())
                        {
                            var personnelPosition = db.Term.FirstOrDefault(x => (x.CompanyId == company.Id || x.CompanyId == Guid.Empty.ToString())
                                                && x.TaxonomyId == (int)TaxonomyType.Position
                                                && x.Name.Contains(company.Person_Position));

                            if (personnelPosition == null)
                            {
                                var newPositionTerm = new Term
                                {
                                    Name = company.Person_Position,
                                    TaxonomyId = (int)TaxonomyType.Position,
                                    CompanyId = newPersonnel.CompanyId,
                                    CreatedOn = DateTime.UtcNow,
                                    CreatedBy = User.Identity.GetUserId()
                                };
                                db.Term.Add(newPositionTerm);
                                db.SaveChanges();
                                db.TermRelationship.Add(new TermRelationship
                                {
                                    TermId = newPositionTerm.Id,
                                    TaxonomyId = (int)TaxonomyType.Position,
                                    EntityId = newPersonnel.Id,
                                    CreatedOn = DateTime.UtcNow,
                                    CreatedBy = User.Identity.GetUserId(),
                                    CompanyId = newPersonnel.CompanyId

                                });
                                db.SaveChanges();
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(company.Person_Bank_AccountNo))
                        {
                            if (string.IsNullOrWhiteSpace(company.Person_Bank_CurrencyType).Not())
                            {
                                var currencyTypeParts = company.Person_Bank_CurrencyType.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                if (currencyTypeParts.IsEmpty().Not() && currencyTypeParts.Length > 1)
                                {
                                    company.Person_Bank_CurrencyTypeTermId = currencyTypeParts[0].AsInt();
                                    company.Person_Bank_CurrencyTypeTermName = currencyTypeParts[1].Trim();
                                }
                            }

                            var branchNameParts = company.Person_Bank_BranchNameCode.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                            if (branchNameParts.IsEmpty().Not() && branchNameParts.Length > 1)
                            {
                                company.Person_Bank_BranchCode = branchNameParts[1].Trim();
                                company.Person_Bank_BranchName = branchNameParts[0].Trim();
                            }

                            var bankNameParts = company.Person_Bank_Name.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            if (bankNameParts.IsEmpty().Not() && bankNameParts.Length > 1)
                            {
                                company.Person_Bank_BankNameTermId = bankNameParts[0].AsInt();
                                company.Person_Bank_BankNameTermName = bankNameParts[1].Trim();
                            }

                            var newPersonnelBank = new PersonnelBank();
                            newPersonnelBank.AccountNo = company.Person_Bank_AccountNo;
                            newPersonnelBank.BankNameTermId = company.Person_Bank_BankNameTermId;
                            newPersonnelBank.BankNameTermName = company.Person_Bank_BankNameTermName;
                            newPersonnelBank.CurrencyTypeTermId = company.Person_Bank_CurrencyTypeTermId;
                            newPersonnelBank.District = company.Person_Bank_District;
                            newPersonnelBank.Province = company.Person_Bank_Province;
                            newPersonnelBank.CurrencyTypeTermName = company.Person_Bank_CurrencyTypeTermName;
                            newPersonnelBank.BranchCode = company.Person_Bank_BranchCode;
                            newPersonnelBank.BranchName = company.Person_Bank_BranchName;
                            newPersonnelBank.Iban = company.Person_Bank_Iban;
                            newPersonnelBank.SwiftNo = company.Person_Bank_SwiftNo;
                            newPersonnelBank.CompanyId = company.Id;
                            newPersonnelBank.PersonnelId = newPersonnel.Id;
                            newPersonnelBank.CreatedOn = DateTime.UtcNow;
                            newPersonnelBank.CreatedBy = User.Identity.GetUserId();
                            db.Entry<PersonnelBank>(newPersonnelBank).State = EntityState.Added;
                            db.SaveChanges();
                        }               
                    }            

                    //******************************************************************//

                    var telephoneList = FillTelefonListCompany(company.Id);

                    if (telephoneList.Any())
                    {
                        db.CompanyTelephone.RemoveRange(db.CompanyTelephone.Where(x => x.CompanyId == company.Id));
                        db.CompanyTelephone.AddRange(telephoneList);
                        ViewBag.Telephones = telephoneList;
                        db.SaveChanges();
                    }

                    //*****************************************************************//            
                    var logisticsCompanies = new List<LogisticsCompany>();
                    var i = 0;
                    while (true)
                    {
                        var importCode = Request["group-logisticscompany[" + i + "][ImportCode]"];
                        var exportCode = Request["group-logisticscompany[" + i + "][ExportCode]"];
                        var logisticsCompanyId = Request["group-logisticscompany[" + i + "][LogisticsCompanyId]"];
                        if (string.IsNullOrWhiteSpace(logisticsCompanyId) || logisticsCompanyId == Guid.Empty.ToString())
                            break;
                        var logisticsCompany = new LogisticsCompany();
                        logisticsCompany.ExportCode = importCode;
                        logisticsCompany.ImportCode = exportCode;
                        logisticsCompany.CompanyId = company.Id;
                        logisticsCompany.LogisticsCompanyId = logisticsCompanyId;
                        logisticsCompanies.Add(logisticsCompany);
                        i++;
                    }
                    db.LogisticsCompany.RemoveRange(db.LogisticsCompany.Where(x => x.CompanyId == company.Id));
                    db.LogisticsCompany.AddRange(logisticsCompanies);
                    db.SaveChanges();
                    ViewBag.LogisticsCompanies = logisticsCompanies;

                    //*****************************************************************//
                    var addressList = FillAddressListCompany(company.Id);
                    if (addressList.Any())
                    {
                        foreach (var item in addressList)
                        {
                            item.AddressType = company.AddressTypeId;
                        }
                        db.CompanyAddress.RemoveRange(db.CompanyAddress.Where(x => x.CompanyId == company.Id));
                        db.CompanyAddress.AddRange(addressList);
                        ViewBag.Addresses = addressList;
                        db.SaveChanges();
                    }

                    //*****************************************************************//  

                    var bankList = FillCompanyBankList(company.Id);

                    if (bankList.Any())
                    {
                        var existingbanks = db.CompanyBank.Where(x=>x.CompanyId == company.Id && !x.IsPassive).ToList();

                        foreach (var item in existingbanks)
                        {
                            item.IsPassive = true;
                            item.MakedPassiveBy = User.Identity.GetUserId();
                            item.MakedPassiveOn = DateTime.UtcNow;
                            db.Entry(item).State = EntityState.Modified;
                        }

                        var dicExistingbanks = existingbanks.ToDictionary(x => x.Id);

                        foreach (var item in bankList)
                        {
                            if (dicExistingbanks.ContainsKey(item.Id))
                            {
                                dicExistingbanks[item.Id].IsPassive = false;
                                dicExistingbanks[item.Id].MakedPassiveBy = null;
                                dicExistingbanks[item.Id].MakedPassiveOn = null;
                                dicExistingbanks[item.Id].ChangedBy = User.Identity.GetUserId();
                                dicExistingbanks[item.Id].ChangedOn = DateTime.UtcNow;
                                dicExistingbanks[item.Id].BranchCode = item.BranchCode;
                                dicExistingbanks[item.Id].BranchName = item.BranchName;
                                dicExistingbanks[item.Id].AccountNo = item.AccountNo;
                                dicExistingbanks[item.Id].District = item.District;
                                dicExistingbanks[item.Id].Province = item.Province;
                                dicExistingbanks[item.Id].Iban = item.Iban;
                                //dicExistingbanks[item.Id].Id = item.Id;
                                dicExistingbanks[item.Id].BankNameTermId = item.BankNameTermId;
                                dicExistingbanks[item.Id].SwiftNo = item.SwiftNo;
                                dicExistingbanks[item.Id].CompanyId = item.CompanyId;
                                dicExistingbanks[item.Id].CurrencyTypeTermId = item.CurrencyTypeTermId;
                            }
                            else
                            {
                                item.CreatedOn = DateTime.UtcNow;
                                item.CreatedBy = User.Identity.GetUserId();
                                db.CompanyBank.Add(item);
                            }
                        }
                    
                        db.SaveChanges();
                    }

                    //*****************************************************************//                  
                    if (company.CompanyRootTypeId.HasValue.Not())
                    {
                        transaction.Rollback();
                        ViewBag.ErrorMessage = "Company Root Type Seçilemedi";

                        EntityTermServices termServicesCompany = new EntityTermServices(db, company.Id, company.Id);
                        company.CompanyTypes = termServicesCompany.GetTermListForCompanyType();
                        company.CompanyTypesTaxonomyViewModel = new TaxonomyViewModel(TaxonomyType.CompanyType) { TermList = company.CompanyTypes };
                    }
                    else
                    {
                        transaction.Commit();
                        return RedirectToAction(actionName: "Index", controllerName: "GuideBook");
                    }       
        
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Fail!" + ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                    transaction.Rollback();
                }
            }

            ViewBag.LogisticsCompanies = new List<LogisticsCompany>();
            ViewBag.AreaCodes = GetAreaCodes();
            ViewBag.CurrencyTypes = _currencyTypes.Value;
            ViewBag.ReasonWhyPassives = _reasonWhyPassives.Value;
            ViewBag.BankNames = _bankNames.Value;
            ViewBag.ParentCompanyTypes = _parentCompanyTypes.Value;
    

            if (ViewBag.Addresses == null)
            {
                ViewBag.Addresses = new List<CompanyAddress>() { new CompanyAddress() };

            }
            ViewBag.CountryList = _addressGuideCountries.Value;

            var logistics = db.Company.Where(x => x.CompanyRootTypeId == (int)CompanyRootType.Others)
                .Select(x => new  { Id = x.Id, Name = x.Name })
                .ToList().Select(x => new LogisticsCompany
                {
                    LogisticsCompanyId = x.Id,
                    LogisticsCompanyName = x.Name

                }).ToList();


            if (!logistics.Any())
                logistics.Add(new LogisticsCompany());


            ViewBag.LogisticsCompanyList = logistics;


            return View(company);
        }
        // GET: Company/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company account = db.Company.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(viewName: "Delete", model: account);
        }
        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Company account = db.Company.Find(id);
            db.Company.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult CompanyTypeId()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PersonPartialList(string companyId)
        {
            companyId = companyId ?? string.Empty;
            var persons = db.Person.Where(x => x.CompanyId == companyId).ToList();

            if (companyId.IsNullOrWhiteSpace().Not() && persons.Any())
                return PartialView(viewName: "_PersonPartialList", model: persons);
            return new EmptyResult();
        }

        private string ExtractAreaNumber(string areaCode) {

            if (areaCode.IsNullOrWhiteSpace())            
                return string.Empty;

            var plus = areaCode.IndexOf('+')-1;
            return areaCode.Substring(plus).Trim();

        }
        public ActionResult CompanyCard(string id)
        {
            if (id.IsNullOrWhiteSpace())
                throw new ArgumentNullException("id");

            using (GLCEmasModel emasDb = new GLCEmasModel())
            {
                var tempCopmany = emasDb.Company.SingleOrDefault(x => x.Id == id);

                if (tempCopmany == null)
                    return RedirectToAction(actionName: "Index", controllerName: "GuideBook");

                tempCopmany.TempFoundingDate = MyDateTimeToString(tempCopmany.FoundingDate);

                //db.TermRelationship.SingleOrDefault(TermRelationshipPredicates.Position(personnel.Id));
                tempCopmany.AddressTypeName = tempCopmany.AddressTypeId.HasValue
                    && tempCopmany.AddressTypeId.Value > 0 ? Utils.AddressTypeNames
                    [Tuple.Create(EntityType.Company, (AddressType)tempCopmany.AddressTypeId)] : "";
                var temp = new CompanyCardViewModel()
                {
                    AddressList = tempCopmany.CompanyAddress.ToList(),
                    PersonnelList = tempCopmany.Person.Select(x => new CompanyCardPersonnelViewModel
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PersonnelId = x.Id
                    }).ToList(),
                    //TelephoneList = tempCopmany.CompanyTelephone.ToList(),
                    Company = tempCopmany,
                    BankList = tempCopmany.CompanyBank.ToList(),
                    LogisticsCompanyList = tempCopmany.LogisticsCompany.Join(db.Company,
                          p => p.LogisticsCompanyId,
                          e => e.Id,
                          (p, e) => new LogisticsCompany { ImportCode = p.ImportCode,ExportCode = p.ExportCode,LogisticsCompanyName = e.Name  }).ToList()
                };

                var listOfChildCompany = db.Company.Where(x => x.ParentId == tempCopmany.Id).Select(x=>new {
                    x.Id,
                    x.Name,
                    x.AddressTypeId
                }).ToList();
                if (listOfChildCompany.Any())
                {
                    var childCompanyies = new List<Tuple<string,string, string>>();
                    foreach (var item in listOfChildCompany)
                    {
                      var addressTypeName = item.AddressTypeId.HasValue
                 && item.AddressTypeId.Value > 0 ? Utils.AddressTypeNames
                 [Tuple.Create(EntityType.Company, (AddressType)item.AddressTypeId)] : string.Empty; 

                        childCompanyies.Add(Tuple.Create(item.Id, addressTypeName,item.Name));
                    }
                    temp.SubChildCompanyList.AddRange(childCompanyies);
                }

                if (!temp.AddressList.Any())
                {
                    temp.AddressList.Add(new CompanyAddress());
                }
                temp.TelephoneList = db.CompanyTelephone.Where(x=>x.CompanyId == tempCopmany.Id).ToList();

                if (temp.TelephoneList.Any())
                {
                    //TelephoneType.CompanyFax), "Fax");
                    //TelephoneType.CompanyMobil), "Company Mobil");
                    //TelephoneType.CompanyOffice), "Office");
                    var listCompanyFax = new List<string>();
                    var listCompanyMobil = new List<string>();
                    var listCompanyOffice = new List<string>();
                    foreach (var item in temp.TelephoneList)
                    {
                        var type = (TelephoneType)item.TelephoneTypeId;
                        switch (type)
                        {
                            case TelephoneType.CompanyFax:
                                listCompanyFax.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                                break;
                            case TelephoneType.CompanyMobil:
                                listCompanyMobil.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                                break;
                            case TelephoneType.CompanyOffice:
                                listCompanyOffice.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                                break;
                            default:
                                break;
                        }
                    }
                    var length = Math.Max(Math.Max(listCompanyFax.Count, listCompanyMobil.Count), listCompanyOffice.Count);
                    var telephones = new List<List<string>>();
                    //telephones.Add(new List<string> { "FIRMA TELEFON NUMARASI", "FIRMA FAX NUMARASI", "FIRMA CEP NUMARASI" });
                    for (int i = 0; i < length; i++)
                    {
                        var tempList = new List<string>();
                        tempList.Add(listCompanyOffice.ElementAtOrDefault(i));
                        tempList.Add(listCompanyFax.ElementAtOrDefault(i));
                        tempList.Add(listCompanyMobil.ElementAtOrDefault(i));
                        telephones.Add(tempList);
                    }

                    temp.TelephoneListRotated = telephones;
                }

                if (temp.BankList.IsEmpty().Not())
                {
                    foreach (var bank in temp.BankList)
                    {
                        bank.CurrencyTypeTermName = (db.Term.FirstOrDefault(x => x.Id == bank.CurrencyTypeTermId) ?? new Term()).Name;
                        bank.BankNameTermName = (db.Term.FirstOrDefault(x => x.Id == bank.BankNameTermId) ?? new Term()).Name;
                    }
                }
                //var postions = db.TermRelationship
                //    .Where(x=> x.CompanyId == tempCopmany.Id && x.TaxonomyId == (int)TaxonomyType.Position)
                //    .ToList();


                var positions = (from r in db.TermRelationship
                               join t in db.Term on r.TermId equals t.Id
                               where (t.CompanyId == tempCopmany.Id ||t.CompanyId == Guid.Empty.ToString()) 
                               && t.TaxonomyId == (int)TaxonomyType.Position 
                               select new
                               {
                                   EntityId = r.EntityId,
                                   TermName = t.Name
                               }).ToList();

                if (temp.PersonnelList.IsEmpty().Not() && positions.IsEmpty().Not())
                {
                    var postionDic = positions.ToLookup(x => x.EntityId);

                    foreach (var item in temp.PersonnelList)
                    {
                        if (postionDic.Contains(item.PersonnelId))
                        {
                            item.Position = postionDic[item.PersonnelId].First().TermName;
                        }
                    }
                }

                return View(model: temp);

            }
        }
        public ActionResult PersonnelCard(string id, string companyId)
        {
            if (id.IsNullOrWhiteSpace())
                throw new ArgumentNullException("id");

            if (companyId.IsNullOrWhiteSpace())
                throw new ArgumentNullException("companyId");

            var model = new PersonnelCardViewModel();
            var personnel = db.Person.SingleOrDefault(x => x.Id == id);
            if (personnel == null)
                return RedirectToAction(actionName: "Index", controllerName: "GuideBook");


            EntityTermServices termServices = new EntityTermServices(db, personnel.Id, personnel.CompanyId);
            model.Hobby = string.Join(", ",termServices.GetTermListForHobby().Select(x => x.Name));
            model.Languages = string.Join(", ", termServices.GetTermListForLanguage().Select(x => x.Name));
            model.ComputerSkills = string.Join(", ",termServices.GetTermListForComputerSkills().Select(x => x.Name));



            var positions = (from r in db.TermRelationship
                             join t in db.Term on r.TermId equals t.Id
                             where (t.CompanyId == companyId || t.CompanyId == Guid.Empty.ToString())
                             && t.TaxonomyId == (int)TaxonomyType.Position
                             && r.EntityId == id
                             select new
                             {
                                 TermName = t.Name
                             }).FirstOrDefault();

            if (positions != null)
            {
                model.Position = positions.TermName.SafeTrim();
            }

            model.Personnel = personnel;
            model.Company = db.Company.Find(personnel.CompanyId);
            model.Company.TempFoundingDate = MyDateTimeToString(model.Company.FoundingDate);

            model.AddressList = db.PersonnelAddress.Where(x=>x.PersonnelId == personnel.Id).ToList();
            if (!model.AddressList.Any())
            {
                model.AddressList.Add(new PersonnelAddress());
            }
  
            model.Personnel.BloodGroupName = termServices.GetTermByTermId(model.Personnel.BloodGroupId).Name;
            model.Personnel.RelationshipStatusName = termServices.GetTermByTermId(model.Personnel.RelationshipStatusId).Name;
            model.Personnel.ReligionName = termServices.GetTermByTermId(model.Personnel.ReligionId).Name;
            // model.Personnel.EducationList = (from t in db.Term
            //                                             join e in db.PersonnelEducation on t.Id equals e.EducationLevelId
            //                                             where t.TaxonomyId == (int)TaxonomyType.EducationLevel
            //                                             && e.PersonnelId == model.Personnel.Id
            //                                             select new { t.Name,e.StudiedSchoolName,e.EducationArea }
            //
            //                                             ).ToList();

            model.Personnel.EducationList = db.PersonnelEducation.Where(x => x.PersonnelId == model.Personnel.Id).ToList();

            if (model.Personnel.EducationList.Any())
            {
                foreach (var item in model.Personnel.EducationList)
                {
                    item.EducationLevelName = termServices.GetTermByTermId(item.EducationLevelId).Name;
                }
            }

            model.TelephoneList = db.PersonnelTelephone.Where(x => x.PersonnelId == personnel.Id).ToList();

            model.TelephoneList = db.PersonnelTelephone.Where(x => x.CompanyId == model.Personnel.Id).ToList();

            if (model.TelephoneList.Any())
            {
                //TelephoneType.CompanyFax), "Fax");
                //TelephoneType.CompanyMobil), "Company Mobil");
                //TelephoneType.CompanyOffice), "Office");
                var listPersonOffice = new List<string>();
                var listPersonHome = new List<string>();
                var listPersonMobil = new List<string>();
                foreach (var item in model.TelephoneList)
                {
                    var type = (TelephoneType)item.TelephoneTypeId;
                    switch (type)
                    {
                        case TelephoneType.PersonOffice:
                            listPersonOffice.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                            break;
                        case TelephoneType.PersonHome:
                            listPersonHome.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                            break;
                        case TelephoneType.PersonMobil:
                            listPersonMobil.Add(ExtractAreaNumber(item.AreaCode) + " " + item.Number);
                            break;
                        default:
                            break;
                    }
                }
                var length = Math.Max(Math.Max(listPersonOffice.Count, listPersonHome.Count), listPersonMobil.Count);
                var telephones = new List<List<string>>();
                //telephones.Add(new List<string> { "FIRMA TELEFON NUMARASI", "FIRMA FAX NUMARASI", "FIRMA CEP NUMARASI" });
                for (int i = 0; i < length; i++)
                {
                    var tempList = new List<string>();
                    tempList.Add(listPersonOffice.ElementAtOrDefault(i));
                    tempList.Add(listPersonHome.ElementAtOrDefault(i));
                    tempList.Add(listPersonMobil.ElementAtOrDefault(i));
                    telephones.Add(tempList);
                }

                model.TelephoneListRotated = telephones;
            }



            model.BankList = model.Personnel.PersonnelBank.ToList();

            if (model.BankList.IsEmpty().Not())
            {
                foreach (var bank in model.BankList)
                {
                    bank.CurrencyTypeTermName = (db.Term.FirstOrDefault(x => x.Id == bank.CurrencyTypeTermId) ?? new Term()).Name;
                    bank.BankNameTermName = (db.Term.FirstOrDefault(x => x.Id == bank.BankNameTermId) ?? new Term()).Name;
                }
            }


            model.LogisticsCompanyList = model.Company.LogisticsCompany.ToList();
            return View(model: model);
        }
        private static Lazy<List<SelectListItem>> _reasonWhyPassives = new Lazy<List<SelectListItem>>(GetReasonWhyPassives);
        private static List<SelectListItem> GetReasonWhyPassives()
        {
            GLCEmasModel db = new GLCEmasModel();
            return (from tx in db.TermTaxonomy
                    join te in db.Term
                        on tx.TermId equals te.Id
                    where tx.TaxonomyId == (int)TaxonomyType.ReasonWhyPassive && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.ReasonWhyPassive && tx.Parent == 0
                    select new SelectListItem
                    {
                        Text = te.Name,
                        Value = te.Id.ToString() + "|" + te.Name,
                        //Selected = termId != 0 && termId == te.Term_Id
                    }).ToList();
        }
        private static Lazy<List<SelectListItem>> _parentCompanyTypes = new Lazy<List<SelectListItem>>(GetParentCompanyTypes);
        private static List<SelectListItem> GetParentCompanyTypes()
        {

            GLCEmasModel db = new GLCEmasModel();
            return (from tx in db.TermTaxonomy
                    join te in db.Term
                        on tx.TermId equals te.Id
                    where tx.TaxonomyId == (int)TaxonomyType.CompanyType && tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.CompanyType && tx.Parent == 0
                    select new SelectListItem
                    {
                        Text = te.Name,
                        Value = te.Id.ToString(),
                        //Selected = termId != 0 && termId == te.Id
                    }).ToList();
        }

        private static Lazy<List<string>> _addressGuideCountries = new Lazy<List<string>>(GetCountries);
        private static List<string> GetCountries()
        {

            GLCEmasModel db = new GLCEmasModel();
            return db.AddressGuide.Select(x => x.Country).Distinct().ToList();
        }

    }
}
//[HttpPost]
//public ActionResult PersonPartialList2(Guid? companyId)
//{
//    if (companyId.HasValue)
//        return PartialView(viewName: "_PersonPartialList2", model: db.Person.Where(x => x.CompanyId == companyId));
//    return new EmptyResult();
//}
//[HttpGet]
//public JsonResult GetCities(int? countryId)
//{
//    var city = db.City.Where(x => x.CountryId == countryId)
//                        .Select(x => new
//                        {
//                            Value = x.Id.ToString(),
//                            Text = x.CityName,
//                        }).ToList();
//    return Json(city, JsonRequestBehavior.AllowGet);
//}

// POST: Company/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.