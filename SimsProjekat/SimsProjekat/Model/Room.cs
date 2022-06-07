// File:    Room.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:19:15 PM
// Purpose: Definition of Class Room

using System;
using Model;
using static Model.RoomType;

namespace Model
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoomType Type { get; set; }
        public int Floor { get; set; }
        public bool Available { get; set; }


        public Room(int id, string name, RoomType type, int floor)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Type = type;

        }
        public Room(int id, string name, int type, int floor)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Available = true;
            Type = (RoomType)type;

        }
        public Room(int id, string name, int type, int floor, bool available)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Available = available;
            Type = (RoomType)type;
        }
    }
}