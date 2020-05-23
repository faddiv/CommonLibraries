#if NETCOREAPP2_1
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace PocketTools.AspNet.Mvc
{
    public static class PocketToolsExtensions
    {
        /// <summary>
        /// Returns the IUrlHelper associated with the current context
        /// or creates a new if not found.
        /// </summary>
        /// <param name="htmlHelper">Html property on the Page.</param>
        /// <returns>An IUrlHelper instance aquired the same way az IHtmlHelper aquires.</returns>
        /// <exception cref="ArgumentNullException">The htmlHelper is null.</exception>
        public static IUrlHelper GetUrlHelper(this IHtmlHelper htmlHelper)
        {
            if (htmlHelper is null)
                throw new ArgumentNullException(nameof(htmlHelper));

            ViewContext viewContext = htmlHelper.ViewContext;
            var urlHelperFactory = (IUrlHelperFactory)viewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory));
            return urlHelperFactory.GetUrlHelper(viewContext);
        }
    }
}
#endif