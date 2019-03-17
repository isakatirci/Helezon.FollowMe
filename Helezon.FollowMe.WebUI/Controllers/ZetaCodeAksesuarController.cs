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
    public class ZetaCodeAksesuarController : BaseController
    {
        public ActionResult Create()
        {
            var model = new AksesuarEditVm();
            FillCollections(model);
            return View(viewName:"Edit",model: model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            var model = new AksesuarEditVm();
            FillCollections(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AksesuarEditVm model)
        {            

            var result = HandleException(() =>
            {
                var container = new AksesuarContainerDto();

                container.AksesuarKompozisyonlar = model.AksesuarKompozisyonlar;
                container.Aksesuar = model.Aksesuar;


                GetAksesuarService().InsertOrUpdate(container);
            });

            if (result)
                return RedirectToActionPermanent(actionName: "Index", controllerName: "ZetaCode");



            FillCollections(model);
            return View(model);
        }


        public ActionResult Card(int id, string companyId)
        {
            var card = GetAksesuarService().GetCard(id: id, company: companyId);         
            var view = new ZetaCodeAksesuarCardVm();
            view.Aksesuar = card.Aksesuar;
            view.AksesuarKompozisyonlar = card.AksesuarKompozisyonlar;
            view.PantoneRenk = card.PantoneRenk;
            view.Renk = card.Renk;
            view.RafyeriTurkiye = card.RafyeriTurkiye;
            view.RafyeriYunanistan = card.RafyeriYunanistan;
            view.Company = card.Company;
            view.PictureUrl = card.PictureUrl;
            return View(model: view);
        }
        public void FillCollections(AksesuarEditVm model
                        , string sirketId = ""
                        , int? ulkeId = null)
        {
            var blueCompanies = GetCompanyService().GetParentCompanyIdAndNames(1, sirketId);



            model.Collections.Sirketler
                = new SelectList(blueCompanies, "Id", "Name", sirketId);
            //var temp = GetOthersService().GetAllCountry().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id }).ToList();
            //var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, ulkeId?.ToString()) == 0);
            //if (ulke != null)
            //{
            //    ulke.Selected = true;
            //}

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

            if (!model.AksesuarKompozisyonlar.Any())
            {
                model.AksesuarKompozisyonlar.Add(new Entities.Models.ZetaCodeAksesuarKompozisyon());
            }


            model.Collections.UrunKompozisyonlar = GetTermService().GetTermsByTaxonomyId((int)TaxonomyType.AksesuarUrunKompozisyonu);





            //model.Collections.Ulkeler = temp;

        }
    }
}