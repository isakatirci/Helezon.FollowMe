using FollowMe.Web.Infrastructure;
using FollowMe.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static FollowMe.Web.Controllers.Utils;

namespace FollowMe.Web.Controllers
{
    public class GuideBookController : BaseController
    {
        public enum CompanyFieldOrdinal
        {
            None,
            CompanyTelephoneId,
            CompanyTelephoneCompanyId,
            CompanyTelephoneTelephoneTypeId,
            CompanyTelephoneNumber,
            CompanyTelephoneAreaCode,
            CompanyTelephoneInterphone,
            CompanyTelephoneIsPassive,
            CompanyTelephoneCreatedOn,
            CompanyTelephoneCreatedBy,
            CompanyTelephoneChangedOn,
            CompanyTelephoneChangedBy,
            CompanyAddressId,
            CompanyAddressCompanyId,
            CompanyAddressAddressType,
            CompanyAddressProvince,
            CompanyAddressDistrict,
            CompanyAddressCountry,
            CompanyAddressLine1,
            CompanyAddressLine2,
            CompanyAddressZipCode,
            CompanyAddressSuburbArea,
            CompanyAddressTown,
            CompanyAddressIsPassive,
            CompanyAddressCreatedOn,
            CompanyAddressCreatedBy,
            CompanyAddressChangedOn,
            CompanyAddressChangedBy,
            CompanyId,
            CompanyCompanyRootTypeId,
            CompanyCode,
            CompanyName,
            CompanyEmail,
            CompanyCompanyTitle,
            CompanyBrand,
            CompanyTaxNumber,
            CompanyTaxOffice,
            CompanyTradeRegisterNumber,
            CompanyFoundingDate,
            CompanyIsWebsiteAvailable,
            CompanyWebsite,
            CompanyReasonWhyPassiveId,
            CompanyReasonWhyPassiveTermName,
            CompanyPersonLimit,
            CompanyPersonLimitPercent,
            CompanyServiceStartDate,
            CompanyServiceEndDate,
            CompanyIsPassive,
            CompanyCreatedOn,
            CompanyCreatedBy,
            CompanyChangedOn,
            CompanyChangedBy
        }
        private static List<CompanyField> _companyFields = new List<CompanyField>
        {
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneId,             columnName =   "CompanyTelephone.Id",                 columnDisplayName =   "CompanyTelephoneId" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneCompanyId,      columnName =   "CompanyTelephone.CompanyId",          columnDisplayName =   "CompanyTelephoneCompanyId" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneTelephoneTypeId,columnName =   "CompanyTelephone.TelephoneTypeId",    columnDisplayName =   "Telephone Type Id" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneNumber,         columnName =   "CompanyTelephone.Number",             columnDisplayName =   "Telephone Number" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneAreaCode,       columnName =   "CompanyTelephone.AreaCode",           columnDisplayName =   "Telephone Area Code" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneInterphone,     columnName =   "CompanyTelephone.Interphone",         columnDisplayName =   "Telephone Interphone" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneIsPassive,      columnName =   "CompanyTelephone.IsPassive",          columnDisplayName =   "CompanyTelephoneIsPassive" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneCreatedOn,      columnName =   "CompanyTelephone.CreatedOn",          columnDisplayName =   "CompanyTelephoneCreatedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneCreatedBy,      columnName =   "CompanyTelephone.CreatedBy",          columnDisplayName =   "CompanyTelephoneCreatedBy" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneChangedOn,      columnName =   "CompanyTelephone.ChangedOn",          columnDisplayName =   "CompanyTelephoneChangedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTelephoneChangedBy,      columnName =   "CompanyTelephone.ChangedBy",          columnDisplayName =   "CompanyTelephoneChangedBy" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressId,               columnName =   "CompanyAddress.Id",                   columnDisplayName =   "CompanyAddressId" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressCompanyId,        columnName =   "CompanyAddress.CompanyId",            columnDisplayName =   "CompanyAddressCompanyId" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressAddressType,      columnName =   "CompanyAddress.AddressType",          columnDisplayName =   "Address Type" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressProvince,         columnName =   "CompanyAddress.Province",             columnDisplayName =   "Address Province" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressDistrict,         columnName =   "CompanyAddress.District",             columnDisplayName =   "Address District" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressCountry,          columnName =   "CompanyAddress.Country",              columnDisplayName =   "Address Country" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressLine1,            columnName =   "CompanyAddress.Line1",                columnDisplayName =   "Address Line1" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressLine2,            columnName =   "CompanyAddress.Line2",                columnDisplayName =   "Address Line2" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressZipCode,          columnName =   "CompanyAddress.ZipCode",              columnDisplayName =   "Address ZipCode" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressSuburbArea,       columnName =   "CompanyAddress.SuburbArea",           columnDisplayName =   "Address SuburbArea" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressTown,             columnName =   "CompanyAddress.Town",                 columnDisplayName =   "Address Town" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressIsPassive,        columnName =   "CompanyAddress.IsPassive",            columnDisplayName =   "CompanyAddressIsPassive" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressCreatedOn,        columnName =   "CompanyAddress.CreatedOn",            columnDisplayName =   "CompanyAddressCreatedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressCreatedBy,        columnName =   "CompanyAddress.CreatedBy",            columnDisplayName =   "CompanyAddressCreatedBy" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressChangedOn,        columnName =   "CompanyAddress.ChangedOn",            columnDisplayName =   "CompanyAddressChangedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyAddressChangedBy,        columnName =   "CompanyAddress.ChangedBy",            columnDisplayName =   "CompanyAddressChangedBy" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyId,                      columnName =   "Company.Id",                          columnDisplayName =   "CompanyId" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyCompanyRootTypeId,       columnName =   "Company.CompanyRootTypeId",           columnDisplayName =   "Company Root Type Id" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyCode,                    columnName =   "Company.Code",                        columnDisplayName =   "CompanyCode" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyName,                    columnName =   "Company.Name",                        columnDisplayName =   "CompanyName" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyEmail,                   columnName =   "Company.Email",                       columnDisplayName =   "Company Email" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyCompanyTitle,            columnName =   "Company.CompanyTitle",                columnDisplayName =   "Company Title" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyBrand,                   columnName =   "Company.Brand",                       columnDisplayName =   "Company Brand" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTaxNumber,               columnName =   "Company.TaxNumber",                   columnDisplayName =   "Company Tax Number" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTaxOffice,               columnName =   "Company.TaxOffice",                   columnDisplayName =   "Company Tax Office" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyTradeRegisterNumber,     columnName =   "Company.TradeRegisterNumber",         columnDisplayName =   "Company Trade Register Number" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyFoundingDate,            columnName =   "Company.FoundingDate",                columnDisplayName =   "Company Founding Date" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyIsWebsiteAvailable,      columnName =   "Company.IsWebsiteAvailable",          columnDisplayName =   "Company Is Website Available" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyWebsite,                 columnName =   "Company.Website",                     columnDisplayName =   "Company Website" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyReasonWhyPassiveId,      columnName =   "Company.ReasonWhyPassiveId",          columnDisplayName = "Company ReasonWhy Passive Id" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyReasonWhyPassiveTermName,columnName =   "Company.ReasonWhyPassiveTermName",    columnDisplayName =   "Company Reason Why Passive" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyPersonLimit,             columnName =   "Company.PersonLimit",                 columnDisplayName =   "Company Person Limit" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyPersonLimitPercent,      columnName =   "Company.PersonLimitPercent",          columnDisplayName =   "Company Person Limit Percent" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyServiceStartDate,        columnName =   "Company.ServiceStartDate",            columnDisplayName =   "Company Service Start Date" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyServiceEndDate,          columnName =   "Company.ServiceEndDate",              columnDisplayName =   "Company Service End Date" },
             new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyIsPassive,               columnName =   "Company.IsPassive",                   columnDisplayName =   "Company Is Passive" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyCreatedOn,               columnName =   "Company.CreatedOn",                   columnDisplayName =   "CompanyCreatedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyCreatedBy,               columnName =   "Company.CreatedBy",                   columnDisplayName =   "CompanyCreatedBy" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyChangedOn,               columnName =   "Company.ChangedOn",                   columnDisplayName =   "CompanyChangedOn" },
             //new CompanyField { ordinalPosition = CompanyFieldOrdinal.CompanyChangedBy,               columnName =   "Company.ChangedBy",                   columnDisplayName =   "CompanyChangedBy" },

        };

