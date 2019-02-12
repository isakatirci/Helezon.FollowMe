using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web
{

    public static class MyHtmlHelpers
    {
        public static MvcHtmlString HtmlEncode(this string data)
        {
            TagBuilder select = new TagBuilder("");
            select.Attributes.Add("class","form-control");
            return MvcHtmlString.Create(data);
        }

        public static SelectListItem[] SelectListForBoolean(bool? value)
        {
            var trueSelected = value.HasValue && value.Value;

            return new SelectListItem[2] {

                new SelectListItem()
                {
                    Text = "Yes",
                    Value = true.ToString(),
                    Selected = trueSelected
                },

                new SelectListItem()
                {
                    Text = "No",
                    Value = false.ToString(),
                    Selected = !trueSelected
                }

            };
        }
    }


}