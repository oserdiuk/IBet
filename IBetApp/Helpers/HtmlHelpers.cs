using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IBetApp.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString ActionImage(this HtmlHelper htmlHelper,
                                 string controller,
                                 string action,
                                 object routeValues,
                                 string imagePath,
                                 string alternateText = "",
                                 object htmlAttributes = null)
        {

            var anchorBuilder = new TagBuilder("a");
            var url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));

            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alternateText);

            var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            imgBuilder.MergeAttributes(attributes);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            anchorBuilder.InnerHtml = imgHtml;
            return MvcHtmlString.Create(anchorBuilder.ToString());
        }

    }
}
