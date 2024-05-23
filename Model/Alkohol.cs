using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Alkohol
    {
        private Int32 id;
        private String bezeichnung;
        private Double gehalt;
        private Decimal preis;

        public int Id { get => id; set => id = value; }
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public double Gehalt { get => gehalt; set => gehalt = value; }
        public decimal Preis { get => preis; set => preis = value; }

        public Alkohol()
        {

        }

        public override string ToString()
        {
            return String.Format("{0}", this.Bezeichnung);
        }
    }
}
