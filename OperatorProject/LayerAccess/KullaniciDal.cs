using LayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class KullaniciDal
    {
        private readonly Baglanti _baglanti;
        public KullaniciDal(Baglanti baglanti)
        {
            _baglanti = baglanti ?? throw new ArgumentNullException(nameof(baglanti));

        }

        public  async Task<List<Kullanici>> KullaniciListesi()
        {
             List<Kullanici> kullanicilar=_baglanti.Kullanici.ToList();
            return kullanicilar;
        }


    }
}
