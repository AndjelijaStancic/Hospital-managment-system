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
    /// Interaction logic for Prikazisvetermine.xaml
    /// </summary>
    public partial class Prikazisvetermine : Window
    {
        TerminController tc1 = new TerminController();
        int iddoktora = 233;
        public List<Termin> Termini
        {
            get;
            set;
        }




        public Prikazisvetermine()
        {

            InitializeComponent();
            this.DataContext = this;

            Termini = tc1.nadjisvetermine(iddoktora);
            Termin tr = new Termin();



        }

        private void Obrisiodabranetermine(object sender, RoutedEventArgs e)

        {

            //    Console.WriteLine("eee");
            //List<Termin> terminizabrisanje = new List<Termin>();
            //    terminizabrisanje = dataGridTermini.SelectedItems.Cast<Termin>().ToList();
            //    foreach(Termin tr in terminizabrisanje)
            //    {
            //        Console.WriteLine(tr.Idtermina);
            //    }
            //    tc1.izbrisitermine(terminizabrisanje);
            //}
            //    foreach (Termin item in dataGridTermini.ItemsSource)
            //    {
            //        if (((CheckBox)Odaberi1.GetCellContent(item)).IsChecked == true)
            //        {
            //            terminizabrisanje.Add(item);
            //        }


            //    }
            //    tc1.izbrisitermine(terminizabrisanje);
            //}

            List<Termin> terminizabrisanje = dataGridTermini.SelectedItems.Cast<Termin>().ToList();
            foreach(Termin tr in terminizabrisanje)
            {
                Console.WriteLine(tr.Idtermina);
            }
            tc1.izbrisitermine(terminizabrisanje);


        }
    }
}