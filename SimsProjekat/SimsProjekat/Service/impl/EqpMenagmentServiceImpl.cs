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
    public class EqpMenagmentServiceImpl : EqpMenagmentService
    {
        public readonly EqpMenagmentRepository eqpMenagment_Repository;
        public readonly RoomRepository room_Repository;

        public EqpMenagmentServiceImpl(EqpMenagmentRepository EqpMenagmentServiceRepository, RoomRepository roomRepository)
        {
            eqpMenagment_Repository = EqpMenagmentServiceRepository;
            room_Repository = roomRepository;
        }

        public List<EquipmentMenagment> GetAll()
        {
            return eqpMenagment_Repository.GetAll();
        }


        public EquipmentMenagment Create(EquipmentMenagment equipment)
        {
            return eqpMenagment_Repository.Create(equipment);
        }
    }
}
