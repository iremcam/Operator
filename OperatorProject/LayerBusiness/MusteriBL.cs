using LayerAccess;
using LayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class MusteriBL
    {
        private readonly MusteriDal _musteriDal;

        public MusteriBL(MusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public async Task<List<Musteri>> MusteriListesiBLAsync()
        {
            return await _musteriDal.MusteriListAsync();
        }

        public async Task<Musteri> GetMusteriAsync(int telefon)
        {
            int id = await _musteriDal.MusteriIdGetir(telefon);
            Musteri musteri = await _musteriDal.MusteriGetir(id);
            return musteri;
        }
        public async Task<int> GetMusteriIdAsync(long telefon)
        {
            
            int id = await _musteriDal.MusteriIdGetir(telefon);
            return id;
        }
    }
}
