using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DonutQueen.Controllers
{
    public class WinkelController : Controller
    {

        private readonly DonutQueenContext _context;

        public WinkelController(DonutQueenContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            WinkelsViewModel vm = new WinkelsViewModel()
            {
                Winkels = _context.Winkels.ToList()
            };

            return View(vm);
        }
    }
}