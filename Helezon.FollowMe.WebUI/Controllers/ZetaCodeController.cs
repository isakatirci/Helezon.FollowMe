using FollowMe.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{
    public class ZetaCodeController : Controller
    {
        string[] NormalIplikColumns = {
             "Id"
            ,"UrunIsmi"
            ,"Master"
            ,"ZetaCode"
            ,"ZetaCodePrevious"
            ,"IplikKategosiId"
            ,"SirketId"
            ,"UlkeId"
            ,"BlueUrunKodIsmi"
            ,"BlueKod"
            ,"BlueSiparisNo"
            ,"UretimTeknolojisiId"
            ,"PantoneId"
            ,"Renkid"
            ,"RafyeriTurkiyeId"
            ,"RafyeriYunanistanId"
            ,"IplikNoCinsi"
            ,"NE"
            ,"NM"
            ,"DNY"
            ,"FL"
            ,"EA"
            ,"IsPassive"
            ,"CreatedOn"
            ,"CreatedBy"
            ,"ChangedOn"
            ,"ChangedBy"
        };
        string[] FanteziIplikColumns = {
               "Id"
              ,"UrunIsmi"
              ,"IplikKategosiId"
              ,"SirketId"
              ,"Master"
              ,"ZetaCode"
              ,"ZetaCodePrevious"
              ,"NM"
              ,"FL"
              ,"EA"
              ,"DNY"
              ,"IplikNoCinsi"
              ,"UlkeId"
              ,"BlueUrunKodIsmi"
              ,"BlueKod"
              ,"BlueSiparisNo"
              ,"RafyeriTurkiyeId"
              ,"RafyeriYunanistanId"
              ,"PantoneId"
              ,"Renkid"
              ,"IsPassive"
              ,"CreatedOn"
              ,"CreatedBy"
              ,"ChangedOn"
              ,"ChangedBy"
        };
        string[] KumasOrmeDokumaColumns = {
           "Id"
          ,"RafyeriTurkiyeId"
          ,"RafyeriYunanistanId"
          ,"UrunKategorisiId"
          ,"ZetaCode"
          ,"ZetaCodePrevious"
          ,"BlueSiparisNo"
          ,"CompanyId"
          ,"Master"
          ,"UrunIsmi"
          ,"BlueUrunKodu"
          ,"En"
          ,"Gramaj"
          ,"Renk"
          ,"MenseyiUlkeId"
          ,"PantoneId"
          ,"Renkid"
          ,"BlueUrunKodIsmi"
          ,"KumasMakineId"
          ,"IplikKullanimOrani"
          ,"MetreTulOrani"
          ,"KoleksiyonKategoriId"
          ,"KumasGoruntuId"
          ,"OrguTipiId"
          ,"BoyaIslemleriIds"
          ,"OrguDetaylariIds"
          ,"IsPassive"
          ,"CreatedOn"
          ,"CreatedBy"
          ,"ChangedOn"
          ,"ChangedBy"

        };
        string[] KumasFanteziColumns = {
                 "Id"
                ,"RafyeriTurkiyeId"
                ,"RafyeriYunanistanId"
                ,"UrunKategorisiId"
                ,"ZetaCode"
                ,"ZetaCodePrevious"
                ,"BlueSiparisNo"
                ,"Master"
                ,"UrunIsmi"
                ,"BlueUrunKodu"
                ,"En"
                ,"Gramaj"
                ,"BaskiliEn"
                ,"Renk"
                ,"MenseyiUlkeId"
                ,"PantoneId"
                ,"Renkid"
                ,"BlueUrunKodIsmi"
                ,"KumasMakineId"
                ,"IplikKullanimOrani"
                ,"MetreTulOrani"
                ,"KoleksiyonKategoriId"
                ,"KumasGoruntuId"
                ,"OrguTipiId"
                ,"BoyaIslemleriIds"
                ,"OrguDetaylariIds"
                ,"CompanyId"
                ,"IsPassive"
                ,"CreatedOn"
                ,"CreatedBy"
                ,"ChangedOn"
                ,"ChangedBy"

        };
        string[] AksesuarColumns = {
               "Id"
              ,"CompanyId"
              ,"UlkeId"
              ,"Master"
              ,"BlueUrunKodIsmi"
              ,"BlueSiparisNo"
              ,"ZetaCode"
              ,"PantoneId"
              ,"Renkid"
              ,"RafyeriTurkiyeId"
              ,"RafyeriYunanistanId"
              ,"ZetaCodePrevious"
              ,"En"
              ,"Boy"
              ,"Gram"
              ,"KategoriId"
              ,"IsPassive"
              ,"CreatedOn"
              ,"CreatedBy"
              ,"ChangedOn"
              ,"ChangedBy"
        };
        string[] HazirGiyimColumns = {
               "Id"
              ,"UrunKategoriId"
              ,"CompanyId"
              ,"UlkeId"
              ,"Master"
              ,"BlueUrunKodIsmi"
              ,"BlueSiparisNo"
              ,"ZetaCode"
              ,"PantoneId"
              ,"Renkid"
              ,"RafyeriTurkiyeId"
              ,"RafyeriYunanistanId"
              ,"ZetaCodePrevious"
              ,"En"
              ,"Boy"
              ,"Gram"
              ,"KategoriId"
              ,"BaskiGoruntuId"
              ,"IsPassive"
              ,"CreatedOn"
              ,"CreatedBy"
              ,"ChangedOn"
              ,"ChangedBy"
        };

        private List<string> GetMappingColumns(string[] columns)
        {
            var list = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                if (columns.Length > i)
                {
                    list.Add(string.Format("CONVERT(nvarchar(250),{0}) as Column{1}", columns[i], i));
                }
                else
                {
                    list.Add(string.Format("CONVERT(nvarchar(250),'') as Column{0}", i));
                }
            }
            return list;
        }
        private string GetMappingColumnsJoin(string[] columns)
        {
            return string.Join(",", GetMappingColumns(columns));
        }
        // GET: ZetaCode
        public ActionResult Index()
        {

            ViewBag.BlueCounter = 0;
            ViewBag.RedCounter = 0;
            ViewBag.OthersCounter = 0;
            ViewBag.ZetaaCounter = 0;


            ViewBag.BlueHref = Url.Action("Index", "ZetaCode");
            ViewBag.BlueDesc = "Test";
            ViewBag.RedHref = Url.Action("Index", "ZetaCode");
            ViewBag.RedDesc = "Test";
            ViewBag.OthersHref = Url.Action("Index", "ZetaCode");
            ViewBag.OthersDesc = "Test";
            ViewBag.ZetaaHref = Url.Action("Index", "ZetaCode");
            ViewBag.ZetaaDesc = "Test";

            DataTable[] table = {
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(NormalIplikColumns), "ZetaCodeNormalIplik")),
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(FanteziIplikColumns), "ZetaCodeFanteziIplik")),
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(KumasFanteziColumns), "ZetaCodeKumasFantazi")),
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(KumasOrmeDokumaColumns), "ZetaCodeKumasOrmeDokuma")),
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(HazirGiyimColumns), "ZetaCodeHazirGiyim")),
               AdoHelper.FillDataTable(string.Format("SELECT {0} FROM {1}", GetMappingColumnsJoin(AksesuarColumns), "ZetaCodeAksesuar"))
            };

            return View(model: table);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}