namespace APBDpk2.Entities
{
    public class Album
    {
        public int IdAlbum { get; set; }

        public string NazwaAlbumu { get; set; }

        public DateTime DataWydania { get; set; }

        public int IdWytwornia { get; set; }

        public virtual ICollection<Utwor> utwor { get; set; }

        public virtual Wytwornia wytwornia { get; set; }

    }
}
