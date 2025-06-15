using Microsoft.AspNetCore.Mvc;
using proje_bitirme.Models;
using System.Linq;

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
            var analizVerileri = _context.AracVerileri
                .GroupBy(a => a.AracSinifi)
                .Select(g => new MarkaAnalizViewModel
                {
                    AracSinifi = g.Key,
                   
                    OrtalamaTuketim = g.Average(x => x.Litre100Km),
                    OrtalamaEmisyon = g.Average(x => x.Emisyon),
                    OrtalamaMotorHacmi = g.Average(x => x.MotorHacmi)
                })
                .ToList();

            return View(analizVerileri);
        }
    }
}