        public GuideBookController()
        {

        }

        [HttpPost]
        public JsonResult SaveCompanyFieldLists(string companyDisabledFieldList, string companyEnabledFieldList)
        {
            var response = new AjaxCustomeResponse();          

            if (companyDisabledFieldList.IsNullOrWhiteSpace() || companyEnabledFieldList.IsNullOrWhiteSpace())
            {
                response.IsFailed = true;
                response.Message = "Listeler Biri yada Bir Kaçı Boş Gönderildi";
                return Json(response, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var existingCompanyDisabledField = db.JsonObject.FirstOrDefault(x => x.CompanyId == Guid.Empty.ToString() && x.JsonTypeId == (int)JsonObjectTypes.CompanyDisabledField);
                var existingCompanyEnabledField = db.JsonObject.FirstOrDefault(x => x.CompanyId == Guid.Empty.ToString() && x.JsonTypeId == (int)JsonObjectTypes.CompanyEnabledField);

                if (existingCompanyDisabledField != null)
                {
                    existingCompanyDisabledField.Json = companyDisabledFieldList;
                }
                else
                {
                    db.JsonObject.Add(new Models.JsonObject
                    {
                        CompanyId = Guid.Empty.ToString(),
                        Json = companyDisabledFieldList,
                        JsonTypeId = (int)JsonObjectTypes.CompanyDisabledField
                    });
                }

                if (existingCompanyEnabledField != null)
                {
                    existingCompanyEnabledField.Json = companyEnabledFieldList;
                }
                else
                {
                    db.JsonObject.Add(new Models.JsonObject
                    {
                        CompanyId = Guid.Empty.ToString(),
                        Json = companyEnabledFieldList,
                        JsonTypeId = (int)JsonObjectTypes.CompanyEnabledField
                    });
                }

                db.SaveChanges();
                response.Message = "Listeler Kaydedildi";
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.ToString();
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private int FindDescendantCount(int type)
        {
            var sb = new System.Text.StringBuilder(302);
            sb.AppendLine(@"WITH A(Id, ParentId) AS");
            sb.AppendLine(@"  ( SELECT t.TermId,");
            sb.AppendLine(@"           t.Parent");
            sb.AppendLine(@"   FROM TermTaxonomy t");
            sb.AppendLine(@"   WHERE t.Parent = @ParentId");
            sb.AppendLine(@"     AND t.TaxonomyId = 8");
            sb.AppendLine(@"   UNION ALL SELECT t.TermId,");
            sb.AppendLine(@"                    p.ParentId");
            sb.AppendLine(@"   FROM TermTaxonomy t");
            sb.AppendLine(@"   JOIN A p ON t.Parent = p.Id");
            sb.AppendLine(@"   WHERE TaxonomyId = 8 )");
            sb.AppendLine(@"SELECT Id");
            sb.AppendLine(@"FROM A;");
            var temp = db.Database.SqlQuery<int>(sb.ToString(), new SqlParameter("ParentId", type)).ToArray();
            if (temp != null && temp.Any())
                return db.TermRelationship.Count(x => temp.Contains(x.TermId));
            return 0;
        }
        public ActionResult DashBoard()
        {
            return View(viewName: "Index");
        }


        public class CompanyField
        {
            public CompanyFieldOrdinal ordinalPosition { get; set; }
            public string columnName { get; set; }
            public string columnDisplayName { get; set; }
        }

        public class CompanyFieldComparer : IEqualityComparer<CompanyField>
        {
            public bool Equals(CompanyField x, CompanyField y)
            {

                //Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return x.ordinalPosition == y.ordinalPosition && x.columnName == y.columnName;
            }

            // If Equals() returns true for a pair of objects 
            // then GetHashCode() must return the same value for these objects.

            public int GetHashCode(CompanyField field)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(field, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = field.columnName == null ? 0 : field.columnName.GetHashCode();

                int hashProductCode = field.ordinalPosition.GetHashCode();

                return hashProductName ^ hashProductCode;
            }

        }

        public ActionResult PartialCompanyList(int? type)
        {
            var disabledFields = db.JsonObject.FirstOrDefault(x => x.CompanyId == Guid.Empty.ToString()
                && x.JsonTypeId == (int)JsonObjectTypes.CompanyDisabledField);

            var enabledFields = db.JsonObject.FirstOrDefault(x => x.CompanyId == Guid.Empty.ToString()
                 && x.JsonTypeId == (int)JsonObjectTypes.CompanyEnabledField);

            List<CompanyField> jsonDisabled = new List<CompanyField>();
            List<CompanyField> jsonEnabled = new List<CompanyField>();

            if (disabledFields != null
                && disabledFields.Json.IsNullOrWhiteSpace().Not()
                && string.Equals(disabledFields.Json, "[]", StringComparison.InvariantCultureIgnoreCase).Not())
            {
                jsonDisabled = JsonConvert.DeserializeObject<List<CompanyField>>(disabledFields.Json) ?? new List<CompanyField>();
            }

            if (enabledFields != null
              && enabledFields.Json.IsNullOrWhiteSpace().Not()
              && string.Equals(enabledFields.Json, "[]", StringComparison.InvariantCultureIgnoreCase).Not())
            {
                jsonEnabled = JsonConvert.DeserializeObject<List<CompanyField>>(enabledFields.Json) ?? new List<CompanyField>();
            }

            ViewBag.JsonEnabled = jsonEnabled;
            ViewBag.CompanyFields = _companyFields.Except(jsonEnabled, new CompanyFieldComparer()).ToList();

            var tempJsonEnabled = jsonEnabled.Select(x => x.columnName.Trim()).ToList();
            tempJsonEnabled.Insert(0, "Company.Id");
            tempJsonEnabled.Insert(1, "Company.Code");
            tempJsonEnabled.Insert(2, "Company.Name");
            tempJsonEnabled.Insert(3, "Company.IsPassive");
            tempJsonEnabled.Insert(4, "CompanyTelephone.Id AS CompanyTelephoneId");
            tempJsonEnabled.Insert(5, "CompanyAddress.Id AS CompanyAddressId");
            var columns = string.Join(", ", tempJsonEnabled);
            var selectCommand = new System.Text.StringBuilder(561);
            selectCommand.AppendLine(@"SELECT ");
            selectCommand.AppendLine(columns);
            selectCommand.AppendLine(@"FROM Company");
            selectCommand.AppendLine(@"LEFT JOIN CompanyTelephone ON Company.Id = CompanyTelephone.CompanyId");
            selectCommand.AppendLine(@"LEFT JOIN CompanyAddress ON Company.Id = CompanyAddress.CompanyId");

            if (type.HasValue)
            {
                var sb = new System.Text.StringBuilder(390);
                sb.AppendLine(@"WITH A(TermId, ParentId) AS");
                sb.AppendLine(@"  (SELECT t.TermId,");
                sb.AppendLine(@"          t.Parent");
                sb.AppendLine(@"   FROM TermTaxonomy t");
                sb.AppendLine(@"   WHERE t.Parent =  @ParentId");
                sb.AppendLine(@"     AND t.TaxonomyId = 8");
                sb.AppendLine(@"   UNION ALL SELECT t.TermId,");
                sb.AppendLine(@"                    p.ParentId");
                sb.AppendLine(@"   FROM TermTaxonomy t");
                sb.AppendLine(@"   JOIN A p ON t.Parent = p.TermId");
                sb.AppendLine(@"   WHERE TaxonomyId = 8 )");
                sb.AppendLine(@"SELECT s.CompanyId");
                sb.AppendLine(@"FROM TermRelationship s");
                sb.AppendLine(@"WHERE s.TermId IN");
                sb.AppendLine(@"    (SELECT TermId");
                sb.AppendLine(@"     FROM A)");

                var temp = db.Database.SqlQuery<string>(sb.ToString(), new SqlParameter("ParentId", type)).Distinct().Select(x => "'" + x + "'").ToArray();

                if (temp.IsEmpty().Not())
                {
                    selectCommand.AppendLine(@"WHERE Company.Id IN (##Id##)".Replace("##Id##", string.Join(", ", temp)));
                    selectCommand.AppendLine(@"ORDER BY Company.CreatedOn DESC");

                    var sql = selectCommand.ToString();
                    var table = AdoHelper.FillDataTable(sql);
                    return PartialView(viewName: "_CompanyList", model: table);
                }
                else
                {
                    selectCommand.AppendLine(@"WHERE  1 = 0 ");
                    selectCommand.AppendLine(@"ORDER BY Company.CreatedOn DESC");

                    var table = AdoHelper.FillDataTable(selectCommand.ToString());
                    return PartialView(viewName: "_CompanyList", model: table);
                }
            }

            selectCommand.AppendLine(@"WHERE  1 = 1 ");
            selectCommand.AppendLine(@"ORDER BY Company.CreatedOn DESC");

            var companyTable = AdoHelper.FillDataTable(selectCommand.ToString());
            var tempCompanyIds = new HashSet<string>();
            var tempRows = new HashSet<DataRow>();
            foreach (DataRow row in companyTable.Rows)
            {
                var companyId = row[0].ToString();
                if (!tempCompanyIds.Contains(companyId))
                {
                    tempCompanyIds.Add(companyId);
                    continue;
                }
                tempRows.Add(row);
            }

            foreach (var row in tempRows)
            {
                companyTable.Rows.Remove(row);
            }

            return PartialView(viewName: "_CompanyList", model: companyTable);


        }

        public ActionResult Index()
        {
            //<select class="form-control  select2  select2-hidden-accessible" data-val="true" data-val-number="The field CompanyRootTypeId must be a number." id="CompanyRootTypeId" name="CompanyRootTypeId" tabindex="-1" aria-hidden="true"><option value="">Please Select</option>
            //<option value="1">BLUE</option>
            //<option value="2">RED</option>
            //<option value="11">OTHER</option>
            //<option value="3">ZETAA</option>
            //</select>

            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        // GET: GuideBook
        public ActionResult Blue()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueType.Iplikci);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueType.Kumas);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueType.Aksesuarci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueType.HazirGiyimci);
            ViewBag.CompanyType = (int)CompanyRootType.Blue;
            ViewBag.BlueHref = Url.Action("BlueIplikci", "GuideBook");
            ViewBag.BlueDesc = "İplikçi";
            ViewBag.RedHref = Url.Action("BlueKumascilar", "GuideBook");
            ViewBag.RedDesc = "Kumaşcılar";
            ViewBag.OthersHref = Url.Action("BlueAksesuarcilar", "GuideBook");
            ViewBag.OthersDesc = "Aksesuarcılar";
            ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimci", "GuideBook");
            ViewBag.ZetaaDesc = "HazirGiyimci";
            return View(viewName: "Index");
        }

