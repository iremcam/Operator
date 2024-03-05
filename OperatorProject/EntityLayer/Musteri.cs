namespace EntityLayer
{
    public class Musteri
    {
        public int Id { get; set; }
        public KimlikBilgileri? KimlikBilgileri { get; set; }
        public int KimlikId { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string FaturaAdresi { get; set; }
    }
}
