using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTesting
{
    [TestFixture]
    public class ITest2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The2Test()
        {
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            driver.FindElement(By.LinkText("Español")).Click();
            driver.FindElement(By.Id("start")).Click();
            driver.FindElement(By.Id("words")).Click();
            driver.FindElement(By.Id("amount")).Click();
            driver.FindElement(By.Id("amount")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=amount | ]]
            driver.FindElement(By.Id("amount")).Clear();
            driver.FindElement(By.Id("amount")).SendKeys("10");
            driver.FindElement(By.Id("generate")).Click();
            driver.FindElement(By.LinkText("English")).Click();
            driver.FindElement(By.Id("amount")).Click();
            driver.FindElement(By.Id("amount")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=amount | ]]
            driver.FindElement(By.Id("amount")).Clear();
            driver.FindElement(By.Id("amount")).SendKeys("10");
            driver.FindElement(By.Id("generate")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
