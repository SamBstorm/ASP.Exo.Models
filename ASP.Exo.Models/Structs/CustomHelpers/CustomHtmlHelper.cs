using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Exo.Models.Structs.CustomHelpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString DateOfNow(this HtmlHelper html)
        {
            DateTime now = DateTime.Now;
            TagBuilder tag = new TagBuilder("span");
            tag.SetInnerText(now.ToString());
            tag.AddCssClass((now.Day % 2 == 0) ? "text-primary" : "text-danger");
            return new MvcHtmlString(tag.ToString());
        }
    }
}