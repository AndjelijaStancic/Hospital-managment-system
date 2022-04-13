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
    /// Interaction logic for Kreirajnovitermin.xaml
    /// </summary>
    public partial class Kreirajnovitermin : Window
    {



       

        TerminController tc = new TerminController();

        private long idtermina = 0;
        private long idpacijenta = 100;
        Doctor doctor = new Doctor();
        List<String> slobodneprostorije = new List<String>();
        

        public Kreirajnovitermin()
        {
            InitializeComponent();
            
            doctor.Ime = "Milos";
            doctor.Prezime = "Todorovic";
            doctor.Jmbg = "3606";
            doctor.Doctorid = 233;
        }


        private void Kreirajnovipregled(object sender, RoutedEventArgs e)
        {
           
            
            Termin termin = new Termin();
            Pacijent pacijent = new Pacijent();
            termin.Brojsale = Brojsale.Text;
           DateTime pocetak =  termin.Vremepocetkatermina = DateTime.Parse(Vremepocetkatermina.Text);
            termin.Vremekrajatermina = pocetak.AddMinutes(15);
            termin.Idtermina = idtermina++;
            termin.Doctor = doctor;
            pacijent.Idpacijenta = idpacijenta++;
            termin.Pacijent = pacijent;
            termin.Tiptermina = Tiptermina.pregled;
            
            
            

           

            Termin termin1 = tc.createtermin(termin);
            

                List<String> slobodneprostorije1 = new List<String>();
                List<long> slobodneprostorije2 = new List<long>();

                DateTime vremepocetkatermina1 = DateTime.Parse(Vremepocetkatermina.Text);
                long iddoktora = doctor.Doctorid;
                slobodneprostorije = tc.pronadjiprostorije(vremepocetkatermina1, iddoktora);

                if (slobodneprostorije == null)
                {
                    Brojsale.ItemsSource = slobodneprostorije2;
                }
                else
                {
                    foreach (String a in slobodneprostorije)
                    {

                        slobodneprostorije1.Add(a);



                    }

                    Brojsale.ItemsSource = slobodneprostorije;

                }




            


        }


        private void Pronadjisale(object sender, RoutedEventArgs e) 
        {

            List<String> slobodneprostorije1 = new List<String>();
            List<long> slobodneprostorije2 = new List<long>();
            
            DateTime vremepocetkatermina1 = DateTime.Parse(Vremepocetkatermina.Text);
            long iddoktora = doctor.Doctorid;
            slobodneprostorije = tc.pronadjiprostorije(vremepocetkatermina1, iddoktora);
            foreach(String b in slobodneprostorije)
            {
                Console.WriteLine("Vraceneprostorije1:" + b);
            }
            if (slobodneprostorije == null)
            {
                Brojsale.ItemsSource = slobodneprostorije2;
            }
            else
            {
                foreach (String a in  slobodneprostorije)
                {

                    slobodneprostorije1.Add(a);



                }

                Brojsale.ItemsSource = slobodneprostorije1;

            }




        }

    }
}
