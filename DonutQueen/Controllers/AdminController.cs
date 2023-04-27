using DonutQueen.Data;
using DonutQueen.Data.Repositories;
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
        //private readonly DonutQueenContext _context;
        private readonly IDonutRepository _donutRepository;
       

        public AdminController(IDonutRepository donutRepository)
        {
            _donutRepository = donutRepository;
        }

       

        [HttpGet(nameof(GetDonutById))]
        public async Task<string> GetDonutById(int donutID)
        {
            var result = await _donutRepository.GetDonutById(donutID);
            return result;
        }

        public IActionResult Donuts()
        {
            DonutOverviewViewModel vm = new DonutOverviewViewModel()
            {
                Donuts = _donutRepository.GetDonuts()
            };

            return View(vm);
        }



        public async Task<IActionResult> DonutDetails(int id)
        {
            Donut donut = await _donutRepository.GetDonut(id);
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
                    Donuts = _donutRepository.GetDonuts().ToList()
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
                /* _context.Add(new Donut()
                {
                    Naam = viewModel.Naam,
                    Topping = viewModel.Topping,
                    Glazuur = viewModel.Glazuur,
                    Vulling = viewModel.Vulling,
                    Omschrijving = viewModel.Omschrijving,
                    IsVegan = viewModel.IsVegan,
                    Afbeelding = viewModel.Afbeelding,
                    Prijs = viewModel.Prijs
                });*/

                await _donutRepository.AddDonut(new Donut()
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

                return RedirectToAction(nameof(Donuts));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditDonut(int id)
        {
           /* if (id == null)
                return NotFound();*/

            Donut donut = await _donutRepository.GetDonut(id);

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
                    
                   await _donutRepository.UpdateDonut(donut);

                }
                catch (DbUpdateConcurrencyException e)
                {
                    if ( await _donutRepository.GetDonut(id) == null)
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
        public async Task<IActionResult> DeleteDonut(int id)
        {
            // Donut donut = _context.Donuts.Where(d => d.DonutId == id).FirstOrDefault();

            Donut donut = await _donutRepository.GetDonut(id);

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
                    Donuts = _donutRepository.GetDonuts()
                };
                return View("Index", vm);
            }
        }

        [HttpPost, ActionName("DeleteDonut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDonutConfirm(int id)
        {
            await _donutRepository.DeleteDonut(id);
            //await _context.SaveChangesAsync();
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