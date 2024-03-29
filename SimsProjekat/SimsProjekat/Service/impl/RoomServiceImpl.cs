// File:    RoomService.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 10:59:07 PM
// Purpose: Definition of Class RoomService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class RoomServiceImpl : RoomService
   {

        public readonly RoomRepository room_Repository;
        public readonly EquipmentRepository equipment_Repository;
        public readonly EqpMenagmentRepository eqpMen_Repository;
        public readonly RenovationRepository reno_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;


        public RoomServiceImpl(RoomRepository roomRepository, EquipmentRepository equipmentRepository, EqpMenagmentRepository eqpMenagmentRepository, RenovationRepository renoRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository)
        {
            room_Repository = roomRepository;
            equipment_Repository = equipmentRepository;
            eqpMen_Repository = eqpMenagmentRepository;
            reno_Repository = renoRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
        }

        public Room GetById(int id)
        {
            return  room_Repository.GetById(id);
        }

        public List<Room> FindMagacines()
        {
            List<Room> roomList = room_Repository.GetAll();
            List<Room> magacines = new List<Room>();

            foreach (Room room in roomList)
            {
                if (room.Type == RoomType.storage)
                {
                    magacines.Add(room);
                }
            }
            return magacines;
        }

     

        public List<Room> GetAll()
        {
            List<RenovationSplit> renovationSplits = this.renoSplit_Repository.GetAll();
            List<Room> rooms = this.room_Repository.GetAll();
            List<Room> doneSplit = new List<Room>();
            
            foreach (RenovationSplit rs in renovationSplits)
            {
                foreach (Room room in rooms)
                {
                    if ((room.Id == rs.RoomId) && (DateTime.Compare(rs.Finish, DateTime.Today) <= 0))
                    {
                        Room Room1 = new Room(-1, rs.NewRoomName1, rs.NewRoomType1, room.Floor);
                        Room Room2 = new Room(-1, rs.NewRoomName2, rs.NewRoomType2, room.Floor);
                        room_Repository.Create(Room1);
                        room_Repository.Create(Room2);
                        doneSplit.Add(room);
                        this.room_Repository.Delete(room.Id);

                    }
                }
            }
            
            List<Room> roomOne = new List<Room>();
            List<RenovationMerge> renovationMerges = this.renoMerge_Repository.GetAll();

            foreach (Room room in rooms)
            {
                foreach (RenovationMerge rm in renovationMerges)
                {
                    if(room.Id == rm.RoomId1)
                    {
                        roomOne.Add(room);
                    }
                }
            }

            List<Room> doneMerge = new List<Room>();

            foreach (RenovationMerge rm in renovationMerges)
            {
                foreach (Room room in roomOne)
                {
                    if ((room.Id == rm.RoomId1) && (DateTime.Compare(rm.Finish, DateTime.Today) <= 0))
                    {
                        Room Room = new Room(-1, rm.NewRoomName, rm.NewRoomType, room.Floor);
                        this.room_Repository.Create(Room);
                        this.room_Repository.Delete(room.Id);
                        doneMerge.Add(room);
                        this.room_Repository.Delete(rm.RoomId2);
                    }
                }
            }
            //delete renovation from csv when done
            foreach(RenovationSplit renovationSplit in renovationSplits)
            {
                if((DateTime.Compare(renovationSplit.Finish, DateTime.Today) <= 0))
                {
                    renoSplit_Repository.Delete(renovationSplit.Id);
                }
            }
            //delete renovation from csv when done
            foreach(RenovationMerge renovationMerge in renovationMerges)
            {
                if ((DateTime.Compare(renovationMerge.Finish, DateTime.Today) <= 0))
                {
                    renoMerge_Repository.Delete(renovationMerge.Id);
                }
            }
            List<Room> roomChecked = new List<Room>();
            roomChecked = room_Repository.GetAll();
            return roomChecked;
        }

        public Room Update(Room room)
        {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<Room> magacines = FindMagacines();
            foreach (Equipment eqpItem in eqp)
            {
                if (eqpItem.idRoom == room.Id)
                {
                    eqpItem.idRoom = magacines.FirstOrDefault().Id;
                    equipment_Repository.Update(eqpItem);
                }
            }
            return room_Repository.Update(room);
        }
      
        public bool Delete(int id)
        {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<Room> magacines = FindMagacines();

            foreach (Equipment eqpItem in eqp)
            {
               if(eqpItem.idRoom == id)
               {
                   eqpItem.idRoom = magacines.FirstOrDefault().Id;
                   equipment_Repository.Update(eqpItem);
               }
            }
            return room_Repository.Delete(id);
        }
     
         public Room Create(Room room)
         {
             return room_Repository.Create(room);
         }
   
   }
}