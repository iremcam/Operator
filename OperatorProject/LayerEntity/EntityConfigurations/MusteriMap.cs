using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class MusteriMap: IEntityTypeConfiguration<Musteri>
    {
        public virtual void Configure(EntityTypeBuilder<Musteri> builder)
        {
            builder.HasKey(x=> x.Id);

           
            builder.HasOne(x => x.KimlikBilgileri)
                .WithMany()
                .HasForeignKey(x => x.KimlikId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Telefon).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.FaturaAdresi).IsRequired();

        }
    }
}
