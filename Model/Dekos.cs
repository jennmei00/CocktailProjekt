using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dekos
    {
        private Data data = new Data();
        private ObservableCollection<Deko> listDekos;

        public ObservableCollection<Deko> ListDekos { get => listDekos; set => listDekos = value; }

        public Dekos()
        {
            listDekos = new ObservableCollection<Deko>();
            DataSet ds = data.GetDekos();
            DataTable dt = ds.Tables[0];
            DataTableReader reader = dt.CreateDataReader();
            while(reader.Read())
            {
                Deko d = mkDeko(reader);
                listDekos.Add(d);
            }
            reader.Close();
        }

        private Deko mkDeko(DataTableReader reader)
        {
            Deko d = new Deko();

            d.Id = reader.GetInt32(0);
            d.Bezeichnung = reader.GetString(1);
            d.Preis = reader.GetDecimal(2);

            return d;
        }
    }
}
