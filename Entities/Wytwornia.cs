namespace APBDpk2.Entities
{
    public class Wytwornia
    {
        public int IdWytwornia { get; set; }

        public string Nazwa { get; set; }

        public virtual ICollection<Album > Album { get; set; }
    }
}
