using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model;
using Repository;
using Service;

namespace SimsProjekat
{
    
    public partial class App : Application
    {
        
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
            .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private string ROOM_FILE = _projectPath + "\\Resources\\Data\\rooms.csv";
        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\Data\\appointments.csv";
        private const string CSV_DELIMITER = ",";

        public RoomController RoomController { get; set; }

        public AppointmentController AppointmentController { get; set; }

        public App()
        {
            var roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);

            var roomService = new RoomService(roomRepository);

            RoomController = new RoomController(roomService);

            var appointmentRepository = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER);

            var appointmentService = new AppointmentService(appointmentRepository);
        
            AppointmentController = new AppointmentController(appointmentService);
        }
    }
}

