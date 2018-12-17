using FollowMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web.Controllers
{
    public class RolesAdminController : Controller
    {
        //public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Initialize ApplicationRole instead of IdentityRole:
        //        var role = new ApplicationRole(roleViewModel.Name);
        //        var rolemanager = new ApplicationRoleManager();
        //        var roleresult = await rolemanager.CreateAsync(role);
        //        if (!roleresult.Succeeded)
        //        {
        //            ModelState.AddModelError("", roleresult.Errors.First());
        //            return View();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}