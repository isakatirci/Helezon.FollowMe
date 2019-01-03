using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMe.Web;
using FollowMe.Web.Controllers;
using FollowMe.Web.Models;
using Helezon.FollowMe.Service;
using Helezon.FollowMe.Service.DataTransferObjects;
using Helezon.FollowMe.WebUI.Code;
using Helezon.FollowMe.WebUI.Models.ViewModels;

namespace Helezon.FollowMe.WebUI.Controllers
{


    public class ZetaCodeNormalIplikController : BaseController
    {

        private static Lazy<List<SelectListItem>> Ulkeler = new Lazy<List<SelectListItem>>(() => new List<SelectListItem> {
            new SelectListItem { Value="1", Text="Afghanistan"},
            new SelectListItem { Value="2", Text="Albania"},
            new SelectListItem { Value="3", Text="Algeria"},
            new SelectListItem { Value="4", Text="American Samoa"},
            new SelectListItem { Value="5", Text="Andorra"},
            new SelectListItem { Value="6", Text="Angola"},
            new SelectListItem { Value="7", Text="Antigua And Barbuda"},
            new SelectListItem { Value="8", Text="Argentina"},
            new SelectListItem { Value="9", Text="Armenia"},
            new SelectListItem { Value="10", Text="Aruba"},
            new SelectListItem { Value="11", Text="Australia"},
            new SelectListItem { Value="12", Text="Austria"},
            new SelectListItem { Value="13", Text="Azerbaijan"},
            new SelectListItem { Value="14", Text="Bahamas The"},
            new SelectListItem { Value="15", Text="Bahrain"},
            new SelectListItem { Value="16", Text="Bangladesh"},
            new SelectListItem { Value="17", Text="Belarus"},
            new SelectListItem { Value="18", Text="Belgium"},
            new SelectListItem { Value="19", Text="Belize"},
            new SelectListItem { Value="20", Text="Benin"},
            new SelectListItem { Value="21", Text="Bermuda"},
            new SelectListItem { Value="22", Text="Bhutan"},
            new SelectListItem { Value="23", Text="Bolivia"},
            new SelectListItem { Value="24", Text="Botswana"},
            new SelectListItem { Value="25", Text="Brazil"},
            new SelectListItem { Value="26", Text="Brunei"},
            new SelectListItem { Value="27", Text="Bulgaria"},
            new SelectListItem { Value="28", Text="Burkina Faso"},
            new SelectListItem { Value="29", Text="Burundi"},
            new SelectListItem { Value="30", Text="Cambodia"},
            new SelectListItem { Value="31", Text="Cameroon"},
            new SelectListItem { Value="32", Text="Canada"},
            new SelectListItem { Value="33", Text="Cape Verde"},
            new SelectListItem { Value="34", Text="Central African Republic"},
            new SelectListItem { Value="35", Text="Chad"},
            new SelectListItem { Value="36", Text="Chile"},
            new SelectListItem { Value="37", Text="China"},
            new SelectListItem { Value="38", Text="Colombia"},
            new SelectListItem { Value="39", Text="Comoros"},
            new SelectListItem { Value="40", Text="Congo"},
            new SelectListItem { Value="41", Text="Congo The Democratic Republic Of The"},
            new SelectListItem { Value="42", Text="Cook Islands"},
            new SelectListItem { Value="43", Text="Costa Rica"},
            new SelectListItem { Value="44", Text="Cote D'Ivoire (Ivory Coast)"},
            new SelectListItem { Value="45", Text="Croatia (Hrvatska)"},
            new SelectListItem { Value="46", Text="Cuba"},
            new SelectListItem { Value="47", Text="Cyprus"},
            new SelectListItem { Value="48", Text="Czech Republic"},
            new SelectListItem { Value="49", Text="Denmark"},
            new SelectListItem { Value="50", Text="Djibouti"},
            new SelectListItem { Value="51", Text="Dominican Republic"},
            new SelectListItem { Value="52", Text="East Timor"},
            new SelectListItem { Value="53", Text="Ecuador"},
            new SelectListItem { Value="54", Text="Egypt"},
            new SelectListItem { Value="55", Text="El Salvador"},
            new SelectListItem { Value="56", Text="Equatorial Guinea"},
            new SelectListItem { Value="57", Text="Eritrea"},
            new SelectListItem { Value="58", Text="Estonia"},
            new SelectListItem { Value="59", Text="Ethiopia"},
            new SelectListItem { Value="60", Text="Faroe Islands"},
            new SelectListItem { Value="61", Text="Fiji Islands"},
            new SelectListItem { Value="62", Text="Finland"},
            new SelectListItem { Value="63", Text="France"},
            new SelectListItem { Value="64", Text="French Guiana"},
            new SelectListItem { Value="65", Text="French Polynesia"},
            new SelectListItem { Value="66", Text="French Southern Territories"},
            new SelectListItem { Value="67", Text="Gabon"},
            new SelectListItem { Value="68", Text="Gambia The"},
            new SelectListItem { Value="69", Text="Georgia"},
            new SelectListItem { Value="70", Text="Germany"},
            new SelectListItem { Value="71", Text="Ghana"},
            new SelectListItem { Value="72", Text="Gibraltar"},
            new SelectListItem { Value="73", Text="Greece"},
            new SelectListItem { Value="74", Text="Greenland"},
            new SelectListItem { Value="75", Text="Guadeloupe"},
            new SelectListItem { Value="76", Text="Guam"},
            new SelectListItem { Value="77", Text="Guatemala"},
            new SelectListItem { Value="78", Text="Guernsey and Alderney"},
            new SelectListItem { Value="79", Text="Guinea"},
            new SelectListItem { Value="80", Text="Guinea-Bissau"},
            new SelectListItem { Value="81", Text="Guyana"},
            new SelectListItem { Value="82", Text="Haiti"},
            new SelectListItem { Value="83", Text="Honduras"},
            new SelectListItem { Value="84", Text="Hungary"},
            new SelectListItem { Value="85", Text="Iceland"},
            new SelectListItem { Value="86", Text="India"},
            new SelectListItem { Value="87", Text="Indonesia"},
            new SelectListItem { Value="88", Text="Iran"},
            new SelectListItem { Value="89", Text="Iraq"},
            new SelectListItem { Value="90", Text="Ireland"},
            new SelectListItem { Value="91", Text="Israel"},
            new SelectListItem { Value="92", Text="Italy"},
            new SelectListItem { Value="93", Text="Jamaica"},
            new SelectListItem { Value="94", Text="Japan"},
            new SelectListItem { Value="95", Text="Jersey"},
            new SelectListItem { Value="96", Text="Jordan"},
            new SelectListItem { Value="97", Text="Kazakhstan"},
            new SelectListItem { Value="98", Text="Kenya"},
            new SelectListItem { Value="99", Text="Kiribati"},
            new SelectListItem { Value="100", Text="Korea North"},
            new SelectListItem { Value="101", Text="Korea South"},
            new SelectListItem { Value="102", Text="Kuwait"},
            new SelectListItem { Value="103", Text="Kyrgyzstan"},
            new SelectListItem { Value="104", Text="Laos"},
            new SelectListItem { Value="105", Text="Latvia"},
            new SelectListItem { Value="106", Text="Lebanon"},
            new SelectListItem { Value="107", Text="Lesotho"},
            new SelectListItem { Value="108", Text="Liberia"},
            new SelectListItem { Value="109", Text="Libya"},
            new SelectListItem { Value="110", Text="Liechtenstein"},
            new SelectListItem { Value="111", Text="Lithuania"},
            new SelectListItem { Value="112", Text="Luxembourg"},
            new SelectListItem { Value="113", Text="Macau S.A.R."},
            new SelectListItem { Value="114", Text="Macedonia"},
            new SelectListItem { Value="115", Text="Madagascar"},
            new SelectListItem { Value="116", Text="Malawi"},
            new SelectListItem { Value="117", Text="Malaysia"},
            new SelectListItem { Value="118", Text="Maldives"},
            new SelectListItem { Value="119", Text="Mali"},
            new SelectListItem { Value="120", Text="Malta"},
            new SelectListItem { Value="121", Text="Man (Isle of)"},
            new SelectListItem { Value="122", Text="Marshall Islands"},
            new SelectListItem { Value="123", Text="Martinique"},
            new SelectListItem { Value="124", Text="Mauritania"},
            new SelectListItem { Value="125", Text="Mauritius"},
            new SelectListItem { Value="126", Text="Mayotte"},
            new SelectListItem { Value="127", Text="Mexico"},
            new SelectListItem { Value="128", Text="Micronesia"},
            new SelectListItem { Value="129", Text="Moldova"},
            new SelectListItem { Value="130", Text="Monaco"},
            new SelectListItem { Value="131", Text="Mongolia"},
            new SelectListItem { Value="132", Text="Montserrat"},
            new SelectListItem { Value="133", Text="Morocco"},
            new SelectListItem { Value="134", Text="Mozambique"},
            new SelectListItem { Value="135", Text="Myanmar"},
            new SelectListItem { Value="136", Text="Namibia"},
            new SelectListItem { Value="137", Text="Nauru"},
            new SelectListItem { Value="138", Text="Nepal"},
            new SelectListItem { Value="139", Text="Netherlands Antilles"},
            new SelectListItem { Value="140", Text="Netherlands The"},
            new SelectListItem { Value="141", Text="New Caledonia"},
            new SelectListItem { Value="142", Text="New Zealand"},
            new SelectListItem { Value="143", Text="Nicaragua"},
            new SelectListItem { Value="144", Text="Niger"},
            new SelectListItem { Value="145", Text="Nigeria"},
            new SelectListItem { Value="146", Text="Niue"},
            new SelectListItem { Value="147", Text="Northern Mariana Islands"},
            new SelectListItem { Value="148", Text="Norway"},
            new SelectListItem { Value="149", Text="Oman"},
            new SelectListItem { Value="150", Text="Pakistan"},
            new SelectListItem { Value="151", Text="Palau"},
            new SelectListItem { Value="152", Text="Palestinian Territory Occupied"},
            new SelectListItem { Value="153", Text="Panama"},
            new SelectListItem { Value="154", Text="Papua new Guinea"},
            new SelectListItem { Value="155", Text="Paraguay"},
            new SelectListItem { Value="156", Text="Peru"},
            new SelectListItem { Value="157", Text="Philippines"},
            new SelectListItem { Value="158", Text="Poland"},
            new SelectListItem { Value="159", Text="Portugal"},
            new SelectListItem { Value="160", Text="Puerto Rico"},
            new SelectListItem { Value="161", Text="Qatar"},
            new SelectListItem { Value="162", Text="Reunion"},
            new SelectListItem { Value="163", Text="Romania"},
            new SelectListItem { Value="164", Text="Russia"},
            new SelectListItem { Value="165", Text="Rwanda"},
            new SelectListItem { Value="166", Text="Saint Helena"},
            new SelectListItem { Value="167", Text="Saint Lucia"},
            new SelectListItem { Value="168", Text="Saint Pierre and Miquelon"},
            new SelectListItem { Value="169", Text="Saint Vincent And The Grenadines"},
            new SelectListItem { Value="170", Text="Samoa"},
            new SelectListItem { Value="171", Text="San Marino"},
            new SelectListItem { Value="172", Text="Sao Tome and Principe"},
            new SelectListItem { Value="173", Text="Saudi Arabia"},
            new SelectListItem { Value="174", Text="Senegal"},
            new SelectListItem { Value="175", Text="Seychelles"},
            new SelectListItem { Value="176", Text="Sierra Leone"},
            new SelectListItem { Value="177", Text="Singapore"},
            new SelectListItem { Value="178", Text="Slovakia"},
            new SelectListItem { Value="179", Text="Slovenia"},
            new SelectListItem { Value="180", Text="Smaller Territories of the UK"},
            new SelectListItem { Value="181", Text="Solomon Islands"},
            new SelectListItem { Value="182", Text="Somalia"},
            new SelectListItem { Value="183", Text="South Africa"},
            new SelectListItem { Value="184", Text="Spain"},
            new SelectListItem { Value="185", Text="Sri Lanka"},
            new SelectListItem { Value="186", Text="Sudan"},
            new SelectListItem { Value="187", Text="SuriText"},
            new SelectListItem { Value="188", Text="Svalbard And Jan Mayen Islands"},
            new SelectListItem { Value="189", Text="Swaziland"},
            new SelectListItem { Value="190", Text="Sweden"},
            new SelectListItem { Value="191", Text="Switzerland"},
            new SelectListItem { Value="192", Text="Syria"},
            new SelectListItem { Value="193", Text="Taiwan"},
            new SelectListItem { Value="194", Text="Tajikistan"},
            new SelectListItem { Value="195", Text="Tanzania"},
            new SelectListItem { Value="196", Text="Thailand"},
            new SelectListItem { Value="197", Text="Togo"},
            new SelectListItem { Value="198", Text="Tokelau"},
            new SelectListItem { Value="199", Text="Tonga"},
            new SelectListItem { Value="200", Text="TrinValuead And Tobago"},
            new SelectListItem { Value="201", Text="Tunisia"},
            new SelectListItem { Value="202", Text="Turkey"},
            new SelectListItem { Value="203", Text="Turkmenistan"},
            new SelectListItem { Value="204", Text="Tuvalu"},
            new SelectListItem { Value="205", Text="Uganda"},
            new SelectListItem { Value="206", Text="Ukraine"},
            new SelectListItem { Value="207", Text="United Arab Emirates"},
            new SelectListItem { Value="208", Text="United Kingdom"},
            new SelectListItem { Value="209", Text="United States"},
            new SelectListItem { Value="210", Text="Uruguay"},
            new SelectListItem { Value="211", Text="Uzbekistan"},
            new SelectListItem { Value="212", Text="Vanuatu"},
            new SelectListItem { Value="213", Text="Venezuela"},
            new SelectListItem { Value="214", Text="Vietnam"},
            new SelectListItem { Value="215", Text="Virgin Islands (British)"},
            new SelectListItem { Value="216", Text="Wallis And Futuna Islands"},
            new SelectListItem { Value="217", Text="Western Sahara"},
            new SelectListItem { Value="218", Text="Yemen"},
            new SelectListItem { Value="219", Text="Yugoslavia"},
            new SelectListItem { Value="220", Text="Zambia"},
            new SelectListItem { Value="221", Text="Zimbabwe"}
       });
        private static Lazy<List<SelectListItem>> elyafOrani = new Lazy<List<SelectListItem>>(() => {
            var list = new List<SelectListItem>();
            for (int i = 1; i <= 100; i++)
            {
                list.Add(new SelectListItem {
                    Text = i + "%",
                    Value = i.ToString()
                });
            }
            return list;
        });

 

