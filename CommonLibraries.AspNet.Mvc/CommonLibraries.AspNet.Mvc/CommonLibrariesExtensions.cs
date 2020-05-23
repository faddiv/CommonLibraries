#if NET45
using System;
using System.Web.Mvc;

namespace PocketTools.AspNet.Mvc
{
    public static class PocketToolsExtensions
    {
        /// <summary>
        /// Returns the UrlHelper associated with the current context on cshtml, aspx, ascx 
        /// or creates a new if not found.
        /// </summary>
        /// <param name="htmlHelper">Html property on the WebViewPage, ViewPage, ViewMasterPage or ViewUserControl.</param>
        /// <returns>Same instance of the page or a new instance if not found.</returns>
        /// <exception cref="ArgumentNullException">The htmlHelper is null.</exception>
        public static UrlHelper GetUrlHelper(this HtmlHelper htmlHelper)
        {
            if (htmlHelper is null)
                throw new ArgumentNullException(nameof(htmlHelper));

            UrlHelper urlHelper;
            switch (htmlHelper.ViewDataContainer)
            {
                case WebViewPage wvp:
                    urlHelper = wvp.Url;
                    break;
                case ViewPage vp:
                    urlHelper = vp.Url;
                    break;
                case ViewUserControl vuc:
                    urlHelper = vuc.Url;
                    break;
                case ViewMasterPage vmp:
                    urlHelper = vmp.Url;
                    break;
                default:
                    urlHelper = null;
                    break;
            }
            return urlHelper
                ?? new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            
        }
    }
}
#endif
