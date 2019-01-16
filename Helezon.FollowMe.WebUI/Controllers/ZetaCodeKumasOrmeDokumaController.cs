using FollowMe.Web.Controllers;
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
            return View();
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
        public ActionResult Card()
        {
            return View(new ZetaCodeKumasOrmeDokumaCardVm());
        }

        public void FillCollections(ZetaCodeKumasOrmeDokumaEditVm model
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


            model.Collections.Ulkeler = temp;
            //model.Collections.NormalIplikler = GetNormalIplikService().GetAllZetaCodeAndUrunIsmiOfNormalIplikler().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.ZetaCodeFormat() + ", " + x.UrunIsmi
            //}).ToList();

        }
    }
}