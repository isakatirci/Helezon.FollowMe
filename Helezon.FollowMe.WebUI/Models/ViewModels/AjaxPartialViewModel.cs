using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FollowMe.Web.Models.ViewModels
{
    public class AjaxPartialViewModel
    {
        public string iframeUrl { get; set; }
        public string modalTitle { get; set; }
        public string foreingKeyId { get; set; }
        public string tableName { get; set; }
        public string dropDownListStyleClass { get; set; }
    }
}