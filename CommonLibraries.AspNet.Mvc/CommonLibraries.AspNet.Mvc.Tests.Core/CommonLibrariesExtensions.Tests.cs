using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System;
using Xunit;

namespace PocketTools.AspNet.Mvc
{
    public class PocketToolsExtensionsTests
    {
        [Fact]
        public void GetUrlHelper_returns_IUrlHelper()
        {
            var urlHelper = new Mock<IUrlHelper>();
            var urlHelperFactory = new Mock<IUrlHelperFactory>();

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(e => e.GetService(typeof(IUrlHelperFactory)))
                .Returns(urlHelperFactory.Object);
            var httpContext = new DefaultHttpContext
            {
                RequestServices = serviceProvider.Object
            };
            var viewContext = new ViewContext
            {
                HttpContext = httpContext
            };
            urlHelperFactory.Setup(e => e.GetUrlHelper(viewContext)).Returns(urlHelper.Object);
            var htmlHelper = new Mock<IHtmlHelper>();
            htmlHelper.SetupGet(e => e.ViewContext).Returns(viewContext);

            var result = htmlHelper.Object.GetUrlHelper();

            result.Should().NotBeNull();
            result.Should().BeSameAs(urlHelper.Object);
        }
    }
}
