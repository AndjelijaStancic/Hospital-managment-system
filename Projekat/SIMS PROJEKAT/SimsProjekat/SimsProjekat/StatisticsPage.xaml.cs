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
using Model;
using Controller;
using System.ComponentModel;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private StatController stat_Controller;

        public event PropertyChangedEventHandler PropertyChangedEvent;

        public List<StatDisplay> statistics { get; set; }
             
        public StatisticsPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            stat_Controller = app.StatController;
            this.statistics = stat_Controller.GetAll();            
            this.DataContext = this;
           
        }

        private void commentsClikck(object sender, RoutedEventArgs e)
        {
            Comments.Visibility = Visibility.Visible;
        }
    }
}
