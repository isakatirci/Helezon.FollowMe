using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Controllers
{
    public class ResponseForJson<T>
    {
        public List<T> Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public ResponseForJson()
        {
            Data = new List<T>();
            ErrorMessages = new List<string>();
        }
        public bool HasErrorMessages
        {
            get
            {
                return ErrorMessages != null && ErrorMessages.Any();
            }
        }
    }
}