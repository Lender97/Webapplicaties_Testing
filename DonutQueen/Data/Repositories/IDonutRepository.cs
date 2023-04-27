using DonutQueen.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using DonutQueen.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DonutQueen.Data.Repositories
{
    public interface IDonutRepository
    {

        List<Donut> GetDonuts();

        Task<string> GetDonutById(int donutId);

        Task<Donut> GetDonut(int donutId);

        Task AddDonut(Donut donut);

        Task DeleteDonut(int id);

        Task UpdateDonut(Donut donut);

    }
}