        public ActionResult Red()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedType.Iplikci);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedType.Kumasci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedType.Aksesuarci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedType.HazirGiyimci);
            ViewBag.CompanyType = (int)CompanyRootType.Red;
            ViewBag.BlueHref = Url.Action("RedIplikci", "GuideBook");
            ViewBag.BlueDesc = "İplikçi";
            ViewBag.RedHref = Url.Action("RedKumascilar", "GuideBook");
            ViewBag.RedDesc = "Kumaşcı";
            ViewBag.OthersHref = Url.Action("RedAksesuarcilar", "GuideBook");
            ViewBag.OthersDesc = "Aksesuarcılar";
            ViewBag.ZetaaHref = Url.Action("RedHazirGiyimci", "GuideBook");
            ViewBag.ZetaaDesc = "HazirGiyimci";
            return View(viewName: "Index");
        }

        public ActionResult Zetaa()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyZetaaType.Merkez);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyZetaaType.YurtDisiOfis);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyZetaaType.YurtIciOfis);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyZetaaType.Depo);
            ViewBag.CompanyType = (int)CompanyRootType.Zetaa;
            ViewBag.BlueHref = Url.Action("ZetaaMerkez", "GuideBook");
            ViewBag.BlueDesc = "Merkez";
            ViewBag.RedHref = Url.Action("ZetaaYurtDisiOfis", "GuideBook");
            ViewBag.RedDesc = "Yurt Dışı Ofis";
            ViewBag.OthersHref = Url.Action("ZetaaYurtIciOfis", "GuideBook");
            ViewBag.OthersDesc = "Yurt İçi Ofis";
            ViewBag.ZetaaHref = Url.Action("ZetaaDepo", "GuideBook");
            ViewBag.ZetaaDesc = "Depo";
            return View(viewName: "Index");
        }

        public ActionResult ZetaaMerkez()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyZetaaType.Merkez);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyZetaaType.YurtDisiOfis);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyZetaaType.YurtIciOfis);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyZetaaType.Depo);
            ViewBag.CompanyType = (int)CompanyZetaaType.Merkez;

            ViewBag.BlueHref = Url.Action("ZetaaMerkez", "GuideBook");
            ViewBag.BlueDesc = "Merkez";
            //ViewBag.RedHref = Url.Action("ZetaaYurtDisiOfis", "GuideBook");
            //ViewBag.RedDesc = "Yurt Dışı Ofis";
            //ViewBag.OthersHref = Url.Action("ZetaaYurtIciOfis", "GuideBook");
            //ViewBag.OthersDesc = "Yurt İçi Ofis";
            //ViewBag.ZetaaHref = Url.Action("ZetaaDepo", "GuideBook");
            //ViewBag.ZetaaDesc = "Depo";

            return View(viewName: "Index");
        }

        public ActionResult ZetaaYurtDisiOfis()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyZetaaType.Merkez);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyZetaaType.YurtDisiOfis);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyZetaaType.YurtIciOfis);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyZetaaType.Depo);
            ViewBag.CompanyType = (int)CompanyZetaaType.YurtDisiOfis;

            //ViewBag.BlueHref = Url.Action("ZetaaMerkez", "GuideBook");
            //ViewBag.BlueDesc = "Merkez";
            ViewBag.RedHref = Url.Action("ZetaaYurtDisiOfis", "GuideBook");
            ViewBag.RedDesc = "Yurt Dışı Ofis";
            //ViewBag.OthersHref = Url.Action("ZetaaYurtIciOfis", "GuideBook");
            //ViewBag.OthersDesc = "Yurt İçi Ofis";
            //ViewBag.ZetaaHref = Url.Action("ZetaaDepo", "GuideBook");
            //ViewBag.ZetaaDesc = "Depo";
            return View(viewName: "Index");
        }


        public ActionResult ZetaaDepo()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyZetaaType.Merkez);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyZetaaType.YurtDisiOfis);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyZetaaType.YurtIciOfis);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyZetaaType.Depo);
            ViewBag.CompanyType = (int)CompanyZetaaType.Depo;

            //ViewBag.BlueHref = Url.Action("ZetaaMerkez", "GuideBook");
            //ViewBag.BlueDesc = "Merkez";
            //ViewBag.RedHref = Url.Action("ZetaaYurtDisiOfis", "GuideBook");
            //ViewBag.RedDesc = "Yurt Dışı Ofis";
            //ViewBag.OthersHref = Url.Action("ZetaaYurtIciOfis", "GuideBook");
            //ViewBag.OthersDesc = "Yurt İçi Ofis";
            ViewBag.ZetaaHref = Url.Action("ZetaaDepo", "GuideBook");
            ViewBag.ZetaaDesc = "Depo";
            return View(viewName: "Index");
        }

        public ActionResult ZetaaYurtIciOfis()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyZetaaType.Merkez);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyZetaaType.YurtDisiOfis);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyZetaaType.YurtIciOfis);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyZetaaType.Depo);
            ViewBag.CompanyType = (int)CompanyZetaaType.YurtIciOfis;

            //ViewBag.BlueHref = Url.Action("ZetaaMerkez", "GuideBook");
            //ViewBag.BlueDesc = "Merkez";
            //ViewBag.RedHref = Url.Action("ZetaaYurtDisiOfis", "GuideBook");
            //ViewBag.RedDesc = "Yurt Dışı Ofis";
            ViewBag.OthersHref = Url.Action("ZetaaYurtIciOfis", "GuideBook");
            ViewBag.OthersDesc = "Yurt İçi Ofis";
            //ViewBag.ZetaaHref = Url.Action("ZetaaDepo", "GuideBook");
            //ViewBag.ZetaaDesc = "Depo";
            return View(viewName: "Index");
        }

        public ActionResult Others()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyOthersType.HizmetSaglayicilar);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyOthersType.UrunSaglayicilar);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyOthersType.ResmiveDevletKurumlari);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyOthersType.DigerSektorler);
            ViewBag.CompanyType = (int)CompanyRootType.Others;
            ViewBag.BlueHref = Url.Action("OthersHizmetSaglayicilar", "GuideBook");
            ViewBag.BlueDesc = "Hizmet Sağlayıcılar";
            ViewBag.RedHref = Url.Action("OthersUrunSaglayicilar", "GuideBook");
            ViewBag.RedDesc = "Ürün Sağlayıcılar";
            ViewBag.OthersHref = Url.Action("OthersResmiveDevletKurumlari", "GuideBook");
            ViewBag.OthersDesc = "Resmi ve Devlet Kurumları";
            ViewBag.ZetaaHref = Url.Action("OthersDigerSektorler", "GuideBook");
            ViewBag.ZetaaDesc = "Diğer Sektörler";
            return View(viewName: "Index");
        }


        public ActionResult OthersHizmetSaglayicilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.Muhasebe);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.Lojistik);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.GumruklemeHizmeti);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.Avukatlik);
            ViewBag.BlueCounter2 = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.Renklam);
            ViewBag.RedCounter2 = FindDescendantCount((int)CompanyOthersHizmetSaglayicilar.Banka);

            ViewBag.CompanyType = (int)CompanyOthersType.HizmetSaglayicilar;

            ViewBag.BlueHref = Url.Action("OthersHizmetSaglayicilarMuhasebe", "GuideBook");
            ViewBag.BlueDesc = "Muhasebe";
            ViewBag.RedHref = Url.Action("OthersHizmetSaglayicilarLojistik", "GuideBook");
            ViewBag.RedDesc = "Lojistik";
            ViewBag.OthersHref = Url.Action("OthersHizmetSaglayicilarGumruklemeHizmeti", "GuideBook");
            ViewBag.OthersDesc = "Gümrükleme Hizmeti";
            ViewBag.ZetaaHref = Url.Action("OthersHizmetSaglayicilarAvukatlik", "GuideBook");
            ViewBag.ZetaaDesc = "Avukatlik";
            ViewBag.BlueHref2 = Url.Action("OthersHizmetSaglayicilarRenklam", "GuideBook");
            ViewBag.BlueDesc2 = "Renklam";
            ViewBag.RedHref2 = Url.Action("OthersHizmetSaglayicilarBanka", "GuideBook");
            ViewBag.RedDesc2 = "Banka";

            return View(viewName: "Index");
        }

        public ActionResult OthersHizmetSaglayicilarMuhasebe()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersHizmetSaglayicilarLojistik()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersHizmetSaglayicilarGumruklemeHizmeti()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersHizmetSaglayicilarAvukatlik()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersHizmetSaglayicilarRenklam()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersHizmetSaglayicilarBanka()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersUrunSaglayicilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.Gida);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.Arac);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.KonaklamaveUlasim);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.SigortaPolice);
            ViewBag.BlueCounter2 = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.Kurumlar);
            ViewBag.RedCounter2 = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.SaglikveBakim);
            ViewBag.OthersCounter2 = FindDescendantCount((int)CompanyOthersUrunSaglayicilar.Ofis);

            ViewBag.CompanyType = (int)CompanyOthersType.UrunSaglayicilar;

            ViewBag.BlueHref = Url.Action("OthersUrunSaglayicilarGida", "GuideBook");
            ViewBag.BlueDesc = "Gida";
            ViewBag.RedHref = Url.Action("OthersUrunSaglayicilarArac", "GuideBook");
            ViewBag.RedDesc = "Arac";
            ViewBag.OthersHref = Url.Action("OthersUrunSaglayicilarKonaklamaveUlasim", "GuideBook");
            ViewBag.OthersDesc = "KonaklamaveUlasim";
            ViewBag.ZetaaHref = Url.Action("COthersUrunSaglayicilarSigortaPolice", "GuideBook");
            ViewBag.ZetaaDesc = "SigortaPolice";
            ViewBag.BlueHref2 = Url.Action("OthersUrunSaglayicilarKurumlar", "GuideBook");
            ViewBag.BlueDesc2 = "Kurumlar";
            ViewBag.RedHref2 = Url.Action("OthersUrunSaglayicilarSaglikveBakim", "GuideBook");
            ViewBag.RedDesc2 = "SaglikveBakim";
            ViewBag.OthersHref2 = Url.Action("OthersUrunSaglayicilarOfis", "GuideBook");
            ViewBag.OthersDesc2 = "Ofis";

            return View(viewName: "Index");
        }

        public ActionResult OthersUrunSaglayicilarGida()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersUrunSaglayicilarArac()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersUrunSaglayicilarKonaklamaveUlasim()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult COthersUrunSaglayicilarSigortaPolice()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersUrunSaglayicilarKurumlar()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersUrunSaglayicilarSaglikveBakim()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersUrunSaglayicilarOfis()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }


        public ActionResult OthersResmiveDevletKurumlari()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyOthersResmiveDevletKurumlari.Noter);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyOthersResmiveDevletKurumlari.MaliMusavir);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyOthersResmiveDevletKurumlari.TercumeBurolari);

            ViewBag.CompanyType = (int)CompanyOthersType.ResmiveDevletKurumlari;

            ViewBag.BlueHref = Url.Action("OthersResmiveDevletKurumlariNoter", "GuideBook");
            ViewBag.BlueDesc = "Noter";
            ViewBag.RedHref = Url.Action("OthersResmiveDevletKurumlariMaliMusavir", "GuideBook");
            ViewBag.RedDesc = "MaliMusavir";
            ViewBag.OthersHref = Url.Action("OthersResmiveDevletKurumlariTercumeBurolari", "GuideBook");
            ViewBag.OthersDesc = "TercumeBurolari";

            return View(viewName: "Index");
        }

        public ActionResult OthersResmiveDevletKurumlariNoter()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersResmiveDevletKurumlariMaliMusavir()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }
        public ActionResult OthersResmiveDevletKurumlariTercumeBurolari()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersDigerSektorler()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyOthersDigerSektorler.KagitSektoru);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyOthersDigerSektorler.PlastikSektoru);

            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("OthersDigerSektorlerKagitSektoru", "GuideBook");
            ViewBag.BlueDesc = "KagitSektoru";
            ViewBag.RedHref = Url.Action("OthersDigerSektorlerPlastikSektoru", "GuideBook");
            ViewBag.RedDesc = "PlastikSektoru";    

            return View(viewName: "Index");
        }

        public ActionResult OthersDigerSektorlerKagitSektoru()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }

        public ActionResult OthersDigerSektorlerPlastikSektoru()
        {
            ViewBag.BlueCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Blue);
            ViewBag.RedCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Red);
            ViewBag.OthersCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Others);
            ViewBag.ZetaaCounter = db.Company.Count(x => x.CompanyRootTypeId == (int)CompanyRootType.Zetaa);
            ViewBag.CompanyType = (int)CompanyOthersType.DigerSektorler;

            ViewBag.BlueHref = Url.Action("Blue", "GuideBook");
            ViewBag.BlueDesc = "Blue";
            ViewBag.RedHref = Url.Action("Red", "GuideBook");
            ViewBag.RedDesc = "Red";
            ViewBag.OthersHref = Url.Action("Others", "GuideBook");
            ViewBag.OthersDesc = "Others";
            ViewBag.ZetaaHref = Url.Action("Zetaa", "GuideBook");
            ViewBag.ZetaaDesc = "Zetaa";
            return View(viewName: "Index");
        }



        //***************************************//

        public ActionResult BlueIplikci()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueIplikciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueIplikciType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueIplikciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueIplikciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueType.Iplikci;

            ViewBag.BlueHref = Url.Action("BlueIplikciIplikUretici", "GuideBook");
            ViewBag.BlueDesc = "İplik Üretici";
            ViewBag.RedHref = Url.Action("BlueIplikciIplikBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "İplik Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueIplikciIplikTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "İplik Tedarikcisi";
            ViewBag.ZetaaHref =  Url.Action("BlueIplikciIplikIthalatci", "GuideBook");
            ViewBag.ZetaaDesc = "İplik Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueKumascilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueKumasType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueKumasType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueKumasType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueKumasType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueType.Kumas;

            ViewBag.BlueHref = Url.Action("BlueKumascilarKumasUretici", "GuideBook");
            ViewBag.BlueDesc = "Kumaş Üretici";
            ViewBag.RedHref = Url.Action("BlueKumascilarKumasBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Kumaş Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueKumascilarKumasTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueKumascilarKumasIthalatci", "GuideBook");
            ViewBag.ZetaaDesc = "Kumaş İthalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueAksesuarcilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueType.Aksesuarci;

            ViewBag.BlueHref = Url.Action("BlueAksesuarcilarAksesuarUretici", "GuideBook");
            ViewBag.BlueDesc = "Aksesuar Üretici";
            ViewBag.RedHref = Url.Action("BlueAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Aksesuar Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueAksesuarcilarAksesuarIthalatci", "GuideBook");
            ViewBag.ZetaaDesc = "Aksesuar Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueHazirGiyimci()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ureticisi);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Boyahanesi);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ithalatcisi);
            ViewBag.CompanyType = (int)CompanyBlueType.HazirGiyimci;

            ViewBag.BlueHref = Url.Action("BlueHazirGiyimciHazirGiyimUretici", "GuideBook");
            ViewBag.BlueDesc = "Hazır Giyim Üretici";
            ViewBag.RedHref = Url.Action("BlueHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Hazır Giyim Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            ViewBag.ZetaaDesc = "Hazır Giyim ithalatcisi";
            return View(viewName: "Index");
        }
        //*************************************//

        public ActionResult BlueIplikciIplikIthalatci()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueIplikciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueIplikciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueIplikciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueIplikciType.Ithalatci;

            //ViewBag.BlueHref = Url.Action("BlueIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("BlueIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "İplik Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueIplikciIplikIthalatci", "GuideBook");
            ViewBag.ZetaaDesc = "İplik Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueIplikciIplikUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueIplikciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueIplikciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueIplikciType.Uretici;

            ViewBag.BlueHref = Url.Action("BlueIplikciIplikUretici", "GuideBook");
            ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("BlueIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "İplik Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueIplikciIplikIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueIplikciIplikBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueIplikciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueIplikciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueIplikciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueIplikciType.Boyahane;

            //ViewBag.BlueHref = Url.Action("BlueIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            ViewBag.RedHref = Url.Action("BlueIplikciIplikBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "İplik Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueIplikciIplikIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueIplikciIplikTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueIplikciType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueIplikciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueIplikciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("BlueIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("BlueIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "İplik Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueIplikciIplikTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueIplikciIplikIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Ithalatci";
            return View(viewName: "Index");
        }

        //****************************************/
        public ActionResult BlueKumascilarKumasUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueKumasType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueKumasType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueKumasType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueKumasType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueKumasType.Uretici;

            ViewBag.BlueHref = Url.Action("BlueKumascilarKumasUretici", "GuideBook");
            ViewBag.BlueDesc = "Kumaş Üretici";
            //ViewBag.RedHref = Url.Action("BlueKumascilarKumasBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Kumaş Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueKumascilarKumasTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş İthalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueKumascilarKumasBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueKumasType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueKumasType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueKumasType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueKumasType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueKumasType.Boyahane;

            //ViewBag.BlueHref = Url.Action("BlueKumascilarKumasUretici", "GuideBook");
            //ViewBag.BlueDesc = "Kumaş Üretici";
            ViewBag.RedHref = Url.Action("BlueKumascilarKumasBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Kumaş Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueKumascilarKumasTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş İthalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueKumascilarKumasTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueKumasType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueKumasType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueKumasType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueKumasType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueKumasType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("BlueKumascilarKumasUretici", "GuideBook");
            //ViewBag.BlueDesc = "Kumaş Üretici";
            //ViewBag.RedHref = Url.Action("BlueKumascilarKumasBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Kumaş Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueKumascilarKumasTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş İthalatci";
            return View(viewName: "Index");
        }

        //****************************************/
        public ActionResult BlueAksesuarcilarAksesuarIthalatci()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueAksesuarciType.Uretici;

            //ViewBag.BlueHref = Url.Action("BlueAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("BlueAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar Boyahanesi";
            //iewBag.OthersHref = Url.Action("BlueAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueAksesuarcilarAksesuarIthalatci", "GuideBook");
            ViewBag.ZetaaDesc = "Aksesuar Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueAksesuarcilarAksesuarUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueAksesuarciType.Uretici;

            ViewBag.BlueHref = Url.Action("BlueAksesuarcilarAksesuarUretici", "GuideBook");
            ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("BlueAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar Boyahanesi";
            //iewBag.OthersHref = Url.Action("BlueAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Ithalatci";
            return View(viewName: "Index");
        }
        public ActionResult BlueAksesuarcilarAksesuarBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Boyahane);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueAksesuarciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("BlueAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            ViewBag.RedHref = Url.Action("BlueAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Aksesuar Boyahanesi";
            //iewBag.OthersHref = Url.Action("BlueAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Ithalatci";
            return View(viewName: "Index");          
        }
        public ActionResult BlueAksesuarcilarAksesuarTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Boyahane);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueAksesuarciType.Ithalatci);
            ViewBag.CompanyType = (int)CompanyBlueAksesuarciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("BlueAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("BlueAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Ithalatci";
            return View(viewName: "Index");
        }
        //****************************************/

        public ActionResult BlueHazirGiyimciHazirGiyimIthalatcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Boyahanesi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ithalatcisi);
            ViewBag.CompanyType = (int)CompanyBlueHazirGiyimciType.Ureticisi;

            ViewBag.BlueHref = Url.Action("BlueHazirGiyimciHazirGiyimUretici", "GuideBook");
            ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("BlueHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            ViewBag.ZetaaDesc = "Hazır Giyim ithalatcisi";
            return View(viewName: "Index");
        }

        public ActionResult  BlueHazirGiyimciHazirGiyimUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Boyahanesi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ithalatcisi);
            ViewBag.CompanyType = (int)CompanyBlueHazirGiyimciType.Ureticisi;

            ViewBag.BlueHref = Url.Action("BlueHazirGiyimciHazirGiyimUretici", "GuideBook");
            ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("BlueHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim ithalatcisi";
            return View(viewName: "Index");
        }
        public ActionResult  BlueHazirGiyimciHazirGiyimBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ureticisi);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Boyahanesi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ithalatcisi);
            ViewBag.CompanyType = (int)CompanyBlueHazirGiyimciType.Boyahanesi;

            //ViewBag.BlueHref = Url.Action("BlueHazirGiyimciHazirGiyimUretici", "GuideBook");
            //ViewBag.BlueDesc = "Hazır Giyim Üretici";
            ViewBag.RedHref = Url.Action("BlueHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            ViewBag.RedDesc = "Hazır Giyim Boyahanesi";
            //ViewBag.OthersHref = Url.Action("BlueHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim ithalatcisi";
            return View(viewName: "Index");
        }
        public ActionResult  BlueHazirGiyimciHazirGiyimTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Boyahanesi);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyBlueHazirGiyimciType.Ithalatcisi);
            ViewBag.CompanyType = (int)CompanyBlueHazirGiyimciType.Tedarikcisi;

            //ViewBag.BlueHref = Url.Action("BlueHazirGiyimciHazirGiyimUretici", "GuideBook");
            //ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("BlueHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim Boyahanesi";
            ViewBag.OthersHref = Url.Action("BlueHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("BlueHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim ithalatcisi";
            return View(viewName: "Index");
        }


        //************************--------------------------------**************************//


        //***************************************//

        public ActionResult RedIplikci()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedIplikciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedIplikciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedIplikciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedIplikciType.Boyahanesi);
            ViewBag.CompanyType = FindDescendantCount((int)CompanyRedType.Iplikci);

            ViewBag.BlueHref = Url.Action("RedIplikciIplikUretici", "GuideBook");
            ViewBag.BlueDesc = "İplik Üretici";
            ViewBag.RedHref = Url.Action("RedIplikciIplikIthalatci", "GuideBook");
            ViewBag.RedDesc = "İplik Ithalatci";
            ViewBag.OthersHref = Url.Action("RedIplikciIplikTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "İplik Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedIplikciIplikBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "İplik Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedKumascilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedKumasciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedKumasciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedKumasciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedKumasciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedType.Kumasci;

            ViewBag.BlueHref = Url.Action("RedKumascilarKumasUretici", "GuideBook");
            ViewBag.BlueDesc = "Kumaş Üretici";
            ViewBag.RedHref = Url.Action("RedKumascilarKumasIthalatci", "GuideBook");
            ViewBag.RedDesc = "Kumaş Ithalatci";
            ViewBag.OthersHref = Url.Action("RedKumascilarKumasTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedKumascilarKumasBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "Kumaş Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedAksesuarcilar()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ureticisi);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedType.Aksesuarci;

            ViewBag.BlueHref = Url.Action("RedAksesuarcilarAksesuarUretici", "GuideBook");
            ViewBag.BlueDesc = "Aksesuar Üretici";
            ViewBag.RedHref = Url.Action("RedAksesuarcilarAksesuarIthalatci", "GuideBook");
            ViewBag.RedDesc = "Aksesuar İthalatci";
            ViewBag.OthersHref = Url.Action("RedAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "Aksesuar Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedHazirGiyimci()
        {

            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ureticisi);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ithalatcisi);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedType.HazirGiyimci;

            ViewBag.BlueHref = Url.Action("RedHazirGiyimciHazirGiyimUretici", "GuideBook");
            ViewBag.BlueDesc = "Hazır Giyim Üretici";
            ViewBag.RedHref = Url.Action("RedHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            ViewBag.RedDesc = "Hazır Giyim İthalatcisi";
            ViewBag.OthersHref = Url.Action("RedHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc ="Hazır Giyim Boyahanesi";
            return View(viewName: "Index");
        }
        //*************************************//

        public ActionResult RedIplikciIplikIthalatci()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedIplikciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedIplikciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedIplikciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedIplikciType.Uretici;

            //ViewBag.BlueHref = Url.Action("RedIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            ViewBag.RedHref = Url.Action("RedIplikciIplikIthalatci", "GuideBook");
            ViewBag.RedDesc = "İplik Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Boyahanesi";
            return View(viewName: "Index");
        }


        public ActionResult RedIplikciIplikUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedIplikciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedIplikciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedIplikciType.Tedarikci;

            ViewBag.BlueHref = Url.Action("RedIplikciIplikUretici", "GuideBook");
            ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("RedIplikciIthalatci", "GuideBook");
            //ViewBag.RedDesc = "İplik Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedIplikciIplikBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedIplikciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedIplikciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedIplikciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedIplikciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("RedIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("RedIplikciIthalatci", "GuideBook");
            //ViewBag.RedDesc = "İplik Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedIplikciIplikTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "İplik Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedIplikciIplikBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "İplik Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedIplikciIplikTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedIplikciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedIplikciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedIplikciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedIplikciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedIplikciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("RedIplikciIplikUretici", "GuideBook");
            //ViewBag.BlueDesc = "İplik Üretici";
            //ViewBag.RedHref = Url.Action("RedIplikciIthalatci", "GuideBook");
            //ViewBag.RedDesc = "İplik Ithalatci";
            ViewBag.OthersHref = Url.Action("RedIplikciIplikTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "İplik Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedIplikciIplikBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "İplik Boyahanesi";
            return View(viewName: "Index");
        }

        //****************************************/

        public ActionResult RedKumascilarKumasIthalatci()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedKumasciType.Uretici);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedKumasciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedKumasciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedKumasciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedKumasciType.Uretici;

            //ViewBag.BlueHref = Url.Action("RedKumascilarKumasUretici", "GuideBook");
            //ViewBag.BlueDesc = "Kumaş Üretici";
            ViewBag.RedHref = Url.Action("RedKumascilarKumasIthalatci", "GuideBook");
            ViewBag.RedDesc = "Kumaş Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedKumascilarKumasTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedKumascilarKumasBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş Boyahanesi";
            return View(viewName: "Index");
        }

        public ActionResult RedKumascilarKumasUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedKumasciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedKumasciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedKumasciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedKumasciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedKumasciType.Uretici;

            ViewBag.BlueHref = Url.Action("RedKumascilarKumasUretici", "GuideBook");
            ViewBag.BlueDesc = "Kumaş Üretici";
            //ViewBag.RedHref = Url.Action("RedKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Kumaş Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedKumascilarKumasTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedKumascilarKumasBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedKumascilarKumasBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedKumasciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedKumasciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedKumasciType.Tedarikci);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedKumasciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedKumasciType.Boyahanesi;

            //ViewBag.BlueHref = Url.Action("RedKumascilarKumasUretici", "GuideBook");
            //ViewBag.BlueDesc = "Kumaş Üretici";
            //ViewBag.RedHref = Url.Action("RedKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Kumaş Ithalatci";
            //ViewBag.OthersHref = Url.Action("RedKumascilarKumasTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedKumascilarKumasBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "Kumaş Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedKumascilarKumasTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedKumasciType.Uretici);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedKumasciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedKumasciType.Tedarikci);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedKumasciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedKumasciType.Tedarikci;

            //ViewBag.BlueHref = Url.Action("RedKumascilarKumasUretici", "GuideBook");
            //ViewBag.BlueDesc = "Kumaş Üretici";
            //ViewBag.RedHref = Url.Action("RedKumascilarKumasIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Kumaş Ithalatci";
            ViewBag.OthersHref = Url.Action("RedKumascilarKumasTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Kumaş Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedKumascilarKumasBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Kumaş Boyahanesi";
            return View(viewName: "Index");
        }

        //****************************************/

        public ActionResult RedAksesuarcilarAksesuarIthalatci()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ureticisi);
            ViewBag.RedCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedAksesuarciType.Ithalatci;

            //ViewBag.BlueHref = Url.Action("RedAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            ViewBag.RedHref = Url.Action("RedAksesuarcilarAksesuarIthalatci", "GuideBook");
            ViewBag.RedDesc = "Aksesuar İthalatci";
            //ViewBag.OthersHref = Url.Action("RedAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Boyahanesi";
            return View(viewName: "Index");
        }

        public ActionResult RedAksesuarcilarAksesuarUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedAksesuarciType.Ureticisi;

            ViewBag.BlueHref = Url.Action("RedAksesuarcilarAksesuarUretici", "GuideBook");
            ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("RedAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar İthalatci";
            //ViewBag.OthersHref = Url.Action("RedAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedAksesuarcilarAksesuarBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ithalatci);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedAksesuarciType.Boyahanesi;

            //ViewBag.BlueHref = Url.Action("RedAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("RedAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar İthalatci";
            //ViewBag.OthersHref = Url.Action("RedAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "Aksesuar Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedAksesuarcilarAksesuarTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Ithalatci);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedAksesuarciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedAksesuarciType.Tedarikcisi;

            //ViewBag.BlueHref = Url.Action("RedAksesuarcilarAksesuarUretici", "GuideBook");
            //ViewBag.BlueDesc = "Aksesuar Üretici";
            //ViewBag.RedHref = Url.Action("RedAksesuarcilarAksesuarIthalatci", "GuideBook");
            //ViewBag.RedDesc = "Aksesuar İthalatci";
            ViewBag.OthersHref = Url.Action("RedAksesuarcilarAksesuarTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Aksesuar Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedAksesuarcilarAksesuarBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Aksesuar Boyahanesi";
            return View(viewName: "Index");
        }
        //****************************************/
        public ActionResult RedHazirGiyimciHazirGiyimUretici()
        {
            ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ithalatcisi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedHazirGiyimciType.Ureticisi;

            ViewBag.BlueHref = Url.Action("RedHazirGiyimciHazirGiyimUretici", "GuideBook");
            ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("RedHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim İthalatcisi";
            //ViewBag.OthersHref = Url.Action("RedHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedHazirGiyimciHazirGiyimBoyahanesi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ithalatcisi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Tedarikcisi);
            ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedHazirGiyimciType.Boyahanesi;

            //ViewBag.BlueHref = Url.Action("RedHazirGiyimciHazirGiyimUretici", "GuideBook");
            //ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("RedHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim İthalatcisi";
            //ViewBag.OthersHref = Url.Action("RedHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            ViewBag.ZetaaHref = Url.Action("RedHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            ViewBag.ZetaaDesc = "Hazır Giyim Boyahanesi";
            return View(viewName: "Index");
        }
        public ActionResult RedHazirGiyimciHazirGiyimTedarikcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ureticisi);
            //ViewBag.RedCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ithalatcisi);
            ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedHazirGiyimciType.Tedarikcisi;

            //ViewBag.BlueHref = Url.Action("RedHazirGiyimciHazirGiyimUretici", "GuideBook");
            //ViewBag.BlueDesc = "Hazır Giyim Üretici";
            //ViewBag.RedHref = Url.Action("RedHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            //ViewBag.RedDesc = "Hazır Giyim İthalatcisi";
            ViewBag.OthersHref = Url.Action("RedHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim Boyahanesi";
            return View(viewName: "Index");
        }

        public ActionResult RedHazirGiyimciHazirGiyimIthalatcisi()
        {
            //ViewBag.BlueCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ureticisi);
             ViewBag.RedCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Ithalatcisi);
            //ViewBag.OthersCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Tedarikcisi);
            //ViewBag.ZetaaCounter = FindDescendantCount((int)CompanyRedHazirGiyimciType.Boyahanesi);
            ViewBag.CompanyType = (int)CompanyRedHazirGiyimciType.Ithalatcisi;

            //ViewBag.BlueHref = Url.Action("RedHazirGiyimciHazirGiyimUretici", "GuideBook");
            //ViewBag.BlueDesc = "Hazır Giyim Üretici";
            ViewBag.RedHref = Url.Action("RedHazirGiyimciHazirGiyimIthalatcisi", "GuideBook");
            ViewBag.RedDesc = "Hazır Giyim İthalatcisi";
            //ViewBag.OthersHref = Url.Action("RedHazirGiyimciHazirGiyimTedarikcisi", "GuideBook");
            //ViewBag.OthersDesc = "Hazır Giyim Tedarikcisi";
            //ViewBag.ZetaaHref = Url.Action("RedHazirGiyimciHazirGiyimBoyahanesi", "GuideBook");
            //ViewBag.ZetaaDesc = "Hazır Giyim Boyahanesi";
            return View(viewName: "Index");
        }




        //public Dictionary<CompanyBlueType, List<int>> CompanyBlueParents = new Dictionary<CompanyBlueType, List<int>>();
        //public Dictionary<CompanyBlueIplikciType, List<int>> CompanyBlueIplikciParents = new Dictionary<CompanyBlueIplikciType, List<int>>();
        //public Dictionary<CompanyBlueKumasType, List<int>> CompanyBlueKumasParents = new Dictionary<CompanyBlueKumasType, List<int>>();
        //public Dictionary<CompanyBlueAksesuarciType, List<int>> CompanyBlueAksesuarcisParents = new Dictionary<CompanyBlueAksesuarciType, List<int>>();
        //public Dictionary<CompanyBlueHazirGiyimciType, List<int>> CompanyBlueHazirGiyimciParents = new Dictionary<CompanyBlueHazirGiyimciType, List<int>>();

        //private void FillTypeMapping()
        //{
        //    CompanyBlueParents.Add(CompanyBlueType.Iplikci, new List<int> { 25, 1 });
        //    CompanyBlueParents.Add(CompanyBlueType.Aksesuarci, new List<int> { 23, 1 });
        //    CompanyBlueParents.Add(CompanyBlueType.HazirGiyimci, new List<int> { 24, 1 });
        //    CompanyBlueParents.Add(CompanyBlueType.Kumas, new List<int> { 18, 1 });

        //    CompanyBlueIplikciParents.Add(CompanyBlueIplikciType.Boyahane, new List<int> { 28, 22, 1 });
        //    CompanyBlueIplikciParents.Add(CompanyBlueIplikciType.Ithalatci, new List<int> { 27, 22, 1 });
        //    CompanyBlueIplikciParents.Add(CompanyBlueIplikciType.Tedarikci, new List<int> { 15, 22, 1 });
        //    CompanyBlueIplikciParents.Add(CompanyBlueIplikciType.Uretici, new List<int> { 25, 22, 1 });

        //    CompanyBlueKumasParents.Add(CompanyBlueKumasType.Boyahane, new List<int> { 19, 22, 1 });
        //    CompanyBlueKumasParents.Add(CompanyBlueKumasType.Ithalatci, new List<int> { 17, 22, 1 });
        //    CompanyBlueKumasParents.Add(CompanyBlueKumasType.Tedarikci, new List<int> { 26, 22, 1 });
        //    CompanyBlueKumasParents.Add(CompanyBlueKumasType.Uretici, new List<int> { 14, 22, 1 });

        //    CompanyBlueHazirGiyimciParents.Add(CompanyBlueHazirGiyimciType.Boyahanesi, new List<int> { 36, 22, 1 });
        //    CompanyBlueHazirGiyimciParents.Add(CompanyBlueHazirGiyimciType.Ithalatcisi, new List<int> { 35, 22, 1 });
        //    CompanyBlueHazirGiyimciParents.Add(CompanyBlueHazirGiyimciType.Tedarikcisi, new List<int> { 34, 22, 1 });
        //    CompanyBlueHazirGiyimciParents.Add(CompanyBlueHazirGiyimciType.Ureticisi, new List<int> { 33, 22, 1 });


        //    CompanyBlueAksesuarcisParents.Add(CompanyBlueAksesuarciType.Boyahane, new List<int> { 32, 22, 1 });
        //    CompanyBlueAksesuarcisParents.Add(CompanyBlueAksesuarciType.Ithalatci, new List<int> { 31, 22, 1 });
        //    CompanyBlueAksesuarcisParents.Add(CompanyBlueAksesuarciType.Tedarikci, new List<int> { 30, 22, 1 });
        //    CompanyBlueAksesuarcisParents.Add(CompanyBlueAksesuarciType.Uretici, new List<int> { 29, 22, 1 });

        //}

    }
}


