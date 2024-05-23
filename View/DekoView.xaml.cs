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

namespace View
{
    /// <summary>
    /// Interaktionslogik für DekoView.xaml
    /// </summary>
    public partial class DekoView : Window
    {
        public DekoView()
        {
            InitializeComponent();
        }

        private void ButtonUebernehmen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
