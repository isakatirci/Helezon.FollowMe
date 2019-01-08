using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Helezon.FollowMe.WebUI.Code
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public string GetInnerExceptionMessage(Exception ex)
        {
            return ex.InnerException == null
                 ? ex.Message
                 : ex.Message + Environment.NewLine + GetInnerExceptionMessage(ex.InnerException);
        }
        public void OnException(ExceptionContext filterContext)
        {
            var message = filterContext.Exception.Message;
            //LogException(filterContext.Exception);
            var entityErrors = string.Empty;
            if (filterContext.Exception is System.Data.Entity.Validation.DbEntityValidationException)
            {
                var temp = (System.Data.Entity.Validation.DbEntityValidationException)filterContext.Exception;

                if (temp.EntityValidationErrors != null)
                {
                    foreach (var errors in temp.EntityValidationErrors)
                    {
                        entityErrors += "," + string.Join(",", errors.ValidationErrors.Select(x => x.ErrorMessage));
                    }
                }
            }

            filterContext.Controller.TempData["Failure"] = message + " " + GetInnerExceptionMessage(filterContext.Exception) + " " + entityErrors;

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult
            {
                ViewData = new ViewDataDictionary(filterContext.Controller.ViewData)                

            };
            //filterContext.Result = new RedirectToRouteResult(
            //   new RouteValueDictionary
            //   {
            //        { "controller", "Home" },
            //        { "action", "Index" }
            //   });


        }


        //void LogException(Exception exception)
        //{
        //    // try-catch because database itself could be down or Request context is unknown.

        //    try
        //    {
        //        EmasDbContext db = new EmasDbContext();

        //        string userId = null;
        //        try { /*userId = HttpContext.Current.User.Identity.GetUserId();*/ /*CurrentUser.Id;*/ }
        //        catch { /* do nothing */ }

        //        // ** Prototype pattern. the Error object has it default values initialized

        //        var error = new Errors
        //        {
        //            UserId = userId,
        //            Exception = exception.GetType().FullName,
        //            ErrorDate = DateTime.UtcNow,
        //            Message = exception.Message,
        //            Everything = exception.ToString(),
        //            IpAddress = HttpContext.Current.Request.UserHostAddress,
        //            UserAgent = HttpContext.Current.Request.UserAgent,
        //            PathAndQuery = HttpContext.Current.Request.Url == null ? "" : HttpContext.Current.Request.Url.PathAndQuery,
        //            HttpReferer = HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.PathAndQuery
        //        };

        //        //ArtContext.Errors.Insert(error);
        //        db.Errors.Add(error);
        //        db.SaveChanges();
        //    }
        //    catch { /* do nothing, or send email to webmaster*/}
        //}

    }
}