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
                room.Floor,
                (int)room.Type);
                //room.Available);
        }

        public Room ConvertRoom(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            return new Room(
                int.Parse(tokens[0]),
                tokens[1],
                int.Parse(tokens[2]),
                int.Parse(tokens[3]));
                //bool.Parse(tokens[4])) ;
        }

        public List<Room> GetAll()
        {
            return File.ReadAllLines(Path)
                .Select(ConvertRoom)
                .ToList();
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


        public Room Create(Room room)
      {
            File.AppendAllText(Path, ConvertCsv(room) + Environment.NewLine);
            return room;
       }

        

    }
}