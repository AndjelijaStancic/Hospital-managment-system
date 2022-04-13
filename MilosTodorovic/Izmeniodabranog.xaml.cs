using System.Windows;

namespace SIMSWPF
{
    /// <summary>
    /// Interaction logic for Izmeniodabranog.xaml
    /// </summary>
    public partial class Izmeniodabranog : Window
    {
        public Termin IzabraniTermin { get; set; }
        TerminController tc1 = new TerminController();

        public Izmeniodabranog(long idtermina)
        {
            InitializeComponent();
            this.DataContext = this;

            IzabraniTermin = tc1.nadjitermin(idtermina);
        }
    }
}