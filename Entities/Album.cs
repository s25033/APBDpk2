namespace APBDpk2.Entities
{
    public class Album
    {
        public int IdAlbum { get; set; }

        public string NazwaAlbumu { get; set; }

        public DateTime DataWydania { get; set; }

        public int IdWytwornia { get; set; }

        public ICollection<Utwor> utwor { get; set; }

        public Wytwornia wytwornia { get; set; }

    }
}
