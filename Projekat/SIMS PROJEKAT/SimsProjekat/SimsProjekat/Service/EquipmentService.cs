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
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;
        public readonly EqpMenagmentRepository eqpMen_Repository;

        public EquipmentService(EquipmentRepository equipmentRepository, RoomRepository roomRepository, EqpMenagmentRepository eqpMenagmentRepository, RenovationRepository renoRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository)
        {
            equipment_Repository = equipmentRepository;
            room_Repository = roomRepository;
            eqpMen_Repository = eqpMenagmentRepository;
            reno_Repository = renoRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
        }
        public List<Equipment> GetAll()
        {
            return equipment_Repository.GetAll();
        }

        public List<EquipmentMenagment> GetAllEqpMen()
        {
            return eqpMen_Repository.GetAll();
        }

        public List<EquipmentDisplay> GetDynEqpDysplay()
        {   
            List<RenovationSplit> renovationSplits = this.renoSplit_Repository.GetAll();
            List<RenovationMerge> renovationMerges = this.renoMerge_Repository.GetAll();
            List<Room> rooms = this.room_Repository.GetAll();
            List<Equipment> eqs = this.equipment_Repository.GetAll();
            List<Equipment> eqpCheckSplit = new List<Equipment>();
            List<Equipment> eqpCheckMerge = new List<Equipment>();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            List<Room> magacines = new List<Room>();

            foreach(Room room in rooms)
            {
                if(room.Type == RoomType.storage)
                {
                    magacines.Add(room);
                }
            }

            foreach(Equipment e in eqs)
            {
                foreach(RenovationSplit renoS in renovationSplits)
                {
                    if (e.idRoom == renoS.RoomId && (DateTime.Compare(renoS.Start, DateTime.Today) <= 0))
                    {
                        e.idRoom = magacines.FirstOrDefault().Id;
                        equipment_Repository.Update(e);
                    }
                }
                eqpCheckSplit.Add(e);
            }

            foreach (Equipment e in eqpCheckSplit)
            {
                foreach (RenovationMerge renoM in renovationMerges)
                {
                    if ((e.idRoom == renoM.RoomId1 && (DateTime.Compare(renoM.Start, DateTime.Today) <= 0)) || (e.idRoom == renoM.RoomId2 && (DateTime.Compare(renoM.Start, DateTime.Today) <= 0)))
                    {
                        e.idRoom = magacines.FirstOrDefault().Id;
                        equipment_Repository.Update(e);
                    }
                }
                eqpCheckMerge.Add(e);
            }

            foreach (Equipment e in eqpCheckMerge)
            {
                if (e.type == "D")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsDisplay;
        }
        public List<EquipmentDisplay> GetAllDisplay()
        {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            foreach (Equipment e in eqp)
            {
                eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
            }
            return eqsDisplay;
        }

        public List<EquipmentDisplay> GetStaticEqpDisplay()
        {

            List<EquipmentMenagment> eqpMen = this.eqpMen_Repository.GetAll();
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<EquipmentDisplay> eqsDisplay = new List<EquipmentDisplay>();
            List<EquipmentMenagment> done = new List<EquipmentMenagment>();
            List<RenovationSplit> renovationSplits = this.renoSplit_Repository.GetAll();
            List<RenovationMerge> renovationMerges = this.renoMerge_Repository.GetAll();
            List<Room> rooms = this.room_Repository.GetAll();
            List<Equipment> eqpUpdated = new List<Equipment>();
            List<Equipment> eqpCheckSplit = new List<Equipment>();
            List<Equipment> eqpCheckMerge = new List<Equipment>();
            List<Room> magacines = new List<Room>();

            foreach (Room room in rooms)
            {
                if (room.Type == RoomType.storage)
                {
                    magacines.Add(room);
                }
            }

            foreach (EquipmentMenagment EqpMenDone in eqpMen)
            {
                if (DateTime.Compare(EqpMenDone.movingDay, DateTime.Today) <= 0)
                {
                    done.Add(EqpMenDone);
                    Equipment equipment = equipment_Repository.GetById(EqpMenDone.idEqp);
                    equipment.idRoom = EqpMenDone.idRoom;
                    equipment_Repository.Update(equipment);
                    equipment.idRoom = EqpMenDone.idRoom;
                    eqpUpdated.Add(equipment);
                }
            }

            foreach (Equipment equipment in eqp)
            {
                foreach (Equipment EqpUpdated in eqpUpdated)
                {
                    if(equipment.idEquipment == EqpUpdated.idEquipment)
                    {
                        equipment.idRoom = EqpUpdated.idRoom;
                    }
                }
            }

            foreach (Equipment e in eqp)
            {
                foreach (RenovationSplit renoS in renovationSplits)
                {
                    if (e.idRoom == renoS.RoomId && (DateTime.Compare(renoS.Start, DateTime.Today) <= 0))
                    {
                        e.idRoom = magacines.FirstOrDefault().Id;
                        equipment_Repository.Update(e);
                    }
                }
                eqpCheckSplit.Add(e);
            }

            foreach (Equipment e in eqpCheckSplit)
            {
                foreach (RenovationMerge renoM in renovationMerges)
                {
                    if ((e.idRoom == renoM.RoomId1 && (DateTime.Compare(renoM.Start, DateTime.Today) <= 0)) || (e.idRoom == renoM.RoomId2 && (DateTime.Compare(renoM.Start, DateTime.Today) <= 0)))
                    {
                        e.idRoom = magacines.FirstOrDefault().Id;
                        equipment_Repository.Update(e);
                    }
                }
                eqpCheckMerge.Add(e);
            }


            foreach (EquipmentMenagment doneEqp in done)
            {
                eqpMen_Repository.DeleteEqpMen(doneEqp.idEqp);
            }
            
            foreach (Equipment e in eqpCheckMerge)
            {
                if (e.type == "S")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsDisplay;
        }

        public List<EquipmentDisplay> GetAllFilteredStatic(String Filter)
        {

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
                    equipment_Repository.Update(equipment);
                }
            }
            foreach (EquipmentMenagment doneEqp in done)
            {
                eqpMen_Repository.DeleteEqpMen(doneEqp.idEqp);
            }
            List<Equipment> eqp = this.equipment_Repository.GetAll();

            foreach (Equipment e in eqp)
            {
                if (e.type == "S" && e.name.Equals(Filter))
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                else if (e.type == "S" && (room_Repository.GetById(e.idRoom).Name.Equals(Filter)))
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                else if (e.type == "S" && e.idEquipment.ToString() == Filter)
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }else if(string.IsNullOrEmpty(Filter) && e.type == "S")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                
            }

            return eqsDisplay;

        }
        public List<EquipmentDisplay> GetAllFilteredDynamic(String Filter)
        {

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
                    equipment_Repository.Update(equipment);
                }
            }
            foreach (EquipmentMenagment doneEqp in done)
            {
                eqpMen_Repository.DeleteEqpMen(doneEqp.idEqp);
            }
            List<Equipment> eqp = this.equipment_Repository.GetAll();

            foreach (Equipment e in eqp)
            {
                if (e.type == "D" && e.name.Equals(Filter))
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                else if (e.type == "D" && (room_Repository.GetById(e.idRoom).Name.Equals(Filter)))
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                else if (e.type == "D" && e.idEquipment.ToString() == Filter)
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
                else if (string.IsNullOrEmpty(Filter) && e.type == "D")
                {
                    eqsDisplay.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }

            }

            return eqsDisplay;

        }
    }
}
