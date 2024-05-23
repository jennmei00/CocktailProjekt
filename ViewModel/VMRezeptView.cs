using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace ViewModel
{
    public class VMRezeptView
    {
        private Rezepte rezeptListe;

        public IEnumerable<Rezept> RezeptListe { get => rezeptListe.ListRezept; }

        public VMRezeptView()
        {
            rezeptListe = new Rezepte();
        }
    }
}
