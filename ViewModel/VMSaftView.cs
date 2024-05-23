using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Model;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace ViewModel
{
    public class VMSaftView
    {
        private ICommand buttonHinzufuegen;
        private ICommand buttonEntfernen;
        private ICommand buttonUebernehmen;
        private Decimal preis;

        private Saefte saftliste;
        private ObservableCollection<Saft> auswahlSaft = new ObservableCollection<Saft>();

        public IEnumerable<Saft> Saftliste { get => saftliste.ListSaft; }
        public ICommand ButtonHinzufuegen { get => buttonHinzufuegen; set => buttonHinzufuegen = value; }
        public ICommand ButtonEntfernen { get => buttonEntfernen; set => buttonEntfernen = value; }
        public ICommand ButtonUebernehmen { get => buttonUebernehmen; set => buttonUebernehmen = value; }
        public ObservableCollection<Saft> AuswahlSaft { get => auswahlSaft; set => auswahlSaft = value; }
        public decimal Preis { get => preis; set => preis = value; }

        public VMSaftView()
        {
            this.ButtonHinzufuegen = new UserCommand(Hinzufuegen);
            this.ButtonEntfernen = new UserCommand(Entfernen);
            this.ButtonUebernehmen = new UserCommand(Uebernehmen);
            saftliste = new Saefte();
        }

        private void Uebernehmen(Object o)
        {
            ObservableCollection<Saft> liste = (ObservableCollection<Saft>)o;
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Saft>));
            FileStream stream = new FileStream("saft.xml", FileMode.Create);
            ser.Serialize(stream, liste);
            stream.Close();

            StreamWriter sw = new StreamWriter("Rezepte.txt", true, Encoding.UTF8);
            String zeile = null;
            foreach (Saft al in liste)
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
                Saft s = (Saft)o;
                Boolean adden = true;
                if (AuswahlSaft.Count != 0)
                {
                    foreach (Saft sa in AuswahlSaft)
                    {
                        if (s == sa)
                        {
                            adden = false;
                        }
                    }

                    if (adden == true)
                    {
                        AuswahlSaft.Add(s);
                        Preis += s.Preis;
                    }
                }
                else
                {
                    AuswahlSaft.Add(s);
                    Preis += s.Preis;
                }
            }           
        }

        public void Entfernen(Object o)
        {
            if (o.ToString() != "System.Object")
            {
                Saft s = (Saft)o;
                AuswahlSaft.Remove(s);
            }
        }
    }
}
