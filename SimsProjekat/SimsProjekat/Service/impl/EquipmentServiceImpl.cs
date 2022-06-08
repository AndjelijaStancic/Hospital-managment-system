using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using Service;


namespace Service
{
    public class EquipmentServiceImpl : EquipmentService
    {
        public readonly EquipmentRepository equipment_Repository;
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;
        public readonly EqpMenagmentRepository eqpMen_Repository;
        public readonly RoomService room_Service;

        public EquipmentServiceImpl(EquipmentRepository equipmentRepository, RoomRepository roomRepository, EqpMenagmentRepository eqpMenagmentRepository, RenovationRepository renoRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository, RoomService roomService)
        {
            equipment_Repository = equipmentRepository;
            room_Repository = roomRepository;
            eqpMen_Repository = eqpMenagmentRepository;
            reno_Repository = renoRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
            room_Service = roomService;
        }
        public List<Equipment> GetAll()
        {
            return equipment_Repository.GetAll();
        }

        public List<EquipmentMenagment> GetAllEqpMen()
        {
            return eqpMen_Repository.GetAll();
        }

        public List<EquipmentDisplay> getDynamic(List<Equipment> equipment)
        {
            List<EquipmentDisplay> eqsDyn = new List<EquipmentDisplay>();

            foreach (Equipment e in equipment)
            {
                if (e.type == "D")
                {
                    eqsDyn.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsDyn;
        }

        //puts equipment in magacine if there is split renovation scheduled for the room
        public List<Equipment> CheckIfSplitReno(List<Equipment> eqp)
        {
            List<RenovationSplit> renovationSplits = this.renoSplit_Repository.GetAll();
            List<Equipment> eqpCheckSplit = new List<Equipment>();

            List<Room> magacines = new List<Room>();
            magacines = room_Service.FindMagacines();

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

            return eqpCheckSplit;

        }

        //puts  equipment in magacine if there is merge renovation scheduled for the room
        public List<Equipment> CheckIfMergeReno(List<Equipment> eqp)
        {
            List<RenovationMerge> renovationMerges = this.renoMerge_Repository.GetAll();
            List<Equipment> eqpCheckMerge = new List<Equipment>();

            List<Room> magacines = new List<Room>();
            magacines = room_Service.FindMagacines();

            foreach (Equipment e in eqp)
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

            return eqpCheckMerge;

        }


        public List<EquipmentDisplay> GetDynEqpDysplay()
        { 
            List<Equipment> eqs = this.equipment_Repository.GetAll();
            List<Equipment> eqpCheckSplit = new List<Equipment>();
            eqpCheckSplit = CheckIfSplitReno(eqs);

            List<Equipment> eqpCheckMerge = new List<Equipment>();
            eqpCheckMerge = CheckIfMergeReno(eqpCheckSplit);

            //gets only dynamic equipment from list
            List<EquipmentDisplay> eqsDisplay = getDynamic(eqpCheckMerge);
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

        public void DeleteFinished(List<EquipmentMenagment> doneEqp)
        {
            foreach (EquipmentMenagment doneEqpMen in doneEqp)
            {
                eqpMen_Repository.DeleteEqpMen(doneEqpMen.idEqp);
            }
        }
        //gets static eqp from list of eqp
        public List<EquipmentDisplay> getStatic(List<Equipment> equipment)
        {
            List<EquipmentDisplay> eqsStatic = new List<EquipmentDisplay>();

            foreach (Equipment e in equipment)
            {
                if (e.type == "S")
                {
                    eqsStatic.Add(new EquipmentDisplay(this.room_Repository.GetById(e.idRoom).Name, e.idEquipment, e.name, e.quantity, e.type));
                }
            }
            return eqsStatic;
        }

        public List<EquipmentDisplay> GetStaticEqpDisplay()
        {
            List<EquipmentMenagment> eqpMen = this.eqpMen_Repository.GetAll();
            List<EquipmentMenagment> done = new List<EquipmentMenagment>();
            List<Equipment> eqpUpdated = new List<Equipment>();

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

            List<Equipment> eqp = this.equipment_Repository.GetAll();

            foreach (Equipment equipment in eqp)
            {
                foreach (Equipment EqpUpdated in eqpUpdated)
                {
                    if (equipment.idEquipment == EqpUpdated.idEquipment)
                    {
                        equipment.idRoom = EqpUpdated.idRoom;
                    }
                }
            }
            //puts equipment in magacine if there is split renovation scheduled for the room
            List<Equipment> eqpCheckSplit = CheckIfSplitReno(eqp);
            //puts equipment in magacine if there is merge renovation scheduled for the room
            List<Equipment> eqpCheckMerge = CheckIfMergeReno(eqpCheckSplit);
            //Deletes finished equipment moving
            DeleteFinished(done);

            List<EquipmentDisplay> eqsDisplay = getStatic(eqpCheckMerge);
            return eqsDisplay;
        }

        



    }
}
