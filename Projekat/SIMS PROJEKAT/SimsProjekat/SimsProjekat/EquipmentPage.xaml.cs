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
using System.Threading;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class EquipmentPage : Window
    {
        private EquipmentController eqp_Controller;

        public event PropertyChangedEventHandler PropertyChangedEvent;

        private EqpMenagmentController eqpMenagment_Controller;

        private RoomController room_Controller;
        public List<EquipmentDisplay> equipment { get; set; }
        public List<EquipmentDisplay> equipmentDin { get; set; }

        public List<EquipmentDisplay> equipmentSFiltered { get; set; }
        public List<String> NameEqp { get; set; }
        public List<int> Quantity { get; set; }
        public List<String> RoomName { get; set; }
        public List<String> TypeEqp { get; set; }
        public List<Room> Rooms { get; set; }
        public List<String> Names { get; set; }


        public EquipmentPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            eqp_Controller = app.EquipmentController;
            eqpMenagment_Controller = app.EqpMenagmentController;
            room_Controller = app.RoomController;
            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
            }
            this.equipment = eqp_Controller.GetEqpDisplay();
            this.equipmentDin = eqp_Controller.DinEqpDisplay();
            
            this.NameEqp = new List<String>();
            this.Quantity = new List<int>();
            this.RoomName = new List<String>();
            this.TypeEqp = new List<String>();
            
            
            foreach(EquipmentDisplay equipment in equipment)
            {
                RoomName.Add(equipment.nameRoom);
                NameEqp.Add(equipment.name);
                Quantity.Add(equipment.quantity);
                TypeEqp.Add(equipment.type);

            }


            this.DataContext = this;
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
        }

        private void AllDrugsNav(object sender, RoutedEventArgs e)
        {
            
        }

        public void RefreshSource1()
        {
            
            
            this.equipment = this.eqp_Controller.GetEqpDisplay();
            GridEqw.ItemsSource = this.equipment;
            GridEqw.Items.Refresh();
            
        }

        private void AllEqpNav(object sender, RoutedEventArgs e)
        {
            EqpButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C7883");
            
        }

        private void AllRoomsNav(object sender, RoutedEventArgs e)
        {
            var roomTab = new RoomOperations();
            roomTab.Show();
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

        private void eqpChangeButton(object sender, RoutedEventArgs e)
        {
            EqpMenagment.Visibility = Visibility.Visible;
        }

        private void ChangeEqpRoomClick(object sender, RoutedEventArgs e)
        {
            String roomName = RoomNameForm.Text;
            int idRoom = -1;
            foreach (Room room in Rooms)
            {
                if(room.Name == roomName)
                   idRoom = room.Id;
            }
            int IdEqp = ((EquipmentDisplay)GridEqw.SelectedItem).idEquipment;
            EquipmentMenagment equipmentMenagment = new EquipmentMenagment(-1, IdEqp, idRoom, DateTime.Parse(datePicker1.Text));
            eqpMenagment_Controller.Create(equipmentMenagment);
            EqpMenagment.Visibility = Visibility.Collapsed;
            RefreshSource1();
        }

        private void StatEqpButtonDis(object sender, RoutedEventArgs e)
        {
            AllEqp.Visibility = Visibility.Visible;
            AllDinEqp.Visibility = Visibility.Collapsed;
            DinEqp.Visibility = Visibility.Visible;
            StatEqp.Visibility = Visibility.Collapsed;
        }

        private void DinEqpButton(object sender, RoutedEventArgs e)
        {
            AllEqp.Visibility = Visibility.Collapsed;
            AllDinEqp.Visibility = Visibility.Visible;
            DinEqp.Visibility = Visibility.Collapsed;
            StatEqp.Visibility = Visibility.Visible;
            
        }

        
        private void SearchButtonConfirm(object sender, RoutedEventArgs e)
        {
            AllEqp.Visibility = Visibility.Collapsed;
            AllDinEqp.Visibility = Visibility.Collapsed;
            DinEqp.Visibility = Visibility.Visible;
            StatEqp.Visibility = Visibility.Collapsed;
            FilteredEqpS.Visibility = Visibility.Visible;   
            String Filter = DinSearchButton.Text;
            this.equipmentSFiltered = this.eqp_Controller.GetAllFiltered(Filter);
            GridFiltered.ItemsSource = this.equipmentSFiltered;
            GridFiltered.Items.Refresh();


        }
    }
}
