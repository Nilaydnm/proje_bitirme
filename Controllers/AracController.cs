using Microsoft.AspNetCore.Mvc;
using proje_bitirme.Models;
using System.Linq;

namespace proje_bitirme.Controllers
{
    public class AracController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AracController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var araclar = _context.AracVerileri.ToList();
            return View(araclar);
        }
    }
}