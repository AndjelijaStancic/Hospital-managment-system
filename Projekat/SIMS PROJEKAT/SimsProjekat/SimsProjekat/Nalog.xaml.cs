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
using Controller;
using Model;
using System.ComponentModel;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for Nalog.xaml
    /// </summary>
    public partial class Nalog : Window
    {
        private AccController acc_Controller;
        public event PropertyChangedEventHandler PropertyChangedEvent;
        
        



        public Nalog()
        {
            InitializeComponent();
            var app = Application.Current as App;
            acc_Controller = app.AccController;
            User user = acc_Controller.GetOne();
            Name.Text = user.FirstName;
            Surname.Text = user.LastName;
            UserName.Text = user.UserName;  
            Email.Text = user.Email;
            this.DataContext = this;
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {

        }
        private void AllRoomsNav(object sender, RoutedEventArgs e)
        {
            
        }

        private void StatNav(object sender, RoutedEventArgs e)
        {

        }

        private void SettNav(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileNav(object sender, RoutedEventArgs e)
        {
            
        }

        private void AllEqpNav(object sender, RoutedEventArgs e)
        {

        }

        private void AllDrugsNav(object sender, RoutedEventArgs e)
        {

        }
    }
}
