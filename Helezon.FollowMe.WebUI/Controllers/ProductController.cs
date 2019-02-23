using FollowMe.Web.Controllers;
using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{
    //Servisten gelen model class ların sonuna dto ekle!
  
    public class ProductVm
    {
        public Product Product { get; set; }
        public ProductType ProductType { get; set; }    
        public string RenkIdHtmlKod { get; set; }
        public ProductVmCollections Collections { get; set; }
        public List<IplikNoDto> IplikNolar { get; set; }
        public Term IplikKategosi { get; set; }
        public Term RafyeriYunanistan { get; set; }
        public Term RafyeriTurkiye { get; set; }
        public Company Company { get; set; }
        public MyNameValueDto Ulke { get; set; }
        public Renk Renk { get; set; }
        public IplikKategoriDegrede Degrede { get; set; }//IplikKategoriFlam
        public IplikKategoriFlam Flam { get; set; }
        public IplikKategoriKircili Kircili { get; set; }
        public IplikKategoriKrep Krep { get; set; }
        public IplikKategoriNopeli Nopeli { get; set; }
        public IplikKategoriSim Sim { get; set; }

        /************************************************************************************/
        public List<MyNameValueDto> KarsimdakiIplikler { get; set; }
        public PantoneRenk PantoneRenk { get; set; }

        public ProductVm()
        {
            KarsimdakiIplikler = new List<MyNameValueDto>();
            Product = new Product();
            Renk = new Renk();
            PantoneRenk = new PantoneRenk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Collections = new ProductVmCollections();
            Company = new Company();
            IplikNolar = new List<IplikNoDto>();
            Ulke = new MyNameValueDto();
            IplikKategosi = new Term();
        }

    }
    public class ProductVmCollections
    {
        public List<SelectListItem> Renkler { get; set; }
        public List<Company> Sirketler { get; set; }
        public List<PairIdNameDto> Ulkeler { get; set; }
        public SelectList PantoneRenkleri { get; set; }
        public SelectList UretimTeknolojileri { get; set; }
        public SelectList IplikKategorileri { get; set; }
        public List<MyNameValueDto> TumIplikler { get; set; }
        public List<SelectListItem> EaIpliNolar { get; internal set; }
        public List<SelectListItem> DnyIpliNolar { get; internal set; }
        public List<SelectListItem> NmIpliNolar { get; internal set; }
        public List<SelectListItem> FlIpliNolar { get; internal set; }
    }

    public enum ProductType
    {
        None,
        NormalKumas,
        NormalHamDuziplik,
        FantaziBukumlu,
        HazirGiyim,
        Aksesuar,
        FantaziKumas

    }
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int productTypeId)
        {
            var model = new ProductVm();
            return View(viewName: "Edit", model: model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductVm model)
        {
            return View();
        }
    }
}