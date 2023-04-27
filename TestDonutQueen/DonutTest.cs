using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DonutQueen;
using Xunit;
using DonutQueen.Controllers;
using DonutQueen.ViewModels;
using DonutQueen.Models;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using DonutQueen.Data.Repositories;

namespace TestDonutQueen
{
    public class DonutTest
    {

        public Mock<IDonutRepository> mock = new Mock<IDonutRepository>();

        [Fact]
        public async void GetDonutByID()
        {
            mock.Setup(d => d.GetDonutById(1)).ReturnsAsync("JellyBelly");
            AdminController adm = new AdminController(mock.Object);
            string result = await adm.GetDonutById(1);
            Assert.Equal("JellyBelly", result);
        }

        private static readonly Donut donut = new Donut()
        {
            DonutId = 1,
            Naam = "JellyBelly",
            Topping = "Geen",
            Glazuur = "Geen",
            Vulling = "Confituur",
            Omschrijving = "Gevulde donut met confituur van bessen",
            IsVegan = false,
            Afbeelding = "/",
            Prijs = 5
        };

        [Fact]
        public async void CreateDonutTest()
        {
            Donut donut = new Donut()
            {
                DonutId = 1,
                Naam = "JellyBelly",
                Topping = "Geen",
                Glazuur = "Geen",
                Vulling = "Confituur",
                Omschrijving = "Gevulde donut met confituur van bessen",
                IsVegan = false,
                Afbeelding = "/",
                Prijs = 5
            };

            var createDonutVm = new CreateDonutViewModel()
            {
                Afbeelding = donut.Afbeelding,
                Glazuur = donut.Glazuur,
                IsVegan = donut.IsVegan,
                Naam = donut.Naam,
                Omschrijving = donut.Omschrijving,
                Prijs = donut.Prijs,
                Topping = donut.Topping,
                Vulling = donut.Vulling
            };

            AdminController adm = new AdminController(mock.Object);
            await adm.CreateDonut(createDonutVm);

            mock.Verify(d => d.AddDonut(It.Is<Donut>(d => d.IsVegan.Equals(donut.IsVegan)
            && d.Glazuur.Equals(donut.Glazuur)
            && d.Topping.Equals(donut.Topping)
            //&& d.DonutId.Equals(donut.DonutId)
            && d.Vulling.Equals(donut.Vulling)
            && d.Omschrijving.Equals(donut.Omschrijving)
            && d.Afbeelding.Equals(donut.Afbeelding)
            && d.Naam.Equals(donut.Naam)
            && d.Prijs.Equals(donut.Prijs))), Times.Once);
        }

        [Fact]

        public async void DeleteDonutTest()
        {
            Donut donut = new Donut()
            {
                DonutId = 1,
                Naam = "JellyBelly",
                Topping = "Geen",
                Glazuur = "Geen",
                Vulling = "Confituur",
                Omschrijving = "Gevulde donut met confituur van bessen",
                IsVegan = false,
                Afbeelding = "/",
                Prijs = 5
            };

            AdminController adm = new AdminController(mock.Object);
            await adm.DeleteDonutConfirm(donut.DonutId);

            mock.Verify(d => d.DeleteDonut(It.Is<int>(id => id.Equals(donut.DonutId))), Times.Once);

        }

        [Fact]
        public async void UpdateTest()
        {
            Donut donut = new Donut()
            {
                DonutId = 1,
                Naam = "JellyBelly",
                Topping = "Geen",
                Glazuur = "Geen",
                Vulling = "Confituur",
                Omschrijving = "Gevulde donut met confituur van bessen",
                IsVegan = false,
                Afbeelding = "/",
                Prijs = 5
            };

            var updateDonutVm = new EditDonutViewModel()
            {
                DonutId= donut.DonutId,
                Afbeelding = donut.Afbeelding,
                Glazuur = donut.Glazuur,
                IsVegan = donut.IsVegan,
                Naam = donut.Naam,
                Omschrijving = donut.Omschrijving,
                Prijs = donut.Prijs,
                Topping = donut.Topping,
                Vulling = donut.Vulling
            };

            AdminController adm = new AdminController(mock.Object);

            await adm.EditDonut(donut.DonutId, updateDonutVm);

            mock.Verify(d => d.UpdateDonut(It.Is<Donut>(d2 => d2.Afbeelding.Equals(donut.Afbeelding) 
            && d2.Glazuur.Equals(donut.Glazuur)
            && d2.DonutId.Equals(donut.DonutId)
            && d2.Topping.Equals(donut.Topping)
            && d2.IsVegan.Equals(donut.IsVegan)
            && d2.Naam.Equals(donut.Naam)
            && d2.Omschrijving.Equals(donut.Omschrijving)
            && d2.Prijs.Equals(donut.Prijs)
            && d2.Vulling.Equals(donut.Vulling))),Times.Once);

        }

    }
}
