// File:    RoomController.cs
// Author:  Andjelija
// Created: Tuesday, April 12, 2022 1:11:58 AM
// Purpose: Definition of Class RoomController

using Model;
using Service;
using System;
using System.Collections.Generic;
namespace Controller
{
   public class RoomController
   {
        private readonly RoomService room_Service;

        public RoomController(RoomService service)
        {
            room_Service = service;
        }

        public Room GetById(int id)
      {
            throw new NotImplementedException(); 
      }
      
      public List<Room> GetAll()
      {
         return room_Service.GetAll();
      }
      
      public Room Update(Room room)
      {
         return room_Service.Update(room);
      }
      
      public bool Delete(int id)
      {
         return room_Service.Delete(id);
      }
      
      public Room Create(Room room)
      {
         return room_Service.Create(room);
      }
      
   
      
 
   
   }
}