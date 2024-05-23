using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Input;
using System.Media;
using System.Data.OleDb;

namespace ViewModel
{
    public class VMHauptView
    {
        private ICommand buttonAktualisieren;
        private ICommand buttonEntfernen;
        private ICommand buttonMixen;

        private Decimal gesamtpreis = 0;

        private ObservableCollection<Object> alleZutaten;

        public ObservableCollection<Object> AlleZutaten { get => alleZutaten; set => alleZutaten = value; }
        public ICommand ButtonAktualisieren { get => buttonAktualisieren; set => buttonAktualisieren = value; }
        public ICommand ButtonEntfernen { get => buttonEntfernen; set => buttonEntfernen = value; }
        public ICommand ButtonMixen { get => buttonMixen; set => buttonMixen = value; }

        public VMHauptView()
        {
            this.ButtonAktualisieren = new UserCommand(Deserialisieren);
            this.ButtonEntfernen = new UserCommand(Entfernen);
            this.ButtonMixen = new UserCommand(Mixen);
            alleZutaten = new ObservableCollection<Object>();

            StreamWriter sw = new StreamWriter("Rezepte.txt", true, Encoding.UTF8);
            String zeile = "Rezept: ";
            sw.WriteLine(zeile);
            sw.Close();
        }

        public void Mixen(Object o)
        {
            String name = (String)o;

            if (name == "")
            {
                MessageBox.Show("Bitte erst Cocktailname eingeben!");
            }
            else
            {
                Data data = new Data();

                foreach(Object obj in AlleZutaten)
                {
                    if(obj.GetType() == typeof(Alkohol))
                    {
                        Alkohol a = (Alkohol)obj;
                        gesamtpreis += a.Preis;
                    }
                    else if(obj.GetType() == typeof(Saft))
                    {
                        Saft s = (Saft)obj;
                        gesamtpreis += s.Preis;
                    }
                    else if(obj.GetType() == typeof(Deko))
                    {
                        Deko d = (Deko)obj;
                        gesamtpreis += d.Preis;
                    }
                }

                if(AlleZutaten.Count == 0)
                {
                    MessageBox.Show("Bitte erst mind. eine Zutat auswählen!");
                }
                else if(AlleZutaten.Count > 5)
                {
                    MessageBox.Show("Nicht mehr als 5 Zutaten möglich!");
                }
                else
                {
                    data.SaveRezepte(name, AlleZutaten, gesamtpreis);
                }
                AlleZutaten.Clear();
            }
        }

        public void Entfernen(Object o)
        {
            MessageBox.Show(o.ToString());
            AlleZutaten.Remove(o);
        }

        public void saftUebernehmen(ObservableCollection<Saft> auswahlSaft)
        {
            foreach (Saft s in auswahlSaft)
            {
                AlleZutaten.Add(s);
            }
        }

        public void dekoUebernehmen(ObservableCollection<Deko> auswahlDeko)
        {
            foreach (Deko d in auswahlDeko)
            {
                AlleZutaten.Add(d);
            }
        }

        public void Deserialisieren(Object o)
        {
            try
            {
                FileStream fsAlkohol = new FileStream("alkohol.xml", FileMode.Open);
                if (fsAlkohol != null)
                {
                    XmlSerializer serAlkohol = new XmlSerializer(typeof(ObservableCollection<Alkohol>));
                    ObservableCollection<Alkohol> alkListe = (ObservableCollection<Alkohol>)serAlkohol.Deserialize(fsAlkohol);
                    foreach (Alkohol a in alkListe)
                    {
                        AlleZutaten.Add(a);
                    }                  
                }
                fsAlkohol.Close();
                File.Delete("alkohol.xml");
            }
            catch (FileNotFoundException e)
            {

            }

            try
            {
                FileStream fsSaft = new FileStream("saft.xml", FileMode.Open);
                XmlSerializer serSaft = new XmlSerializer(typeof(ObservableCollection<Saft>));
                ObservableCollection<Saft> saftListe = (ObservableCollection<Saft>)serSaft.Deserialize(fsSaft);
                foreach (Saft s in saftListe)
                {
                    AlleZutaten.Add(s);
                }
                fsSaft.Close();
                File.Delete("saft.xml");
            }
            catch (FileNotFoundException e)
            {
             
            }

            try
            {
                FileStream fsDeko = new FileStream("deko.xml", FileMode.Open);
                XmlSerializer serDeko = new XmlSerializer(typeof(ObservableCollection<Deko>));
                ObservableCollection<Deko> dekoListe = (ObservableCollection<Deko>)serDeko.Deserialize(fsDeko);
                foreach (Deko d in dekoListe)
                {
                    AlleZutaten.Add(d);
                }
                fsDeko.Close();
                File.Delete("deko.xml");
            }
            catch (FileNotFoundException e)
            {

            }
        }     
    }
}
