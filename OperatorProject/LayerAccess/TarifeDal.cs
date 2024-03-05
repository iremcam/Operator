using LayerEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class TarifeDal
    {
        public readonly Baglanti _baglanti;
        public TarifeDal( Baglanti baglanti)
        {
                _baglanti=baglanti;
        }
        public async Task<List<Tarife>> TarifeListesi()
        {
            try
            {
                List<Tarife> Tarifeler = await _baglanti.Tarife.ToListAsync();
                return Tarifeler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return new List<Tarife>();
                
            }
        }
        public async Task<Tarife> TarifeAsync(int id)
        {
            try
            {
                Tarife tarife = await _baglanti.Tarife.FirstOrDefaultAsync(m => m.Id == id);
                return tarife;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return null;
            }
        }
    }
}
