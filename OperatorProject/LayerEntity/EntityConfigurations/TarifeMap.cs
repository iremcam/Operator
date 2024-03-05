using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class TarifeMap : IEntityTypeConfiguration<Tarife>
    {
        public void Configure(EntityTypeBuilder<Tarife> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TarifeAdi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Icerik).IsRequired();

            // HatTuru ile ilişki
            builder.HasOne(x => x.HatTuru)
                   .WithMany()
                   .HasForeignKey(x => x.HatTuruId)
                   .OnDelete(DeleteBehavior.Restrict); 
            builder.Property(x => x.TarifeUcreti)
                   .IsRequired();
               
        }
    }
}
