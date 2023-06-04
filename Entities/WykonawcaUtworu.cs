namespace APBDpk2.Entities
{
    public class WykonawcaUtworu
    {

        public int IdMuzyk { get; set; }

        public int IdUtwor { get; set; }

        public Muzyk Muzyk { get; set; }

        public Utwor utwor { get; set; }
    }
}
