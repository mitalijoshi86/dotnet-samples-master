﻿using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace NUnitTestSample
{
    [TestFixture]
    public class BrowserTest
    {
        readonly string BaseURL = "https://www.qasymphony.com";
        private IWebDriver _webDriver;

        [SetUp]
        public void Initialize()
        {
            _webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Go to QASymphony website and search for qTest Launch product
        /// </summary>
        [Test]
        public void SearchForQtestLaunch()
        {
            _webDriver.Navigate().GoToUrl(this.BaseURL);

            // click on Search icon to open search input
            IWebElement searchIcon = _webDriver.FindElement(By.XPath("/html/body/div[2]/header/div/div[2]/div/nav/ul/li[9]/a"));
            searchIcon.Click();

            // find the search input element and search for `qTest Launch`
            IWebElement searchInput = _webDriver.FindElement(By.Id("input-search"));
            searchInput.SendKeys("qTest Launch");
            searchInput.SendKeys(Keys.Enter);

            // from search result, look for h2 elament containing text qTest Launch, and click on it
            IWebElement h2Element = _webDriver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[1]/a/div[2]/div/h2"));
            h2Element.Click();
        }

        [TearDown]
        public void Cleanup()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}
