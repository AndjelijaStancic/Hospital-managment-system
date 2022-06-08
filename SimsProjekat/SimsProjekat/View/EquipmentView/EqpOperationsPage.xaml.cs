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
using System.Collections.ObjectModel;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for EqpOperationsPage.xaml
    /// </summary>
    public partial class EqpOperationsPage : Page , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChangedEvent;

        #region NotifyProperties

        private List<EquipmentDisplay> _equipmentSourceStatic;
        public List<EquipmentDisplay> EquipmentSourceStatic
        {
            get
            {
                return _equipmentSourceStatic;
            }
            set
            {
                if (value != _equipmentSourceStatic)
                {
                    _equipmentSourceStatic = value;
                    OnPropertyChanged("EquipmentSourceStatic");
                }
            }
        }

        private ObservableCollection<EquipmentDisplay> _equipmentStatic;
        public ObservableCollection<EquipmentDisplay> EquipmentStatic
        {
            get
            {
                return _equipmentStatic;
            }
            set
            {
                if (value != _equipmentStatic)
                {
                    _equipmentStatic = value;
                    
                    OnPropertyChanged("EquipmentStatic");
                }
            }
        }
        private string _filterStatic;
        public string FilterStatic
        {
            get { return _filterStatic; }
            set
            {
                if (value != _filterStatic)
                {
                    _filterStatic = value;
                    OnPropertyChanged("FilterStatic");
                    FilterDataStatic();
                }
            }
        }

        private List<EquipmentDisplay> _equipmentSourceDin;
        public List<EquipmentDisplay> EquipmentSourceDin
        {
            get
            {
                return _equipmentSourceDin;
            }
            set
            {
                if (value != _equipmentSourceDin)
                {
                    _equipmentSourceDin = value;
                    OnPropertyChanged("EquipmentSourceDin");
                }
            }
        }

        private ObservableCollection<EquipmentDisplay> _equipmentDin;
        public ObservableCollection<EquipmentDisplay> EquipmentDin
        {
            get
            {
                return _equipmentDin;
            }
            set
            {
                if (value != _equipmentDin)
                {
                    _equipmentDin = value;

                    OnPropertyChanged("EquipmentDin");
                }
            }
        }
        private string _filterDin;
        public string FilterDin
        {
            get { return _filterDin; }
            set
            {
                if (value != _filterDin)
                {
                    _filterDin = value;
                    OnPropertyChanged("FilterDin");
                    FilterDataDin();
                }
            }
        }


        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        private EquipmentController eqp_Controller;
        private EqpMenagmentController eqpMenagment_Controller;
        private RoomController room_Controller;
        public List<String> NameEqp { get; set; }
        public List<String> GroupEqp { get; set; }
        public List<int> Quantity { get; set; }
        public List<String> RoomName { get; set; }
        public List<String> TypeEqp { get; set; }
        public List<Room> Rooms { get; set; }
        public List<String> Names { get; set; }
        public EqpOperationsPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            eqp_Controller = app.EquipmentController;
            eqpMenagment_Controller = app.EqpMenagmentController;

            EquipmentStatic = new ObservableCollection<EquipmentDisplay>();
            EquipmentSourceStatic = eqp_Controller.GetEqpDisplay();
            EquipmentDin = new ObservableCollection<EquipmentDisplay>();
            EquipmentSourceDin = eqp_Controller.GetAllDisplayDin();

            room_Controller = app.RoomController;
            this.Rooms = room_Controller.GetAll();
            this.Names = new List<String>();

            foreach (Room room in Rooms)
            {
                Names.Add(room.Name);
            }
            

            this.NameEqp = new List<String>();
            this.Quantity = new List<int>();
            this.RoomName = new List<String>();
            this.TypeEqp = new List<String>();
            this.GroupEqp = new List<String>();


            
            foreach (EquipmentDisplay equipment in EquipmentSourceStatic)
            {
                RoomName.Add(equipment.nameRoom);
                NameEqp.Add(equipment.name);
                Quantity.Add(equipment.quantity);
                TypeEqp.Add(equipment.type);
                EquipmentStatic.Add(equipment);   

            }
            foreach (EquipmentDisplay equipment in EquipmentSourceDin)
            {
                EquipmentDin.Add(equipment);
            }



            this.DataContext = this;
        }
        public void RefreshSource1()
        {
            this.EquipmentSourceStatic = this.eqp_Controller.GetEqpDisplay();
            foreach (EquipmentDisplay equipment in EquipmentSourceStatic)
            {
                EquipmentStatic.Add(equipment);
            }
            GridEqw.ItemsSource = this.EquipmentStatic;
            StaticFilterData.Clear();
            GridEqw.Items.Refresh();

        }

        private void eqpChangeButton(object sender, RoutedEventArgs e)
        {
            EqpMenagment.Visibility = Visibility.Visible;
           
        }

        private void eqpChangeButtonF(object sender, RoutedEventArgs e)
        {
            EqpMenagment.Visibility = Visibility.Collapsed;
        }

        private void ChangeEqpRoomClick(object sender, RoutedEventArgs e)
        {
            
            String roomName = RoomNameForm.Text;
            int idRoom = -1;
            foreach (Room room in Rooms)
            {
                if (room.Name == roomName)
                    idRoom = room.Id;
            }
            int IdEqp = ((EquipmentDisplay)GridEqw.SelectedItem).idEquipment;
            EquipmentMenagment equipmentMenagment = new EquipmentMenagment(-1, IdEqp, idRoom, DateTime.Parse(datePicker.Text));
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
            StaticSearchEqp.Visibility= Visibility.Visible;
            DinSearchEqp.Visibility = Visibility.Collapsed;
        }

        private void DinEqpButton(object sender, RoutedEventArgs e)
        {
            AllEqp.Visibility = Visibility.Collapsed;
            AllDinEqp.Visibility = Visibility.Visible;
            DinEqp.Visibility = Visibility.Collapsed;
            StatEqp.Visibility = Visibility.Visible;
            DinSearchEqp.Visibility = Visibility.Visible;
            StaticSearchEqp.Visibility = Visibility.Collapsed;
        }
        
        public void FilterDataStatic()
        {
    
            EquipmentStatic.Clear();
            foreach(EquipmentDisplay equipmentDisplay in EquipmentSourceStatic)
            {
                if(FilterStatic == "" || (equipmentDisplay.name).Contains(FilterStatic) || (equipmentDisplay.nameRoom).Contains(FilterStatic))
                {
                    EquipmentStatic.Add(equipmentDisplay);
                }
            }
        }
        public void FilterDataDin()
        {
            EquipmentDin.Clear();
            foreach (EquipmentDisplay equipmentDisplay in EquipmentSourceDin)
            {
                if (FilterDin == "" || (equipmentDisplay.name).Contains(FilterDin) || (equipmentDisplay.nameRoom).Contains(FilterDin))
                {
                    EquipmentDin.Add(equipmentDisplay);
                }
            }
            
        }
    }
}
