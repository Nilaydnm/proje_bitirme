using Microsoft.AspNetCore.Mvc;
using proje_bitirme.Models;
using System.Linq;
using System.Collections.Generic;

namespace proje_bitirme.Controllers
{
    public class AnalizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnalizController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var veriler = _context.AracVerileri.ToList();

            var viewModel = new MarkaAnalizViewModel
            {
                OrtalamaMotorHacmi = veriler.Average(x => x.MotorHacmi),
                OrtalamaSilindir = (int)veriler.Average(x => x.Silindir),
                OrtalamaEmisyon = veriler.Average(x => x.Emisyon),
                OrtalamaLitre100Km = veriler.Average(x => x.Litre100Km),
                OrtalamaTahminiTuketim = veriler.Average(x => x.TahminiTuketim ?? 0),
                MinEmisyon = veriler.Min(x => x.Emisyon),
                MaxEmisyon = veriler.Max(x => x.Emisyon),
                ToplamKayit = veriler.Count,
                SanzimanDagilimi = veriler
                    .GroupBy(x => x.Sanziman)
                    .ToDictionary(g => g.Key, g => g.Count()),
                YakitTuruDagilimi = veriler
                    .GroupBy(x => x.YakitTuru)
                    .ToDictionary(g => g.Key, g => g.Count()),
                AracSinifiDagilimi = veriler
                    .GroupBy(x => x.AracSinifi)
                    .ToDictionary(g => g.Key, g => g.Count())
            };

            return View(viewModel);
        }
    }
}