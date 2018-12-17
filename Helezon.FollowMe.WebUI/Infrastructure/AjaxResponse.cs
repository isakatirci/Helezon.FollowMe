using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Infrastructure
{
    public class AjaxCustomeResponse
    {
        public bool IsFailed { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}