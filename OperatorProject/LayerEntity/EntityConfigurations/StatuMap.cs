using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.EntityConfigurations
{
    public class StatuMap : IEntityTypeConfiguration<Statu>
    {

        public virtual void Configure(EntityTypeBuilder<Statu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(10);
        }

    }
}
