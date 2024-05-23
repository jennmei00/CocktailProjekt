using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rezepte
    {
        private Data data = new Data();
        private ObservableCollection<Rezept> listRezept;

        public ObservableCollection<Rezept> ListRezept { get => listRezept; set => listRezept = value; }

        public Rezepte()
        {
            listRezept = new ObservableCollection<Rezept>();
            DataSet ds = data.GetRezepte();
            DataTable dt = ds.Tables[0];
            DataTableReader reader = dt.CreateDataReader();
            while(reader.Read())
            {
                Rezept r = mkRezept(reader);
                listRezept.Add(r);
            }
            reader.Close();
        }

        private Rezept mkRezept(DataTableReader reader)
        {
            Rezept r = new Rezept();

            r.Name = Convert.ToString(CheckDbNull(reader[1]));
            r.Zutat1 = Convert.ToString(CheckDbNull(reader[2]));
            r.Zutat2 = Convert.ToString(CheckDbNull(reader[3]));
            r.Zutat3 = Convert.ToString(CheckDbNull(reader[4]));
            r.Zutat4 = Convert.ToString(CheckDbNull(reader[5]));
            r.Zutat5 = Convert.ToString(CheckDbNull(reader[6]));
            r.Preis = Convert.ToDecimal(CheckDbNull(reader[7]));

            return r;
        }

        private Object CheckDbNull(Object o)
        {
            if (DBNull.Value.Equals(o))
            {
                return null;
            }
            else return o;
        }
    }
}