        // GET: ZetaCodeNormalIplik
        public ActionResult Index()
        {
            var list = GetZetaCodeNormalIplikService().GetAllZetaCodeNormalIplikler();
            //var zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Include(z => z.PantoneRengi).Include(z => z.Renk);
            var model = new List<ZetaCodeNormalIplikVm>();
            foreach (var item in list)
            {
                model.Add(new ZetaCodeNormalIplikVm {
                    ZetaCodeNormalIplikDto = item
                });
            }
            return View(model);
        }

        // GET: ZetaCodeNormalIplik/Details/5

        // GET: ZetaCodeNormalIplik/Create

        public void FillCollections(ZetaCodeNormalIplikVm model,string sirketId="", string ulkeId = "",int pantoneRenkId=0,int renkId=0,int uretimTeknolojitermId=0)
        {
            model.Collections.Sirketler = new SelectList(GetCompanyService().GetParentCompanyIdAndNames(1), "Id", "Name", sirketId);
            var temp = Ulkeler.Value.Select(x => new SelectListItem() { Text = x.Text , Value = x.Value}).ToList();
            var ulke = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value,ulkeId.ToString()) == 0);
            if (ulke!=null)
            {
                ulke.Selected = true;
            }
            model.Collections.Ulkeler = temp;
            model.Collections.PantoneRenkleri = new SelectList(GetZetaCodeNormalIplikService().GetPantoneRenkler(), "Id", "PantoneKodu", pantoneRenkId);
            model.Collections.Renkler = new SelectList(GetZetaCodeNormalIplikService().GetRenkler(), "Id", "Ad", renkId);
            model.Collections.UretimTeknolojileri = new SelectList(GetTermService().GetTermsByTaxonomyId(25), "Id", "Name", uretimTeknolojitermId);
            model.NE = new IplikNoGuideMethod(GetSelectListNE);
            model.NM = new IplikNoGuideMethod(GetSelectListNM);
            model.DYN = new IplikNoGuideMethod(GetSelectListDYN);
            model.FL = new IplikNoGuideMethod(GetSelectListFL);
            model.EA = new IplikNoGuideMethod(GetSelectListEA);
            model.ElyafOrani = new ElyafOraniMethod(GetSelectListElyafOrani);

        }      
        public List<SelectListItem> GetSelectListNE(string value)
        {
            return GetSelectListIplikNoGuide(value, "NE");
        }
        public List<SelectListItem> GetSelectListNM(string value)
        {
            return GetSelectListIplikNoGuide(value, "NM");
        }
        public List<SelectListItem> GetSelectListDYN(string value)
        {
            return GetSelectListIplikNoGuide(value, "DNY");
        }
        public List<SelectListItem> GetSelectListFL(string value)
        {
            return GetSelectListIplikNoGuide(value, "FL");
        }
        public List<SelectListItem> GetSelectListEA(string value)
        {
            return GetSelectListIplikNoGuide(value, "EA");
        }


        public List<SelectListItem> GetSelectListElyafOrani(int? yuzde)
        {
            var temp = elyafOrani.Value.Select(x => new SelectListItem() { Text = x.Text, Value = x.Value }).ToList();
            if (yuzde.HasValue)
            {
                var entity = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, yuzde.ToString()) == 0);
                if (entity != null)
                {
                    entity.Selected = true;
                }
            }          
            return temp;
        }

        private List<SelectListItem> GetSelectListIplikNoGuide(string value, string columnName)
        {
            var guide = GetZetaCodeNormalIplikService().GetIplikNoGuideByColumnName(columnName);
            List<SelectListItem> temp  = null;

            if (string.Equals(columnName, "NE", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Ne.ToString(), Value = x.Ne.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "NM", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Nm.ToString(), Value = x.Nm.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "DNY", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Dny.ToString(), Value = x.Dny.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "FL", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Fl.ToString(), Value = x.Fl.ToString() }).ToList();
            }
            else if (string.Equals(columnName, "EA", StringComparison.OrdinalIgnoreCase))
            {
                temp = guide.Select(x => new SelectListItem() { Text = x.Ea.ToString(), Value = x.Ea.ToString() }).ToList();
            }


            if (!string.IsNullOrWhiteSpace(value))
            {
                var entity = temp.FirstOrDefault(x => string.CompareOrdinal(x.Value, value) == 0);
                if (entity != null)
                {
                    entity.Selected = true;
                }
            }          
            return temp;
        }
 

        public ActionResult Create()
        {
            var model = new ZetaCodeNormalIplikVm();
            FillCollections(model);            
            model.Operation = "insert";
            return View(viewName: "Edit", model: model);
        }

        public ActionResult GetBlueCompanyData(string companyId)
        {
            MyJsonResult jsonResult = new MyJsonResult();
            var company = GetCompanyService().GetCompanyCodeById(companyId);
            if (company != null)
            {
                var blueSequence = new Helezon.FollowMe.Entities.Models.SequenceBlueSiparisNo();
                blueSequence.BlueCompanyId = companyId;
                GetZetaCodeNormalIplikService().GetSequenceBlueSiparisNo(blueSequence);
                UnitOfWorkAsync.SaveChanges();
                jsonResult.Data = new { BlueCode = company.Code, SiparisNo = blueSequence.SiparisNo };
                jsonResult.SuccessMessage = "Sipariş No Hesaplandı";
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
            jsonResult.ErrorMessage = "Şirket Bulunamadı";
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JSTreeIplikKategoriler()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.IplikKategorileri);
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

        public ActionResult JSTreeElyafCinsiveKalitesi()
        {
            var data = GetTermService().GetJsTreeData("00000000-0000-0000-0000-000000000001", (int)TaxonomyType.ElyafCinsiveKalitesi);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // POST: ZetaCodeNormalIplik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZetaCodeNormalIplikVm model)
        {
            try
            {
                UnitOfWorkAsync.BeginTransaction();
                var entityZetaCodeNormalIplik = AutoMapperConfig.Mapper.Map<ZetaCodeNormalIplikDto, Helezon.FollowMe.Entities.Models.ZetaCodeNormalIplik>(model.ZetaCodeNormalIplikDto);
                GetZetaCodeNormalIplikService().Insert(entityZetaCodeNormalIplik);
                UnitOfWorkAsync.SaveChanges();
                foreach (var iplikNo in model.ZetaCodeNormalIplikDto.IplikNo)
                {
                    var entityIplikNo = AutoMapperConfig.Mapper.Map<IplikNoDto, Helezon.FollowMe.Entities.Models.IplikNo>(iplikNo);
                    entityIplikNo.ZetaCodeNormalIplikId = entityZetaCodeNormalIplik.Id;
                    GetIplikNoService().Insert(entityIplikNo);
                    UnitOfWorkAsync.SaveChanges();
                }
                UnitOfWorkAsync.Commit();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                UnitOfWorkAsync.Rollback();
                var newException = new FormattedDbEntityValidationException(e);
                Failure = newException.Message;
            }
            catch (Exception ex) {
                UnitOfWorkAsync.Rollback();
                Failure = ex.Message;
            }  
            //if (ModelState.IsValid)
            //{
            //    db.ZetaCodeNormalIplik.Add(zetaCodeNormalIplik);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.PantoneId = new SelectList(db.PantoneRenk, "Id", "PantoneKodu", zetaCodeNormalIplik.PantoneId);
            //ViewBag.Renkid = new SelectList(db.Renk, "Id", "HtmlKod", zetaCodeNormalIplik.Renkid);
            FillCollections(model);
            
            return View(viewName: "Edit", model: model);
        }

        // GET: ZetaCodeNormalIplik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZetaCodeNormalIplikDto zetaCodeNormalIplik = GetZetaCodeNormalIplikService().GetZetaCodeNormalIplikById(id.Value);
            if (zetaCodeNormalIplik == null)
            {
                return HttpNotFound();
            }
            var model = new ZetaCodeNormalIplikVm();
            model.Operation = "update";
            model.ZetaCodeNormalIplikDto = zetaCodeNormalIplik;
            FillCollections(model
                ,sirketId: zetaCodeNormalIplik.SirketId
                ,ulkeId:zetaCodeNormalIplik.Ulke
                ,pantoneRenkId: zetaCodeNormalIplik.PantoneId??0
                ,renkId: zetaCodeNormalIplik.Renkid??0,uretimTeknolojitermId:zetaCodeNormalIplik.UretimTeknolojisiId??0);

         
            return View(viewName:"Edit",model: model);
        }

        // POST: ZetaCodeNormalIplik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZetaCodeNormalIplik zetaCodeNormalIplik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zetaCodeNormalIplik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PantoneId = new SelectList(db.PantoneRenk, "Id", "PantoneKodu", zetaCodeNormalIplik.PantoneId);
            ViewBag.Renkid = new SelectList(db.Renk, "Id", "HtmlKod", zetaCodeNormalIplik.Renkid);
            return View(viewName: "Edit", model: zetaCodeNormalIplik);
        }

        //// GET: ZetaCodeNormalIplik/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    if (zetaCodeNormalIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeNormalIplik);
        //}

        //// POST: ZetaCodeNormalIplik/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    db.ZetaCodeNormalIplik.Remove(zetaCodeNormalIplik);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ZetaCodeNormalIplik zetaCodeNormalIplik = db.ZetaCodeNormalIplik.Find(id);
        //    if (zetaCodeNormalIplik == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(zetaCodeNormalIplik);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
