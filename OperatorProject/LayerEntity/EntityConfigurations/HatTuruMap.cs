using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class HatTuruMap : IEntityTypeConfiguration<HatTuru>
    {
        public virtual void Configure(EntityTypeBuilder<HatTuru> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(10);
        }
    }
}