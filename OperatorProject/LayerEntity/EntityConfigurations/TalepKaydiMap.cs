using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class TalepKaydiMap:IEntityTypeConfiguration<TalepKaydi>
    {
        public void Configure(EntityTypeBuilder<TalepKaydi> builder)
        {
           
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Konu).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(500);           
            builder.HasOne(x => x.Statu)
            .WithMany()
            .HasForeignKey(x => x.StatuId).OnDelete(DeleteBehavior.Restrict);

       
            builder.HasOne(x => x.Kullanici)
                   .WithMany()
                   .HasForeignKey(x => x.KullaniciId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

