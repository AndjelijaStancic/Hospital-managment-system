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
    /// Interaction logic for Salezaoperaciju.xaml
    /// </summary>
    public partial class Salezaoperaciju : Window
    {
        Doctor doctor = new Doctor();
        Pacijent pacijent = new Pacijent();
        Random rnd = new Random();
        Termin termin = new Termin();
        TerminController tc1 = new TerminController();
        
        
        public Salezaoperaciju(List<String> idsala, DateTime vremepocetkatermina,DateTime vremekrajatermina, long iddoktora)
        {
            InitializeComponent();
            Brojsale.ItemsSource = idsala;
            termin.Vremepocetkatermina = vremepocetkatermina;
            termin.Vremekrajatermina = vremekrajatermina;
            doctor.Doctorid = iddoktora;
            termin.Doctor = doctor;
            pacijent.Idpacijenta = rnd.Next();
            termin.Pacijent = pacijent;
            termin.Tiptermina = Tiptermina.operacija;
        }

        private void Dodajoperaciju_Click(object sender, RoutedEventArgs e)
        {

            termin.Brojsale = Brojsale.Text;
            Termin termin1 = tc1.createtermin(termin);





        }
    }
}
