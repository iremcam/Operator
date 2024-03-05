using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity
{
    public class KimlikBilgileri
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public DateTime DogumTarihi { get; set; }
        [NotMapped]
        public Cinsiyet Cinsiyet { get; set; }
        public int CinsiyetId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }

    }
}
