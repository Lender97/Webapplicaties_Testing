using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Data.Repositories
{
    public class DonutRepository : IDonutRepository
    {
        private readonly DonutQueenContext _context;

        public DonutRepository(DonutQueenContext _context)
        {
            this._context = _context;
        }

        /* public async Task<IActionResult> CreateDonut (CreateDonutViewModel viewModel)
         {
             Donut donut = new Donut()
             {
                 Naam = viewModel.Naam,
                 Topping = viewModel.Topping,
                 Glazuur = viewModel.Glazuur,
                 Vulling = viewModel.Vulling,
                 Omschrijving = viewModel.Omschrijving,
                 IsVegan = viewModel.IsVegan,
                 Afbeelding = viewModel.Afbeelding,
                 Prijs = viewModel.Prijs
             };

             _context.Add(donut);

             await _context.SaveChangesAsync();
             return (IActionResult)viewModel;
         } */

        public async Task<string> GetDonutById(int donutId)
        {
            var naam = await _context.Donuts.Where(d => d.DonutId == donutId).Select(d => d.Naam).FirstOrDefaultAsync();
            return naam;
        }

        public async Task AddDonut(Donut donut)
        {
            await _context.Donuts.AddAsync(donut);
            await _context.SaveChangesAsync();
        }

        public async Task<Donut> GetDonut(int donutId)
        {
            return await _context.Donuts.FindAsync(donutId);
        }

        public List<Donut> GetDonuts()
        {
            List<Donut> donuts = new List<Donut>();
            donuts = _context.Donuts.ToList();
            return donuts;
        }

        public async Task DeleteDonut(int id)
        {
            Donut donut = await _context.Donuts.FindAsync(id);

            _context.Donuts.Remove(donut);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDonut(Donut donut)
        {
           Donut donut1 = await _context.Donuts.FindAsync(donut.DonutId);

            donut1.Vulling =donut.Vulling;
            donut1.Afbeelding=donut.Afbeelding;
            donut1.Omschrijving=donut.Omschrijving;
            donut1.Prijs=donut.Prijs;
            donut1.Glazuur=donut.Glazuur;
            donut1.Naam=donut.Naam;
            donut1.Topping=donut.Topping;
            donut1.IsVegan=donut.IsVegan;

            await _context.SaveChangesAsync();
        }
    }
}
