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
    /// Interaction logic for RoomCrud.xaml
    /// </summary>
    public partial class RoomCrud : Window
    {
        public RoomCrud()
        {
            InitializeComponent();
        }

        private void ShowRooms(object sender, RoutedEventArgs e)
        {
            var s = new ShowRooms();
            s.Show();
        }

        private void DeleteRoom(object sender, RoutedEventArgs e)
        {
            var s = new DeleteRoom();
            s.Show();
        }

        private void CreateRoom(object sender, RoutedEventArgs e)
        {
            var s = new CreateRoom();
            s.Show();
        }

        private void UpdateRoom(object sender, RoutedEventArgs e)
        {
            var s = new UpdateRoom();
            s.Show();
        }

    }
}
