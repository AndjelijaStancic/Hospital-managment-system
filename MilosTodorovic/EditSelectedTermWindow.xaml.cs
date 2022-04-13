using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for EditSelectedTermWindow.xaml
    /// </summary>
    public partial class EditSelectedTermWindow : Window, INotifyPropertyChanged
    {

        long iddoktora = 233;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Termin selectedTerm;
        private long idtermina4;
        
        public Termin SelectedTerm
        {
            get
            {
                return selectedTerm;
            }

            set
            {
                if(value != selectedTerm)
                {
                    selectedTerm = value;
                    OnPropertyChanged("SelectedTerm");
                }
            }
        }
        
        List<String> Prostorije { get; set; }
        

        TerminController tc1 = new TerminController();

        public EditSelectedTermWindow(long termId)
        {
            InitializeComponent();
            Console.WriteLine(termId);
            this.DataContext = this;
            SelectedTerm = tc1.nadjitermin(termId);
            idtermina4 = termId;
           
            String brojsale = SelectedTerm.Brojsale;
            Prostorije = new List<String>();
            
            Console.WriteLine(brojsale);
            Prostorije.Add(brojsale);
            Console.WriteLine("Datum i vreme:" + SelectedTerm.Vremepocetkatermina);
            foreach(String a in Prostorije)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine(SelectedTerm.Vremepocetkatermina.ToString());
            //Vremepocetkatermina.Text = SelectedTerm.Vremepocetkatermina.ToString();
            RoomComboBox.ItemsSource = Prostorije;
            

        }

  
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(idtermina4);
            Termin termin34 = tc1.nadjitermin(idtermina4);
            termin34.Brojsale = SelectedTerm.Brojsale;
            termin34.Vremepocetkatermina = SelectedTerm.Vremepocetkatermina;
            termin34.Vremekrajatermina = termin34.Vremepocetkatermina.AddMinutes(15);
             Console.WriteLine(termin34.Brojsale);
            Console.WriteLine(termin34.Idtermina);
           Termin termin33 =  tc1.izmenitermin(termin34);
        }

        private void Vremepocetkatermina_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            DateTime vremepocetka1 = SelectedTerm.Vremepocetkatermina;
            Prostorije = tc1.pronadjiprostorije(vremepocetka1, iddoktora);
            RoomComboBox.ItemsSource = Prostorije;

            
        }

       
    }
}
