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

        public RoomService(RoomRepository roomRepository)
        {
            room_Repository = roomRepository;
        }

        public Room GetById(int id)
      {
         throw new NotImplementedException();
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
         return room_Repository.Delete(id);
      }
     
      public Room Create(Room room)
      {
         throw new NotImplementedException();
      }
   
   }
}