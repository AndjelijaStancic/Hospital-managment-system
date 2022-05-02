// File:    Equipment.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:23:44 PM
// Purpose: Definition of Class Equipment

using System;
using Model;

namespace Model
{
   public class Equipment 
   {
        public int idEquipment { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public int idRoom { get; set; }

        public Equipment(int IdEquipment,  string Name, int Quantity, string Type, int IdRoom)
        {
            idEquipment = IdEquipment;
            name = Name;
            quantity = Quantity;
            type = Type;
            idRoom = IdRoom;
        }


    }
}