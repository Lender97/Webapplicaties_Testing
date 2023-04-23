using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Controllers
{
    public class AdminController : Controller
    {
        private readonly DonutQueenContext _context;

        public AdminController(DonutQueenContext context)
        {
            _context = context;
        }

        public IActionResult Donuts()
        {
            DonutOverviewViewModel vm = new DonutOverviewViewModel()
            {
                Donuts = _context.Donuts.ToList()
            };

            return View(vm);
        }

        public IActionResult DonutDetails(int id)
        {
            Donut donut = _context.Donuts.Where(d => d.DonutId == id).FirstOrDefault();
            if (donut != null)
            {
                DonutDetailsViewModel vm = new DonutDetailsViewModel()
                {
                    DonutId = id,
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
            else
            {
                DonutOverviewViewModel vm = new DonutOverviewViewModel()
                {
                    Donuts = _context.Donuts.ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpGet]
        public IActionResult CreateDonut()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDonut(CreateDonutViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Donut()
                {
                    Naam = viewModel.Naam,
                    Topping = viewModel.Topping,
                    Glazuur = viewModel.Glazuur,
                    Vulling = viewModel.Vulling,
                    Omschrijving = viewModel.Omschrijving,
                    IsVegan = viewModel.IsVegan,
                    Afbeelding = viewModel.Afbeelding,
                    Prijs = viewModel.Prijs
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Donuts));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditDonut(int? id)
        {
            if (id == null)
                return NotFound();

            Donut donut = _context.Donuts.Where(d => d.DonutId == id).FirstOrDefault();

            if (donut == null)
                return NotFound();

            EditDonutViewModel vm = new EditDonutViewModel()
            {
                DonutId = donut.DonutId,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDonut(int id, EditDonutViewModel viewModel)
        {
            if (id != viewModel.DonutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Donut donut = new Donut()
                    {
                        DonutId = viewModel.DonutId,
                        Naam = viewModel.Naam,
                        Topping = viewModel.Topping,
                        Glazuur = viewModel.Glazuur,
                        Vulling = viewModel.Vulling,
                        Omschrijving = viewModel.Omschrijving,
                        IsVegan = viewModel.IsVegan,
                        Afbeelding = viewModel.Afbeelding,
                        Prijs = viewModel.Prijs
                    };
                    _context.Update(donut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Donuts.Any(d => d.DonutId == viewModel.DonutId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Donuts));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult DeleteDonut(int id)
        {
            Donut donut = _context.Donuts.Where(d => d.DonutId == id).FirstOrDefault();
            if (donut != null)
            {
                DeleteDonutViewModel vm = new DeleteDonutViewModel()
                {
                    DonutId = id,
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
            else
            {
                DonutOverviewViewModel vm = new DonutOverviewViewModel()
                {
                    Donuts = _context.Donuts.ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpPost, ActionName("DeleteDonut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDonutConfirm(int id)
        {
            Donut donut = await _context.Donuts.FindAsync(id);
            _context.Donuts.Remove(donut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Donuts));
        }

        public IActionResult Winkels()
        {
            WinkelOverviewViewModel vm = new WinkelOverviewViewModel()
            {
                Winkels = _context.Winkels.ToList()
            };

            return View(vm);
        }

        public IActionResult Gebruikers()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}