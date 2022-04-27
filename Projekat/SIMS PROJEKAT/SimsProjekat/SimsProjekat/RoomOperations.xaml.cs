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

        public event PropertyChangedEventHandler PropertyChangedEvent;
        public List<Room> Rooms { get; set; }
        public List<String> Names { get; set; }
        public List<int> Floors { get; set; }
        public List<RoomType> TypesList { get; set; }

        
        public RoomOperations()
        {
            InitializeComponent();
            var app = Application.Current as App;
            room_Controller = app.RoomController;

            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();
            this.Floors = new List<int>();
            var roomTypes = Enum.GetValues(typeof(RoomType));
            TypesList = roomTypes.OfType<RoomType>().ToList();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
                Floors.Add(room.Floor);
            }

            this.DataContext = this;
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            
        }
        private void AllRoomButton(object sender, RoutedEventArgs e)
        {
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            RenovationButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            AllRooms.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            this.Rooms = room_Controller.GetAll();
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            RenovationButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
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
            AllRooms.Visibility = Visibility.Visible;
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

        }

        private void RenovateButton(object sender, RoutedEventArgs e)
        {
            AllRooms.Visibility = Visibility.Collapsed;
        }

    }
}
