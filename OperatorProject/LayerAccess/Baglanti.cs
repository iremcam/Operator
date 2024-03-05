using LayerEntity;
using LayerEntity.EntityConfigurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LayerAccess
{
    public class Baglanti : DbContext
    {

        public Baglanti(DbContextOptions<Baglanti> options)
       : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OperatorDb;Uid=sa;Pwd=1234;Encrypt=true;TrustServerCertificate=true;");
            }
        }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<HatTuru> HatTuru { get; set; }
        public DbSet<KimlikBilgileri> KimlikBilgileri { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<MusteriPaketTutar> MusteriPaketTutar { get; set; }
        public DbSet<TalepKaydi> TalepKaydi { get; set; }
        public DbSet<Statu> Statu { get; set; }
        public DbSet<Cinsiyet> Cinsiyet { get; set; }
        public DbSet<Tarife> Tarife { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MusteriMap());
            builder.ApplyConfiguration(new CinsiyetMap());
            builder.ApplyConfiguration(new HatTuruMap());
            builder.ApplyConfiguration(new KimlikBilgileriMap());
            builder.ApplyConfiguration(new KullaniciMap());
            builder.ApplyConfiguration(new MusteriPaketTutarMap());
            builder.ApplyConfiguration(new StatuMap());
            builder.ApplyConfiguration(new TalepKaydiMap());
            builder.ApplyConfiguration(new TarifeMap());


        }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Baglanti>
        {
            public Baglanti CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Baglanti>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OperatorDb;User Id=sa;Password=1234;");

                return new Baglanti(optionsBuilder.Options);
            }
        }
    }
}
