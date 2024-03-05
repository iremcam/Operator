using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity
{
    public class MusteriPaketTutar
    {
        public int Id { get; set; }
        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }
        public Tarife Tarife { get; set; }
        public int TarifeId { get; set; }
    
    }
}
