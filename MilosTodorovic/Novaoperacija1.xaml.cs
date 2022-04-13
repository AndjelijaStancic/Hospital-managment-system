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

namespace SIMSWPF
{
    /// <summary>
    /// Interaction logic for Novaoperacija1.xaml
    /// </summary>
    public partial class Novaoperacija1 : Window
    {

        long iddoktora = 233;
        TerminController tc1 = new TerminController();
        private List<String> idsala = new List<String>();
        public Novaoperacija1()
        {
            InitializeComponent();
        }

        private void Pronadjisalezaoperaciju_Click(object sender, RoutedEventArgs e)
        {
            DateTime vremepocetkatermina = DateTime.Parse(Vremepocetkatermina.Text);
            DateTime vremekrajatermina = DateTime.Parse(Vremekrajatermina.Text);
             idsala = tc1.pronadjisalezaoperaciju(vremepocetkatermina, vremekrajatermina, iddoktora);
            if (idsala == null)
            {
                List<String> idsala1 = new List<String>();
                var s1 = new Salezaoperaciju(idsala1, vremepocetkatermina, vremekrajatermina, iddoktora);
                s1.Show();
            }
            else
            {
                foreach (String a in idsala)
                {
                    Console.WriteLine(a);
                }

                var s = new Salezaoperaciju(idsala, vremepocetkatermina, vremekrajatermina, iddoktora);
                s.Show();
            }
        }
    }
}
