﻿namespace APBDpk2.Entities
{
    public class Muzyk
    {
        public int IdMuzyk { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string? Pseudonim { get; set; }

        public ICollection<WykonawcaUtworu> wykonawcaUtworu { get; set; }


    }
}
