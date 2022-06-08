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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new RoomOperationsPage();
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
        }

        private void AllDrugsNav(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DrugOperationsPage();
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");

        }

        private void AllEqpNav(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EqpOperationsPage();   
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");

        }

        private void AllRoomsNav(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new RoomOperationsPage();
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
        }

        private void StatNav(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StatisticsPage(); 
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");

        }

        private void SettNav(object sender, RoutedEventArgs e)
        {
            
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
        }

        private void ProfileNav(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AccPage();
            ProfileButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            SettingsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            StatButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
            DrugsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2A393A");
        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            app.Properties["IdUser"] = -1;
            app.Properties["Role"] = "null";
            var logOut = new LoginWindow();
            logOut.Show();
            Close();
        }
    }
}
