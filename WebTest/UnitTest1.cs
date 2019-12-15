using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace WebTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string CurrentPath = "";
        private static readonly string DriverPath = "C:\\selenium";
        private static IWebDriver _driver;


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverPath);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void WebsiteTitleCheck()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("Eksame", _driver.Title);
        }

        [TestMethod]
        public void TabeDataCheck()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            IWebElement tableData = _driver.FindElement(By.Id("output_1"));
            IWebElement hentData = _driver.FindElement(By.Id("GetAll"));
            hentData.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.IsNotNull(tableData.FindElement(By.XPath("//*[@id=\"output_1\"]/tr[1]/th")));
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException), "Button was not clicked!")]
        public void IdSearchCheckFail()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            IWebElement data = _driver.FindElement(By.Id("output_2"));

            IWebElement inputElement = _driver.FindElement(By.Id("Searchbar"));
            inputElement.SendKeys("1");

            IWebElement getIdBtn = _driver.FindElement(By.Id("GetId"));
            //getIdBtn.Click(); not clicking!

            string text = data.Text;
            Assert.AreEqual("#1 Temp1234.5 Pres12.3 Hum12.3 time1999-01-01T00:00:00", text);
        }

    }
}
