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
            //nieuwe donut aanmaken
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

            //waardes van de donut ingeven in de juiste input velden
            _driver.FindElement(By.Id("txtNaam")).SendKeys(donut.Naam);
            _driver.FindElement(By.Id("txtTopping")).SendKeys(donut.Topping);
            _driver.FindElement(By.Id("txtGlazuur")).SendKeys(donut.Glazuur);
            _driver.FindElement(By.Id("txtVulling")).SendKeys(donut.Vulling);
            _driver.FindElement(By.Id("cbVegan")).Click();
            _driver.FindElement(By.Id("txtOmschrijving")).SendKeys(donut.Omschrijving);
            _driver.FindElement(By.Id("txtAfbeelding")).SendKeys(donut.Afbeelding);
            _driver.FindElement(By.Id("txtPrijs")).SendKeys(donut.Prijs.ToString());
            
            //donut aanmaken door de knop te gebruiken
            _driver.FindElement(By.Id("btnAanmaken")).Click();

            Thread.Sleep(1000);


            //javascript gebruiken om te scrollen door de pagina
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            //controleren dat de juiste url is gevonden
            Thread.Sleep(10000);
            Assert.Equal("https://localhost:44316/Admin/Donuts", _driver.Url);
        }

        [Fact]
        public void DeleteDonut()
        {
            //waiter initialiseren
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));


            //De driver naar de juiste pagina laten navigeren



            //waiter een waarde geven
            _timeout = 4;

            //waiter laten wachten tot het juiste element zichtbaar is en dit element zoeken, tip: id 11


            //de knop verwijderen aanklikken


            //controleren dat de juiste pagina geladen wordt

        }
    }
}