//var CompanyBlueKumasTypeBoyahane = new EnumTypeMapping<CompanyBlueKumasType>(CompanyBlueKumasType.Boyahane);
//CompanyBlueKumasTypeBoyahane.SetValues("19", "22", "1");
//var CompanyBlueKumasTypeIthalatci = new EnumTypeMapping<CompanyBlueKumasType>(CompanyBlueKumasType.Ithalatci);
//CompanyBlueKumasTypeIthalatci.SetValues("17", "22", "1");
//var CompanyBlueKumasTypeTedarikci = new EnumTypeMapping<CompanyBlueKumasType>(CompanyBlueKumasType.Tedarikci);
//CompanyBlueKumasTypeTedarikci.SetValues("26", "22", "1");
//var CompanyBlueKumasTypeUretici = new EnumTypeMapping<CompanyBlueKumasType>(CompanyBlueKumasType.Uretici);
//CompanyBlueKumasTypeUretici.SetValues("14", "22", "1");

//var companyBlueAksesuarciTypeBoyahane = new EnumTypeMapping<CompanyBlueAksesuarciType>(CompanyBlueAksesuarciType.Boyahane);
//companyBlueAksesuarciTypeBoyahane.SetValues("32", "22", "1");
//var companyBlueAksesuarciTypeIthalatci = new EnumTypeMapping<CompanyBlueAksesuarciType>(CompanyBlueAksesuarciType.Ithalatci);
//companyBlueAksesuarciTypeIthalatci.SetValues("31", "22", "1");
//var companyBlueAksesuarciTypeTedarikci = new EnumTypeMapping<CompanyBlueAksesuarciType>(CompanyBlueAksesuarciType.Tedarikci);
//companyBlueAksesuarciTypeTedarikci.SetValues("30", "22", "1");
//var companyBlueAksesuarciTypeUretici = new EnumTypeMapping<CompanyBlueAksesuarciType>(CompanyBlueAksesuarciType.Uretici);
//companyBlueAksesuarciTypeUretici.SetValues("29", "22", "1");


