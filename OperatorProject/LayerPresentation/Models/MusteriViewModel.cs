using LayerEntity;

namespace LayerPresentation.Models
{
    public class MusteriViewModel
    {
        public int MusteriId { get; set; }
        public List<KimlikBilgileri> KimlikBilgileri { get; set; }
        public List<MusteriPaketTutar> PaketTutarBilgileri { get; set; }
        public List<TalepKaydi> MusteriyeAitTalepKayitlari { get; set; }
        
        public List<Tarife> Tarife { get; set; }   
    }
}
