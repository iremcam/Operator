using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity
{
    public class TalepKaydi
    {
        public int Id { get; set; }
        public Kullanici? Kullanici { get; set; }
        public int KullaniciId { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public Statu Statu { get; set; }
        public int StatuId { get; set; }
        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }
    }
}
