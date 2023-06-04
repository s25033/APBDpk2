using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDpk2.Entities.Configs
{
    public class AlbumEfConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(e => e.IdAlbum).HasName("Album_pk");
            builder.Property(e=>e.IdAlbum).UseIdentityColumn();

            builder.Property(e => e.NazwaAlbumu).IsRequired().HasMaxLength(30);

            builder.Property(e => e.DataWydania).IsRequired();

            builder.HasOne(e => e.wytwornia) // 'Wytwornia' to właściwość, która reprezentuje powiązaną encję 'Wytwornia'
                   .WithMany(w => w.Album) // 'WithMany' oznacza, że 'Wytwornia' może mieć wiele albumów
                   .HasForeignKey(e => e.IdWytwornia) // 'IdWytwornia' to pole, na którym definiujemy klucz obcy
                   .HasConstraintName("Wytwornia_fk"); // Nazwa ograniczenia klucza obcego, możesz ją dostosować do swoich potrzeb


            builder.ToTable("Album");
        }
    }
}
