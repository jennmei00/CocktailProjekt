using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Alkohole
    {
        private Data dto = new Data();
        private ObservableCollection<Alkohol> listAlkohol;

        public ObservableCollection<Alkohol> ListAlkohol { get => listAlkohol; set => listAlkohol = value; }

        public Alkohole()
        {
            listAlkohol = new ObservableCollection<Alkohol>();
            DataSet ds = dto.GetAlkohole();
            DataTable dt = ds.Tables[0];
            DataTableReader reader = dt.CreateDataReader();
            while (reader.Read())
            {
                Alkohol a = mkAlkohol(reader);
                listAlkohol.Add(a);
            }
            reader.Close();
        }

        private Alkohol mkAlkohol(DataTableReader reader)
        {
            Alkohol a = new Alkohol();

            a.Id = reader.GetInt32(0);
            a.Bezeichnung = reader.GetString(1);
            a.Gehalt = reader.GetDouble(2);
            a.Preis = reader.GetDecimal(3);

            return a;
        }
    }
}
