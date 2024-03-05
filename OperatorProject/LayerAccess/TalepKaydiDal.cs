using LayerEntity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class TalepKaydiDal
    {
        private readonly Baglanti _baglanti;
        public TalepKaydiDal( Baglanti baglanti)
        {
                _baglanti = baglanti;
        }

        public async Task TalepKaydiEkleAsync(int kullaniciId, int musteriId, string konu, string aciklama)
        {
            if (kullaniciId <= 0 || musteriId <= 0 || string.IsNullOrWhiteSpace(konu) || string.IsNullOrWhiteSpace(aciklama))
                throw new ArgumentException("Geçersiz parametreler.");

            var talepKaydi = new TalepKaydi
            {
                KullaniciId = kullaniciId,
                Konu = konu,
                Aciklama = aciklama,
                StatuId = 1,
                MusteriId=musteriId
            };

            _baglanti.TalepKaydi.Add(talepKaydi);

            try
            {
                await _baglanti.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                throw new Exception("Talep kaydı eklenirken bir hata oluştu.", ex);
            }
        }
        public async Task<List<TalepKaydi>> MusteriyeAitTalepKayitlariGetirAsync(int musteriId)
        {
            if (musteriId <= 0)
                throw new ArgumentException("Geçersiz müşteri ID.");

            return await _baglanti.TalepKaydi
                .Include(tk => tk.Kullanici)
                
                .Where(tk => tk.MusteriId == musteriId)
                .ToListAsync();
        }
        public async Task<TalepKaydi> GetTalepByIdAsync(int talepId)
        {
            return await _baglanti.TalepKaydi.FindAsync(talepId);
        }

        public async Task UpdateTalepAsync(TalepKaydi talepKaydi)
        {
            try
            {
                _baglanti.TalepKaydi.Update(talepKaydi);
                await _baglanti.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Talep kaydı güncellenirken bir hata oluştu.", ex);
            }
        }

    }
}
