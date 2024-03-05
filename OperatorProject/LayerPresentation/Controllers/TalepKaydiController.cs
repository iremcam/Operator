using LayerAccess;
using LayerBusiness;
using LayerPresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayerPresentation.Controllers
{
    public class TalepKaydiController : Controller
    {
        private readonly TalepKaydiBL _talepKaydiBL;
        private readonly KullaniciBL _kullaniciBL;  

        public TalepKaydiController(TalepKaydiBL talepKaydiBL,KullaniciBL kullaniciBL)
        {
            _talepKaydiBL = talepKaydiBL;
            _kullaniciBL = kullaniciBL;
        }

        public async Task<IActionResult> Index(int musteriId)
        {
            if (musteriId <= 0)
                return BadRequest("Geçersiz müşteri ID.");

            try
            {
                ViewBag.MusteriId = musteriId;

                var talepKayitlari = await _talepKaydiBL.MusteriyeAitTalepKayitlariAsync(musteriId);


                var talepKayitlariViewModel = talepKayitlari.Select(talep => new TalepKaydiViewModel
                {
                    MusteriId=musteriId,
                    Id = talep.Id,
                    Konu = talep.Konu,
                    Aciklama = talep.Aciklama
                }).ToList();

                return View(talepKayitlariViewModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDescription(int talepId, string yeniAciklama)
        {
            try
            {
                var talep = await _talepKaydiBL.GetTalepByIdAsync(talepId);
                if (talep == null)
                {
                    return NotFound();
                }


                talep.Aciklama = $"{talep.Aciklama} {yeniAciklama}";
                await _talepKaydiBL.UpdateDescription(talepId, yeniAciklama);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(500, "Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> YeniTalepKaydi(int  musteriId)
        {
            if (musteriId<=0)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.MusteriId = musteriId;
            var kullanici = await _kullaniciBL.GetKullanicisAsync();
            return View( new TalepKaydiViewModel
            {
                kullanicilar=kullanici
            }
                );
        }

        [HttpPost]
        public async Task<IActionResult> YeniTalepKaydi(string konu, string aciklama, int kullaniciId, int musteriId)
        {


            try
            {
               
                await _talepKaydiBL.YeniTelepKaydiEkle(kullaniciId, musteriId, konu, aciklama);

            
                return RedirectToAction("Index", "TalepKaydi", new { musteriId = musteriId });
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error", "Home");
            }

        }
    }
}
