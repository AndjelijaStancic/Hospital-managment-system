using System.Collections.Generic;
using System.Windows;

namespace SIMSWPF
{
    /// <summary>
    /// Interaction logic for Izmenipregled.xaml
    /// </summary>
    public partial class Izmenipregled : Window
    {
        TerminController tc1 = new TerminController();

        public List<Termin> Termini1
        {
            get;
            set;
        }





        private int iddoktora = 233;
        public Izmenipregled()
        {
            InitializeComponent();
            this.DataContext = this;
            Termini1 = tc1.nadjisvetermine(iddoktora);
        }



        private void Izmeniodabranog(object sender, RoutedEventArgs e)

        {



            Termin termin = (Termin)dataGridTermini1.SelectedItem;

           


            var s = new EditSelectedTermWindow(termin.Idtermina);
            s.Show();




        }








    }
}
