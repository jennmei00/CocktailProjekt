using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Serialization;
using System.IO;

namespace ViewModel
{
    public class VMAlkoholView
    {

        private ICommand buttonHinzufuegen;
        private ICommand buttonEntfernen;
        private ICommand buttonUebernehmen;
        private ICommand buttonSerialisieren;
        private Decimal preis;

        private Alkohole alkoholliste;
        private ObservableCollection<Alkohol> auswahlAlkohol = new ObservableCollection<Alkohol>();

        public IEnumerable<Alkohol> Alkoholliste { get => alkoholliste.ListAlkohol; }
        public ICommand ButtonHinzufuegen { get => buttonHinzufuegen; set => buttonHinzufuegen = value; }
        public ICommand ButtonEntfernen { get => buttonEntfernen; set => buttonEntfernen = value; }
        public ICommand ButtonUebernehmen { get => buttonUebernehmen; set => buttonUebernehmen = value; }
        public ObservableCollection<Alkohol> AuswahlAlkohol { get => auswahlAlkohol; set => auswahlAlkohol = value; }
        public ICommand ButtonSerialisieren { get => buttonSerialisieren; set => buttonSerialisieren = value; }
        public decimal Preis { get => preis; set => preis = value; }

        public VMAlkoholView()
        {
            this.ButtonHinzufuegen = new UserCommand(Hinzufuegen);
            this.ButtonEntfernen = new UserCommand(Entfernen);
            this.ButtonSerialisieren = new UserCommand(Serialisieren);
            alkoholliste = new Alkohole();
        }

        public void Hinzufuegen(Object o)
        {
            if(o.ToString() != "System.Object")
            {
                Alkohol a = (Alkohol)o;
                Boolean adden = true;

                if (AuswahlAlkohol.Count != 0)
                {
                    foreach (Alkohol al in AuswahlAlkohol)
                    {
                        if (a == al)
                        {
                            adden = false;
                        }
                    }

                    if (adden == true)
                    {
                        AuswahlAlkohol.Add(a);
                        Preis += a.Preis;
                    }
                }
                else
                {
                    AuswahlAlkohol.Add(a);
                    Preis += a.Preis;
                }
            }
        }

        public void Entfernen(Object o)
        {
            if(o.ToString() != "System.Object")
            {
                Alkohol a = (Alkohol)o;
                AuswahlAlkohol.Remove(a);
                Preis -= a.Preis;
            }
        }

         public void Serialisieren(Object o)
         {
             ObservableCollection<Alkohol> liste = (ObservableCollection<Alkohol>)o;
             XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Alkohol>));
             FileStream stream = new FileStream("alkohol.xml", FileMode.Create);
             ser.Serialize(stream, liste);
             stream.Close();

            StreamWriter sw = new StreamWriter("Rezepte.txt", true, Encoding.UTF8);
            String zeile = null;
            foreach(Alkohol al in liste)
            {
                zeile += al.Bezeichnung.ToString() + " für ";
                zeile += al.Preis.ToString() + " €";
                sw.WriteLine(zeile);
            }
            sw.Close();
         }
    }
}
