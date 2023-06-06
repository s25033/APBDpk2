namespace APBDpk2.Entities
{
    public class Utwor
    {

        public int IdUtwor { get; set; }

        public string NazwaUtworu { get; set; }

        public DateTime CzasTrwania { get; set; }

        public int? IdAlbum { get; set; }

        public virtual ICollection<WykonawcaUtworu> wykonawcaUtworu { get; set; }  

        public virtual Album Album { get; set; }
    }
}
