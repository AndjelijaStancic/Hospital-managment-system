using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface RoomRepository
    {
        public string ConvertCsv(Room room);
        public Room ConvertRoom(string CsvFormat);
        public Room GetById(int id);
        public List<Room> GetAll();
        public bool Delete(int id);
        public Room Update(Room room);
        protected int NewId();
        public Room Create(Room room);
    }
}
