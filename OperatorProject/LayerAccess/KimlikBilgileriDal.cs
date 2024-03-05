using LayerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class KimlikBilgileriDal
    {
        public readonly Baglanti _baglanti;
        public KimlikBilgileriDal(Baglanti baglanti)
        {
            _baglanti = baglanti ?? throw new ArgumentNullException(nameof(baglanti));
        }

        public async Task<List<KimlikBilgileri>> MusteriAitKimlikBilgileri(int musteriId)
        {
            if (musteriId <= 0)
                throw new ArgumentException("Geçersiz müşteri ID.");

            return await _baglanti.KimlikBilgileri
                .Where(kb => kb.MusteriId == musteriId)
                .ToListAsync();
        }
    }
}
