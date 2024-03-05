using LayerAccess;
using LayerBusiness;
using LayerEntity;
using LayerPresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayerPresentation.Controllers
{
    public class MusteriController : Controller
    {
        private readonly KimlikBilgileriBL _kimlikBilgileriBL;
        private readonly MusteriPaketTutarBL _musteriPaketTutarBL;
        private readonly TalepKaydiBL _talepKaydiBL;       
        private readonly MusteriBL _musteriBL;
        private readonly TarifeBL _tarifeBL;


        public MusteriController(KimlikBilgileriBL kimlikBilgileriBL, MusteriPaketTutarBL musteriPaketTutarBL,TalepKaydiBL talepKaydiBL, MusteriBL musteriBL, TarifeBL tarifeBL)
        {
            _kimlikBilgileriBL = kimlikBilgileriBL;
            _musteriPaketTutarBL = musteriPaketTutarBL;
            _talepKaydiBL = talepKaydiBL;           
            _musteriBL = musteriBL;
            _tarifeBL = tarifeBL;
        }
        [HttpGet]
        public IActionResult MusteriIdAl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MusteriIdAl(string Telefon)
        {
            
            TempData["Telefon"] = Telefon;
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> Index()
        {
            if (TempData.TryGetValue("Telefon", out var telefonObject) && telefonObject is string telefon)
            {
                telefon = telefon.Trim();

                if (string.IsNullOrWhiteSpace(telefon) || telefon.Length != 10 || !telefon.All(char.IsDigit))
                {
                    return BadRequest("Geçersiz telefon numarası.");
                }


                if (!long.TryParse(telefon, out long telefonNumber))
                {
                    return BadRequest("Telefon numarası geçerli bir sayı değil.");
                }


                int musteriId = await _musteriBL.GetMusteriIdAsync(telefonNumber);
                if (musteriId <= 0)
                {
                    return BadRequest("Geçersiz müşteri ID.");
                }

                var kimlikBilgileri = await _kimlikBilgileriBL.MusteriAitKimlikBilgileriAsync(musteriId);
                var paketTutarBilgileri = await _musteriPaketTutarBL.MusteriPaketTutarListAsync(musteriId);
                var talepKayitlari = await _talepKaydiBL.MusteriyeAitTalepKayitlariAsync(musteriId);
               
                int tarifeId = paketTutarBilgileri.FirstOrDefault()?.TarifeId ?? 0;
                var tarifebilgisi = await _tarifeBL.GetTarifeAsync(tarifeId);

                return View(new MusteriViewModel
                {
                    MusteriId = musteriId,
                    KimlikBilgileri = kimlikBilgileri,
                    PaketTutarBilgileri = paketTutarBilgileri,
                    MusteriyeAitTalepKayitlari = talepKayitlari,
                    
                    Tarife= new List<Tarife> { tarifebilgisi }
                });
            }
            else
            {
                return BadRequest("Telefon numarası bulunamadı.");
            }
            
        }
        private async Task<string> TarifeBilgisiGetir(int tarifeId)
        {

            var tarife = await _tarifeBL.GetTarifeAsync(tarifeId);
            return tarife != null ? tarife.TarifeAdi : string.Empty;
        }
    }
}
