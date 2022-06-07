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
        private const string CSV_DELIMITER = ";";

        public RoomController RoomController { get; set; }

        public EquipmentController EquipmentController { get; set; }

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
            var roomRepository = new RoomRepositoryImpl(RoomFile, CSV_DELIMITER);

            var equipmentRepository = new EquipmentRepositoryImpl(EquipmentFile, CSV_DELIMITER);

            var drugRepository = new DrugRepositoryImpl(DrugsFile, CSV_DELIMITER);

            var drugService = new DrugServiceImpl(drugRepository);

            DrugController = new DrugController(drugService);

            var eqpMenagmentRepository = new EqpMenagmentRepositoryImpl(EqpMenagmentFile, CSV_DELIMITER);

            var eqpMenagmentService = new EqpMenagmentServiceImpl(eqpMenagmentRepository, roomRepository);

            EqpMenagmentController = new EqpMenagmentController(eqpMenagmentService);

            var userRepository = new UserRepositoryImpl(UserFile, CSV_DELIMITER);

            var userService = new UserServiceImpl(userRepository);

            UserController = new UserController(userService);

            var renoRepository = new RenovationRepositoryImpl(RenoFile, CSV_DELIMITER);

            var accRepository = new AccRepositoryImpl(UserFile, CSV_DELIMITER);

            var accService = new AccServiceImpl(accRepository);

            AccController = new AccController(accService);
            
            var renovationSplitRepository = new RenovationSplitRepositoryImpl(RenoSplitFile, CSV_DELIMITER);

            var renovationMergeRepository = new RenovationMergeRepositoryImpl(RenoMergeFile, CSV_DELIMITER);

            var timeOverlapService = new TimeOverlapServiceImpl(renovationSplitRepository, renoRepository, renovationMergeRepository);

            var renovationMergeService = new RenovationMergeServiceImpl(renoRepository, roomRepository, renovationMergeRepository, renovationSplitRepository, timeOverlapService);

            RenovationMergeController = new RenovationMergeController(renovationMergeService);

            var renovationSplitService = new RenovationSplitServiceImpl(renovationSplitRepository, renoRepository, roomRepository, renovationMergeRepository, timeOverlapService);

            RenovationSplitController = new RenovationSplitController(renovationSplitService);

            var renoService = new RenovationServiceImpl(renoRepository, roomRepository, renovationMergeRepository, renovationSplitRepository, timeOverlapService);

            RenovationController = new RenovationController(renoService);

            var roomService = new RoomServiceImpl(roomRepository, equipmentRepository, eqpMenagmentRepository, renoRepository, renovationMergeRepository, renovationSplitRepository);

            RoomController = new RoomController(roomService);

            var equipmentService = new EquipmentServiceImpl(equipmentRepository, roomRepository, eqpMenagmentRepository, renoRepository, renovationMergeRepository, renovationSplitRepository, roomService);

            EquipmentController = new EquipmentController(equipmentService);

            var statHospitalRepository = new StatHospitalRepositoryImpl(StatHospitalFile, CSV_DELIMITER);

            var statRepository = new StatRepositoryImpl(StatFile, CSV_DELIMITER);

            var statService = new StatServiceImpl(statRepository, statHospitalRepository, userRepository);

            StatController = new StatController(statService);

        }
    }
}

