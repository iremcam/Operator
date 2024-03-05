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
    public class KimlikBilgileriBL
    {
        private readonly KimlikBilgileriDal _kimlikBilgileriDal;

        public KimlikBilgileriBL(KimlikBilgileriDal kimlikBilgileriDal)
        {
            _kimlikBilgileriDal = kimlikBilgileriDal ?? throw new ArgumentNullException(nameof(kimlikBilgileriDal));
        }

        public async Task<List<KimlikBilgileri>> MusteriAitKimlikBilgileriAsync(int musteriId)
        {
            if (musteriId <= 0)
                throw new ArgumentException("Geçersiz müşteri ID.");

            return await _kimlikBilgileriDal.MusteriAitKimlikBilgileri(musteriId);
        }

    }
}
