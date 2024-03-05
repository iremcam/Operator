using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class KimlikBilgileriMap : IEntityTypeConfiguration<KimlikBilgileri>
    {
        public virtual void Configure(EntityTypeBuilder<KimlikBilgileri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tc).IsRequired();
            builder.Property(x => x.DogumTarihi).IsRequired();
            builder.Property(x => x.CinsiyetId).IsRequired();
            builder.Property(x => x.Ad).IsRequired();
            builder.Property(x => x.Soyad).IsRequired();
        }
    }
}
