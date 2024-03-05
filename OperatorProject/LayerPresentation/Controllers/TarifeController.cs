using LayerBusiness;
using LayerPresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayerPresentation.Controllers
{
    public class TarifeController : Controller
    {
        private readonly TarifeBL _tarifeBL;
        private readonly MusteriPaketTutarBL _tarifeTutarBL;

        public TarifeController(TarifeBL tarifeBL, MusteriPaketTutarBL tarifeTutarBL)
        {
            _tarifeBL = tarifeBL;
            _tarifeTutarBL = tarifeTutarBL;
        }
        public async Task<IActionResult> Index(int musteriId)
        {
            var tarifeler = await _tarifeBL.TarifeListesiBL();
            var tarifeViewModels = tarifeler.Select(t => new TarifeViewModel { TarifeAdi=t.TarifeAdi,Icerik=t.Icerik,Id=t.Id,Fiyat=t.TarifeUcreti});
            ViewData["MusteriId"] = musteriId;
            return View(tarifeViewModels);
        }
        
       
        public IActionResult Tanimla(int tarifeId, int musteriId)
        {
            _tarifeTutarBL.KayitEkle(tarifeId, musteriId);
            var javascript = "<script>alert('Tarife müşteriye başarıyla tanımlandı!');</script>";

            
            return Content(javascript, "text/html");
        }
    }
}