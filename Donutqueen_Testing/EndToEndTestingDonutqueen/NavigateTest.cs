using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using Xunit;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DonutQueen.Data;

namespace EndToEndTestingDonutqueen
{
    public class NavigateTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public NavigateTest() => _driver = new ChromeDriver();

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void NavigeerDonutDetails()
        {
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));

            _driver.Navigate().GoToUrl("https://localhost:44316/");

            _driver.FindElement(By.Id("donuts")).Click();

            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("3")));
            _driver.FindElement(By.Id("3")).Click();

            Thread.Sleep(5000);

            Assert.Equal("https://localhost:44316/Shop/Details/3", _driver.Url);
        }
    }
}
