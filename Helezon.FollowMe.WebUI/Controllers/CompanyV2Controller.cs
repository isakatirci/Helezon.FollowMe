using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web.Models;

namespace Helezon.FollowMe.WebUI.Controllers
{
    public class CompanyV2Controller : Controller
    {
        private GLCEmasModel db = new GLCEmasModel();

        // GET: CompanyV2
        public ActionResult CompanyIndex()
        {
            return View(db.Company.ToList());
        }

        // GET: CompanyV2/Create
        public ActionResult CompanyCreate()
        {
            return View();
        }

        // POST: CompanyV2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyCreate(
        Company company)
        {
            if (ModelState.IsValid)
            {
                db.Company.Add(company);
                db.SaveChanges();
                return RedirectToAction("CompanyIndex");
            }

            return View(company);
        }

        // GET: CompanyV2/Edit/5
        public ActionResult CompanyEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: CompanyV2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyEdit(
        Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CompanyIndex");
            }
            return View(company);
        }

        //// GET: CompanyV2/Delete/5
        //public ActionResult CompanyDelete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = db.Company.Find(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

        //// POST: CompanyV2/Delete/5
        //[HttpPost, ActionName("CompanyDelete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CompanyDeleteConfirmed(string id)
        //{
        //    Company company = db.Company.Find(id);
        //    db.Company.Remove(company);
        //    db.SaveChanges();
        //    return RedirectToAction("CompanyIndex");
        //}

        //// GET: CompanyV2/Details/5
        //public ActionResult CompanyDetails(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = db.Company.Find(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

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
