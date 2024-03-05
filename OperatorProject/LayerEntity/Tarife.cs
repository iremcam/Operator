using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity
{
    public class Tarife
    {
        public int Id { get; set; }
        public HatTuru HatTuru { get; set; }
        public int HatTuruId { get; set; }
        public string TarifeAdi { get; set; }
        public string Icerik { get; set; }
        public int TarifeUcreti { get; set; }

    }
}
