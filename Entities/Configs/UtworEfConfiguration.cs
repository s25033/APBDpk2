using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDpk2.Entities.Configs
{
    public class UtworEfConfiguration : IEntityTypeConfiguration<Utwor>
    {
        public void Configure(EntityTypeBuilder<Utwor> builder)
        {
            builder.HasKey(e => e.IdUtwor).HasName("Utwor_pk");
            builder.Property(e=>e.IdUtwor).UseIdentityColumn();

            builder.Property(e => e.NazwaUtworu).IsRequired().HasMaxLength(30);

            builder.Property(e => e.CzasTrwania).IsRequired();

       



            builder.HasOne(e => e.Album) // 'Album' to właściwość, która reprezentuje powiązaną encję 'Album'
                .WithMany() // 'WithMany' oznacza, że 'Album' może mieć wiele utworów
                .HasForeignKey(e => e.IdAlbum) // 'IdAlbum' to pole, na którym definiujemy klucz obcy
                .HasConstraintName("UtworAlbum_fk"); // Nazwa ograniczenia klucza obcego, możesz ją dostosować do swoich potrzeb

            builder.ToTable("Utwor");


        }
    }
}
