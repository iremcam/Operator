namespace EntityLayer
{
    public class MusteriPaketTutar
    {
        public int Id { get; set; }
        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }
        public Tarife Tarife { get; set; }
        public int TarifeId { get; set; }
        public int IndirimOrani { get; set; }
    }
}
