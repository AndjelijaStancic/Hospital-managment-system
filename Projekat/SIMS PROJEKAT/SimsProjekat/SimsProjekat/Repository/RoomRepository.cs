// File:    RoomRepository.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 9:38:22 PM
// Purpose: Definition of Class RoomRepository

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Repository
{
    public class RoomRepository
    {
        private string Path;
        private string Delimiter;
        public Model.Room GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RoomRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }
        public string ConvertCsv(Room room)
        {
            return string.Join(Delimiter,
                room.Id,
                room.Name,
                (int)room.Type,
                room.Floor);
            
        }

        public Room ConvertRoom(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int Id = int.Parse(tokens[0]);
            String Name = tokens[1];
            int TypeRoom = int.Parse(tokens[2]);
            int Floor = int.Parse(tokens[3]);
            return new Room(Id,Name,TypeRoom,Floor);
        }

        public List<Room> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertRoom).ToList();
        }

        public bool Delete(int id)
        {
            List<Room> rooms = GetAll().ToList();
            bool delete = false;
            List<string> updated = new List<string>();
            foreach (Room room in rooms)
            {
                if (room.Id != id)
                {
                    delete = true;
                    updated.Add(ConvertCsv(room));

                }
            }
            File.WriteAllLines(Path, updated);
            return delete;
        }

        public Room Update(Room room)
        {
            List<Room> rooms = GetAll().ToList();
            List<string> updated = new List<string>();
            foreach (Room room1 in rooms)
            {
                if (room1.Id == room.Id)
                {
                    room1.Type = room.Type;
                    room1.Name = room.Name;
                }
                updated.Add(ConvertCsv(room1));
            }
            File.WriteAllLines(Path, updated);
            return room;
        }

        protected int NewId(List<Room> rooms)
        {
            int id = 0;
            List<Room> rooms1 = GetAll().ToList();
            foreach (Room room in rooms1)
            {
                if(room.Id > id)
                {
                    id = room.Id;
                }
            }
            return id;
        }
        public Room Create(Room room)
        {
            List<Room> rooms = GetAll().ToList();
            int id = (NewId(rooms));
            room.Id = ++id;
            File.AppendAllText(Path, ConvertCsv(room) + Environment.NewLine);
            return room;
            
        }
        


    }
}