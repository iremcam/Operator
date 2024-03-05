using LayerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class MusteriPaketTutarDal
    {
        public readonly Baglanti _baglanti;
        public MusteriPaketTutarDal(Baglanti baglanti)
        {
                _baglanti = baglanti;
        }
        public async Task<List<MusteriPaketTutar>> MusteriPaketTutarBilgisi(int musteriId)
        {
            if (musteriId<=0)
            
                throw new ArgumentException("Geçersiz Müşteri ID.");
                return await _baglanti.MusteriPaketTutar.Where(a => a.MusteriId == musteriId).ToListAsync();
            
        }
        public void Ekle(MusteriPaketTutar musteriPaketTutar)
        {
            _baglanti.MusteriPaketTutar.Add(musteriPaketTutar);
            _baglanti.SaveChanges();
        }
    }
}
