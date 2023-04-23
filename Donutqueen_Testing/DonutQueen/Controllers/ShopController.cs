using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DonutQueen.Controllers
{
    public class ShopController : Controller
    {

        private readonly DonutQueenContext _context;

        public ShopController(DonutQueenContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ShopViewModel vm = new ShopViewModel()
            {
                Donuts = _context.Donuts.ToList()
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            Donut donut = _context.Donuts.Where(d => d.DonutId == id).FirstOrDefault();

            ShopDetailsViewModel vm = new ShopDetailsViewModel()
            {
                Naam = donut.Naam,
                Topping = donut.Topping,
                Glazuur = donut.Glazuur,
                Vulling = donut.Vulling,
                Omschrijving = donut.Omschrijving,
                IsVegan = donut.IsVegan,
                Afbeelding = donut.Afbeelding,
                Prijs = donut.Prijs
            };

            return View(vm);
        }
    }
}