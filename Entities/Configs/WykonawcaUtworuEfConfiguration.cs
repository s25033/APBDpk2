using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDpk2.Entities.Configs
{
    public class WykonawcaUtworuEfConfiguration : IEntityTypeConfiguration<WykonawcaUtworu>
    {
        public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
        {
            builder.HasKey(e => new { e.IdMuzyk, e.IdUtwor }).HasName("WykonawcaUtworu_pk");

            builder.HasOne(wu => wu.Muzyk)
            .WithMany(m => m.wykonawcaUtworu)
            .HasForeignKey(wu => wu.IdMuzyk);

            // Skonfiguruj relację z Utwor (wiele do wielu)
            builder.HasOne(wu => wu.utwor)
                .WithMany(u => u.wykonawcaUtworu)
                .HasForeignKey(wu => wu.IdUtwor); ;

            builder.ToTable("Wykonawca_Utworu");
        }
    }
}
