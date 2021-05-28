using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace TestProject3
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver(@"C:\chromedriver_win32");
        }

        [Test]
        public void Test1()
        {
            // Navigation
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));

            element.SendKeys("lenovo laptop");
            element.Submit();

            // on the page with search results there are many links with same class
            // I select all of them and then choose the first one by index
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(".a-link-normal .a-text-normal"));

            // click on the  first one
            elements[0].Click();

            IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
            addToCartButton.Click();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement noThanksButton = wait.Until(e => e.FindElement(By.Id("attachSiNoCoverage-announce")));

                noThanksButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // If nothing is found, wait.Until throws an WebDriverTimeoutException, which we catch here.
                // That means that the panel didn't show up and we don't need to do anything and can proceed to the next step.
            };

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement viewCartButton = wait.Until(e => e.FindElement(By.Id("attach-sidesheet-view-cart-button")));

                viewCartButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                IWebElement cartPage = driver.FindElement(By.Id("nav-cart"));
                cartPage.Click();
            };
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}