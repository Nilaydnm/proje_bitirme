using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using proje_bitirme.Models;

namespace proje_bitirme.Controllers
{
    public class TahminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public TahminController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sonuc(AracVerisi veri)
        {
            // Python API'ye JSON gönder
            var inputJson = JsonSerializer.Serialize(new
            {
                motor_hacmi = veri.MotorHacmi,
                model_yili = veri.Yil,
                silindir = veri.Silindir,
                sanziman = veri.Sanziman,
                yakit_turu = veri.YakitTuru,
                arac_sinifi = veri.AracSinifi,
                emisyon = veri.Emisyon
            });

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:8000/predict", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var sonuc = JsonSerializer.Deserialize<TahminSonucu>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // 🔽 Tahmin sonucunu veri nesnesine ekle
                    veri.TahminiTuketim = sonuc.Litre100Km;

                    // 🔽 Güncellenmiş haliyle veritabanına kaydet
                    _context.AracVerileri.Add(veri);
                    _context.SaveChanges();

                    return View(sonuc);
                }
                else
                {
                    return View("Hata", $"API hatası: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return View("Hata", $"Bağlantı hatası: {ex.Message}");
            }
        }

    }
}
