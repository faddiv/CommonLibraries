using FluentAssertions;
using Moq;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace PocketTools.AspNet.Mvc
{
    public class PocketToolsExtensionsTests
    {
        [Fact]
        public void GetUrlHelper_returns_UrlHelper_from_WebViewPage()
        {
            var mock = new Mock<WebViewPage>()
            {
                CallBase = true
            };
            var page = mock.Object;
            page.ViewContext = new ViewContext();
            page.ViewData = new ViewDataDictionary();
            page.InitHelpers();

            var url = page.Html.GetUrlHelper();

            url.Should().BeSameAs(page.Url);
        }

        [Fact]
        public void GetUrlHelper_returns_UrlHelper_from_ViewPage()
        {
            var page = new ViewPage
            {
                ViewContext = new ViewContext(),
                ViewData = new ViewDataDictionary()
            };
            page.InitHelpers();

            var url = page.Html.GetUrlHelper();

            url.Should().BeSameAs(page.Url);
        }

        [Fact]
        public void GetUrlHelper_returns_UrlHelper_from_ViewMasterPage()
        {
            var page = new ViewPage
            {
                ViewContext = new ViewContext(),
                ViewData = new ViewDataDictionary()
            };
            page.InitHelpers();
            var masterPage = new ViewMasterPage
            {
                Page = page
            };

            var url = masterPage.Html.GetUrlHelper();

            url.Should().BeSameAs(page.Url);
        }

        [Fact]
        public void GetUrlHelper_returns_UrlHelper_from_ViewUserControl()
        {
            var control = new ViewUserControl();
            ViewPage viewPage = new ViewPage();
            viewPage.ViewContext = new ViewContext();
            viewPage.ViewData = new ViewDataDictionary();
            viewPage.InitHelpers();
            viewPage.Controls.Add(control);

            var url = control.Html.GetUrlHelper();

            url.Should().BeSameAs(control.Url);
        }

        [Fact]
        public void GetUrlHelper_returns_new_UrlHelper_on_diferent_type()
        {
            var viewDataContainer = new Mock<IViewDataContainer>();
            var viewContext = new Mock<ViewContext>();
            var routeCollection = new RouteCollection();
            var helper = new HtmlHelper(
                viewContext.Object, 
                viewDataContainer.Object,
                routeCollection);

            var url = helper.GetUrlHelper();

            url.Should().NotBeNull();
            url.RouteCollection.Should().BeSameAs(routeCollection);
            url.RequestContext.Should().BeSameAs(viewContext.Object.RequestContext);
        }
    }
}
