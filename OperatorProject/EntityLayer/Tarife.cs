using Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EntityLayer
{
    public class Tarife
    {
        public int Id { get; set; }
        public HatTuru HatTuru { get; set; }
        public int HatTuruId { get; set; }
        public string TarifeAdi { get; set; }
        public string Icerik { get; set; }
        public decimal TarifeUcreti { get; set; }

    }
}
