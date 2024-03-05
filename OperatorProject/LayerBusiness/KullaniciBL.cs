using LayerAccess;
using LayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class KullaniciBL
    {
        private readonly KullaniciDal _kullaniciDal;
        public KullaniciBL(KullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public async Task<List<Kullanici>> GetKullanicisAsync()
        {
           return  await _kullaniciDal.KullaniciListesi();
        }
    }
}
