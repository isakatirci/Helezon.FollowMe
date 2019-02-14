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
                //,"ZetaCode"
                ,"ZetaCodePrevious"
                ,"SirketId"
                ,"UlkeId"    
                ,"BlueUrunKodIsmi"
                ,"BlueKod"
                , "BlueSiparisNo"
                , "PantoneId"
                , "Renkid"
                , "IplikKategosiId"
                , "IplikNoCinsi"     
                , "NM"
                , "DNY"
                , "FL"
                , "EA"                
                , "RafyeriTurkiyeId"
                , "RafyeriYunanistanId"                 
                , "IsPassive"
                , "CreatedOn"
                , "CreatedBy"
                , "ChangedOn"
                , "ChangedBy"
                , "UretimTeknolojisiId"
                , "NE"
                ,""//En
                ,""//Gramaj
                ,""//"//BaskiliEn
                ,""//Renk
                ,""//KumasMakineId
                ,""//IplikKullanimOrani
                ,""//MetreTulOrani
                ,""//KoleksiyonKategoriId
                ,""//KumasGoruntuId
                ,""//OrguTipiId
                ,""//BoyaIslemleriIds
                ,""//OrguDetaylariIds
                ,""//UrunKategorisiId
                ,""//Boy
                ,""//Gram
                ,""//KategoriId
                ,""//UrunKategoriId
                ,""//BaskiGoruntuId
                 ,"Normaliplik"
        };
        string[] FanteziIplikColumns = {
               "Id"
              ,"UrunIsmi"
               ,"Master"
                //,"ZetaCode"
              ,"ZetaCodePrevious"
              ,"SirketId"
               ,"UlkeId"
               ,"BlueUrunKodIsmi"
                 ,"BlueKod"
                   ,"BlueSiparisNo"
                     ,"PantoneId"
              ,"Renkid"
              ,"IplikKategosiId"
             ,"IplikNoCinsi"
              ,"NM"
                 ,"DNY"
              ,"FL"
              ,"EA"
             
           
             
           
              ,"RafyeriTurkiyeId"
              ,"RafyeriYunanistanId"
         
              ,"IsPassive"
              ,"CreatedOn"
              ,"CreatedBy"
              ,"ChangedOn"
              ,"ChangedBy"

                ,""//UretimTeknolojisiId
                ,""//NE
                ,""//En
                ,""//Gramaj
                ,""//"//BaskiliEn
                ,""//Renk
                ,""//KumasMakineId
                ,""//IplikKullanimOrani
                ,""//MetreTulOrani
                ,""//KoleksiyonKategoriId
                ,""//KumasGoruntuId
                ,""//OrguTipiId
                ,""//BoyaIslemleriIds
                ,""//OrguDetaylariIds
                ,""//UrunKategorisiId
                ,""//Boy
                ,""//Gram
                ,""//KategoriId
                ,""//UrunKategoriId
                ,""//BaskiGoruntuId
                ,"Fanteziiplik"



        };
        string[] KumasOrmeDokumaColumns = {
                "Id"
                ,"UrunIsmi"
                ,"Master"
                //,"ZetaCode"
                ,"ZetaCodePrevious"
                ,"CompanyId"
                ,"MenseyiUlkeId"
                ,"BlueUrunKodIsmi"
                ,"BlueUrunKodu"
                ,"BlueSiparisNo"
                ,"PantoneId"
                ,"Renkid"    
                ,""//IplikKategorisiId
                ,""//IplikNoCinsi
                ,""//NM
                ,""//DNY
                ,""//FL
                ,""//EA
                ,"RafyeriTurkiyeId"
                ,"RafyeriYunanistanId"
                ,"IsPassive"
                ,"CreatedOn"
                ,"CreatedBy"
                ,"ChangedOn"
                ,"ChangedBy"
                ,""//UretimTeknolojisiId
                ,""//NE
                ,"En"
                ,"Gramaj"
                ,""//BaskiliEn
                ,"Renk" 
                ,"KumasMakineId"
                ,"IplikKullanimOrani"
                ,"MetreTulOrani"
                ,"KoleksiyonKategoriId"
                ,"KumasGoruntuId"
                ,"OrguTipiId"
                ,"BoyaIslemleriIds"
                ,"OrguDetaylariIds"
                ,"UrunKategorisiId"
                ,""//Boy
                ,""//Gram
                ,""//KategoriId
                ,""//UrunKategoriId
                ,""//BaskiGoruntuId
                 ,"KumasOrme"

        };
        string[] KumasFanteziColumns = {
            "Id"
            ,"UrunIsmi"
            ,"Master"
            // ,"ZetaCode"
            ,"ZetaCodePrevious"
            ,"CompanyId"
            ,"MenseyiUlkeId"
            ,"BlueUrunKodIsmi"
            ,"BlueUrunKodu"
            ,"BlueSiparisNo"
            ,"PantoneId"
            ,"Renkid"
            ,""//IplikKategorisiId
            ,""//IplikNoCinsi
            ,""//NM
            ,""//DNY
            ,""//FL
            ,""//EA
            ,"RafyeriTurkiyeId"
            ,"RafyeriYunanistanId"
            ,"IsPassive"
            ,"CreatedOn"
            ,"CreatedBy"
            ,"ChangedOn"
            ,"ChangedBy"
            ,""//UretimTeknolojisiId
            ,""//NE
            ,"En"
            ,"Gramaj"
            ,"BaskiliEn"
            ,"Renk"        
            ,"KumasMakineId"
            ,"IplikKullanimOrani"
            ,"MetreTulOrani"
            ,"KoleksiyonKategoriId"
            ,"KumasGoruntuId"
            ,"OrguTipiId"
            ,"BoyaIslemleriIds"
            ,"OrguDetaylariIds"
            ,"UrunKategorisiId"

            ,""//Boy
            ,""//Gram
            ,""//KategoriId
            ,""//UrunKategoriId
            ,""//BaskiGoruntuId
             ,"KumasFantezi"


        };
        string[] AksesuarColumns = {
                     "Id"
                    ,""//UrunIsmi
                    ,"Master"
                    // ,"ZetaCode"
                    ,"ZetaCodePrevious"
                    ,"CompanyId"
                    ,"UlkeId"             
                    ,"BlueUrunKodIsmi"
                    ,""//BlueUrunKodu
                    ,"BlueSiparisNo"          
                    ,"PantoneId"
                    ,"Renkid"
                    ,""//IplikKategorisiId
                    ,""//IplikNoCinsi
                    ,""//NM
                    ,""//DNY
                    ,""//FL
                    ,""//EA
                    ,"RafyeriTurkiyeId"
                    ,"RafyeriYunanistanId"
                    ,"IsPassive"
                    ,"CreatedOn"
                    ,"CreatedBy"
                    ,"ChangedOn"
                    ,"ChangedBy"
                    ,""//UretimTeknolojisiId
                    ,""//NE
                    ,"En"
                    ,""//Gramaj
                    ,""//BaskiliEn
                    ,""//Renk
                    ,""//KumasMakineId
                    ,""//IplikKullanimOrani
                    ,""//MetreTulOrani
                    ,""//KoleksiyonKategoriId
                    ,""//KumasGoruntuId
                    ,""//OrguTipiId
                    ,""//BoyaIslemleriIds
                    ,""//OrguDetaylariIds
                    ,""//UrunKategorisiId
                    ,"Boy"
                    ,"Gram"
                    ,"KategoriId"
                    ,""//UrunKategoriId
                    ,""//BaskiGoruntuId
                      ,"Aksesuar"

        };
        string[] HazirGiyimColumns = {
                "Id"
                ,""//UrunIsmi
                ,"Master"
                //ZetaCode
                ,"ZetaCodePrevious"
                ,"CompanyId"
                ,"UlkeId"
                ,"BlueUrunKodIsmi"
                ,""//BlueUrunKodu
                ,"BlueSiparisNo"
                ,"PantoneId"
                ,"Renkid"
                ,""//IplikKategorisiId
                ,""//IplikNoCinsi
                ,""//NM
                ,""//DNY
                ,""//FL
                ,""//EA
                ,"RafyeriTurkiyeId"
                ,"RafyeriYunanistanId"
                ,"IsPassive"
                ,"CreatedOn"
                ,"CreatedBy"
                ,"ChangedOn"
                ,"ChangedBy"
                ,""//UretimTeknolojisiId
                ,""//NE
                ,"En"
                ,""//Gramaj
                ,""//BaskiliEn
                ,""//Renk
                ,""//KumasMakineId
                ,""//IplikKullanimOrani
                ,""//MetreTulOrani
                ,""//KoleksiyonKategoriId
                ,""//KumasGoruntuId
                ,""//OrguTipiId
                ,""//BoyaIslemleriIds
                ,""//OrguDetaylariIds
                ,""//UrunKategorisiId
                ,"Boy"
                ,"Gram"
                ,"KategoriId"
                ,"UrunKategoriId"       
                ,"BaskiGoruntuId"
                ,"HazirGiyim"
        };

        private List<string> GetMappingColumns(string[] columns)
        {

            string[] columnNames = {
                    "Id"
                    ,"UrunIsmi"//
                    ,"Master"
                    //"ZetaCode"
                    ,"ZetaCodePrevious"
                    ,"CompanyId"
                    ,"UlkeId"
                    ,"BlueUrunKodIsmi"
                    ,"BlueUrunKodu"
                    ,"BlueSiparisNo"
                    ,"PantoneId"
                    ,"Renkid"
                    ,"IplikKategorisiId"
                    ,"IplikNoCinsi"
                    ,"NM"
                    ,"DNY"
                    ,"FL"
                    ,"EA"
                    ,"RafyeriTurkiyeId"
                    ,"RafyeriYunanistanId"
                    ,"IsPassive"
                    ,"CreatedOn"
                    ,"CreatedBy"
                    ,"ChangedOn"
                    ,"ChangedBy"
                    ,"UretimTeknolojisiId"
                    ,"NE"
                    ,"En"
                    ,"Gramaj"
                    ,"BaskiliEn"
                    ,"Renk"
                    ,"KumasMakineId"
                    ,"IplikKullanimOrani"
                    ,"MetreTulOrani"
                    ,"KoleksiyonKategoriId"
                    ,"KumasGoruntuId"
                    ,"OrguTipiId"
                    ,"BoyaIslemleriIds"
                    ,"OrguDetaylariIds"
                    ,"UrunKategorisiId"
                    ,"Boy"
                    ,"Gram"
                    ,"KategoriId"
                    ,"UrunKategoriId"
                    ,"BaskiGoruntuId"
            };


            var list = new List<string>();
            //if (columnNames.Length != columns.Length)
            //{
            //    throw new Exception("Boyutları Farklı");
            //}
            for (int i = 0; i < columnNames.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(columns[i]))
                {
                    list.Add(string.Format("CONVERT(nvarchar(250),{0}) as {1}", columns[i], columnNames[i]));
                }
                else
                {
                    list.Add(string.Format("'' as {0}", columnNames[i]));
                }
            }

            list.Add(string.Format("'{0}' as Type", columns.Last()));

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