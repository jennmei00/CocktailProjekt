using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaktionslogik für HauptView.xaml
    /// </summary>
    public partial class HauptView : Window
    {
        private ObservableCollection<Object> alleZutaten = new ObservableCollection<Object>();

        public ObservableCollection<Object> AlleZutaten { get => alleZutaten; set => alleZutaten = value; }
        public HauptView()
        {
            InitializeComponent();
        }

        private void buttonAlkohol_Click(object sender, RoutedEventArgs e)
        {
            AlkoholView alkoholView = new AlkoholView();
            alkoholView.Show();
        }

        private void buttonSaft_Click(object sender, RoutedEventArgs e)
        {
            SaftView saftView = new SaftView();
            saftView.Show();
        }

        private void buttonDeko_Click(object sender, RoutedEventArgs e)
        {
            DekoView dekoView = new DekoView();
            dekoView.Show();
        }

        private void buttonRezepte_Click(object sender, RoutedEventArgs e)
        {
            RezeptView rezeptView = new RezeptView();
            rezeptView.Show();
        }
    }
}
