using FollowMe.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Helezon.FollowMe.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        // last resort error logging
        // note: customErrors in web config specifies error page

        protected void Application_Error(object sender, EventArgs e)
        {
            // get last exception
            var exception = HttpContext.Current.Server.GetLastError();

            if (exception != null)
                LogException(exception);
        }

        // logs an exception with relevant context data to the error table

        void LogException(Exception exception)
        {
            // try-catch because database itself could be down or Request context is unknown.

            try
            {
                GLCEmasModel db = new GLCEmasModel();
                string userId = null;
                try { userId = User.Identity.GetUserId(); /*CurrentUser.Id;*/ }
                catch { /* do nothing */ }

                // ** Prototype pattern. the Error object has it default values initialized

                var error = new Error
                {
                    UserId = userId,
                    Exception = exception.GetType().FullName,
                    ErrorDate = DateTime.UtcNow,
                    Message = exception.Message,
                    Everything = exception.ToString(),
                    IpAddress = HttpContext.Current.Request.UserHostAddress,
                    UserAgent = HttpContext.Current.Request.UserAgent,
                    PathAndQuery = HttpContext.Current.Request.Url == null ? "" : HttpContext.Current.Request.Url.PathAndQuery,
                    HttpReferer = HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.PathAndQuery
                };

                //ArtContext.Errors.Insert(error);
                db.Error.Add(error);
                db.SaveChanges();
            }
            catch { /* do nothing, or send email to webmaster*/}
        }
    }
}
