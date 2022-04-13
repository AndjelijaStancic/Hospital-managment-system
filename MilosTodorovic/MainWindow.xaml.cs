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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMSWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Kreirajnovitermin(object sender, RoutedEventArgs e)
        {
            var s = new Kreirajnovitermin();
            s.Show();
        }

        private void Prikazisvetermine(object sender, RoutedEventArgs e)
        {
            var s = new Prikazisvetermine();
            s.Show();
        }


        private void Izmenipregled(object sender, RoutedEventArgs e)
        {
            var s = new Izmenipregled();
            s.Show();
        }


        private void Novaoperacija1(object sender, RoutedEventArgs e)
        {
            var s = new Novaoperacija1();
            s.Show();
        }




    }
}
