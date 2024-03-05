using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity
{
    public class Musteri
    {

        public int Id { get; set; }
        public KimlikBilgileri? KimlikBilgileri { get; set; }
        public int KimlikId { get; set; }
        public long Telefon { get; set; }
        public string Email { get; set; }
        public string FaturaAdresi { get; set; }
    }
}
