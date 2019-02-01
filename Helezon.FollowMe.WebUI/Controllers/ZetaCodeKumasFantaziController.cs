using FollowMe.Web;
using FollowMe.Web.Controllers;
using Helezon.FollowMe.Service.DataTransferObjects;
using Helezon.FollowMe.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{
    public class ZetaCodeKumasFantaziController : BaseController
    {
        public ActionResult Create()
        {
            var model = new KumasFanteziEditVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            var model = new KumasFanteziEditVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KumasFanteziEditVm model)
        {
            var result = HandleException(() =>
            {
                GetKumasFanteziService().InsertOrUpdate(model.KumasFantaziDto);
            });

            if (result)            
                return View(viewName:"Index");
            
            FillCollections(model);
            return View(model);
        }

        public ActionResult Card()
        {

            var normal = new ZetaCodeKumasFantaziCardVm();
            //normal.ParentUrunKategoriler.Add(new TermDto());
            //normal.ParentUrunKategoriler.Add(new TermDto());
            //normal.ParentUrunKategoriler.Add(new TermDto());
            //normal.ParentUrunKategoriler.Add(new TermDto());
            //normal.ParentUrunKategoriler.Add(new TermDto());

            return View(normal);
        }
        public void FillCollections(KumasFanteziEditVm model
                             , string sirketId = ""
                             , int? ulkeId = null)
        {
            var blueCompanies = GetCompanyService().GetParentCompanyIdAndNames(1, sirketId);

            model.Collections.OrguTipleri = new List<SelectListItem>();
            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariOrmeDuz).ToString(),
                Text = "Örme Düz"
            });

            model.Collections.TupAcikEnler = GetOthersService().GetAllTupAcikEn();
            model.Collections.Elastanlar = GetOthersService().GetAllElastan();

            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariOrmeYuvarlak).ToString(),
                Text = "Örme Yuvarlak"
            });
            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariOrmeCozgulu).ToString(),
                Text = "Örme Çözgülü"
            });
            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariDokuma).ToString(),
                Text = "Dokuma"
            });
            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariNonwoven).ToString(),
                Text = "Nonwoven"
            });


            model.Collections.Sirketler
                = new SelectList(blueCompanies, "Id", "Name", sirketId);
            var temp = GetOthersService().GetAllCountry().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, ulkeId?.ToString()) == 0);
            if (ulke != null)
            {
                ulke.Selected = true;
            }

            model.Collections.PantoneRenkler = GetNormalIplikService().GetPantoneRenkler().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.PantoneKodu + " " + x.PantoneRengi
            }).ToList();

            model.Collections.Renkler = GetNormalIplikService().GetRenkler(2).Select(x => new SelectListItem
            {
                Value = string.Format("{0}|{1}", x.Id, x.HtmlKod ?? string.Empty),
                Text = x.Ad
            }).ToList();

            model.Collections.KumasGoruntuleri = GetTermService().GetTermsByTaxonomyId((int)TaxonomyType.KumasGoruntuler)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

            model.Collections.YikamaSekilleri = GetOthersService().GetYikamaSekilleri().Select(x => new SelectListItem
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();

            model.AdimIslemleri = new SelectList(GetTermService().GetTermsByTaxonomyId((int)TaxonomyType.UcuncuAdimIslemleri), dataTextField: "Name", dataValueField: "Id");

            if (!model.KumasFantaziDto.ZetaCodeKumasFantezi3AdimIslemleri.Any())
            {
                model.KumasFantaziDto.ZetaCodeKumasFantezi3AdimIslemleri.Add(new ZetaCodeKumasFantezi3AdimIslemleriDto());
            }

            model.OrmeDokumaKumaslar = new List<SelectListItem>();
            if (!model.OrmeDokumaKumaslar.Any())
            {
                model.OrmeDokumaKumaslar.Add(new SelectListItem());
            }
          
            model.FanteziKumaslar = new List<SelectListItem>();
            if (!model.FanteziKumaslar.Any())
            {
                model.FanteziKumaslar.Add(new SelectListItem());
            }


            //model.Collections.FanteziKumaslar=GetKumasFanteziService().
            model.Collections.OrmeDokumaKumaslar = GetKumasOrmeDokumaService().GetZetaCodeIsimler(model.KumasFantaziDto.CompanyId).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCode + "," + x.UrunIsmi

            }).ToList();

            model.Collections.FanteziKumaslar = GetKumasFanteziService().GetZetaCodeIsimler(model.KumasFantaziDto.CompanyId).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCode + "," + x.UrunIsmi

            }).ToList();
            model.Collections.Ulkeler = temp;    

        }
    }
}