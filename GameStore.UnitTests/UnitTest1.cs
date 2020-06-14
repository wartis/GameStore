using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameStore.WebUI.HtmlHelpers;
using GameStore.WebUI.Models;

namespace GameStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper helper = null;

            PagingInfo pi = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> urlGeneratorDelegate = i => "Page" + i;  

            MvcHtmlString result = helper.PageLinks(pi, urlGeneratorDelegate);

            Assert.AreEqual<string>(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString()); 


        }
    }
}
