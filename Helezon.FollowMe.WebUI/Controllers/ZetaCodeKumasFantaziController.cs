using FollowMe.Web;
using FollowMe.Web.Controllers;
using Helezon.FollowMe.Service.ContainerDtos;
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
                var container = new KumasFantaziContainerDto();
                if (model.Kumaslar != null && model.Kumaslar.Any())
                {
                    for (int i = 0; i < model.Kumaslar.Count; i++)
                    {
                        if (model.Kumaslar[i] == null || string.IsNullOrWhiteSpace(model.Kumaslar[i].Id) || model.Kumaslar[i].Id.IndexOf('|') < 0)
                        {
                            break;
                        }
                        var arr = model.Kumaslar[i].Id.Split('|');                       
                        var id = arr[0].Trim();
                        var iplikTipi = arr[1].Trim();
                        if (string.Equals(iplikTipi, "FanteziKumas", StringComparison.InvariantCultureIgnoreCase))
                        {
                            container.KumasFanteziler.Add(new ZetaCodeKumasFanteziKumasFanteziDto {
                                KumasFanteziId = model.KumasFantazi.Id,
                                KumasOtherFanteziId = id.AsInt()

                            });
                        }
                        else if (string.Equals(iplikTipi, "NormalKumas", StringComparison.InvariantCultureIgnoreCase))
                        {
                            container.KumasOrmeDokumalar.Add(new ZetaCodeKumasFanteziKumasOrmeDokumaDto {
                                KumasFanteziId = model.KumasFantazi.Id,
                                KumasOrmeDokumaId = id.AsInt()
                            });
                        }

                    }
                }
                container.KumasMakine = model.Makine;
                container.YikamaTalimati = model.YikamaTalimati;
                container.KumasFantazi = model.KumasFantazi;
                //container.KumasFantezi3AdimIslemleri = model.KumasFantezi3AdimIslemleri;

                if (model.KumasFantezi3AdimIslemleri != null && model.KumasFantezi3AdimIslemleri.Any())
                {
                    for (int i = 0; i < model.KumasFantezi3AdimIslemleri.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(model.KumasFantezi3AdimIslemleri[i]._3AdimIslemlerId)
                        && string.IsNullOrWhiteSpace(model.KumasFantezi3AdimIslemleri[i].DesenKodu))
                        {
                            break;
                        }
                        container.KumasFantezi3AdimIslemleri.Add(new ZetaCodeKumasFantezi3AdimIslemleriDto
                        {
                            DesemRengi1= model.KumasFantezi3AdimIslemleri[i].DesemRengi1.Split('|')[0],
                            DesemRengi2 = model.KumasFantezi3AdimIslemleri[i].DesemRengi2.Split('|')[0],
                            DesemRengi3 = model.KumasFantezi3AdimIslemleri[i].DesemRengi3.Split('|')[0],
                            DesenKodu = model.KumasFantezi3AdimIslemleri[i].DesenKodu,
                            Id = model.KumasFantezi3AdimIslemleri[i].Id,
                            _3AdimIslemlerId = model.KumasFantezi3AdimIslemleri[i]._3AdimIslemlerId


                        });
                    }                   
                }

                GetKumasFanteziService().InsertOrUpdate(container);
            });

                if (result)
                    return RedirectToActionPermanent(actionName: "Index", controllerName: "ZetaCode");

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

            model.Collections.YikamaSekilleri = GetOthersService().GetYikamaSekilleri();

            model.AdimIslemleri = GetTermService().GetTermsByTaxonomyId((int)TaxonomyType.UcuncuAdimIslemleri);

            if (!model.KumasFantezi3AdimIslemleri.Any())
            {
                model.KumasFantezi3AdimIslemleri.Add(new ZetaCodeKumasFantezi3AdimIslemleriDto());
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
            model.Collections.OrmeDokumaKumaslar = GetKumasOrmeDokumaService().GetZetaCodeIsimler(model.KumasFantazi.CompanyId).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCode + "," + x.UrunIsmi

            }).ToList();

            model.Collections.FanteziKumaslar = GetKumasFanteziService().GetZetaCodeIsimler(model.KumasFantazi.CompanyId).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCode + "," + x.UrunIsmi

            }).ToList();
            model.Collections.Ulkeler = temp;

            //


            if (model.ZetaCodeKumasMakine == null)
            {
                model.ZetaCodeKumasMakine = new ZetaCodeKumasMakineDto();
            }


            if (model.YikamaTalimati == null)
            {
                model.YikamaTalimati = new ZetaCodeYikamaTalimatiDto();
            }

            var normalKumaslar = GetKumasOrmeDokumaService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");
            var fanteziKumaslar = GetKumasFanteziService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");

            model.Kumaslar.AddRange(model.KumasOrmeDokumalar.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "NormalKumas",
                ZetaCode = x.ZetaCode + ", " + x.Ad
            }));

            model.Kumaslar.AddRange(model.KumasFanteziler.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "FanteziKumas",
                ZetaCode = x.ZetaCode + ", " + x.Ad
            }));


            model.Collections.Kumaslar.AddRange(normalKumaslar.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "NormalKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            model.Collections.Kumaslar.AddRange(fanteziKumaslar.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "FanteziKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            if (!model.Kumaslar.Any())
            {
                model.Kumaslar.Add(new ZetaCodeDto());
            }
           
        }
    }
}