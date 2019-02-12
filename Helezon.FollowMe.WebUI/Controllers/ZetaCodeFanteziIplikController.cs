using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using Helezon.FollowMe.Service.ContainerDtos;
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
            var model = new List<ZetaCodeFanteziIplikEditVm>();
            foreach (var item in fanteziIplikler)
            {
                model.Add(new ZetaCodeFanteziIplikEditVm
                {
                    FanteziIplik = item
                });
            }
            return View(model);
        }

   

        // GET: ZetaCodeFanteziIplik/Create
        public ActionResult Create()
        {
            var model = new ZetaCodeFanteziIplikEditVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }

        public void FillCollections(ZetaCodeFanteziIplikEditVm model
                                        , string sirketId = ""
                                        , int? ulkeId = null)
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
       

            model.Collections.EaIpliNolar = GetNormalIplikService().GetIplikNoGuideByColumnName("EA").Select(x => new SelectListItem() { Value = x.Ea.ToString(), Text = x.Ea.ToString() }).ToList();
            model.Collections.DnyIpliNolar = GetNormalIplikService().GetIplikNoGuideByColumnName("DNY").Select(x => new SelectListItem() { Value = x.Dny.ToString(), Text = x.Dny.ToString() }).ToList();
            model.Collections.NmIpliNolar = GetNormalIplikService().GetIplikNoGuideByColumnName("NM").Select(x => new SelectListItem() { Value = x.Nm.ToString(), Text = x.Nm.ToString() }).ToList();
            model.Collections.FlIpliNolar = GetNormalIplikService().GetIplikNoGuideByColumnName("FL").Select(x => new SelectListItem() { Value = x.Fl.ToString(), Text = x.Fl.ToString() }).ToList();
            model.Collections.EaIpliNolar.Insert(0,new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            model.Collections.DnyIpliNolar.Insert(0, new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            model.Collections.FlIpliNolar.Insert(0, new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            model.Collections.NmIpliNolar.Insert(0, new SelectListItem { Value = "", Text = "Please Select", Selected = true });

            model.Collections.Ulkeler = temp;
            model.Collections.NormalIplikler = GetNormalIplikService().GetAllZetaCodeAndUrunIsmiOfNormalIplikler().Select(x => new SelectListItem {
                Value = x.Id.ToString(), Text = x.ZetaCodeFormat() + ", " + x.UrunIsmi
            }).ToList();

           

        }

        //public ActionResult GetNormalIplikRenkler(int? normalIplikId)
        //{
        //    if (!normalIplikId.HasValue || normalIplikId.Value < 1)
        //    {
        //        return new EmptyResult();
        //    }
        //    var normalIplik = GetNormalIplikService().GetRenklerOfNormalIplik(normalIplikId: normalIplikId.Value);
        //    var model = new GetNormalIplikRenklerVm();
        //    model.NormalIplikDto = normalIplik;
        //    return PartialView(viewName: "~/Views/ZetaCodeFanteziIplik/_NormalIplikRenkler.cshtml", model: model);
        //}

        // GET: ZetaCodeFanteziIplik/Edit/5
        public ActionResult Edit(int? id,string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var zetaCodeFanteziIplik = GetFanteziIplikService().GetFanteziIplikById(id.Value, companyId, includeNormalIplikler: true);
            if (zetaCodeFanteziIplik == null)
            {
                return HttpNotFound();
            }
            var model = new ZetaCodeFanteziIplikEditVm();
            model.FanteziIplik = zetaCodeFanteziIplik;
            FillCollections(model
                , sirketId: zetaCodeFanteziIplik.SirketId
                , ulkeId: zetaCodeFanteziIplik.Ulke?.Id.AsInt());
            return View(model);
        }

        // POST: ZetaCodeFanteziIplik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeFanteziIplikEditVm model)
        {


            var keys = Request.Form.Keys;
            var companyId = Request.Form["Company.Id"];//Company.Id

            var container = new FanteziIplikContainerDto();
            container.FanteziIplik = model.FanteziIplik;
            container.NormalIplikler = model.NormalIplikler;
            model.Company.Id = companyId;
            container.Company = model.Company;
            Action action = () =>
            {
                GetFanteziIplikService().InsertOrUpdate(container);
            };

            if (HandleException(action))
                return RedirectToAction(controllerName:"ZetaCode",actionName: "Index");

            var fanteziIplik = model.FanteziIplik;
            FillCollections(model
                , sirketId: fanteziIplik.SirketId
                , ulkeId: fanteziIplik.Ulke?.Id.AsInt()
               );

            return View(viewName: "Edit", model: model);
        }

        public ActionResult Card(int? id, string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var fanteziIplik = GetFanteziIplikService().GetAllFanteziIplikler(id.Value, companyId).FirstOrDefault();
            if (fanteziIplik == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new ZetaCodeFanteziIplikCardVm();

            model.ZetaCodeFanteziIplikDto = fanteziIplik;
            model.ParentIplikCategories = GetTermService().GetAllParentsById(fanteziIplik.IplikKategosiId);
            model.ParentIplikCategories.Reverse();

            if (true)
            {

            }

            var photoEditUrl = string.Format("/FileUpload/Edit?returnUrl={0}&entitytype={1}&entityId={2}&companyId={3}"
                                    , Url.Encode("/ZetaCodeNormalIplik/Card?Id=" + fanteziIplik.Id + "&companyId=" + fanteziIplik.SirketId)
                                    , (int)EntityType.ZetaCodeNormalIplik
                                    , fanteziIplik.Id
                                    , fanteziIplik.SirketId);

            model.PictureEditUrl = photoEditUrl;
            model.PictureUrl = GetZetaCodeFanteziIplikPictureService().GetZetaCodeFanteziIplikPictureUrl(model.ZetaCodeFanteziIplikDto.Id, model.ZetaCodeFanteziIplikDto.SirketId);
            return View(model);
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
