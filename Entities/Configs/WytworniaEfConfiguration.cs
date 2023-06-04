using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDpk2.Entities.Configs
{
    public class WytworniaEfConfiguration : IEntityTypeConfiguration<Wytwornia>
    {
        public void Configure(EntityTypeBuilder<Wytwornia> builder)
        {
            builder.HasKey(e=>e.IdWytwornia).HasName("Wytwornia_pk");
            builder.Property(e=>e.IdWytwornia).UseIdentityColumn();

            builder.Property(e=>e.Nazwa).HasMaxLength(50).IsRequired();

            builder.ToTable("Wytwornia");
        }
    }
}
