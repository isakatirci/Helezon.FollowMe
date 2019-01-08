using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
using Helezon.FollowMe.WebUI.Code;
using Helezon.FollowMe.WebUI.Models.ViewModels;

namespace Helezon.FollowMe.WebUI.Controllers
{


    public class ZetaCodeNormalIplikController : BaseController
    {

        
        private static Lazy<List<SelectListItem>> elyafOrani = new Lazy<List<SelectListItem>>(() => {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Text = "Please Select",
                Value = ""
            });
            for (int i = 1; i <= 100; i++)
            {
                list.Add(new SelectListItem {
                    Text = i + "%",
                    Value = i.ToString()
                });
            }
            return list;
        });

        // GET: ZetaCodeNormalIplik

        public ActionResult Create(string page)
        {
            var model = new ZetaCodeNormalIplikVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }
        public ActionResult Index()
        {
            var list = GetZetaCodeNormalIplikService().GetAllZetaCodeNormalIplikler();
            //var zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Include(z => z.PantoneRengi).Include(z => z.Renk);
            var model = new List<ZetaCodeNormalIplikVm>();
            foreach (var item in list)
            {
                model.Add(new ZetaCodeNormalIplikVm {
                    ZetaCodeNormalIplikDto = item
                });
            }
            return View(model);
        }

        // GET: ZetaCodeNormalIplik/Details/5

        // GET: ZetaCodeNormalIplik/Create

        public void FillCollections(ZetaCodeNormalIplikVm model
            ,string sirketId = ""
            ,int? ulkeId = null
            ,int pantoneRenkId = 0
            ,int renkId = 0
            ,int uretimTeknolojitermId = 0)
        {
            model.Collections.Sirketler
                = new SelectList(GetCompanyService().GetParentCompanyIdAndNames(1,sirketId), "Id", "Name", sirketId);
            var temp = GetOthersService().GetAllCountry().Select(x => new SelectListItem() { Text = x.Name , Value = x.Id}).ToList();
            var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value,ulkeId?.ToString()) == 0);
            if (ulke != null)
            {
                ulke.Selected = true;
            }
            model.Collections.Ulkeler = temp;
            model.Collections.PantoneRenkleri = new SelectList(GetZetaCodeNormalIplikService().GetPantoneRenkler(), "Id", "PantoneKodu", pantoneRenkId);
            model.Renkler = new GetSelectListWithId(GetSelectListRenkler);
            model.Collections.UretimTeknolojileri = new SelectList(GetTermService().GetTermsByTaxonomyId(31), "Id", "Name", uretimTeknolojitermId);
            model.NE = new IplikNoGuideMethod(GetSelectListNE);
            model.NM = new IplikNoGuideMethod(GetSelectListNM);
            model.DYN = new IplikNoGuideMethod(GetSelectListDYN);
            model.FL = new IplikNoGuideMethod(GetSelectListFL);
            model.EA = new IplikNoGuideMethod(GetSelectListEA);
            model.ElyafOrani = new ElyafOraniMethod(GetSelectListElyafOrani);

        }    

        public string GetSelectListNE(string value)
        {
            return GetSelectListIplikNoGuide(value, "NE");
        }
        public string GetSelectListNM(string value)
        {
            return GetSelectListIplikNoGuide(value, "NM");
        }
        public string GetSelectListDYN(string value)
        {
            return GetSelectListIplikNoGuide(value, "DNY");
        }
        public string GetSelectListFL(string value)
        {
            return GetSelectListIplikNoGuide(value, "FL");
        }
        public string GetSelectListEA(string value)
        {
            return GetSelectListIplikNoGuide(value, "EA");
        }

        public string GetSelectListRenkler(int? id)
        {

            //https://medium.com/@ulkutokmak/asp-net-mvc-html-helpers-484ae121e383
            var renkler = GetZetaCodeNormalIplikService().GetRenkler().Select(x=> new SelectListItem {
                Value = string.Format("{0}|{1}",x.Id,x.HtmlKod??string.Empty),
                Text= x.Ad            });

            var sb = new StringBuilder(150);
            sb.AppendLine(@"<select class=""form-control select2"" onchange=""setHtmlColorCode($(this))"" id=""ZetaCodeNormalIplikDto_RenkIdFormat"" name=""ZetaCodeNormalIplikDto.RenkIdFormat"">");
            var flag = id.HasValue;
            if (!flag)
            {
                sb.AppendLine(@"<option value="""" selected> Please Select </option>");
            }

            foreach (var item in renkler)
            {
                if (flag && string.CompareOrdinal(item.Value.Split('|')[0], id.Value.ToString()) == 0)
                {
                    flag = false;
                    sb.AppendLine(@"<option value=""" + item.Value + @""" selected>" + item.Text + "</option>");
                }
                else
                {
                    sb.AppendLine(@"<option value=""" + item.Value + @""">" + item.Text + "</option>");
                }

            }

            sb.AppendLine(@"  </select>");
            return sb.ToString();
        }
        public string GetSelectListElyafOrani(int? yuzde)
        {
            var temp = elyafOrani.Value;
            //if (yuzde.HasValue)
            //{
            //    var entity = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, yuzde.ToString()) == 0);
            //    if (entity != null)
            //    {
            //        entity.Selected = true;
            //    }
            //}          
            //return temp;

            var sb = new System.Text.StringBuilder(150);
            sb.AppendLine(@"  <select class=""form-control select2 elyaf-orani"" name=""" + "ElyafOrani" + @"""> ");


            var loop = true;
            foreach (var item in temp)
            {
                if (loop && yuzde.HasValue  &&  string.CompareOrdinal(item.Value, yuzde.ToString()) == 0)
                {
                    loop = false;
                    sb.AppendLine(@"<option value=""" + item.Value + @""" selected>" + item.Text + "</option>");
                }
                else
                {
                    sb.AppendLine(@"<option value=""" + item.Value + @""">" + item.Text + "</option>");
                }

            }

            sb.AppendLine(@"  </select>");
            return sb.ToString();
        }

        private string GetSelectListIplikNoGuide(string value, string columnName)
        {
            var guide = GetZetaCodeNormalIplikService().GetIplikNoGuideByColumnName(columnName);
            List<SelectListItem> temp  = null;

            if (string.Equals(columnName, "NE", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Ne.ToString(), Value = x.Ne.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "NM", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Nm.ToString(), Value = x.Nm.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "DNY", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Dny.ToString(), Value = x.Dny.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "FL", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Fl.ToString(), Value = x.Fl.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "EA", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Ea.ToString(), Value = x.Ea.ToString() }).ToList();
            }


            //if (!string.IsNullOrWhiteSpace(value))
            //{
            //    var entity = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, value) == 0);
            //    if (entity != null)
            //    {
            //        entity.Selected = true;
            //    }
            //}

            var sb = new System.Text.StringBuilder(150);
            sb.AppendLine(@"  <select class=""form-control select2"" name=""" + columnName + @"""> ");
            if (string.IsNullOrWhiteSpace(value))
            {
                sb.AppendLine(@"<option value=""selected"">Please Select</option>");

            }

            var loop = true;
            foreach (var item in temp)
            {
                if (loop && !string.IsNullOrWhiteSpace(value) && string.CompareOrdinal(item.Value, value) == 0)
                {
                    loop = false;
                    sb.AppendLine(@"<option value=\""" + item.Value + @""" selected>" + item.Text + "</option>");
                }
                else
                {
                    sb.AppendLine(@"<option value=""" + item.Value + @""">" + item.Text + "</option>");
                }

            }

            sb.AppendLine(@"  </select>");
            var temssp= sb.ToString();
            return temssp;
        }

        public ActionResult GetBlueCompanyData(string companyId)
        {
            MyJsonResult jsonResult = new MyJsonResult();
            var company = GetCompanyService().GetCompanyCodeById(companyId);
            if (company != null)
            {
                var blueSequence = new Helezon.FollowMe.Entities.Models.SequenceBlueSiparisNo();
                blueSequence.BlueCompanyId = companyId;
                GetZetaCodeNormalIplikService().GetSequenceBlueSiparisNo(blueSequence);
                UnitOfWorkAsync.SaveChanges();
                jsonResult.Data = new { BlueCode = company.Code, SiparisNo = blueSequence.SiparisNo };
                jsonResult.SuccessMessage = "Sipariş No Hesaplandı";
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
            jsonResult.ErrorMessage = "Şirket Bulunamadı";
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeIplikKategoriler()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.IplikKategorileriNormal);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeUretimTeknolojisi()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.UretimTeknolojisi);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JSTreeRafyeriTurkiyeId()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.RafYeriIplikTurkiye);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeRafyeriYunanistanId()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.RafYeriIplikYunanistan);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeElyafCinsiveKalitesi()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.ElyafCinsiveKalitesi);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateIndex()
        {            
            return View();
        }

        // GET: ZetaCodeNormalIplik/Edit/5
        public ActionResult Edit(int? id,string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZetaCodeNormalIplikDto zetaCodeNormalIplik = GetZetaCodeNormalIplikService().GetZetaCodeNormalIplikById(id.Value, companyId);
            if (zetaCodeNormalIplik == null)
            {
                return HttpNotFound();
            }
            var model = new ZetaCodeNormalIplikVm();
            model.ZetaCodeNormalIplikDto = zetaCodeNormalIplik;
            FillCollections(model
                ,sirketId: zetaCodeNormalIplik.SirketId
                ,ulkeId:zetaCodeNormalIplik.Ulke
                ,pantoneRenkId: zetaCodeNormalIplik.PantoneId??0
                ,renkId: zetaCodeNormalIplik.Renkid??0
                ,uretimTeknolojitermId:zetaCodeNormalIplik.UretimTeknolojisiId??0);

            //model.ZetaCodeNormalIplikDto.ZetaCodeNormalIplikSirketName
            //    = model.Collections.Sirketler.FirstOrDefault(x => x.Value == model.ZetaCodeNormalIplikDto.SirketId)?.Text;

            return View(viewName:"Edit",model: model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeNormalIplikVm model)
        {
            model.ZetaCodeNormalIplikDto.Renkid = model.ZetaCodeNormalIplikDto.RenkIdFormat.AsInt();
            Action action = () =>
            {
                GetZetaCodeNormalIplikService().InsertOrUpdate(model.ZetaCodeNormalIplikDto);
            };

            if (HandleException(action))
                return RedirectToAction("Index");

            var zetaCodeNormalIplik = model.ZetaCodeNormalIplikDto;
            FillCollections(model
                , sirketId: zetaCodeNormalIplik.SirketId
                , ulkeId: zetaCodeNormalIplik.Ulke
                , pantoneRenkId: zetaCodeNormalIplik.PantoneId ?? 0
                , renkId: zetaCodeNormalIplik.Renkid ?? 0
                , uretimTeknolojitermId: zetaCodeNormalIplik.UretimTeknolojisiId ?? 0);

            return View(viewName: "Edit", model: model);
        }


        // POST: ZetaCodeNormalIplik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        protected bool HandleException(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                Failure = newException.Message;
            }
            catch (Exception ex)
            {
                Failure = ex.Message;
            }
            return false;
        }


        public ActionResult ZetaCodeNormalIplikCard(int? id,string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))           
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var normalIplik = GetZetaCodeNormalIplikService().GetAllZetaCodeNormalIplikler(id.Value, companyId).FirstOrDefault();
            if (normalIplik  == null)
            {
                return new HttpNotFoundResult();
            }

            var model = new ZetaCodeNormalIplikCardVm();
            model.ZetaCodeNormalIplik = normalIplik;



            var photoEditUrl = string.Format("/FileUpload/Edit?returnUrl={0}&entitytype={1}&entityId={2}&companyId={3}"
                                    , Url.Encode("/ZetaCodeNormalIplik/ZetaCodeNormalIplikCard?Id=" + normalIplik.Id + "&companyId=" + normalIplik.SirketId)
                                    , (int)EntityType.ZetaCodeNormalIplik
                                    , normalIplik.Id
                                    , normalIplik.SirketId);

            model.ZetaCodeNormalIplik.PictureEditUrl = photoEditUrl;
            model.ZetaCodeNormalIplik.PictureUrl = GetZetaCodeNormalIplikPictureService().GetZetaCodeNormalIplikPictureUrl(model.ZetaCodeNormalIplik.Id,model.ZetaCodeNormalIplik.SirketId);

            return View(model);
        }

        public ActionResult GetIplikKategoriPartial(string partialName) {

            if (string.IsNullOrWhiteSpace(partialName))
            {
                return new EmptyResult();
            }

            return PartialView(viewName: "~/Views/ZetaCodeNormalIplik/IplikKategoriPartials/" + partialName+".cshtml");
        }




        //// GET: ZetaCodeNormalIplik/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    if (zetaCodeNormalIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeNormalIplik);
        //}

        //// POST: ZetaCodeNormalIplik/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    db.ZetaCodeNormalIplik.Remove(zetaCodeNormalIplik);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    if (zetaCodeNormalIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeNormalIplik);
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
