using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Deko
    {
        private Int32 id;
        private String bezeichnung;
        private Decimal preis;

        public int Id { get => id; set => id = value; }
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public decimal Preis { get => preis; set => preis = value; }

        public Deko()
        {

        }

        public override string ToString()
        {
            return String.Format("{0}", this.Bezeichnung);
        }
    }
}
