using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service.DataTransferObjects
{
    public class JsTreeDataDto
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parent { get; set; }
        public object state { get; set; }
    }
}
