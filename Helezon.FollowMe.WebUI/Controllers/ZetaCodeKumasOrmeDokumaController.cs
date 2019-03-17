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
    public class ZetaCodeKumasOrmeDokumaController : BaseController
    {
        public ActionResult Create()
        {
            var model = new ZetaCodeKumasOrmeDokumaEditVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            var model = new ZetaCodeKumasOrmeDokumaEditVm();
            FillCollections(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeKumasOrmeDokumaEditVm model)
        {
            var result = HandleException(() =>
            {
                var container = new KumasOrmeDokumaContainerDto();
                if (model.Iplikler != null && model.Iplikler.Any())
                {
                    for (int i = 0; i < model.Iplikler.Count; i++)
                    {

                        if (string.IsNullOrWhiteSpace(model.Iplikler[i].Id))
                        {
                            continue;
                        }

                        var arr = model.Iplikler[i].Id.Split('|');
                        var id = arr[0].Trim();
                        var iplikTipi = arr[1].Trim();
                        //if (string.Equals(iplikTipi, "Normaliplik", StringComparison.InvariantCultureIgnoreCase))
                        //{
                        //    container.NormalIplikler.Add(new Service.DataTransferObjects.ZetaCodeNormalIplikDto()
                        //    {
                        //        Id = id.AsInt()
                        //    });
                        //}
                        //else if (string.Equals(iplikTipi, "Fanzteziiplik", StringComparison.InvariantCultureIgnoreCase))
                        //{
                        //    container.FanteziIplikler.Add(new Service.DataTransferObjects.ZetaCodeFanteziIplikDto()
                        //    {
                        //        Id = id.AsInt()
                        //    });
                        //}

                    }
                }
                container.KumasOrmeDokuma = model.KumasOrmeDokuma;
                container.KumasMakine = model.KumasMakine;
                container.YikamaTalimati = model.YikamaTalimati;           
                GetKumasOrmeDokumaService().InsertOrUpdate(container);
            });

            if (result)
                return RedirectToActionPermanent(actionName: "Index", controllerName: "ZetaCode");
            FillCollections(model);
            return View(model);
        }
        public ActionResult Card(int id,string companyId)
        {
            KumasOrmeDokumaContainerDto container = GetKumasOrmeDokumaService().GetCard(id,companyId);


            var view = new ZetaCodeKumasOrmeDokumaCardVm();
            view.Container = container;

            return View(model: view);
        }

        public void FillCollections(ZetaCodeKumasOrmeDokumaEditVm model
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

            //model.Collections.TupAcikEnler = GetOthersService().GetAllTupAcikEn();
            //model.Collections.Elastanlar = GetOthersService().GetAllElastan();


            //model.Collections.YikamaSekilleri = GetOthersService().GetYikamaSekilleri();

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


            //model.Collections.Sirketler
            //    = new SelectList(blueCompanies, "Id", "Name", sirketId);
            //var temp = GetOthersService().GetAllCountry().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, ulkeId?.ToString()) == 0);
            //if (ulke != null)
            //{
            //    ulke.Selected = true;
            //}

            model.Collections.PantoneRenkler = GetNormalIplikService().GetPantoneRenkler().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text =  x.PantoneKodu + " " + x.PantoneRengi
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

            //model.Collections.ModelYillari = GetOthersService().GetAllMakineModelYillari().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //model.Collections.Puslar = GetOthersService().GetAllMakinePusYillari().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //model.Collections.Finelar = GetOthersService().GetAllMakineFinelar().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //model.Collections.YedekFinelar = GetOthersService().GetAllMakineYedekFinelar().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //model.Collections.Sistemler = GetOthersService().GetAllMakineYedekSistemler().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //model.Collections.IgneSayisi = GetOthersService().GetAllMakineIgneSayisi().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();

            //var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, ulkeId?.ToString()) == 0);
            //if (ulke != null)
            //{
            //    ulke.Selected = true;
            //}


            //model.Collections.Ulkeler = temp;
            model.Collections.NormalIplikler = GetNormalIplikService().GetAllZetaCodeAndUrunIsmiOfNormalIplikler().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCodeFormat() + ", " + x.UrunIsmi
            }).ToList();
            model.Collections.FanteziIplikler = GetFanteziIplikService().GetAllZetaCodeAndUrunIsmiOfFantaziIplikler().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ZetaCodeFormat() + ", " + x.UrunIsmi
            }).ToList();

            //if (!model.KumasOrmeDokumaDto.ZetaCodeNormalIplik.Any())
            //{
            //    model.KumasOrmeDokumaDto.ZetaCodeNormalIplik.Add(new Service.DataTransferObjects.ZetaCodeNormalIplikDto());
            //}

            if (!model.ZetaCodeFanteziIplik.Any())
            {
                model.ZetaCodeFanteziIplik.Add(new Entities.Models.ZetaCodeFanteziIplik());
            }          

            if (model.KumasMakine == null)
            {
                model.KumasMakine = new Entities.Models.ZetaCodeKumasMakine();
            }

            if (model.YikamaTalimati == null)
            {
                model.YikamaTalimati = new Entities.Models.ZetaCodeYikamaTalimati();
            }

            if (model.Aksesuarlar == null)
            {
                model.Aksesuarlar = new List<Entities.Models.Term>();
            }


            var normalIplikler = GetNormalIplikService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");
            var fanteziIplikler = GetFanteziIplikService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");

            model.Iplikler.AddRange(model.ZetaCodeNormalIplik.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "Normaliplik",
                ZetaCode = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));

            model.Iplikler.AddRange(model.ZetaCodeFanteziIplik.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "Fanteziiplik",
                ZetaCode = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));


            model.Collections.Iplikler.AddRange(normalIplikler.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "Normaliplik",
                ZetaCode = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));

            model.Collections.Iplikler.AddRange(fanteziIplikler.Select(x => new ZetaCodeDto
            {
                Id = x.Id + "|" + "Fanteziiplik",
                ZetaCode = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));

            if (!model.Iplikler.Any())
            {
                model.Iplikler.Add(new ZetaCodeDto());
            }


        }
        private string ZetaCodeFormatli(int zetaCode)
        {
            return "Z" + zetaCode.ToString().PadLeft(4, '0');
        }
    }
}