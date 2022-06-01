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
        
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private string RoomFile = _projectPath + "\\Resources\\Data\\rooms.csv";
        private string EquipmentFile = _projectPath + "\\Resources\\Data\\equipment.csv";
        private string DrugsFile = _projectPath + "\\Resources\\Data\\drugs.csv";
        private string RenoMergeFile = _projectPath + "\\Resources\\Data\\renoMerge.csv";
        private string RenoSplitFile = _projectPath + "\\Resources\\Data\\renoSplit.csv";
        private string EqpMenagmentFile = _projectPath + "\\Resources\\Data\\eqpMenagment.csv";
        private string UserFile = _projectPath + "\\Resources\\Data\\user.csv";
        private string StatHospitalFile = _projectPath + "\\Resources\\Data\\statHospital.csv";
        private string RenoFile = _projectPath + "\\Resources\\Data\\reno.csv";
        private string StatFile = _projectPath + "\\Resources\\Data\\stat.csv";
        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\Data\\appointments.csv";
        private const string CSV_DELIMITER = ";";

        public RoomController RoomController { get; set; }

        public EquipmentController EquipmentController { get; set; }

        public AppointmentController AppointmentController { get; set; }

        public EqpMenagmentController EqpMenagmentController { get; set; }

        public RenovationController RenovationController { get; set; }  

        public UserController UserController { get; set; }  

        public AccController AccController { get; set; }

        public DrugController DrugController { get; set; }

        public StatController StatController { get; set; }

        public RenovationMergeController RenovationMergeController { get; set; }

        public RenovationSplitController RenovationSplitController { get; set; }

        public App()
        {
            var roomRepository = new RoomRepository(RoomFile, CSV_DELIMITER);

            var equipmentRepository = new EquipmentRepository(EquipmentFile, CSV_DELIMITER);

            var drugRepository = new DrugRepository(DrugsFile, CSV_DELIMITER);

            var drugService = new DrugService(drugRepository);

            DrugController = new DrugController(drugService);

            var eqpMenagmentRepository = new EqpMenagmentRepository(EqpMenagmentFile, CSV_DELIMITER);

            var eqpMenagmentService = new EqpMenagmentService(eqpMenagmentRepository, roomRepository);

            EqpMenagmentController = new EqpMenagmentController(eqpMenagmentService);

            var appointmentRepository = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER);

            var appointmentService = new AppointmentService(appointmentRepository);
        
            AppointmentController = new AppointmentController(appointmentService);

            var userRepository = new UserRepository(UserFile, CSV_DELIMITER);

            var userService = new UserService(userRepository);

            UserController = new UserController(userService);

            var renoRepository = new RenovationRepository(RenoFile, CSV_DELIMITER);

            var accRepository = new AccRepository(UserFile, CSV_DELIMITER);

            var accService = new AccService(accRepository);

            AccController = new AccController(accService);
            
            var renovationSplitRepository = new RenovationSplitRepository(RenoSplitFile, CSV_DELIMITER);

            var renovationMergeRepository = new RenovationMergeRepository(RenoMergeFile, CSV_DELIMITER);

            var renovationMergeService = new RenovationMergeService(renoRepository, roomRepository, renovationMergeRepository, renovationSplitRepository);

            RenovationMergeController = new RenovationMergeController(renovationMergeService);

            var renovationSplitService = new RenovationSplitService(renovationSplitRepository, renoRepository, roomRepository, renovationMergeRepository);

            RenovationSplitController = new RenovationSplitController(renovationSplitService);

            var renoService = new RenovationService(renoRepository, roomRepository, renovationMergeRepository, renovationSplitRepository);

            RenovationController = new RenovationController(renoService);

            var equipmentService = new EquipmentService(equipmentRepository, roomRepository, eqpMenagmentRepository, renoRepository, renovationMergeRepository, renovationSplitRepository);

            EquipmentController = new EquipmentController(equipmentService);

            var roomService = new RoomService(roomRepository, equipmentRepository, eqpMenagmentRepository, renoRepository, renovationMergeRepository, renovationSplitRepository);

            RoomController = new RoomController(roomService);

            var statHospitalRepository = new StatHospitalRepository(StatHospitalFile, CSV_DELIMITER);

            var statRepository = new StatRepository(StatFile, CSV_DELIMITER);

            var statService = new StatService(statRepository, statHospitalRepository, userRepository);

            StatController = new StatController(statService);

            



        }
    }
}

