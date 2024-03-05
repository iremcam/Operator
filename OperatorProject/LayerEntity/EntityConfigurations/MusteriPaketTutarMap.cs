using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class MusteriPaketTutarMap: IEntityTypeConfiguration<MusteriPaketTutar>
    {
        public void Configure(EntityTypeBuilder<MusteriPaketTutar> builder)
        {
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MusteriId).IsRequired();
            builder.Property(x => x.TarifeId).IsRequired();
            

            builder.HasOne(x => x.Musteri)
                   .WithMany()
                   .HasForeignKey(x => x.MusteriId);

            builder.HasOne(x => x.Tarife)
                   .WithMany()
                   .HasForeignKey(x => x.TarifeId);
        }
    }
}
 
