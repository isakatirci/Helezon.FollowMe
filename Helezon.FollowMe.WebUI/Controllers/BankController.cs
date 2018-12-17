//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using FollowMe.Web.Models;
//using static FollowMe.Web.Controllers.Utils;

//namespace FollowMe.Web.Controllers
//{
//    public class BankController : BaseController
//    {

//        // GET: Bank
//        public ActionResult Index()
//        {
//            return View(db.Banks.ToList());
//        }

//        // GET: Bank/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Bank bank = db.Banks.Find(id);
//            if (bank == null)
//            {
//                return HttpNotFound();
//            }
//            return View(bank);
//        }

//        // GET: Bank/Edit/5
//        public ActionResult Edit(Guid? id, Guid? companyId)
//        {
//            if (id == null || companyId == null)
//            {
//                ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name");
//                return View(new Bank());
//            }
//            Bank bank = db.Banks.Find(id);
//            if (bank != null)
//            {
//                ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", bank.CompanyId);
//                ViewBag.TempCreatedAt = MyDateTimeToString(bank.CreatedAt);
//                bank.CurrencyType = db.Term_Relationships.Where(x => x.EntityId == bank.Id && x.CompanyId == x.CompanyId && x.TaxonomyId == (int)TaxonomyType.CurrencyType).SingleOrDefault();
//            }
//            return View(bank ?? new Bank());
//        }

//        // POST: Bank/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Bank bank)
//        {
//            using (DbContextTransaction transaction = db.Database.BeginTransaction())
//            {
//                try
//                {
//                    if (bank.Id.Equals(Guid.Empty))
//                    {
//                        bank.Id = Guid.NewGuid();
//                        bank.CreatedAt = DateTime.Now;
//                        db.Banks.Add(bank);
//                    }
//                    else
//                    {
//                        db.Entry(bank).State = EntityState.Modified;
//                    }

//                    db.SaveChanges();

//                    var currencyTypeName = Request["CurrencyTypeName"];
//                    var currencyTypeId = Request["CurrencyTypeId"];

//                    if (!string.IsNullOrWhiteSpace(currencyTypeId))
//                    {
//                        var previousBank = db.Term_Relationships.Where(x => x.EntityId == bank.Id && x.CompanyId == bank.CompanyId && x.TaxonomyId == (int)TaxonomyType.CurrencyType).SingleOrDefault();

//                        if (previousBank != null)                        
//                            db.Term_Relationships.Remove(previousBank);

//                        db.SaveChanges();

//                        db.Term_Relationships.Add(new Term_Relationships {

//                            CompanyId = bank.CompanyId,
//                            EntityId = bank.Id,
//                            TermId = int.Parse(currencyTypeId),
//                            TermName = currencyTypeName,
//                            TaxonomyId = (int)TaxonomyType.CurrencyType
//                        });

//                        db.SaveChanges();

//                    }

//                    transaction.Commit();
//                    return RedirectToAction("Index");

//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                }        
//            }

//            ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", bank.CompanyId);
//            ViewBag.TempCreatedAt = MyDateTimeToString(bank.CreatedAt);
//            return View(bank);
//        }

//        // GET: Bank/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Bank bank = db.Banks.Find(id);
//            if (bank == null)
//            {
//                return HttpNotFound();
//            }
//            return View(bank);
//        }

//        // POST: Bank/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Bank bank = db.Banks.Find(id);
//            db.Banks.Remove(bank);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
