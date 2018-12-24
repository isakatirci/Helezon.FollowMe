using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web.Models;
using Microsoft.AspNet.Identity;
using static FollowMe.Web.Controllers.Utils;
namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class PeopleController : BaseController
    {

        private static TaxonomyType[] TaxonomyTypeForPersonnel = new TaxonomyType[] {
                 TaxonomyType.Department
               , TaxonomyType.Authority
               , TaxonomyType.Region
               , TaxonomyType.Nationality
               , TaxonomyType.JobExperience
               , TaxonomyType.Hobby
               , TaxonomyType.Language
               , TaxonomyType.ComputerSkills

            };

        // GET: People
        public ActionResult Index()
        {
            //var person = db.Person.Include(p => p.Company)
            //    .Include(p => p.Discriminator)
            //    .Include(p => p.Language)
            //    .Include(p => p.PersonDepartmentLanguage)
            //    .Include(p => p.PersonPositionLanguage)
            //    .Include(p => p.PersonTask)
            //    .Include(p => p.PersonTaskMap);
            return View(db.Person.ToList());
        }



        private void GetAllPersonnelTerms(Person personnel)
        {
            EntityTermServices termServices = new EntityTermServices(db, personnel.Id, personnel.CompanyId);

            personnel.Departments = termServices.GetTermListForDepartment();
            personnel.Positions = termServices.GetTermListForPosition();
            personnel.Authorities = termServices.GetTermListForAuthority();
            personnel.Region = termServices.GetTermListForRegion();
            personnel.PersonCategory = termServices.GetTermListForPersonCategory();
            personnel.Nationality = termServices.GetTermListForNationality();
            personnel.JobExperience = termServices.GetTermListForJobExperience();
            personnel.Religion = termServices.GetTermListForReligion();
            personnel.Hobby = termServices.GetTermListForHobby();
            personnel.Languages = termServices.GetTermListForLanguage();
            personnel.ComputerSkills = termServices.GetTermListForComputerSkills();
            personnel.RelationshipStatus = termServices.GetTermListForRelationshipStatus();

            var list = new List<string>();
            list.AddRange(GetSelectNodeScript(personnel.Departments));
            list.AddRange(GetSelectNodeScript(personnel.Positions));
            list.AddRange(GetSelectNodeScript(personnel.Authorities));
            list.AddRange(GetSelectNodeScript(personnel.Region));
            list.AddRange(GetSelectNodeScript(personnel.PersonCategory));
            list.AddRange(GetSelectNodeScript(personnel.Nationality));
            list.AddRange(GetSelectNodeScript(personnel.JobExperience));
            list.AddRange(GetSelectNodeScript(personnel.Religion));
            list.AddRange(GetSelectNodeScript(personnel.Hobby));
            list.AddRange(GetSelectNodeScript(personnel.Languages));
            list.AddRange(GetSelectNodeScript(personnel.RelationshipStatus));
            list.AddRange(GetSelectNodeScript(personnel.ComputerSkills));

            personnel.JstreeSelectNodeScript = string.Join(";", list);



        }

        private void SetJstreeScripts(Person personnel)
        {


            personnel.AjaxTreeFillScript = string.Join("", GetAjaxTreeFillScript(personnel.CompanyId, TaxonomyTypeForPersonnel));

            personnel.ChangedJstreeScript = string.Join("", GetChangedJstreeScript(TaxonomyTypeForPersonnel));

        }

        private List<string> GetSelectNodeScript(List<Term> termList)
        {
            var list = new List<string>();
            if (termList.Any())
            {
                var treeName = ((TaxonomyType)termList.First().TaxonomyId).ToString().ToLowerInvariant();
                foreach (var item in termList)
                {
                    list.Add(string.Format("$(\"#tree_{0}\").jstree(\"select_node\",\"#{1}\");", treeName, item.Id));
                }
            }
            return list;
        }

        private List<string> GetAjaxTreeFillScript(string companyId, params TaxonomyType[] taxonomyTypes)
        {
            var list = new List<string>();
            foreach (var item in taxonomyTypes)
            {
                var treeName = item.ToString().ToLowerInvariant();
                list.Add(string.Format("ajaxTreeFill(\"#tree_{0}\",\"{1}?taxonomy={2}&companyId={3}\");"
                    , treeName
                    , Url.Action("JSTreeData", "Terms")
                    , (int)item
                    , companyId));
            }

            return list;
        }

        private List<string> GetChangedJstreeScript(params TaxonomyType[] taxonomyTypes)
        {
            var list = new List<string>();
            var sb = new System.Text.StringBuilder(344);
            sb.AppendLine(@" $(""#tree_{0}"").on(""changed.jstree"", function (e, data) {{");
            sb.AppendLine(@"     var i, j, r = [], t = [];");
            sb.AppendLine(@"     for (i = 0, j = data.selected.length; i < j; i++) {{");
            sb.AppendLine(@"         var node = data.instance.get_node(data.selected[i]);");
            sb.AppendLine(@"         r.push(node.id);");
            sb.AppendLine(@"         t.push(node.text);");
            sb.AppendLine(@"     }}");
            sb.AppendLine(@"     $(""#{1}Name"").val(t.join("", ""));");
            sb.AppendLine(@"     $(""#{2}Id"").val(r.join("", ""));");
            sb.AppendLine(@" }});");
            var temp = sb.ToString();
            foreach (var item in taxonomyTypes)
            {
                var treeName = item.ToString().ToLowerInvariant();
                var name = item.ToString();

                list.Add(string.Format(temp
                    , treeName
                    , name
                    , name));
            }

            return list;
        }

        //    $("#").on("changed.jstree", function (e, data) {
        //        var i, j, r = [], t = [];
        //        for (i = 0, j = data.selected.length; i < j; i++) {
        //            var node = data.instance.get_node(data.selected[i]);
        //            r.push(node.id);
        //            t.push(node.text);
        //        }
        //        $("#@Name").val(t.join(", "));
        //        $("#@Id").val(r.join(", "));
        //    });





        // GET: People/Details/5
        public ActionResult Details(string id, string companyId)
        {
            if (id.IsNullOrWhiteSpace() || companyId.IsNullOrWhiteSpace())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.SingleOrDefault(x => x.Id == id && x.CompanyId == companyId);
            if (person == null)
            {
                return HttpNotFound();
            }
            GetAllPersonnelTerms(person);
            return View(person);
        }
        // GET: People/Edit/5
        public ActionResult Edit(string id, string companyId)
        {
            ViewBag.Banks = new List<PersonnelBank> { new PersonnelBank() };  

            Person personnel = db.Person.SingleOrDefault(x => x.Id == id && x.CompanyId == companyId);
            if (personnel != null)
            {
                ViewBag.Educations = db.PersonnelEducation.Where(x => x.PersonnelId == personnel.Id).ToList();
                ViewBag.TempCreatedAt = MyDateTimeToString(personnel.CreatedOn);
                ViewBag.Telephones = db.PersonnelTelephone.Where(x => x.PersonnelId == personnel.Id && x.CompanyId == personnel.CompanyId).ToList();
                personnel.BirthDayString = MyDateTimeToString(personnel.BirthDay);
                personnel.CompanyName = (db.Company.FirstOrDefault(x=>x.Id == personnel.CompanyId)??new Company()).Name;
                GetAllPersonnelTerms(personnel);

                var addresses = db.PersonnelAddress.Where(x => x.CompanyId == companyId && x.PersonnelId == personnel.Id).ToList();
                ViewBag.Addresses = addresses;
                if (addresses.IsEmpty().Not())
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


                var temp = db.PersonnelBank.Where(x => x.CompanyId == personnel.CompanyId && x.PersonnelId == personnel.Id).ToList();

                if (temp.IsEmpty().Not())
                {
                    ViewBag.Banks = temp;

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


            }


            ViewBag.CompanyId = new SelectList(db.Company
                , "Id", "Name", personnel != null ? personnel.CompanyId : companyId);

            personnel = personnel ?? new Person() { CompanyId = companyId,CompanyName = companyId
                .IsNullOrWhiteSpace()
                .Not() ? db.Company.First(x=>x.Id == companyId).Name : string.Empty };

            ViewBag.PositionId = new SelectList(db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.Position), "Id", "Name", personnel.PositionId);

            SetJstreeScripts(personnel);

            ViewBag.RelationshipStatusId = new SelectList(
               db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.RelationshipStatus).ToList()
               , "Id", "Name", personnel.RelationshipStatusId);

            ViewBag.ReligionId = new SelectList(
               db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.Religion).ToList()
               , "Id", "Name", personnel.ReligionId);

            ViewBag.ReasonWhyPassiveId = new SelectList(
               db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.ReasonWhyPassiveForPersonnel).ToList()
               , "Id", "Name", personnel.ReasonWhyPassiveId);


            var temp1 = (from tx in db.TermTaxonomy
                        join te in db.Term on tx.TermId equals te.Id
                        where te.TaxonomyId == (int)TaxonomyType.BloodGroup
                        orderby tx.Id
                        select te).ToList();



            ViewBag.BloodGroupId = new SelectList(
               temp1
               , "Id", "Name", personnel.BloodGroupId);

            //ViewBag.EducationLevelId = new SelectList(
            //   db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.EducationLevel).ToList()
            //         , "Id", "Name", personnel.EducationLevelId);
            return View(personnel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {

            person.BirthDay = MyConvertToDateTime(person.BirthDayString);

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (person.Id.IsNullOrWhiteSpace() || person.Id.Equals(Guid.Empty))
                    {
                        person.Id = Guid.NewGuid().ToString();
                        person.CreatedOn = DateTime.Now;
                        db.Person.Add(person);
                    }
                    else
                    {
                        var existingPersonnel = db.Person.First(x => x.CompanyId == person.CompanyId && x.Id == person.Id);
                        person.CreatedOn = existingPersonnel.CreatedOn;
                        db.Entry(existingPersonnel).State = EntityState.Detached;
                        existingPersonnel = null;
                        db.Entry(person).State = EntityState.Modified;
                    }
                    db.SaveChanges();

                    //********************************************************************//
                    var telephoneList = FillTelefonListPersonnel(person.Id,person.CompanyId);

                    db.PersonnelTelephone.RemoveRange(db.PersonnelTelephone.Where(x => x.CompanyId == person.CompanyId && x.PersonnelId == person.Id));

                    if (telephoneList.Any())
                    {
                        db.PersonnelTelephone.AddRange(telephoneList);
                        db.SaveChanges();
                    }
               
                    //*****************************************************************//
                    var addressList = FillAddressListPersonnel(person.CompanyId, person.Id);

                    db.PersonnelAddress.RemoveRange(db.PersonnelAddress
                       .Where(x => x.CompanyId == person.CompanyId && x.PersonnelId == person.Id));

                    if (addressList.IsEmpty().Not())
                    {
                   
                        db.PersonnelAddress.AddRange(addressList);
                        db.SaveChanges();
                    }
                    //******************************************************************//
                    var bankList = FillPersonnelBankList(person.CompanyId, person.Id);
                    db.PersonnelBank.RemoveRange(db.PersonnelBank.Where(x => x.CompanyId == person.CompanyId
                                                                 && x.PersonnelId == person.Id));
                    if (bankList.Any())
                    {
                    
                        db.PersonnelBank.AddRange(bankList);
                        db.SaveChanges();
                    }
                    //******************************************************************//
                    //group-education[0][EducationLevelId]
                    var educationList = new List<PersonnelEducation>();
                    var i = 0;
                    while (true)
                    {
                        var educationLevelId = Request["group-education[" + i + "][EducationLevelId]"];
                        var studiedSchoolName = Request["group-education[" + i + "][StudiedSchoolName]"];
                        var educationArea = Request["group-education[" + i + "][EducationArea]"];
                        var id = Request["group-education[" + i + "][EducationId]"];
                        if (string.IsNullOrWhiteSpace(studiedSchoolName))
                            break;
                        var education = new PersonnelEducation();
                        education.EducationLevelId = educationLevelId.AsInt();
                        education.StudiedSchoolName = studiedSchoolName;
                        education.EducationArea = educationArea;
                        education.Id = id.AsInt();
                        educationList.Add(education);
                        i++;
                    }



                    var existingEducations = db.PersonnelEducation.Where(x => x.PersonnelId == person.Id && !x.IsPassive).ToList();

                    foreach (var item in existingEducations)
                    {
                        item.IsPassive = true;
                        item.MakedPassiveBy = User.Identity.GetUserId();
                        item.MakedPassiveOn = DateTime.UtcNow;
                        db.Entry(item).State = EntityState.Modified;
                    }


                    if (educationList.Any())
                    {
                

                        var dicExistingEducations = existingEducations.ToDictionary(x => x.Id);

                        foreach (var item in educationList)
                        {
                            if (dicExistingEducations.ContainsKey(item.Id))
                            {
                                dicExistingEducations[item.Id].IsPassive = false;
                                dicExistingEducations[item.Id].MakedPassiveBy = null;
                                dicExistingEducations[item.Id].MakedPassiveOn = null;
                                dicExistingEducations[item.Id].ChangedBy = User.Identity.GetUserId();
                                dicExistingEducations[item.Id].ChangedOn = DateTime.UtcNow;
                                dicExistingEducations[item.Id].EducationLevelId = item.EducationLevelId;
                                dicExistingEducations[item.Id].StudiedSchoolName = item.StudiedSchoolName;
                                dicExistingEducations[item.Id].EducationArea = item.EducationArea;
                            }
                            else
                            {
                                item.CreatedOn = DateTime.UtcNow;
                                item.CreatedBy = User.Identity.GetUserId();
                                item.PersonnelId = person.Id;
                                db.PersonnelEducation.Add(item);
                            }
                        }

                        db.SaveChanges();
                    }
                    //******************************************************************//


                    SaveEntityTerms(GetListNewTerms(TaxonomyTypeForPersonnel,person.CompanyId), person.Id, person.CompanyId);

                        db.SaveChanges();
                        transaction.Commit();
                        return RedirectToAction(actionName: "Index",controllerName: "GuideBook");
                        //foreach (ModelState modelState in ViewData.ModelState.Values)
                        //{
                        //    foreach (ModelError error in modelState.Errors)
                        //    {
                        //        var te = error.ErrorMessage;
                        //    }
                        //}                  
                   
                }
                catch (Exception ex)
                {
                    ViewBag.PositionId = new SelectList(db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.Position), "Id", "Name", person.PositionId);

                    ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", person.CompanyId);
                    ViewBag.RelationshipStatusId = new SelectList(
         db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.RelationshipStatus).ToList()
         , "Id", "Name", person.RelationshipStatusId);

                    ViewBag.ReligionId = new SelectList(
                       db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.Religion).ToList()
                       , "Id", "Name", person.ReligionId);

                    ViewBag.BloodGroupId = new SelectList(
                       db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.BloodGroup).ToList()
                       , "Id", "Name", person.BloodGroupId);
                    ViewBag.ReasonWhyPassiveId = new SelectList(
         db.Term.Where(x => x.TaxonomyId == (int)TaxonomyType.ReasonWhyPassiveForPersonnel).ToList()
         , "Id", "Name", person.ReasonWhyPassiveId);
                    transaction.Rollback();
                    ViewBag.ErrorMessage = "<p>"+ex.ToString()+"</p>";
                    return View(person);
                }
            }
        }
        // GET: People/Delete/5
        public ActionResult Delete(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.SingleOrDefault(x => x.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Person person = db.Person.SingleOrDefault(x => x.Id == id);
            db.Person.Remove(person);
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
    }
}
