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
    /// Interaction logic for RoomOperationsPage.xaml
    /// </summary>
    public partial class RoomOperationsPage : Page
    {
        private RoomController room_Controller;
        private RenovationController reno_Controller;
        private RenovationMergeController renoMerge_Controller;
        private RenovationSplitController renoSplit_Controller;

        public event PropertyChangedEventHandler PropertyChangedEvent;
        public List<Room> Rooms { get; set; }
        public List<Renovation> Renovations { get; set; }
        public List<String> Names { get; set; }
        public List<int> Floors { get; set; }
        public List<RoomType> TypesList { get; set; }
        public RoomOperationsPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            room_Controller = app.RoomController;
            reno_Controller = app.RenovationController;
            renoMerge_Controller = app.RenovationMergeController;
            renoSplit_Controller = app.RenovationSplitController;

            this.Renovations = reno_Controller.GetAll();
            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();
            this.Floors = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var roomTypes = Enum.GetValues(typeof(RoomType));
            TypesList = roomTypes.OfType<RoomType>().ToList();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
            }
            this.DataContext = this;
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
            //AllRoomsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");

            AllRooms.Visibility = Visibility.Visible;
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            this.Rooms = room_Controller.GetAll();
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddRoomButton.Visibility = Visibility.Collapsed;
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
            AddRoomButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF142223");
            NewRoomName.Clear();
            NewRoomFloor.Clear();
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
            int roomId = ((Room)GridRoom.SelectedItem).Id;
            String roomName = room_Controller.GetById(roomId).Name;
            PickedRoomName.Text = roomName;
            UpdateRoom.Visibility = Visibility.Visible;
            AllRooms.Visibility = Visibility.Collapsed;
            AddRoom.Visibility = Visibility.Collapsed;
            AddRoomButton.Visibility = Visibility.Collapsed;
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
            AddRoomButton.Visibility = Visibility.Visible;
            UpdatedName.Clear();
            RefreshSource();
        }

        private void RenovateButton(object sender, RoutedEventArgs e)
        {
            AllRooms.Visibility = Visibility.Collapsed;
        }

        private void renovationButton(object sender, RoutedEventArgs e)
        {
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            RenoRoom.Visibility = Visibility.Visible;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;

        }

        private void renoConfirmClick(object sender, RoutedEventArgs e)
        {
            int roomId = -1;
            roomId = ((Room)GridRoom.SelectedItem).Id;
            DateTime startReno = DateTime.Parse(start.Text);
            DateTime endReno = DateTime.Parse(finish.Text);
            Renovation renovation = new Renovation(-1, roomId, startReno, endReno, descriptionReno.Text);
            reno_Controller.RenovationCheck(renovation);
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;


        }
       
        private void mergeRenovation(object sender, RoutedEventArgs e)
        {
            int roomId = ((Room)GridRoom.SelectedItem).Id;
            String roomName = room_Controller.GetById(roomId).Name;
            RoomNumberOne.Text = roomName;
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Visible;
            SplitRenoRoom.Visibility = Visibility.Collapsed;

        }

        private void splitRenovation(object sender, RoutedEventArgs e)
        {
            int roomId = ((Room)GridRoom.SelectedItem).Id;
            String roomName = room_Controller.GetById(roomId).Name;
            RoomName.Text = roomName;
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Visible;

        }

        private void mergeClick(object sender, RoutedEventArgs e)
        {
            int roomId1 = -1;
            int roomId2 = -1;
            roomId1 = ((Room)GridRoom.SelectedItem).Id;
            foreach (Room room in Rooms)
            {
                if (room.Name.Equals(AddSecRoom.Text))
                {
                    roomId2 = room.Id;
                }
            }
            DateTime startReno = DateTime.Parse(startMerge.Text);
            DateTime endReno = DateTime.Parse(finishMerge.Text);
            RenovationMerge renovation = new RenovationMerge(-1, roomId1, roomId2, startReno, endReno,
                newRoomNameMerge.Text, (RoomType)Enum.Parse(typeof(RoomType), AddNewRoomType.Text, true), descriptionMergeReno.Text);

            renoMerge_Controller.MergeRenovationCheck(renovation);

            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;


            descriptionMergeReno.Clear();
            newRoomNameMerge.Clear();
            startMerge.SelectedDate = null;
            finishMerge.SelectedDate = null;



        }

        private void ExitRenovation(object sender, RoutedEventArgs e)
        {
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;

        }

        private void basicRenovation(object sender, RoutedEventArgs e)
        {
            int roomId = ((Room)GridRoom.SelectedItem).Id;
            String roomName = room_Controller.GetById(roomId).Name;
            SelectedRoomName.Text = roomName;
            BasicRenoRoom.Visibility = Visibility.Visible;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;
            RenoRoom.Visibility = Visibility.Collapsed;

        }

        private void splitClick(object sender, RoutedEventArgs e)
        {
            int roomId = -1;
            roomId = ((Room)GridRoom.SelectedItem).Id;
            DateTime startReno = DateTime.Parse(startSplit.Text);
            DateTime endReno = DateTime.Parse(finishSplit.Text);

            RenovationSplit renovation = new RenovationSplit(-1, roomId, FirstRoomNameSplit.Text, SecondRoomNameSplit.Text,
                (RoomType)Enum.Parse(typeof(RoomType), Room1Type.Text, true), (RoomType)Enum.Parse(typeof(RoomType), Room2Type.Text, true),
                startReno, endReno, descriptionSplitReno.Text);

            renoSplit_Controller.SplitRenovationCheck(renovation);

            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            RenoRoom.Visibility = Visibility.Collapsed;
            BasicRenoRoom.Visibility = Visibility.Collapsed;
            MergeRenoRoom.Visibility = Visibility.Collapsed;
            SplitRenoRoom.Visibility = Visibility.Collapsed;
            descriptionMergeReno.Clear();
            FirstRoomNameSplit.Clear();
            SecondRoomNameSplit.Clear();
            startSplit.SelectedDate = null;
            finishSplit.SelectedDate = null;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            AddRoom.Visibility = Visibility.Collapsed;
            UpdateRoom.Visibility = Visibility.Collapsed;
            AllRooms.Visibility = Visibility.Visible;
            AddRoomButton.Visibility = Visibility.Visible;
            NewRoomName.Clear();
            NewRoomFloor.Clear();
        }
    }
}
