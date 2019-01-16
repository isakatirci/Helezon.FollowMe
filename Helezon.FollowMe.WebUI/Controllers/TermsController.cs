using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web.Models;
using FollowMe.Web.Models.ViewModels;
using Newtonsoft.Json;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Controllers
{
    public class TermsController : BaseController
    {
        //public ActionResult EditTaxonomies(string companyId, int? taxonomyId)
        //{
        //    if (companyId.IsNullOrWhiteSpace() || !taxonomyId.HasValue)
        //    {
        //        ViewBag.TaxonomyId = Utils.GetTaxonomyNames();
        //        ViewBag.CompanyList = db.Company.ToList();
        //        return View();
        //    }
        //    return View();
        //}


        [HttpGet]
        public ActionResult Taxonomies(string companyId, int? taxonomyId)
        {
            ViewBag.NestedListHtmlString = "<div class=\"dd-empty\"></div>";
            ViewBag.NewNestedListHtmlString = "<div class=\"dd-empty\"></div>";
            ViewBag.ShowNestableList = false;

            if (companyId.IsNullOrWhiteSpace())
            {
                ViewBag.TaxonomyId = Enumerable.Empty<SelectListItem>();/* Utils.GetTaxonomyNames();*/
                //ViewBag.CompanyList = db.Company.ToList();
                return View(viewName: "Taxonomies");

            }

            switch (companyId)
            {
                case "00000000-0000-0000-0000-000000000000":
                    ViewBag.TaxonomyId = Utils.GetTaxonomyNames();
                    break;
                case "00000000-0000-0000-0000-000000000001":
                    ViewBag.TaxonomyId = Utils.GetTaxonomyNamesZCode();
                    break;
                default:
                    ViewBag.TaxonomyId = Enumerable.Empty<SelectListItem>();
                    break;
            }


            if (taxonomyId.HasValue)
            {
                var nestedList = (from tx in db.TermTaxonomy
                                  join te in db.Term
                                      on tx.TermId equals te.Id
                                  where tx.TaxonomyId == taxonomyId && tx.CompanyId == companyId && te.CompanyId == companyId
                                  orderby tx.Id
                                  select new TermTaxonomyView
                                  {
                                      TermId = te.Id,
                                      Name = te.Name,
                                      Parent = tx.Parent,
                                      NoDragClass = te.NoDragClass,
                                      NoChildrenClass = te.NoChildrenClass,
                                      Color = te.Color
                                  }).ToList();

                var newNestedList = (from tx in db.Term
                                     where tx.CompanyId == companyId && tx.TaxonomyId == taxonomyId && !db.TermTaxonomy.Any(x => x.TermId == tx.Id)
                                     select tx).ToList();


                ViewBag.NestedListHtmlString = !nestedList.Any() ? string.Empty : GenerateNestedListHtmlString(nestedList);
                ViewBag.NewNestedListHtmlString = !newNestedList.Any() ? string.Empty : GenerateNewNestedListHtmlString(newNestedList);
                ViewBag.ShowNestableList = true;   
            }
            return View(viewName: "Taxonomies");
        }

        [HttpGet]
        public ActionResult TaxonomyAssign()
        {
        
            return View();
        }


        public class ActionMessage
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }

        [HttpPost]
        public ActionResult TermUpdate(TermViewModel editTerm)
        {
            var message = new ActionMessage();
           
            var tempTerm = db.Term.Find(editTerm.Id);
            if (tempTerm != null)
            {
                tempTerm.Color = editTerm.Color;
                tempTerm.NoDragClass = editTerm.NoDragClass == "1";
                tempTerm.NoChildrenClass = editTerm.NoChildrenClass == "1";
                tempTerm.Name = editTerm.Name;
                db.Entry(tempTerm).State = EntityState.Modified;
                db.SaveChanges();
                message.IsSuccess = true;
                return Json(message, JsonRequestBehavior.AllowGet);

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }



        //public string GetNestableListHtmlString(IEnumerable<TermTaxonomyView> taxonomies)
        //{
        //    string htmlOutput = string.Empty;
        //    foreach (var taxonomy in taxonomies)
        //    {
        //        htmlOutput += "<li class=\"dd-item\" data-id=\"" + taxonomy.Id + "\">";
        //        htmlOutput += "<div class=\"dd-handle\">" + taxonomy.Name + "</div>";
        //        var subList = taxonomies.Where(x => x.Parent.Equals(taxonomy.Id)).ToList();
        //        if (subList.Any())
        //        {
        //            htmlOutput += "<ol class=\"dd-list\">";
        //            htmlOutput += GetNestableListHtmlString(subList);
        //            htmlOutput += "</ol>";
        //        }             
        //        htmlOutput += "</li>";
        //    }
        //     htmlOutput += "</ol>";
        //    return htmlOutput;

        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult AddNewTerm(Term term,string companyId)
        {
            term.CompanyId = companyId;
            if (ModelState.IsValid)
            {
                if (term.Id < 1)
                    db.Term.Add(term);
                else
                    db.Entry(term).State = EntityState.Modified;
                db.SaveChanges();
            }

            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    var t = error;
                }
            }
            return Json(term, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult AddNewTerm(string companyId, int taxonomyId,string termName,int termParent)
        {
            var term = new Term();
            term.Name = termName;
            term.CreatedOn = DateTime.Now;
            term.CompanyId = companyId;
            term.TaxonomyId = taxonomyId;

            if (term.Id < 1)
                db.Term.Add(term);
            else
                db.Entry(term).State = EntityState.Modified;
            db.SaveChanges();   


            TermTaxonomy tx = new TermTaxonomy();
            tx.Parent = termParent;
            tx.TermId = term.Id;
            tx.CompanyId = term.CompanyId;
            tx.TaxonomyId = term.TaxonomyId;
            db.TermTaxonomy.Add(tx);
            db.SaveChanges();


            //foreach (ModelState modelState in ViewData.ModelState.Values)
            //{
            //    foreach (ModelError error in modelState.Errors)
            //    {
            //        var t = error;
            //    }
            //}
            return Taxonomies(companyId,taxonomyId);
        }

        [HttpPost]
        public JsonResult Term_Taxonomy(string companyId, int taxonomy, string nestableList)
        {
            //db.Database.Log = Console.Write;
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var termTaxonomies = JsonToTermTaxonomy(nestableList, taxonomy);
                    db.TermTaxonomy.RemoveRange(db.TermTaxonomy.Where(x => x.TaxonomyId == taxonomy && x.CompanyId == companyId));
                    foreach (var item in termTaxonomies)
                    {
                        item.CompanyId = companyId;
                        db.TermTaxonomy.Add(item);
                    }                    
                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { IsSucceeded = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Json(new { IsSucceeded = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        public ActionResult JSTreeData(int taxonomy,string companyId)
        {
            // { "id" : "ajson1", "parent" : "#", "text" : "Simple root node" },

            var department = (from tx in db.TermTaxonomy
                              join te in db.Term
                                  on tx.TermId equals te.Id
                              where tx.TaxonomyId == taxonomy && ((tx.CompanyId == companyId && te.CompanyId == companyId) 
                              || (tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString())) && te.TaxonomyId == taxonomy 
                              select new
                              {
                                  id = te.Id.ToString(),
                                  text = te.Name,
                                  parent = tx.Parent == 0 ? "#" : tx.Parent.ToString()
                              }).ToList();

            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public class TreeDate
        {
            public string id { get; set; }
            public string text { get; set; }
            public string parent { get; set; }
            public NodeState state { get; set; }
        }
        public class NodeState
        {
            public bool disabled { get; set; }
        }

        public ActionResult JSTreeDataV2(int taxonomy, string companyId)
        {
            // { "id" : "ajson1", "parent" : "#", "text" : "Simple root node" },

            var department = (from tx in db.TermTaxonomy
                              join te in db.Term
                                  on tx.TermId equals te.Id
                              where tx.TaxonomyId == taxonomy && ((tx.CompanyId == companyId && te.CompanyId == companyId) 
                              || (tx.CompanyId == Guid.Empty.ToString() 
                              && te.CompanyId == Guid.Empty.ToString())) 
                              && te.TaxonomyId == taxonomy
                              select new TreeDate
                              {
                                  id = te.Id.ToString(),
                                  text = te.Name,
                                  parent = tx.Parent == 0 ? "#" : tx.Parent.ToString(),
                                  state = new NodeState { disabled = tx.Parent == 0 }
                              }).ToList();



            var parents = department.Where(x=>x.parent == "#").ToList();

            foreach (var parent in parents)
            {
                var children = department.Where(x => x.parent == parent.id).ToList();
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].state.disabled = true ;
                }  
            }

            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeDataDescendances(int taxonomy, string companyId, int termId)
        {
            // { "id" : "ajson1", "parent" : "#", "text" : "Simple root node" },


            //var list = (from tx in db.Term_Taxonomy
            //                  join te in db.Terms
            //                      on tx.Id equals te.Id 
            //                  where (tx.Parent == termId || te.Id == termId) && tx.TaxonomyId == taxonomy && ((tx.CompanyId == companyId && te.CompanyId == companyId) || (tx.CompanyId == Guid.Empty && te.CompanyId == Guid.Empty)) && te.TaxonomyId == taxonomy
            //            select new TermTaxonomyView
            //                  {
            //                      Id = te.Id,
            //                      Name = te.Name,
            //                      Parent = tx.Parent
            //                  }).ToList();

            var term = (from tx in db.TermTaxonomy
                              join te in db.Term
                                  on tx.TermId equals te.Id 
                              where te.Id == termId && (te.TaxonomyId == taxonomy && tx.TaxonomyId == taxonomy) 
                              && ((tx.CompanyId == companyId && te.CompanyId == companyId) 
                              || (tx.CompanyId == Guid.Empty.ToString() && te.CompanyId == Guid.Empty.ToString())) 
                        select new TermTaxonomyView
                              {
                                  TermId = te.Id,
                                  Name = te.Name,
                                  Parent = tx.Parent,
                                  Disabled = te.Disabled.HasValue && te.Disabled.Value
                        }).SingleOrDefault();

           
            var temp = GenerateNestedList(term, taxonomy, companyId);           


            var temp2 = (from te in temp
                         select new
                         {
                             id = te.TermId.ToString(),
                             text = te.Name,
                             parent = te.Parent.HasValue && te.Parent == 0 ? "#" : te.Parent.ToString(),
                             state = new { disabled = te.Disabled }
                         }).ToList();

            return Json(temp2, JsonRequestBehavior.AllowGet);
        }

        public List<TermTaxonomyView> GenerateNestedList(TermTaxonomyView parent, int taxonomy, string companyId)
        {
            var all = new List<TermTaxonomyView>();
            if (parent == null)            
                return all;

            //parent.Disabled = true;

            all.Add(parent);
            var tempNestedList = (from tx in db.TermTaxonomy
                                  join te in db.Term
                                      on tx.TermId equals te.Id
                                  where tx.Parent == parent.TermId 
                                  select new TermTaxonomyView
                                  {
                                      TermId = te.Id,
                                      Name = te.Name,
                                      Parent = tx.Parent,
                                      Disabled = te.Disabled.HasValue && te.Disabled.Value
                                  }).ToList();

            if (tempNestedList != null && tempNestedList.Any())
            {
                foreach (var item in tempNestedList)
                {
                    all.Add(item);

                    List<TermTaxonomyView> childTerms = (from tx in db.TermTaxonomy
                                                         join te in db.Term
                                                             on tx.TermId equals te.Id
                                                         where tx.Parent == item.TermId 
                                                         select new TermTaxonomyView
                                                         {
                                                             TermId = te.Id,
                                                             Name = te.Name,
                                                             Parent = tx.Parent,
                                                             Disabled = te.Disabled.HasValue && te.Disabled.Value
                                                         }).ToList();
                    if (childTerms!=null && childTerms.Any())
                        AddChildTerms(all, childTerms);
                }
            }

       
            return all;
        }

        //bool firtloop = true;
        private void AddChildTerms(List<TermTaxonomyView> all, List<TermTaxonomyView> terms)
        {
            //if (firtloop)
            //{
            //    foreach (TermTaxonomyView term in terms)
            //    {
            //        term.Disabled = true;
            //    }
            //    firtloop = false;
            //}


            foreach (TermTaxonomyView term in terms)
            {
               
                all.Add(term);
                var subChilds = (from tx in db.TermTaxonomy
                                                    join te in db.Term
                                                        on tx.TermId equals te.Id
                                                    where tx.Parent == term.TermId 
                                                    select new TermTaxonomyView
                                                    {
                                                        TermId = te.Id,
                                                        Name = te.Name,
                                                        Parent = tx.Parent,
                                                        Disabled = te.Disabled.HasValue && te.Disabled.Value
                                                    }).ToList();
                if (subChilds != null && subChilds.Any())
                {
                    AddChildTerms(all, subChilds);
                }
            }
        }

        public ActionResult BankGuide(int? termId)
        {

            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            ViewBag.TermNames = (from tx in db.TermTaxonomy
                                 join te in db.Term
                                     on tx.TermId equals te.Id
                                 where tx.TaxonomyId == (int)TaxonomyType.BankName && tx.CompanyId == Guid.Empty.ToString() 
                                 && te.CompanyId == Guid.Empty.ToString() && te.TaxonomyId == (int)TaxonomyType.BankName
                                 select new SelectListItem
                                 {
                                     Text = te.Name,
                                     Value = te.Id.ToString(),
                                     //Selected = termId != 0 && termId == te.Id
                                 }).ToList();

            ViewBag.SwiftNo = Request["SwiftNo"];

            if (termId.HasValue)
            {

                ViewBag.TermId = termId.ToString();

             

                var temp = db.BankGuide.Where(x => x.TermId == termId).ToList();

                if (temp.Any())
                {
                    ViewBag.SwiftNo = temp[0].SwiftNo;
                    return View(temp);
                }
                else
                {

                    return View(viewName: "BankGuide", model: new List<BankGuide> { new BankGuide() });
                }

            }





            return View(viewName: "BankGuide", model:new List<BankGuide> { new BankGuide() });
        }



        [HttpGet]
        public ActionResult AddNewBank(string termId, string termName)
        {

            int? id = null;
            if (!string.IsNullOrWhiteSpace(termId))
            {
                id = int.Parse(termId);
            }

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var term = new Term();
                    term.Name = termName;
                    term.CreatedOn = DateTime.Now;
                    term.CompanyId = Guid.Empty.ToString();
                    term.TaxonomyId = (int)TaxonomyType.BankName;

                    //if (!term.Id.HasValue || term.Id.Value < 1)
                    //else
                    //    db.Entry(term).State = EntityState.Modified;

                    db.Term.Add(term);
                    db.SaveChanges();



                    TermTaxonomy tx = new TermTaxonomy();
                    tx.Parent = 0;
                    tx.TermId = term.Id;
                    tx.CompanyId = term.CompanyId;
                    tx.TaxonomyId = term.TaxonomyId;
                    db.TermTaxonomy.Add(tx);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }              

            }

            return BankGuide(id);

        }



        [HttpPost]
        public ActionResult BankGuide(FormCollection form)
        {
            var bankNames = form["BankNames"]; 
             var swiftNo= form["SwiftNo"];
            if (!string.IsNullOrWhiteSpace(bankNames))
            {
                var termId = int.Parse(bankNames);
                var banks = new List<BankGuide>();

                var i = 0;
                while (true)
                {
                    var branchCode = form["group-bank[" + i + "][BranchCode]"];
                    var branchName = form["group-bank[" + i + "][BranchName]"];
                  

                    if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
                        break;

                    var bank = new BankGuide();
                    bank.TermId = termId;
                    bank.BranchCode = branchCode;
                    bank.BranchName = branchName;
                    bank.SwiftNo = swiftNo;
                    bank.CompanyId = Guid.Empty.ToString();
                    bank.CreatedOn = DateTime.UtcNow;
                    banks.Add(bank);
                    i++;
                }

                db.BankGuide.RemoveRange(db.BankGuide.Where(x => x.CompanyId == Guid.Empty.ToString() && x.TermId == termId));

                db.BankGuide.AddRange(banks);

                db.SaveChanges();
                TempData["SuccessMessage"] = "Saved.";
            }




            return BankGuide(string.IsNullOrWhiteSpace(bankNames) ? (int?)null : int.Parse(bankNames));

        }


    }
}
