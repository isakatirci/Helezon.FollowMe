using FollowMe.Web;
using FollowMe.Web.Controllers;
using Helezon.FollowMe.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{


    public class ZetaCodeHazirGiyimController : BaseController
    {
        public ActionResult Create()
        {
            var model = new HazirGiyimEditVm();
            FillCollections(model);
            return View(viewName: "Edit", model: model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            var model = new HazirGiyimEditVm();
            FillCollections(model);
            return View(model);
        }
        public ActionResult Card()
        {
            return View(new ZetaCodeKumasOrmeDokumaCardVm());
        }
        public void FillCollections(HazirGiyimEditVm model
                        , string sirketId = ""
                        , int? ulkeId = null)
        {
            if (model.HazirGiyimDto.BedenOlculeri == null || !model.HazirGiyimDto.BedenOlculeri.Any())
            {
                model.HazirGiyimDto.BedenOlculeri = new List<Service.DataTransferObjects.BedenOlculeriDto>();
                model.HazirGiyimDto.BedenOlculeri.Add(new Service.DataTransferObjects.BedenOlculeriDto { });
                model.HazirGiyimDto.BedenOlculeri.Add(new Service.DataTransferObjects.BedenOlculeriDto { });
                model.HazirGiyimDto.BedenOlculeri.Add(new Service.DataTransferObjects.BedenOlculeriDto { });
                model.HazirGiyimDto.BedenOlculeri.Add(new Service.DataTransferObjects.BedenOlculeriDto { });
                model.HazirGiyimDto.BedenOlculeri.Add(new Service.DataTransferObjects.BedenOlculeriDto { });
            }



            var blueCompanies = GetCompanyService().GetParentCompanyIdAndNames(1, sirketId);

            model.Collections.BedenKalipIsimleri = GetOthersService().GetBedenKaliplari().Select(x => new SelectListItem
            {
                Value = x.Id,
                Text = x.Name
            }).ToList(); ;

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


            model.Collections.YikamaSekilleri = GetOthersService().GetYikamaSekilleri().Select(x => new SelectListItem
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();

            model.Collections.BaskiGoruntuler = GetTermService().GetTermsByTaxonomyId((int)TaxonomyType.BaskiGoruntuler).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var normalKumaslar = GetKumasOrmeDokumaService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");
            var fanteziKumaslar = GetKumasFanteziService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");
            var aksesuarlar = GetAksesuarService().GetZetaCodeIsimler("CompanyId ile bu metot çağırılmalı");

            model.Kumaslar.AddRange(model.HazirGiyimDto.ZetaCodeKumasOrmeDokuma.Select(x => new ZetaCodeVm
            {
                Id = x.Id + "|" + "NormalKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            model.Kumaslar.AddRange(model.HazirGiyimDto.ZetaCodeKumasFantazi.Select(x => new ZetaCodeVm
            {
                Id = x.Id + "|" + "FanteziKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            model.Aksesuarlar.AddRange(model.HazirGiyimDto.ZetaCodeAksesuar.Select(x => new ZetaCodeVm
            {
                Id = x.Id.ToString(),
                ZetaCode = x.ZetaCode + ", " + x.UrunKompozisyonu
            }));


            model.Collections.Kumaslar.AddRange(normalKumaslar.Select(x => new ZetaCodeVm
            {
                Id = x.Id + "|" + "NormalKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            model.Collections.Kumaslar.AddRange(fanteziKumaslar.Select(x => new ZetaCodeVm
            {
                Id = x.Id + "|" + "FanteziKumas",
                ZetaCode = x.ZetaCode + ", " + x.UrunIsmi
            }));

            model.Collections.Aksesuarlar.AddRange(aksesuarlar.Select(x => new ZetaCodeVm
            {
                Id = x.Id.ToString(),
                ZetaCode = x.ZetaCode + ", " + x.UrunKompozisyonu
            }));

            model.Collections.Ulkeler = temp;

            if (!model.Kumaslar.Any())
            {
                model.Kumaslar.Add(new ZetaCodeVm());
            }

            if (!model.Aksesuarlar.Any())
            {
                model.Aksesuarlar.Add(new ZetaCodeVm());
            }

        }
    }
}