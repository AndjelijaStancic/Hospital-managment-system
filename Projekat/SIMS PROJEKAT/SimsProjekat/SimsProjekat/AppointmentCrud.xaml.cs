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

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for AppointmentCrud.xaml
    /// </summary>
    public partial class AppointmentCrud : Window
    {
        public AppointmentCrud()
        {
            InitializeComponent();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            var btn = new CreateAppointment();
            btn.Show();
        }

        private void ShowAppointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = new AppointmentCrud();
            btn.Show();
        }
    }
}