//var companyBlueHazirGiyimciTypeBoyahanesi = new EnumTypeMapping<CompanyBlueHazirGiyimciType>(CompanyBlueHazirGiyimciType.Boyahanesi);
//companyBlueHazirGiyimciTypeBoyahanesi.SetValues("36", "22", "1");
//var companyBlueHazirGiyimciTypeIthalatcisi = new EnumTypeMapping<CompanyBlueHazirGiyimciType>(CompanyBlueHazirGiyimciType.Ithalatcisi);
//companyBlueHazirGiyimciTypeIthalatcisi.SetValues("35", "22", "1");
//var companyBlueHazirGiyimciTypeTedarikcisi = new EnumTypeMapping<CompanyBlueHazirGiyimciType>(CompanyBlueHazirGiyimciType.Tedarikcisi);
//companyBlueHazirGiyimciTypeTedarikcisi.SetValues("34", "22", "1");
//var companyBlueHazirGiyimciTypeUreticisi = new EnumTypeMapping<CompanyBlueHazirGiyimciType>(CompanyBlueHazirGiyimciType.Ureticisi);
//companyBlueHazirGiyimciTypeUreticisi.SetValues("33", "22", "1");

//var companyBlueTypeAksesuarci = new EnumTypeMapping<CompanyBlueType>(CompanyBlueType.Aksesuarci);
//companyBlueTypeAksesuarci.SetValues("23", "1");
//var companyBlueTypeHazirGiyimci = new EnumTypeMapping<CompanyBlueType>(CompanyBlueType.HazirGiyimci);
//companyBlueTypeHazirGiyimci.SetValues("24", "1");
//var companyBlueTypeIplikci = new EnumTypeMapping<CompanyBlueType>(CompanyBlueType.Iplikci);
//companyBlueTypeIplikci.SetValues("22", "1");
//var companyBlueTypeKumas = new EnumTypeMapping<CompanyBlueType>(CompanyBlueType.Kumas);
//companyBlueTypeKumas.SetValues("18", "1");

