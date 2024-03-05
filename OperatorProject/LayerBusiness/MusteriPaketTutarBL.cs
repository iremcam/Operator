using LayerAccess;
using LayerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class MusteriPaketTutarBL
    {
        private readonly MusteriPaketTutarDal _musteriPaketTutarDal;

        public MusteriPaketTutarBL(MusteriPaketTutarDal musteriPaketTutarDal)
        {
            _musteriPaketTutarDal = musteriPaketTutarDal ?? throw new ArgumentNullException(nameof(musteriPaketTutarDal));
        }

        public async Task<List<MusteriPaketTutar>> MusteriPaketTutarListAsync(int musteriId)
        {
            if (musteriId <= 0)
                throw new ArgumentException("Geçersiz müşteri ID.");

            return await _musteriPaketTutarDal.MusteriPaketTutarBilgisi(musteriId);
        }
        public void KayitEkle(int tarifeId, int musteriId)
        {
            var musteriPaketTutar = new MusteriPaketTutar
            {
                TarifeId = tarifeId,
                MusteriId = musteriId
            };

            _musteriPaketTutarDal.Ekle(musteriPaketTutar);
        }

    }
}
