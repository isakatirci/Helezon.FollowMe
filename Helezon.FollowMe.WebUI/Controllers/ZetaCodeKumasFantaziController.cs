using FollowMe.Web.Controllers;
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
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Card()
        {
            return View(new ZetaCodeKumasFantaziCardVm());
        }
    }
}