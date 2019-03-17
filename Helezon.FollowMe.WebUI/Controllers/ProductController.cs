using FollowMe.Web;
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
            var model = new ProductVm();
            FillCollection(ProductType.None,model);
            model.Update = model.Product != null && model.Product.Id > 0; 
            return View(model: model);
        }

        [HttpPost]
        public ActionResult Edit(ProductVm model)
        {
            return View();
        }
        private void FillCollection(ProductType type, ProductVm model)
        {
            FillCommonCollection(model);
            switch (type)
            {
                case ProductType.None:
                    break;
                case ProductType.NormalKumas:
                    break;
                case ProductType.NormalHamDuziplik:
                    break;
                case ProductType.FantaziBukumlu:
                    break;
                case ProductType.HazirGiyim:
                    break;
                case ProductType.Aksesuar:
                    break;
                case ProductType.FantaziKumas:
                    break;
                default:
                    break;
            }
        }

        private void FillCommonCollection(ProductVm model)
        {
            var companies = GetCompanyService().GetRootCompanyIdAndNames(companyRootType: 1, companyId: "");
            var ulkeler = GetOthersService().GetAllCountry();
            var pantoneRenkler = GetNormalIplikService().GetPantoneRenkler().Select(x => new
            {
                Id = x.Id.ToString(),
                PantoneKodu = x.PantoneKodu + " " + x.PantoneRengi
            }).ToList();
            var renkler = GetNormalIplikService().GetRenkler(2).Select(x => new SelectListItem
            {
                Value = string.Format("{0}|{1}", x.Id, x.HtmlKod ?? string.Empty),
                Text = x.Ad
            }).ToList();
            var uretimTeknojileri = GetTermService().GetTermsByTaxonomyId(31);

            model.Collections.Companies = new SelectList(companies, "Value", "Name", model.Product.CompanyId);
            model.Collections.Ulkeler = new SelectList(ulkeler, "Value", "Name", model.Product.UlkeId?.ToString());
            model.Collections.PantoneRenkleri = new SelectList(pantoneRenkler, "Id", "PantoneKodu", model.Product.PantoneId?.ToString());
            model.Collections.Renkler = new SelectList(renkler, "Value", "Text", model.Product.Renkid?.ToString());
            model.Collections.UretimTeknolojileri = new SelectList(uretimTeknojileri, "Id", "Name", model.Product.UretimTeknolojisiId?.ToString());

            model.Collections.ElyafOranlari.AddRange(Enumerable.Range(1, 100).Select(x => new MyNameValueDto { Name = x.ToString() + "%", Value = x.ToString() }));


            var normalIplikler = GetNormalIplikService().GetZetaCodeIsimler();
            var fanteziIplikler = GetFanteziIplikService().GetZetaCodeIsimler();

            model.Iplikler.AddRange(model.FanteziKumasNormalHamDuzIplikler.Select(x => new MyNameValueDto
            {
                Value = x.Id + "|" + "Normaliplik",
                Name = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));

            model.Iplikler.AddRange(model.FanteziKumasFanteziBukumluGipeler.Select(x => new MyNameValueDto
            {
                Value = x.Id + "|" + "Fanteziiplik",
                Name = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));


            model.Collections.Iplikler.AddRange(normalIplikler.Select(x => new MyNameValueDto
            {
                Value = x.Id + "|" + "Normaliplik",
                Name = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));

            model.Collections.Iplikler.AddRange(fanteziIplikler.Select(x => new MyNameValueDto
            {
                Value = x.Id + "|" + "Fanteziiplik",
                Name = ZetaCodeFormatli(x.ZetaCode) + ", " + x.UrunIsmi
            }));


            model.Collections.TupAcikEnler = GetOthersService().GetAllTupAcikEn();
            model.Collections.Elastanlar = GetOthersService().GetAllElastan();

            model.Collections.OrguTipleri = new List<SelectListItem>();
            model.Collections.OrguTipleri.Add(new SelectListItem
            {
                Value = ((int)TaxonomyType.OrguDetaylariOrmeDuz).ToString(),
                Text = "Örme Düz"
            });

            //model.Collections.TupAcikEnler = GetOthersService().GetAllTupAcikEn();
            //model.Collections.Elastanlar = GetOthersService().GetAllElastan();

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



            //model.KarsimdakiIplikler=

            //var normalIplikler = GetNormalIplikService().GetAllZetaCodeAndUrunIsmiOfNormalIplikler();

            //if (normalIplikler.Any())
            //{
            //    for (int i = 0; i < normalIplikler.Count; i++)
            //    {
            //        var id = normalIplikler[i].Id;
            //        var name = normalIplikler[i].UrunIsmi;
            //        model.Collections.TumIplikler.Add(new MyNameValueDto()
            //        {
            //            Name = name,
            //            Value = string.Format("{0}|{1}", id, "Normaliplik")
            //        });
            //    }
            //}

            //var fanteziIplikler = GetFanteziIplikService().GetAllZetaCodeAndUrunIsmiOfFantaziIplikler();

            //if (fanteziIplikler.Any())
            //{
            //    for (int i = 0; i < fanteziIplikler.Count; i++)
            //    {
            //        var id = fanteziIplikler[i].Id;
            //        var name = fanteziIplikler[i].UrunIsmi;
            //        model.Collections.TumIplikler.Add(new MyNameValueDto()
            //        {
            //            Name = name,
            //            Value = string.Format("{0}|{1}", id, "Fanteziiplik")
            //        });
            //    }
            //}


            if ( !model.AksesuarKompozisyonlar.Any())
            {
                model.AksesuarKompozisyonlar.Add(new ZetaCodeAksesuarKompozisyon());
            }

            if (!model.KarsimdakiIplikler.Any())
            {
                model.KarsimdakiIplikler.Add(new MyNameValueDto());
            }

            //model.NE = new IplikNoGuideMethod(GetSelectListNE);
            //model.NM = new IplikNoGuideMethod(GetSelectListNM);
            //model.DYN = new IplikNoGuideMethod(GetSelectListDYN);
            //model.FL = new IplikNoGuideMethod(GetSelectListFL);
            //model.EA = new IplikNoGuideMethod(GetSelectListEA);
            //model.ElyafOrani = new ElyafOraniMethod(GetSelectListElyafOrani);
            if (!model.Iplikler.Any())
            {
                model.Iplikler.Add(new MyNameValueDto());
            }
            if (!model.IplikNolar.Any())
            {
                model.IplikNolar.Add(new IplikNoDto()
                {
                    ElyafCinsiKalitesi = new Term(),
                    IplikNo = new IplikNo()
                });

            }
        }

        private string ZetaCodeFormatli(int zetaCode)
        {
            return "Z" + zetaCode.ToString().PadLeft(4, '0');
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


            var data = GetOthersService().GetAllAksesuar().Select(x => new
            {
                id = x.Value.ToString(),
                text = x.Name,
                parent = "#"
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
    }

    //Servisten gelen model class ların sonuna dto ekle!

    public class ProductVm
    {
        public bool Update { get; set; }
        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
        public string RenkIdHtmlKod { get; set; }
        public Collections Collections { get; set; }
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
        /************************************************************************************/
        public List<ZetaCodeFanteziIplik> FanteziKumasFanteziBukumluGipeler { get; set; }
        public List<ZetaCodeNormalIplik> FanteziKumasNormalHamDuzIplikler { get; set; }
        public ZetaCodeKumasMakine KumasMakine { get; set; }
        public ZetaCodeYikamaTalimati YikamaTalimati { get; set; }
        public List<Term> Aksesuarlar { get; set; }
        public List<Term> OrguDetaylari { get; set; }
        public List<Term> BoyaIslemleri { get; set; }
        public List<MyNameValueDto> Iplikler { get; set; }
        /************************************************************************************/
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }
        public List<MyNameValueDto> Kumaslar { get; set; }
        public List<ZetaCodeKumasFantezi3AdimIslemleri> KumasFantezi3AdimIslemleri { get; set; }
        //public ZetaCodeKumasMakine Makine { get; set; }
        public ZetaCodeYikamaTalimati ZetaCodeYikamaTalimati { get; set; }
        public List<Term> AdimIslemleri { get; set; }
        public List<MyNameValueDto> KumasOrmeDokumalar { get; set; }
        public List<MyNameValueDto> KumasFanteziler { get; set; }
        /************************************************************************************/
        public List<BedenOlculeri> BedenOlculeri { get; set; }
        public Term UrunKategori { get; set; }
        /************************************************************************************/
        public List<ZetaCodeAksesuarKompozisyon> AksesuarKompozisyonlar { get; set; }
        public List<ElyafCinsiKalitesi> ElyafCinsiKaliteleri { get; set; }


        public ProductVm()
        {
            Collections = new Collections();
            KarsimdakiIplikler = new List<MyNameValueDto>();
            Product = new Product();
            Renk = new Renk();
            PantoneRenk = new PantoneRenk();
            RafyeriTurkiye = new Term();
            RafyeriYunanistan = new Term();
            Company = new Company();
            IplikNolar = new List<IplikNoDto>();
            Ulke = new MyNameValueDto();
            IplikKategosi = new Term();
            Iplikler = new List<MyNameValueDto>();
            FanteziKumasNormalHamDuzIplikler = new List<ZetaCodeNormalIplik>();
            FanteziKumasFanteziBukumluGipeler = new List<ZetaCodeFanteziIplik>();
            Collections.Iplikler = new List<MyNameValueDto>();
            Collections.TupAcikEnler = new HashSet<MyNameValueDto>();
            KumasMakine = new ZetaCodeKumasMakine();
            Collections.Elastanlar = new HashSet<MyNameValueDto>();
            Collections.OrguTipleri = new List<SelectListItem>();
            OrguDetaylari = new List<Term>();
            YikamaTalimati = new ZetaCodeYikamaTalimati();
            Collections.YikamaSekilleri = new HashSet<MyNameValueDto>();
            AksesuarKompozisyonlar = new List<ZetaCodeAksesuarKompozisyon>();
            Kumaslar = new List<MyNameValueDto>();
            Aksesuarlar = new List<Term>();
            Collections.BaskiGoruntuler = new List<SelectListItem>();            
        }

    }

    public class Collections
    {
        //public List<SelectListItem> Renkler { get; set; }
        //public List<Company> Sirketler { get; set; }
        //public List<MyNameValueDto> Ulkeler { get; set; }
        //public SelectList PantoneRenkleri { get; set; }
        //public SelectList UretimTeknolojileri { get; set; }
        public List<MyNameValueDto> ElyafOranlari { get; set; }

        public SelectList IplikKategorileri { get; set; }
        //public List<MyNameValueDto> TumIplikler { get; set; }
        public List<SelectListItem> EaIpliNolar { get; set; }
        public List<SelectListItem> DnyIpliNolar { get; set; }
        public List<SelectListItem> NmIpliNolar { get; set; }
        public List<SelectListItem> FlIpliNolar { get; set; }
        public List<SelectListItem> ModelYillari { get; set; }
        public List<SelectListItem> NormalIplikler { get; set; }
        public List<SelectListItem> FanteziIplikler { get; set; }
        public HashSet<MyNameValueDto> TupAcikEnler { get; set; }
        public HashSet<MyNameValueDto> Elastanlar { get; set; }
        public HashSet<MyNameValueDto> YikamaSekilleri { get; set; }
        public SelectList UrunKategorileri { get; set; }
        public List<SelectListItem> PantoneRenkler { get; set; }
        public List<SelectListItem> OrguTipleri { get; set; }
        public List<SelectListItem> OrguCesidleri { get; set; }
        public List<SelectListItem> OrguKabiliyetleri { get; set; }
        public List<SelectListItem> OrguDigerleri { get; set; }
        public IEnumerable<SelectListItem> KumasGoruntuleri { get; set; }
        public List<MyNameValueDto> Iplikler { get; set; }
        public List<Term> AdimIslemleri { get; set; }
        public List<SelectListItem> FanteziKumaslar { get; set; }
        public List<SelectListItem> OrmeDokumaKumaslar { get; set; }
        public List<MyNameValueDto> Kumaslar { get; set; }
        public List<SelectListItem> BaskiGoruntuler { get; set; }
        public List<SelectListItem> BedenKalipIsimleri { get; set; }
        public List<MyNameValueDto> Aksesuarlar { get; set; }
        public List<Term> UrunKompozisyonlar { get; set; } 

        //********************************************//
        public SelectList ElyafOrani { get; set; }
        public SelectList Companies { get; set; }
        public SelectList Ulkeler { get; set; }
        public SelectList PantoneRenkleri { get; set; }
        public SelectList Renkler { get; set; }
        public SelectList UretimTeknolojileri { get; set; }
        public SelectList Ne { get; set; }
        public SelectList Nm { get; set; }
        public SelectList Dny { get; set; }
        public SelectList Fl { get; set; }
        public Collections()
        {
            ElyafOranlari = new List<MyNameValueDto>();
        }
    }

    public class ElyafCinsiKalitesi
    {
        public string Termid { get; set; }
        public string TermName { get; set; }
        public string ElyafOrani { get; set; }
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
}