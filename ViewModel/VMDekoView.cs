using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

namespace ViewModel
{
    public class VMDekoView
    {
        private ICommand buttonHinzufuegen;
        private ICommand buttonEntfernen;
        private ICommand buttonUebernehmen;
        private Decimal preis;

        private Dekos dekoliste;
        private ObservableCollection<Deko> auswahlDeko = new ObservableCollection<Deko>();

        public IEnumerable<Deko> Dekoliste { get => dekoliste.ListDekos; }
        public ICommand ButtonHinzufuegen { get => buttonHinzufuegen; set => buttonHinzufuegen = value; }
        public ICommand ButtonEntfernen { get => buttonEntfernen; set => buttonEntfernen = value; }
        public ICommand ButtonUebernehmen { get => buttonUebernehmen; set => buttonUebernehmen = value; }
        public ObservableCollection<Deko> AuswahlDeko { get => auswahlDeko; set => auswahlDeko = value; }
        public decimal Preis { get => preis; set => preis = value; }

        public VMDekoView()
        {
            this.ButtonHinzufuegen = new UserCommand(Hinzufuegen);
            this.ButtonEntfernen = new UserCommand(Entfernen);
            this.ButtonUebernehmen = new UserCommand(Uebernehmen);
            dekoliste = new Dekos(); 
        }

        private void Uebernehmen(Object o)
        {
            ObservableCollection<Deko> liste = (ObservableCollection<Deko>)o;
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Deko>));
            FileStream stream = new FileStream("deko.xml", FileMode.Create);
            ser.Serialize(stream, liste);
            stream.Close();

            StreamWriter sw = new StreamWriter("Rezepte.txt", true, Encoding.UTF8);
            String zeile = null;
            foreach (Deko al in liste)
            {
                zeile += al.Bezeichnung.ToString() + " für ";
                zeile += al.Preis.ToString() + " €";
                sw.WriteLine(zeile);
            }
            sw.Close();
        }

        public void Hinzufuegen(Object o)
        {
            if (o.ToString() != "System.Object")
            {
                Deko d = (Deko)o;
                Boolean adden = true;

                if (AuswahlDeko.Count != 0)
                {
                    foreach (Deko de in AuswahlDeko)
                    {
                        if (d == de)
                        {
                            adden = false;
                        }
                    }

                    if (adden == true)
                    {
                        AuswahlDeko.Add(d);
                        Preis += d.Preis;
                    }
                }
                else
                {
                    AuswahlDeko.Add(d);
                    Preis += d.Preis;
                }
            }        
        }

        public void Entfernen(Object o)
        {
            if(o.ToString() != "System.Object")
            {
                Deko d = (Deko)o;
                AuswahlDeko.Remove(d);
            }        
        }
    }
}
