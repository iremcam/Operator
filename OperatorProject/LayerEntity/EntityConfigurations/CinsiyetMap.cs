using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class CinsiyetMap: IEntityTypeConfiguration<Cinsiyet>
    {

        public virtual void Configure(EntityTypeBuilder<Cinsiyet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(10);
        }
    }
}