//var companyBlueIplikciTypeBoyahane = new EnumTypeMapping<CompanyBlueIplikciType>(CompanyBlueIplikciType.Boyahane);
//companyBlueIplikciTypeBoyahane.SetValues("28", "22", "1");
//var companyBlueIplikciTypeIthalatci = new EnumTypeMapping<CompanyBlueIplikciType>(CompanyBlueIplikciType.Ithalatci);
//companyBlueIplikciTypeIthalatci.SetValues("27", "22", "1");
//var companyBlueIplikciTypeTedarikci = new EnumTypeMapping<CompanyBlueIplikciType>(CompanyBlueIplikciType.Tedarikci);
//companyBlueIplikciTypeTedarikci.SetValues("15", "22", "1");
//var companyBlueIplikciTypeUretici = new EnumTypeMapping<CompanyBlueIplikciType>(CompanyBlueIplikciType.Uretici);
//companyBlueIplikciTypeUretici.SetValues("25", "22", "1");


//public class EnumTypeMapping<T>
//{
//    private T _enumType;
//    private static Dictionary<T, List<string>> _typeMappingDictionary = new Dictionary<T, List<string>>();       //
//    public EnumTypeMapping(T enumType)
//    {
//        _enumType = enumType;
//    }
//    public List<string> GetValues()
//    {
//        if (!_typeMappingDictionary.ContainsKey(_enumType))
//            return new List<string>();
//        return _typeMappingDictionary[_enumType];
//    }
//    public void SetValue(string value)
//    {
//        if (!_typeMappingDictionary.ContainsKey(_enumType))
//            _typeMappingDictionary.Add(_enumType, new List<string>());

//        _typeMappingDictionary[_enumType].Add(value);
//    }
//    public void SetValues(params string[] value)
//    {
//        if (!_typeMappingDictionary.ContainsKey(_enumType))
//            _typeMappingDictionary.Add(_enumType, new List<string>());

//        _typeMappingDictionary[_enumType].AddRange(value);
//    }
//}
