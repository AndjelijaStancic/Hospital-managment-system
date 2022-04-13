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
    /// Interaction logic for ShowRooms.xaml
    /// </summary>
    public partial class ShowRooms : Window
    {
        private RoomController room_Controller;
        public event PropertyChangedEventHandler PropertyChangedEvent;
        public List<Room> Rooms { get; set; }
        public List<String> Names { get; set; }
        public List<int> Floors { get; set; }

        //public List<bool> Availability { get; set; }
        public List<RoomType> TypesList { get; set; }

        public ShowRooms()
        {
            InitializeComponent();
            var app = Application.Current as App;
            room_Controller = app.RoomController;

            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();
            this.Floors = new List<int>();
            //this.Availability = new List<bool>();

            var roomTypes = Enum.GetValues(typeof(RoomType));
            TypesList = roomTypes.OfType<RoomType>().ToList();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
                Floors.Add(room.Floor);
                //Availability.Add(room.Available);   
            }

            this.DataContext = this;


        }
        
    }
}
