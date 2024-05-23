using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rezept
    {
        private String name;
        private String zutat1;
        private String zutat2;
        private String zutat3;
        private String zutat4;
        private String zutat5;
        private Decimal preis;

        public string Name { get => name; set => name = value; }
        public string Zutat1 { get => zutat1; set => zutat1 = value; }
        public string Zutat2 { get => zutat2; set => zutat2 = value; }
        public string Zutat3 { get => zutat3; set => zutat3 = value; }
        public string Zutat4 { get => zutat4; set => zutat4 = value; }
        public string Zutat5 { get => zutat5; set => zutat5 = value; }
        public decimal Preis { get => preis; set => preis = value; }
    }
}
