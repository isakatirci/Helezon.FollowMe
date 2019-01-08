using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI
{

    public static class HtmlHelpers
    {
        public static MvcHtmlString HtmlEncode(this string data)
        {
            TagBuilder select = new TagBuilder("");
            select.Attributes.Add("class","form-control");
            return MvcHtmlString.Create(data);
        }
    }


}