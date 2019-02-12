using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.ContainerDtos;
using Helezon.FollowMe.Service.DataTransferObjects;
using Helezon.FollowMe.WebUI.Code;
using Helezon.FollowMe.WebUI.Models.ViewModels;

namespace Helezon.FollowMe.WebUI.Controllers
{


    public class ZetaCodeNormalIplikController : BaseController
    {
        private static Lazy<List<SelectListItem>> elyafOrani = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(new SelectListItem {
                    Text = i + "%",
                    Value = i.ToString()
                });
            }
            return list;
        });

        //nokta, kırçıl, flam
        //mesafe :0,10cm ile 20cm (0,01 aratacak)
        //uzunluk :0,01cm ile 5cm (0,01 aratacak)


      



        // GET: ZetaCodeNormalIplik

        public ActionResult Create(string operation)
        {
            ZetaCodeNormalIplikVm model = new ZetaCodeNormalIplikVm();
            if (operation.IsNullOrWhiteSpace().Not())
            {
                if (string.Equals(operation, "masterbluesiparis", StringComparison.InvariantCulture))
                {
                    model.NormalIplik = GetNormalIplikService().GetZetaCodeNormalIplikByMaster();
                }
            }         
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }
        public ActionResult Index()
        {
            var list = GetNormalIplikService().GetAllNormalIplikler(include:true);
            //var zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Include(z => z.PantoneRengi).Include(z => z.Renk);
            var model = new List<ZetaCodeNormalIplikVm>();
            foreach (var item in list)
            {
                model.Add(new ZetaCodeNormalIplikVm {
                    NormalIplik = item
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
            model.Collections.PantoneRenkleri = new SelectList(GetNormalIplikService().GetPantoneRenkler()
                .Select(x => new { Id = x.Id.ToString(), PantoneKodu = x.PantoneKodu + " " + x.PantoneRengi }), "Id", "PantoneKodu", pantoneRenkId.ToString());
            model.Renkler = new GetSelectListWithId(GetSelectListRenkler);
            model.Collections.UretimTeknolojileri = new SelectList(GetTermService().GetTermsByTaxonomyId(31), "Id", "Name", uretimTeknolojitermId);
            model.NE = new IplikNoGuideMethod(GetSelectListNE);
            model.NM = new IplikNoGuideMethod(GetSelectListNM);
            model.DYN = new IplikNoGuideMethod(GetSelectListDYN);
            model.FL = new IplikNoGuideMethod(GetSelectListFL);
            model.EA = new IplikNoGuideMethod(GetSelectListEA);
            model.ElyafOrani = new ElyafOraniMethod(GetSelectListElyafOrani);


            if (!model.IplikNolar.Any())
            {
                model.IplikNolar.Add(new IplikNoDto());
            }


        }    

        public string GetSelectListNE(string value)
        {
            return GetSelectListIplikNoGuide(value, "Ne");
        }
        public string GetSelectListNM(string value)
        {
            return GetSelectListIplikNoGuide(value, "Nm");
        }
        public string GetSelectListDYN(string value)
        {
            return GetSelectListIplikNoGuide(value, "Dny");
        }
        public string GetSelectListFL(string value)
        {
            return GetSelectListIplikNoGuide(value, "Fl");
        }
        public string GetSelectListEA(string value)
        {
            return GetSelectListIplikNoGuide(value, "Ea");
        }

        public string GetSelectListRenkler(int? id)
        {

            //https://medium.com/@ulkutokmak/asp-net-mvc-html-helpers-484ae121e383
            var renkler = GetNormalIplikService().GetRenkler(2).Select(x=> new SelectListItem {
                Value = string.Format("{0}|{1}",x.Id,x.HtmlKod??string.Empty),
                Text= x.Ad            });

            var sb = new StringBuilder(150);
            sb.AppendLine(@"<select class=""form-control select2"" onchange=""setHtmlColorCode($(this))"" id=""NormalIplik_RenkIdFormat"" name=""NormalIplik.RenkIdFormat"">");
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
                    sb.AppendLine(@"<option value=""" + item.Value + @""" selected> " + item.Text + " </option>");
                }
                else
                {
                    sb.AppendLine(@"<option value=""" + item.Value + @"""> " + item.Text + " </option>");
                }

            }

            sb.AppendLine(@"  </select>");
            return sb.ToString();
        }
        public string GetSelectListElyafOrani(int? yuzde)
        {
            var temp = elyafOrani.Value;
            var sb = new System.Text.StringBuilder(150);
            sb.AppendLine("<select class=\"form-control select2 elyaf-orani\" name=\"ElyafOrani\">");

            if (!yuzde.HasValue)
            {
                sb.AppendLine("<option value=\"\" selected> Please Select </option>");
            }

            var loop = true;
            var str = yuzde.HasValue ? yuzde.ToString() : string.Empty;
            foreach (var item in temp)
            {
                if (loop && yuzde.HasValue && string.CompareOrdinal(item.Value, str) == 0)
                {
                    loop = false;
                    sb.AppendFormat("<option value=\"{0}\" selected> {1} </option>", item.Value, item.Text);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\"> {1} </option>", item.Value, item.Text);
                }

            }

            sb.AppendLine(@"  </select>");
            return sb.ToString();
        }

        private string GetSelectListIplikNoGuide(string value, string columnName)
        {
            var guide = GetNormalIplikService().GetIplikNoGuideByColumnName(columnName);
            List<SelectListItem> temp  = null;

            if (string.Equals(columnName, "Ne", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Ne.ToString(), Value = x.Ne.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "Nm", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Nm.ToString(), Value = x.Nm.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "Dny", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Dny.ToString(), Value = x.Dny.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "Fl", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Fl.ToString(), Value = x.Fl.ToString() }).ToList();
            }
            //else if (string.Equals(columnName, "Ea", StringComparison.OrdinalIgnoreCase))
            //{
            //    temp = guide.Select(x => new SelectListItem() { Text = x.Ea.ToString(), Value = x.Ea.ToString() }).ToList();
            //}


            //if (!string.IsNullOrWhiteSpace(value))
            //{
            //    var entity = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, value) == 0);
            //    if (entity != null)
            //    {
            //        entity.Selected = true;
            //    }
            //}

            var sb = new System.Text.StringBuilder(150);
            sb.AppendFormat("<select class=\"form-control select2\" name=\"{0}\" >", "NormalIplik." + columnName);
            if (string.IsNullOrWhiteSpace(value))
            {
                sb.AppendLine("<option value=\"\" selected> Please Select </option>");
            }
            var loop = true;
            foreach (var item in temp)
            {
                if (loop && !string.IsNullOrWhiteSpace(value) && string.CompareOrdinal(item.Value, value) == 0)
                {
                    loop = false;
                    sb.AppendFormat("<option value=\"{0}\" selected> {1} </option>", item.Value, item.Text);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\"> {1} </option>", item.Value, item.Text);
                }

            }

            sb.AppendLine("</select>");
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
                GetNormalIplikService().GetSequenceBlueSiparisNo(blueSequence);
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

        public ActionResult JSTreeIplikKategorilerFantezi()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.IplikKategorileriFantazi);
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
        public ActionResult JSTreeBoyaIslemleri()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.BoyahaneIslemleri);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeMakineMarkalar()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.MakineDetaylariMakineMarkasi);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeMakineModeller()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.MakineDetaylariMakineModeli);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeAksesuarlar()
        {
            //               var jsTreeDataDtos = (from tx in termTaxonomy
            //                                      join te in term on tx.TermId equals te.Id
            //                                      where tx.TaxonomyId == taxonomyId && te.TaxonomyId == taxonomyId && tx.CompanyId == companyId && te.CompanyId == companyId
            //                                      select new JsTreeDataDto
            //                                      {
            //                                          id = te.Id.ToString(),
            //                                          text = te.Name,
            //                                          parent = tx.Parent.HasValue && tx.Parent == 0 ? "#" : tx.Parent.ToString(),
            //                                          state = new { disabled = te.Disabled }
            //                                      }).ToList();


            var data = GetOthersService().GetAllAksesuar().Select(x=> new JsTreeDataDto
            {
                id = x.Id.ToString(),
                text = x.Name,
                parent =  "#" 
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /*************************************************************************/
        public ActionResult JSTreeOrguDetaylariOrmeCozgulu()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.OrguDetaylariOrmeCozgulu);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JSTreeOrguDetaylariOrmeDuz()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.OrguDetaylariOrmeDuz);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JSTreeOrguDetaylariOrmeYuvarlak()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.OrguDetaylariOrmeYuvarlak);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JSTreeOrguDetaylariDokuma()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.OrguDetaylariDokuma);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeOrguDetaylariNonwoven()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.OrguDetaylariNonwoven);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        /**************************************************************************/
        public ActionResult JSTreeElyafCinsiveKalitesi()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.ElyafCinsiveKalitesi);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeKoleksiyonKategorileri()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.KoleksiyonKategorileri);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeHazirGiyimKategorileri()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.HazirGiyimKategorileri);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeKumasGoruntuleri()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.KumasGoruntuler);
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
            ZetaCodeNormalIplikDto zetaCodeNormalIplik = GetNormalIplikService().GetZetaCodeNormalIplikById(id.Value, companyId);
            if (zetaCodeNormalIplik == null)
            {
                return HttpNotFound();
            }
            var model = new ZetaCodeNormalIplikVm();
            model.NormalIplik = zetaCodeNormalIplik;
            FillCollections(model
                ,sirketId: zetaCodeNormalIplik.SirketId
                ,ulkeId:zetaCodeNormalIplik.UlkeId
                ,pantoneRenkId: zetaCodeNormalIplik.PantoneId??0
                ,renkId: zetaCodeNormalIplik.Renkid??0
                ,uretimTeknolojitermId:zetaCodeNormalIplik.UretimTeknolojisiId??0);

            //model.ZetaCodeNormalIplikDto.ZetaCodeNormalIplikSirketName
            //    = model.Collections.Sirketler.FirstOrDefault(x => x.Value == model.ZetaCodeNormalIplikDto.SirketId)?.Text;

            return View(viewName:"Edit",model: model);
        }
        private decimal MyNumberParse(string value)
        {
            try
            {
                return decimal.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

                return decimal.Zero;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeNormalIplikVm model)
        {
            var container = new NormalIplikContainerDto();
            model.NormalIplik.Renkid = model.NormalIplik.RenkIdFormat.AsInt();
            container.NormalIplik = model.NormalIplik;
            container.Degrede = model.Degrede;
            container.Flam = model.Flam;
            container.Sim = model.Sim;
            container.Kircili = model.Kircili;
            container.Nopeli = model.Nopeli;
            container.Krep = model.Krep;
            container.Company = model.Company;
            container.IplikNolar = model.IplikNolar;

            Action action = () =>
            {
                GetNormalIplikService().InsertOrUpdate(container);
            };

            if (HandleException(action))
                return RedirectToAction(controllerName:"ZetaCode",actionName: "Index");

            var zetaCodeNormalIplik = model.NormalIplik;
            FillCollections(model
                , sirketId: zetaCodeNormalIplik.SirketId
                , ulkeId: zetaCodeNormalIplik.UlkeId
                , pantoneRenkId: zetaCodeNormalIplik.PantoneId ?? 0
                , renkId: zetaCodeNormalIplik.Renkid ?? 0
                , uretimTeknolojitermId: zetaCodeNormalIplik.UretimTeknolojisiId ?? 0);

            return View(viewName: "Edit", model: model);
        }


        // POST: ZetaCodeNormalIplik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



        private string MyToString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return obj.ToString();
        }

        private List<Tuple<string, string>> GetPropertiesWithTheirValues(object obj)
        {
            if (obj ==null)
            {
                return new List<Tuple<string, string>>();
            }
            return obj.GetType()
                 .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                 .Select(a => Tuple.Create(a.Name, MyToString(a.GetValue(obj, null)))).ToList();
        }


        public ActionResult ZetaCodeNormalIplikCard(int? id,string companyId)
        {
            if (!id.HasValue || id < 1 || string.IsNullOrWhiteSpace(companyId))           
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var normalIplik = GetNormalIplikService().GetAllNormalIplikler(id.Value, companyId,include:true).FirstOrDefault();
            if (normalIplik  == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new ZetaCodeNormalIplikCardVm();



            //if (normalIplik.IplikKategoriFlam != null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriFlam);          
            //}
            //else if (normalIplik.IplikKategoriKircili!= null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriKircili);
               
            //}
            //else if (normalIplik.IplikKategoriKrep != null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriKrep);
               
            //}
            //else if (normalIplik.IplikKategoriNopeli != null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriNopeli);
               
            //}
            //else if (normalIplik.IplikKategoriSim != null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriSim);
            //}
            //else if (normalIplik.IplikKategoriDegrede != null)
            //{
            //    model.IplikKategoriDetay = GetPropertiesWithTheirValues(normalIplik.IplikKategoriDegrede);

            //}

            model.ZetaCodeNormalIplikDto = normalIplik;
            model.ParentIplikCategories = GetTermService().GetAllParentsById(normalIplik.IplikKategosiId);
            model.ParentIplikCategories.Reverse();
   

            var photoEditUrl = string.Format("/FileUpload/Edit?returnUrl={0}&entitytype={1}&entityId={2}&companyId={3}"
                                    , Url.Encode("/ZetaCodeNormalIplik/ZetaCodeNormalIplikCard?Id=" + normalIplik.Id + "&companyId=" + normalIplik.SirketId)
                                    , (int)EntityType.ZetaCodeNormalIplik
                                    , normalIplik.Id
                                    , normalIplik.SirketId);

            model.ZetaCodeNormalIplikDto.PictureEditUrl = photoEditUrl;
            model.ZetaCodeNormalIplikDto.PictureUrl = GetZetaCodeNormalIplikPictureService().GetZetaCodeNormalIplikPictureUrl(model.ZetaCodeNormalIplikDto.Id,model.ZetaCodeNormalIplikDto.SirketId);

            return View(model);
        }

        private static Lazy<List<SelectListItem>> mesafe = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (decimal i = 0.1m; i <= 20; i = i + 0.01m)
            {
                list.Add(new SelectListItem
                {
                    Text = i + " cm",
                    Value = i.ToString("N2", CultureInfo.InvariantCulture)
                });
            }
            return list;
        });

        private static Lazy<List<SelectListItem>> uzunluk = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (decimal i = 0.01m; i <= 5; i = i + 0.01m)
            {
                list.Add(new SelectListItem
                {
                    Text = i + " cm",
                    Value = i.ToString("N2", CultureInfo.InvariantCulture)
                });
            }
            return list;
        });


        //
        //yükseklik:0,01cm ile 5cm (0,01 aratacak)
        //sim kesim boyutu:0,01cm ile 1cm (0,01 aratacak)
        //krem tur sayısı: 80 T/D ile 3000 T/D (1er 1 er artacak) her rakamın yanında T/D yazacak

        private static Lazy<List<SelectListItem>> yukseklik = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (decimal i = 0.01m; i <= 5; i = i + 0.01m)
            {
                list.Add(new SelectListItem
                {
                    Text = i + " cm",
                    Value = i.ToString("N2", CultureInfo.InvariantCulture)
                });
            }
            return list;
        });

        private static Lazy<List<SelectListItem>> simKesimBoyutu = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (decimal i = 0.01m; i <= 1; i = i + 0.01m)
            {
                list.Add(new SelectListItem
                {
                    Text = i + " cm",
                    Value = i.ToString("N2", CultureInfo.InvariantCulture)
                });
            }
            return list;
        });

        private static Lazy<List<SelectListItem>> krepTurSayisi = new Lazy<List<SelectListItem>>(() => {

            var list = new List<SelectListItem>();

            for (int i = 80; i <= 3000; i = i + 1)
            {
                list.Add(new SelectListItem
                {
                    Text = i + " T/D",
                    Value = i.ToString()
                });
            }
            return list;
        });

        public ActionResult GetIplikKategoriPartial(string partialName,int? normalIplikId,string sirketId) {

            if (string.IsNullOrWhiteSpace(partialName))
            {
                return new EmptyResult();
            }

            object model = null;

            //var normalIplik = GetZetaCodeNormalIplikService().GetZetaCodeNormalIplikById(normalIplikId, sirketId, includeIplikNo: false);

            if (partialName == "flam")
            {
                //FLAM
                //public decimal FlamlarArasindakiMesafe { get; set; } // FlamlarArasindakiMesafe
                //public decimal FlamUzunlugu { get; set; } // FlamUzunlugu
                //public decimal FlamYuksekligi { get; set; } // FlamYuksekligi
                var flam = GetNormalIplikService().GetIplikKategoriFlamByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.Mesafe = new SelectList(mesafe.Value, "Value", "Text", flam?.FlamlarArasindakiMesafe);
                ViewBag.Uzunluk = new SelectList(uzunluk.Value, "Value", "Text", flam?.FlamUzunlugu);
                ViewBag.Yukseklik = new SelectList(yukseklik.Value, "Value", "Text", flam?.FlamYuksekligi);
                model = flam;
            }
            else if (partialName == "degrede")
            {
                //DEGREDE IPLIK
               var degrede = GetNormalIplikService().GetIplikKategoriDegredeByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.BoyaYonu = new SelectList(GetOthersService().GetAllBoyaYonu(), "Id", "Name", degrede?.BoyaYonu);
                ViewBag.BoyaTipi = new SelectList(GetOthersService().GetAllBoyaTipi(), "Id", "Name", degrede?.BoyaTipi);
                model = degrede;
            }
            else if (partialName == "kircili")
            {
                //KIRCILI
                // public string KircillarArasiMesafe { get; set; } // KircillarArasiMesafe (length: 10)
                // public string KircilUzunlugu { get; set; } // KircilUzunlugu (length: 10)
                // public string KircilYuksekligi { get; set; } // KircilYuksekligi (length: 10)
               var kircili = GetNormalIplikService().GetIplikKategoriKirciliByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.Mesafe = new SelectList(mesafe.Value, "Value", "Text", kircili?.KircillarArasiMesafe);
                ViewBag.Uzunluk = new SelectList(uzunluk.Value, "Value", "Text", kircili?.KircilUzunlugu);
                ViewBag.Yukseklik = new SelectList(yukseklik.Value, "Value", "Text", kircili?.KircilYuksekligi);
                model = kircili;

            }
            else if (partialName == "nopeli")
            {
                //NOPELI IPLIK
                //public string NoktalarArasiMesafe { get; set; } // NoktalarArasiMesafe (length: 10)
                //public string NoktaUzunlugu { get; set; } // NoktaUzunlugu (length: 10)
                //public string NoktaYuksekligi { get; set; } // NoktaYuksekligi (length: 10)

                var nopeli = GetNormalIplikService().GetIplikKategoriNopeliByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.Mesafe = new SelectList(mesafe.Value, "Value", "Text", nopeli?.NoktalarArasiMesafe);
                ViewBag.Uzunluk = new SelectList(uzunluk.Value, "Value", "Text", nopeli?.NoktaUzunlugu);
                ViewBag.Yukseklik = new SelectList(yukseklik.Value, "Value", "Text", nopeli?.NoktaYuksekligi);
                model = nopeli;

            }
            else if (partialName == "sim")
            {
                //SIM IPLIK
                //public string SimKesimBoyutu { get; set; } // SimKesimBoyutu (length: 200)
                var sim = GetNormalIplikService().GetIplikKategoriSimByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.SimKesimBoyutu = new SelectList(simKesimBoyutu.Value, "Value", "Text", sim?.SimKesimBoyutu);
                model = sim;
            }
            else if (partialName == "krep")
            {
                //KREP IPLIK
                //public string TurSayisi { get; set; } // TurSayisi (length: 10)
                var krep = GetNormalIplikService().GetIplikKategoriKrepByZetaCodeNormalIplikId(normalIplikId);
                ViewBag.TurSayisi = new SelectList(krepTurSayisi.Value, "Value", "Text", krep?.TurSayisi);
                model = krep;
            }
            return PartialView(viewName: "~/Views/ZetaCodeNormalIplik/IplikKategoriPartials/" + partialName+".cshtml",model: model);
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


//      if (model.Degrede != null)
//            {
//                model.Degrede.BoyamaProsesi = MyNumberParse(model.Degrede.BoyamaProsesiFormat);
//            }
//            if (model.Flam != null)
//            {
//                model.Flam.FlamlarArasindakiMesafe = MyNumberParse(model.Flam.FlamlarArasindakiMesafeFormat);
//                model.Flam.FlamUzunlugu = MyNumberParse(model.Flam.FlamUzunluguFormat);
//                model.Flam.FlamYuksekligi = MyNumberParse(model.Flam.FlamYuksekligiFormat);
//            }
//            if (model.Kircili != null)
//            {
//                model.Kircili.KircillarArasiMesafe = MyNumberParse(model.Kircili.KircillarArasiMesafeFormat);
//                model.Kircili.KircilUzunlugu = MyNumberParse(model.Kircili.KircilUzunluguFormat);
//                model.Kircili.KircilYuksekligi = MyNumberParse(model.Kircili.KircilYuksekligiFormat);
//            }
//            if (model.Krep != null)
//            {
//                model.Krep.TurSayisi = (int)MyNumberParse(model.Krep.TurSayisiFormat);
//
//            }
//            if (model.Nopeli != null)
//            {
//                model.Nopeli.NoktalarArasiMesafe = MyNumberParse(model.Nopeli.NoktalarArasiMesafeFormat);
//                model.Nopeli.NoktaUzunlugu = MyNumberParse(model.Nopeli.NoktaUzunluguFormat);
//                model.Nopeli.NoktaYuksekligi = MyNumberParse(model.Nopeli.NoktaYuksekligiFormat);
//            }
//
//            if (model.Sim != null)
//            {
//                model.Sim.SimKesimBoyutu = MyNumberParse(model.Sim.SimKesimBoyutuFormat);
//
//            }
