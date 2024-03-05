namespace EntityLayer
{
    public class TalepKaydi
    {
        public int Id { get; set; }
        public Kullanici? Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public Statu Statu { get; set; }
    }
}
