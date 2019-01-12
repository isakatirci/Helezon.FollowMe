using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using Helezon.FollowMe.WebUI.Models.ViewModels;

namespace Helezon.FollowMe.WebUI.Controllers
{
    public class ZetaCodeFanteziIplikController : BaseController
    {

        // GET: ZetaCodeFanteziIplik
        public ActionResult Index()
        {
            var fanteziIplikler = GetFanteziIplikService().GetAllFanteziIplikler();
            //var zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Include(z => z.PantoneRengi).Include(z => z.Renk);
            var model = new List<ZetaCodeFanteziIplikVm>();
            foreach (var item in fanteziIplikler)
            {
                model.Add(new ZetaCodeFanteziIplikVm
                {
                    ZetaCodeFanteziIplikDto = item
                });
            }
            return View(model);
        }

   

        // GET: ZetaCodeFanteziIplik/Create
        public ActionResult Create()
        {
            var model = new ZetaCodeFanteziIplikVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }

        public void FillCollections(ZetaCodeFanteziIplikVm model
                                        , string sirketId = ""
                                        , int? ulkeId = null
                                        , int pantoneRenkId = 0
                                        , int renkId = 0
                                        , int uretimTeknolojitermId = 0)
        {
            var blueCompanies = GetCompanyService().GetParentCompanyIdAndNames(1, sirketId);
            model.Collections.Sirketler
                = new SelectList(blueCompanies, "Id", "Name", sirketId);
            var temp = GetOthersService().GetAllCountry().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, ulkeId?.ToString()) == 0);
            if (ulke != null)
            {
                ulke.Selected = true;
            }
            model.Collections.Ulkeler = temp;   
            //model.Collections.PantoneRenkleri = new SelectList(GetZetaCodeNormalIplikService().GetPantoneRenkler(), "Id", "PantoneKodu", pantoneRenkId);
            //model.Renkler = new GetSelectListWithId(GetSelectListRenkler);
            //model.Collections.UretimTeknolojileri = new SelectList(GetTermService().GetTermsByTaxonomyId(31), "Id", "Name", uretimTeknolojitermId);
            //model.NE = new IplikNoGuideMethod(GetSelectListNE);
            //model.NM = new IplikNoGuideMethod(GetSelectListNM);
            //model.DYN = new IplikNoGuideMethod(GetSelectListDYN);
            //model.FL = new IplikNoGuideMethod(GetSelectListFL);
            //model.EA = new IplikNoGuideMethod(GetSelectListEA);
            //model.ElyafOrani = new ElyafOraniMethod(GetSelectListElyafOrani);

        }

        // GET: ZetaCodeFanteziIplik/Edit/5
        public ActionResult Edit(int? id,string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZetaCodeFanteziIplik zetaCodeFanteziIplik = db.ZetaCodeFanteziIplik.Find(id);
            if (zetaCodeFanteziIplik == null)
            {
                return HttpNotFound();
            }
            return View(zetaCodeFanteziIplik);
        }

        // POST: ZetaCodeFanteziIplik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeFanteziIplikVm zetaCodeFanteziIplik)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(zetaCodeFanteziIplik).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(zetaCodeFanteziIplik);
        }

        // GET: ZetaCodeFanteziIplik/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeFanteziIplik zetaCodeFanteziIplik = db.ZetaCodeFanteziIplik.Find(id);
        //    if (zetaCodeFanteziIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeFanteziIplik);
        //}

        //// POST: ZetaCodeFanteziIplik/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ZetaCodeFanteziIplik zetaCodeFanteziIplik = db.ZetaCodeFanteziIplik.Find(id);
        //    db.ZetaCodeFanteziIplik.Remove(zetaCodeFanteziIplik);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: ZetaCodeFanteziIplik/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeFanteziIplik zetaCodeFanteziIplik = db.ZetaCodeFanteziIplik.Find(id);
        //    if (zetaCodeFanteziIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeFanteziIplik);
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
