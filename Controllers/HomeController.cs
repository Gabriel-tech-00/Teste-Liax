using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Threading.Tasks;
using Gerenciamento_Empresas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FusionCharts.Visualization;
using FusionCharts.DataEngine;
using Microsoft.Extensions.Logging;

namespace Gerenciamento_Empresas.Controllers
{
    public class HomeController : Controller

    {
        private readonly Contexto _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Contexto context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

       
        public IActionResult Index()
        {
            this.RenderOsByVacinasEmpresa();
            this.RenderOsByPessoaVacina();
            return View();
        }

        public void RenderOsByVacinasEmpresa()
        {
            var quant = (from _Lote in _context.Set <Lote>()
            join _Vacina in _context.Set<Vacina>() on _Lote.VacinaId equals _Vacina.Id
            group _Vacina by new { _Vacina.Nome, _Vacina.Id } into total
            select new { total.Key.Nome, total = total.Count() }).ToArray();
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Lote", typeof(System.String));
            ChartData.Columns.Add("Vacina", typeof(System.Int32));
            foreach (var item in quant)
            {
                
                ChartData.Rows.Add(item.Nome, item.total);
            }
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Charts.PieChart pie = new Charts.PieChart("count_vacina");
            pie.Data.Source = model;
            pie.Width.Percentage(100);
            pie.Height.Pixel(500);
            pie.Caption.Text = "Lotes por Vacina";
            pie.ThemeName = FusionChartsTheme.ThemeName.CANDY;
            ViewData["Chart_1"] = pie.Render();

        }

        public void RenderOsByPessoaVacina()
        {
            var quantVac = (from _Locais in _context.Set<Locais>()
               join _Estado in _context.Set<Locais>() on _Locais.EstadoId equals _Estado.Id
            group _Estado by new { _Estado.Nome, _Estado.Id } into total
               select new { total.Key.Nome, total = total.Count() }).ToArray();
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Nome", typeof(System.String));
            ChartData.Columns.Add("Qtd", typeof(System.Int32));
            foreach (var item in quantVac)
            {
                // ChartData.Rows.Add(descStatus[i], quant[i]);
                ChartData.Rows.Add(item.Nome, item.total);
            }
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Charts.PieChart pie = new Charts.PieChart("count_vacina");
            pie.Data.Source = model;
            pie.Width.Percentage(100);
            pie.Height.Pixel(500);
            pie.Caption.Text = "Quantidade de Locais por Estado";
            pie.ThemeName = FusionChartsTheme.ThemeName.CANDY;
            ViewData["Chart_2"] = pie.Render();

        }

    }

}