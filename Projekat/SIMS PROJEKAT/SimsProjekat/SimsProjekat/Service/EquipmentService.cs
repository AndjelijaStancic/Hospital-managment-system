using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;


namespace Service
{
    public class EquipmentService
    {
        public readonly EquipmentRepository equipment_Repository;
        public readonly RoomRepository room_Repository;
        public readonly EqpMenagmentRepository eqpMen_Repository;

        public EquipmentService(EquipmentRepository equipmentRepository, RoomRepository roomRepository, EqpMenagmentRepository eqpMenagmentRepository)
        {
            equipment_Repository = equipmentRepository;
            room_Repository = roomRepository;
            eqpMen_Repository = eqpMenagmentRepository;
        }
        public List<Equipment> GetAll()
        {
            return equipment_Repository.GetAll();
        }

        public List<EquipmentMenagment> GetAllEqpMen()
        {
            return eqpMen_Repository.GetAll();
        }

        public List<EquipmentDisplay> GetAllDis()
        {
            List<Equipment> eqs = this.equipment_Repository.GetAll();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            foreach(Equipment e in eqs)
            {
                eqsDisplay.Add(new EquipmentDisplay( this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
            }
            return eqsDisplay;
        }
        public List<EquipmentDisplay> DinEqpDisplay()
        {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            foreach (Equipment e in eqp)
            {
                if (e.type == "D")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsDisplay;
        }

        public List<EquipmentDisplay> GetEqpDisplay()
        {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<EquipmentMenagment> eqpMen = this.eqpMen_Repository.GetAll();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            List<EquipmentMenagment> done = new List<EquipmentMenagment>();


            foreach (EquipmentMenagment EqpMenDone in eqpMen)
            {
                if (DateTime.Compare(EqpMenDone.movingDay, DateTime.Today) <= 0)
                {
                    done.Add(EqpMenDone);
                    Equipment equipment = equipment_Repository.GetById(EqpMenDone.idEqp);
                    equipment.idRoom = EqpMenDone.idRoom;
                    //equipment.quantity = equipment.quantity - EqpMenDone.quantity;
                    //Equipment equipment1 = new Equipment(equipment.idEquipment, equipment.name, EqpMenDone.quantity, equipment.type, EqpMenDone.idRoom);
                    equipment_Repository.Update(equipment);
                    //equipment_Repository.Create(equipment1);
                }
            }
            foreach (EquipmentMenagment doneEqp in done)
            {
                eqpMen_Repository.DeleteEqpMen(doneEqp.idEqp);
            }

            foreach (Equipment e in eqp)
            {
                if (e.type == "S")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsDisplay;
        }

    }
}
