using LayerEntity;

namespace LayerPresentation.Models
{
    public class TalepKaydiViewModel
    {
        public int Id { get; set; }
        
        
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public Statu Statu { get; set; }
        public int StatuId { get; set; }
      
        public int? MusteriId { get; set; }
        public int KullaniciId { get; set; }
        public List< Kullanici>? kullanicilar { get; set; }
    }
}
