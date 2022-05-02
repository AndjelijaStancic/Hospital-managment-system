using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;
using Repository;

namespace Service
{
    public class EqpMenagmentService
    {
        public readonly EqpMenagmentRepository eqpMenagmentService_Repository;
        public readonly RoomRepository room_Repository;

        public EqpMenagmentService(EqpMenagmentRepository EqpMenagmentServiceRepository, RoomRepository roomRepository)
        {
            eqpMenagmentService_Repository = EqpMenagmentServiceRepository;
            room_Repository = roomRepository;
        }

        public List<EquipmentMenagment> GetAll()
        {
            return eqpMenagmentService_Repository.GetAll();
        }


        public EquipmentMenagment Create(EquipmentMenagment equipment)
        {
            return eqpMenagmentService_Repository.Create(equipment);
        }
    }
}
