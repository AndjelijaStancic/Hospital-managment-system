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
using Controller;
using Model;
using System.ComponentModel;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for AccPage.xaml
    /// </summary>
    public partial class AccPage : Page
    {
        private AccController acc_Controller;
        public event PropertyChangedEventHandler PropertyChangedEvent;
        public AccPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            acc_Controller = app.AccController;
            int Id = int.Parse(string.Format("{0}", app.Properties["IdUser"]));
            User user = acc_Controller.GetById(Id);
            Name.Text = user.FirstName;
            Surname.Text = user.LastName;
            UserName.Text = user.UserName;
            Email.Text = user.Email;
            this.DataContext = this;
        }
    }
}
