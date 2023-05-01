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
    public class CRUDTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private int _timeout;

        public CRUDTest() => _driver = new ChromeDriver();

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void DonutToevoegen()
        {
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));
            Donut donut = new Donut();
            donut.Naam = "Blue Rainbow";
            donut.Topping = "Blauwe hagelslag";
            donut.Glazuur = "Witte chocolade";
            donut.Vulling = "Geen";
            donut.Omschrijving = "Heerlijke donut met blauwe hagelslag";
            donut.Afbeelding = "Bluey.jpg";
            donut.Prijs = 3.5m;

            _driver.Navigate().GoToUrl("https://localhost:44316/Admin/CreateDonut?");

            Thread.Sleep(5000);

            _driver.FindElement(By.Id("txtNaam")).SendKeys(donut.Naam);
            _driver.FindElement(By.Id("txtTopping")).SendKeys(donut.Topping);
            _driver.FindElement(By.Id("txtGlazuur")).SendKeys(donut.Glazuur);
            _driver.FindElement(By.Id("txtVulling")).SendKeys(donut.Vulling);
            _driver.FindElement(By.Id("cbVegan")).Click();
            _driver.FindElement(By.Id("txtOmschrijving")).SendKeys(donut.Omschrijving);
            _driver.FindElement(By.Id("txtAfbeelding")).SendKeys(donut.Afbeelding);
            _driver.FindElement(By.Id("txtPrijs")).SendKeys(donut.Prijs.ToString());
            _driver.FindElement(By.Id("btnAanmaken")).Click();

            Thread.Sleep(10000);
            Assert.Equal("https://localhost:44316/Admin/Donuts", _driver.Url);
        }

        [Fact]
        public void DeleteDonut()
        {
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));

            _driver.Navigate().GoToUrl("https://localhost:44316/Admin/Donuts");

            Thread.Sleep(5000);

            _timeout = 4;
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id("19")));
            _driver.FindElement(By.Id("19")).Click();

            _driver.FindElement(By.Id("btnVerwijderen")).Click();

            Thread.Sleep(5000);
            Assert.Equal("https://localhost:44316/Admin/Donuts", _driver.Url);
        }
    }
}
