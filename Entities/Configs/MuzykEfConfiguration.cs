using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDpk2.Entities.Configs
{
    public class MuzykEfConfiguration : IEntityTypeConfiguration<Muzyk>
    {
        public void Configure(EntityTypeBuilder<Muzyk> builder)
        {
            builder.HasKey(e => e.IdMuzyk).HasName("Muzyk_pk");
            builder.Property(e => e.IdMuzyk).UseIdentityColumn();
            //builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Imie).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Nazwisko).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Pseudonim).HasMaxLength(50);

            builder.ToTable("Muzyk");
        }
    }
}
