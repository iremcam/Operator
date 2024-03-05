using LayerAccess;
using LayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class TarifeBL
    {
        private readonly TarifeDal _tarifeDal;

        public TarifeBL(TarifeDal tarifeDal)
        {
            _tarifeDal = tarifeDal;
        }

        public async Task<List<Tarife>> TarifeListesiBL()
        {
            return await _tarifeDal.TarifeListesi();
        }
        public async Task<Tarife>GetTarifeAsync(int id)

        { Tarife tarife=await _tarifeDal.TarifeAsync(id);
            return tarife;
        }

    }
}
