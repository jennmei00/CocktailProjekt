using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Data
    {
        OleDbConnection con;

        public Data()
        {
            con = new OleDbConnection(Properties.Settings1.Default.ConString);
        }

        public bool OpenConnection()
        {
            Boolean result = true;
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public DataSet GetAlkohole()
        {
            DataSet dsAlkohole = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Alkohol", con);
            adapter.Fill(dsAlkohole, "Alkohol");
            return dsAlkohole;
        }

        public DataSet GetSaefte()
        {
            DataSet dsSaefte = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Saft", con);
            adapter.Fill(dsSaefte, "Saft");
            return dsSaefte;
        }

        public DataSet GetDekos()
        {
            DataSet dsDekos = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Deko", con);
            adapter.Fill(dsDekos, "Deko");
            return dsDekos;
        }

        public DataSet GetRezepte()
        {
            DataSet dsRezepte = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Rezept", con);
            adapter.Fill(dsRezepte, "Rezept");
            return dsRezepte;
        }

        public void SaveRezepte(String name, ObservableCollection<Object> zutaten, Decimal preis)
        {
            OpenConnection();
            OleDbCommand cmd = con.CreateCommand();
            if (zutaten.Count == 5)
            {
                cmd.CommandText = "Insert into Rezept (Name, Zutat1, Zutat2, Zutat3, Zutat4, Zutat5, Preis) values ('" + name + "','" + zutaten[0] + "','" + zutaten[1] +
                    "','" + zutaten[2] + "','" + zutaten[3] + "','" + zutaten[4] + "','" + preis + "')";
            }
            else if (zutaten.Count == 4)
            {
                cmd.CommandText = "Insert into Rezept (Name, Zutat1, Zutat2, Zutat3, Zutat4, Preis) values ('" + name + "','" + zutaten[0] + "','" + zutaten[1] +
                    "','" + zutaten[2] + "','" + zutaten[3] + "','" + preis + "')";
            }
            else if (zutaten.Count == 3)
            {
                cmd.CommandText = "Insert into Rezept (Name, Zutat1, Zutat2, Zutat3, Preis) values ('" + name + "','" + zutaten[0] + "','" + zutaten[1] +
                    "','" + zutaten[2] + "','" + preis + "')";
            }
            else if (zutaten.Count == 2)
            {
                cmd.CommandText = "Insert into Rezept (Name, Zutat1, Zutat2, Preis) values ('" + name + "','" + zutaten[0] + "','" + zutaten[1] + 
                    "','" + preis + "')";
            }
            else if (zutaten.Count == 1)
            {
                cmd.CommandText = "Insert into Rezept (Name, Zutat1, Preis) values ('" + name + "','" + zutaten[0] + "','" + preis + "')";
            }
            cmd.ExecuteNonQuery();
        }
    }
}
