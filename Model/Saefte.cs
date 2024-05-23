using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Saefte
    {
        private Data data = new Data();
        private ObservableCollection<Saft> listSaft;

        public ObservableCollection<Saft> ListSaft { get => listSaft; set => listSaft = value; }

        public Saefte()
        {
            listSaft = new ObservableCollection<Saft>();
            DataSet ds = data.GetSaefte();
            DataTable dt = ds.Tables[0];
            DataTableReader reader = dt.CreateDataReader();
            while (reader.Read())
            {
                Saft s = mkSaft(reader);
                listSaft.Add(s);
            }
            reader.Close();
        }

        private Saft mkSaft(DataTableReader reader)
        {
            Saft s = new Saft();

            s.Id = reader.GetInt32(0);
            s.Bezeichnung = reader.GetString(1);
            s.Preis = reader.GetDecimal(2);

            return s;
        }
    }
}
