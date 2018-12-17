using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Message = db.Database.CreateIfNotExists() ? "Veritabanı Oluşturuldu" : "Başarısız";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


/*
 
     
           <li class="heading">
                <h3 class="uppercase">Companies</h3>
            </li>
            <li class="nav-item @(controllerName.Equals("Company",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty) ">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Company</span>
                    <span class="selected"></span>
                    <span class="arrow open"></span>
                </a>
                <ul class="sub-menu">
                    <li class="nav-item   @(actionName.Equals("Index",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Index", "Company",new { id = string.Empty})" class="nav-link ">
                            <span class="title">List</span>
                            <span class="selected"></span>
                        </a>
                    </li>
                    <li class="nav-item   @(actionName.Equals("Edit",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Edit", "Company",new { id = string.Empty})" class="nav-link ">
                            <span class="title">Add New</span>
                        </a>
                    </li>
                    @*<li class="nav-item   @(actionName.Equals("Department",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("Sector", "Company",new { id = string.Empty, taxonomy = "Department" })" class="nav-link ">
                        <span class="title">Departments</span>
                        <span class="selected"></span>
                    </a>
                </li>*@
                    @*<li class="nav-item   @(actionName.Equals("Position",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("Position", "Company",new { id = string.Empty})" class="nav-link ">
                        <span class="title">Positions</span>
                    </a>
                </li>*@
                </ul>
            </li>
            <li class="heading">
                <h3 class="uppercase">People</h3>
            </li>
            <li class="nav-item   @(controllerName.Equals("People",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-settings"></i>
                    <span class="title">Person</span>
                    <span class="arrow"></span>
                </a>
                <ul class="sub-menu">
                    <li class="nav-item   @(actionName.Equals("Index",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Index", "People",new { id = string.Empty})" class="nav-link ">
                            <span class="title">
                                List
                            </span>
                        </a>
                    </li>
                    <li class="nav-item   @(actionName.Equals("Edit",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Edit", "People",new { id = string.Empty})" class="nav-link ">
                            <span class="title">
                                Add New
                            </span>
                        </a>
                    </li>
                </ul>
            </li>
            <li class="heading">
                <h3 class="uppercase">Banks</h3>
            </li>
            <li class="nav-item   @(controllerName.Equals("Bank",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-settings"></i>
                    <span class="title">Bank</span>
                    <span class="arrow"></span>
                </a>
                <ul class="sub-menu">
                    <li class="nav-item   @(actionName.Equals("Index",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Index", "Bank",new { id = string.Empty})" class="nav-link ">
                            <span class="title">
                                List
                            </span>
                        </a>
                    </li>
                    <li class="nav-item   @(actionName.Equals("Edit",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Edit", "Bank",new { id = string.Empty})" class="nav-link ">
                            <span class="title">
                                Add New
                            </span>
                        </a>
                    </li>
                </ul>
            </li>
            <li class="heading">
                <h3 class="uppercase">Telephones</h3>
            </li>
            <li class="nav-item @(controllerName.Equals("Telephone",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty) ">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Telephone</span>
                    <span class="selected"></span>
                    <span class="arrow open"></span>
                </a>
                <ul class="sub-menu">
                    @*<li class="nav-item   @(actionName.Equals("Index",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("Index", "Telephone",new { id = string.Empty})" class="nav-link ">
                        <span class="title">List</span>
                        <span class="selected"></span>
                    </a>
                </li>*@
                    <li class="nav-item   @(actionName.Equals("Edit",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Edit", "Telephone",new { id = string.Empty , entityType = (int)FollowMe.Web.Controllers.Utils.ObjectType.Person })" class="nav-link ">
                            <span class="title">Add Person Telephone</span>
                        </a>
                    </li>
                    <li class="nav-item   @(actionName.Equals("Edit",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Edit", "Telephone",new { id = string.Empty , entityType = (int)FollowMe.Web.Controllers.Utils.ObjectType.Company })" class="nav-link ">
                            <span class="title">Add Company Telephone</span>
                        </a>
                    </li>
                    @*<li class="nav-item   @(actionName.Equals("Department",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("Sector", "Company",new { id = string.Empty, taxonomy = "Department" })" class="nav-link ">
                        <span class="title">Departments</span>
                        <span class="selected"></span>
                    </a>
                </li>*@
                    @*<li class="nav-item   @(actionName.Equals("Position",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("Position", "Company",new { id = string.Empty})" class="nav-link ">
                        <span class="title">Positions</span>
                    </a>
                </li>*@
                </ul>
            </li>
            <li class="heading">
                <h3 class="uppercase">Taxonomies</h3>
            </li>
            <li class="nav-item   @(controllerName.Equals("Terms",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-settings"></i>
                    <span class="title">Taxonomy</span>
                    <span class="arrow"></span>
                </a>
                <ul class="sub-menu">
                    <li class="nav-item   @(actionName.Equals("Taxonomies",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                        <a href="@Url.Action("Taxonomies", "Terms",new { id = string.Empty})" class="nav-link ">
                            <span class="title">
                                Taxonomy Lists
                            </span>
                        </a>
                    </li>
                    @*<li class="nav-item   @(actionName.Equals("Taxonomies",StringComparison.OrdinalIgnoreCase) ? "active open" : string.Empty)">
                    <a href="@Url.Action("TaxonomyAssign", "Terms",new { id = string.Empty})" class="nav-link ">
                        <span class="title">
                            Taxonomy Lists
                        </span>
                    </a>
                </li>*@
                </ul>
            </li>
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     */
