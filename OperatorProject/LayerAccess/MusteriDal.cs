using LayerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class MusteriDal
    {
        private readonly Baglanti _baglanti;
        public MusteriDal( Baglanti baglanti)
        {
            _baglanti = baglanti ?? throw new ArgumentNullException(nameof(baglanti));

        }
        public static int MusteriEkle( Musteri musteri ) 
        {
            return 0;
        }
        public async Task<List<Musteri>> MusteriListAsync()
        {
            try
            {
               
                List<Musteri> musteriler = _baglanti.Musteri.ToList();

                return musteriler;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return new List<Musteri>();
            }
        }
        public async Task<int> MusteriIdGetir(long telefon)
        {
            try
            {
               int musteri = await _baglanti.Musteri
            .Where(m => m.Telefon == telefon)
            .Select(m => m.Id)
            .FirstOrDefaultAsync();

                return musteri;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return 0;
            }
        }
        public async Task<Musteri> MusteriGetir(int musteriId)
        {
            try
            {
                Musteri musteri = await _baglanti.Musteri.FirstOrDefaultAsync(m => m.Id == musteriId);
                return musteri;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return null;
            }
        }
    }
}
