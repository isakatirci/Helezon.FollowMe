using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web.Models;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Controllers
{
    public class TelephoneController : BaseController
    {

        // GET: Telephone
        public ActionResult Index(int entityType, Guid companyId, Guid? entityId)
        {
            //ObjectType type = (ObjectType)entityType;
            //if (type == ObjectType.Person)
            //{

            //    //var terms = (from tx in db.Term_Taxonomy
            //    //             join te in db.Terms
            //    //                 on tx.Id equals te.Id
            //    //             where tx.TaxonomyId == taxonomyId && tx.CompanyId == companyId && te.CompanyId == companyId
            //    //             select new TermTaxonomyView
            //    //             {
            //    //                 Id = te.Id,
            //    //                 Name = te.Name,
            //    //                 Parent = tx.Parent
            //    //             }).ToList();

            //    var telephones= from p in db.Person
            //                    join te in db.Telephones
            //                    on new { Key1 = p.Id ,  Key2 = p.CompanyId } equals new { Key1 = te.EntityId , Key2 = te.CompanyId }  
            //                    select new { AreaCode = te.AreaCode,Number = te.Number, Id = te.Id, CreatedAt= te.CreatedAt,   };



            //    return View(db.Telephone.Where(x => x.CompanyId == companyId && x.EntityId == entitiyId).ToList());

            //}
            //else if (type == ObjectType.Company)
            //{
            //    return View(db.Telephone.Where(x => x.CompanyId == companyId && x.EntityId == null).ToList());
            //}
            //return RedirectToAction("Edit", new { id = (int?)null, entitiyType = ObjectType.Company, companyId = (Guid?)null });

            return View("Index",db.CompanyTelephone.ToList());            

        }

        // GET: Telephone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTelephone telephone = db.CompanyTelephone.Find(id);
            if (telephone == null)
            {
                return HttpNotFound();
            }
            return View(telephone);
        }



        // GET: Telephone/Edit/5
        public ActionResult Edit(int? id, int entityType, string companyId)
        {
            EntityType type = (EntityType)entityType;

            ViewBag.ObjectType = type;

            if (!id.HasValue)
            {
                ViewBag.ObjectId = Enumerable.Empty<SelectListItem>();
                ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name");
                ViewBag.AreaCode = new SelectList(Utils.AreaCodes.Select(x => new { Id = x.Item2 + " (+" + x.Item1 + ")", Name = x.Item2 + " (+" + x.Item1 + ")" }).ToList(), "Id", "Name");
                return View();
            }

            CompanyTelephone telephone = db.CompanyTelephone.Find(id);
            if (telephone != null)
            {
                if (type == EntityType.Company)
                {
                    ViewBag.ObjectId = new SelectList(db.Company, "Id", "Name", telephone.CompanyId);
                }
                else if (type == EntityType.Person)
                {
                    ViewBag.ObjectId = new SelectList(db.Person.Where(x => x.CompanyId == companyId), "Id", "Name", telephone.CompanyId);
                }
                ViewBag.TempCreatedAt = MyDateTimeToString(telephone.CreatedOn);
            }
            return View(telephone ?? new CompanyTelephone());
        }

        // POST: Telephone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyTelephone telephone)
        {
            if (ModelState.IsValid)
            {
                if (telephone.Id < 1)
                {
                    telephone.CreatedOn = DateTime.Now;
                    db.CompanyTelephone.Add(telephone);
                }
                else
                {
                    db.Entry(telephone).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index",new { companyId = telephone.CompanyId });
            }
            //ViewBag.ObjectType = telephone.EntityType;
            return View(telephone);
        }

        // GET: Telephone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTelephone telephone = db.CompanyTelephone.Find(id);
            if (telephone == null)
            {
                return HttpNotFound();
            }
            return View(telephone);
        }

        [HttpGet]
        public JsonResult GetPersonIds(string companyId)
        {
            return Json(db.Person.Where(p => p.CompanyId == companyId).Select(x => new { Text = x.FirstName + " " + x.LastName, Value = x.Id }).ToList(), JsonRequestBehavior.AllowGet);
        }


        // POST: Telephone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyTelephone telephone = db.CompanyTelephone.Find(id);
            db.CompanyTelephone.Remove(telephone);
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
