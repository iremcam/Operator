
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class VeriTabaniContext:DbContext
    {
        public VeriTabaniContext(DbContextOptions<VeriTabaniContext> options)
        : base(options)
        {
        }
       public DbSet<Musteri> Musteris { get; set; }
    }
}
