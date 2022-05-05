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
    /// Interaction logic for RoomOperations.xaml
    /// </summary>
    public partial class RoomOperations : Window
    {
        private RoomController room_Controller;
        private RenovationController reno_Controller;

        public event PropertyChangedEventHandler PropertyChangedEvent;
        public List<Room> Rooms { get; set; }
        public List<Renovation> Renovations { get; set; }
        public List<String> Names { get; set; }
        public List<int> Floors { get; set; }
        public List<RoomType> TypesList { get; set; }

        
        public RoomOperations()
        {
            InitializeComponent();
            var app = Application.Current as App;
            room_Controller = app.RoomController;
            reno_Controller = app.RenovationController;

            this.Renovations = reno_Controller.GetAll();
            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();
            this.Floors = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var roomTypes = Enum.GetValues(typeof(RoomType));
            TypesList = roomTypes.OfType<RoomType>().ToList();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
            }

            this.DataContext = this;
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");

        }
        public void RefreshSource()
        {
            this.Rooms = this.room_Controller.GetAll();
            GridRoom.ItemsSource = this.Rooms;
            GridRoom.Items.Refresh();
            this.Names.Clear();
            this.Floors.Clear();
            foreach (Room room in this.Rooms)
            {
                this.Names.Add(room.Name);
            }
        }
        private void AllRoomButton(object sender, RoutedEventArgs e)
        {
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            
            AllRooms.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            this.Rooms = room_Controller.GetAll();
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            
            AllRooms.Visibility = Visibility.Collapsed;
            AddRoom.Visibility = Visibility.Visible;
            UpdateRoom.Visibility = Visibility.Collapsed;
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
         Room newRoom = new Room(-1, NewRoomName.Text, (RoomType)Enum.Parse(typeof(RoomType), AddRoomType.Text, true), int.Parse(NewRoomFloor.Text));
         room_Controller.Create(newRoom);
         AllRooms.Visibility = Visibility.Visible;
         AddRoom.Visibility = Visibility.Collapsed;
         UpdateRoom.Visibility = Visibility.Collapsed;
         RefreshSource();
         AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
         AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
         

        }

        private void delButton(object sender, RoutedEventArgs e)
        {
            WarningDelete.Visibility = Visibility.Visible;
            AllRooms.Visibility = Visibility.Visible;
            UpdateRoom.Visibility = Visibility.Collapsed;
        }
        private void ConfirmDelete(object sender, RoutedEventArgs e)
        {
            int roomId = -1;
            roomId = ((Room)GridRoom.SelectedItem).Id;
            room_Controller.Delete(roomId);
            WarningDelete.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            UpdateRoom.Visibility = Visibility.Collapsed;
            RefreshSource();
        }
        
        private void DenyDelete(object sender, RoutedEventArgs e)
        {
            WarningDelete.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            UpdateRoom.Visibility = Visibility.Collapsed;
        }

        private void updateButton(object sender, RoutedEventArgs e)
        {
            UpdateRoom.Visibility = Visibility.Visible;
            AllRooms.Visibility = Visibility.Collapsed;
            AddRoom.Visibility = Visibility.Collapsed;
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            int roomId = -1;
            roomId = ((Room)GridRoom.SelectedItem).Id;
            int floor = -1;
            foreach (Room r in Rooms)
            {
                if (r.Id == roomId)
                {
                    floor = r.Floor;
                }
            }
            Room room = new Room(roomId, UpdatedName.Text, (RoomType)Enum.Parse(typeof(RoomType), AddUpdatedType.Text, true), floor);
            room_Controller.Update(room);
            AllRooms.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            RefreshSource();
        }

        private void RenovateButton(object sender, RoutedEventArgs e)
        {
            AllRooms.Visibility = Visibility.Collapsed;
        }

        private void AllDrugsNav(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new RoomsPage();
        }

        private void AllEqpNav(object sender, RoutedEventArgs e)
        {
            var eqpShow = new EquipmentPage();
            eqpShow.Show();
        }

        private void AllRoomsNav(object sender, RoutedEventArgs e)
        {
            AllRooms.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            RoomAllButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
        }

        private void StatNav(object sender, RoutedEventArgs e)
        {

        }

        private void SettNav(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileNav(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new EqPages();
            var acc = new Nalog();
            acc.Show();
        }

        private void renovationButton(object sender, RoutedEventArgs e)
        {
            RenoMenagment.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
        }

        private void renoConfirmClick(object sender, RoutedEventArgs e)
        {
            int roomId = -1;
            roomId = ((Room)GridRoom.SelectedItem).Id;
            DateTime startReno = DateTime.Parse(start.Text);
            DateTime endReno = DateTime.Parse(finish.Text);
            Renovation renovation = new Renovation(-1, roomId, startReno, endReno, descriptionReno.Text);
            reno_Controller.Create(renovation);
            RenoMenagment.Visibility = Visibility.Collapsed;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;


        }
    }
}
