// File:    RoomService.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 10:59:07 PM
// Purpose: Definition of Class RoomService

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RoomService
   {

        public readonly RoomRepository room_Repository;
        public readonly EquipmentRepository equipment_Repository;
        public readonly EqpMenagmentRepository eqpMen_Repository;

        public RoomService(RoomRepository roomRepository, EquipmentRepository equipmentRepository, EqpMenagmentRepository eqpMenagmentRepository)
        {
            room_Repository = roomRepository;
            equipment_Repository = equipmentRepository;
            eqpMen_Repository = eqpMenagmentRepository;
        }

        public Room GetById(int id)
      {
            return  room_Repository.GetById(id);
      }
      
      public List<Room> GetAll()
      {
         return room_Repository.GetAll();
      }
      
      public Room Update(Room room)
      {
            return room_Repository.Update(room);
        }
      
      public bool Delete(int id)
      {
            List<Equipment> eqp = this.equipment_Repository.GetAll();
            List<Equipment> eqsDeletedRoom = new List<Equipment>();

            foreach (Equipment eqpItem in eqp)
            {
                if(eqpItem.idRoom == id)
                {
                    equipment_Repository.DeleteEqp(eqpItem.idEquipment);
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