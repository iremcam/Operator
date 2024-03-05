using LayerAccess;
using LayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class TalepKaydiBL
    {
        private readonly TalepKaydiDal _talepKaydiDal;

        public TalepKaydiBL(TalepKaydiDal talepKaydiDal)
        {
            _talepKaydiDal = talepKaydiDal;
        }
        public async Task<List<TalepKaydi>> MusteriyeAitTalepKayitlariAsync(int musteriId)
        {

            if (musteriId <= 0)
                throw new ArgumentException("Geçersiz müşteri ID.");

            return await _talepKaydiDal.MusteriyeAitTalepKayitlariGetirAsync(musteriId);
        }


        public async Task UpdateDescription(int talepId, string yeniAciklama)
        {
            var talep = await GetTalepByIdAsync(talepId);
            if (talep == null)
            {
                throw new ArgumentException("Talep bulunamadı.");
            }

            talep.Aciklama = talep.Aciklama + " " + yeniAciklama; 
            await _talepKaydiDal.UpdateTalepAsync(talep);
        }
        public async Task<TalepKaydi> GetTalepByIdAsync(int talepId)
        {
            return await _talepKaydiDal.GetTalepByIdAsync(talepId);
        }
        public async Task YeniTelepKaydiEkle(int kullanici, int musteri, string kayitKonu, string kayitAciklama)
        {
           

            await _talepKaydiDal.TalepKaydiEkleAsync(kullanici, musteri, kayitKonu, kayitAciklama);
        }
    }
}