namespace EntityLayer
{
    public class OdemeGecmisi
    {
        public int Id { get; set; }
        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }
        public string Detay { get; set; }
        public decimal Tutar { get; set; }
        public OdemeDetay OdemeTur { get; set; }
        public int OdemeTurId { get; set; }
    }
}
