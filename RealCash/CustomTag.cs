using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealCash
{
    public static class CustomTag
    {
        public static IHtmlString Image(string src, string alt, string height, string width)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' height='{2}' width='{3}'></img>", src,alt,height,width));
        }
    }
}