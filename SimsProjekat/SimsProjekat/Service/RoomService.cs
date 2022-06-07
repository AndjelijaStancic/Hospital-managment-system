using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface RoomService
    {
        public Room GetById(int id);
        public List<Room> FindMagacines();
        public List<Room> GetAll();
        public Room Update(Room room);
        public bool Delete(int id);
        public Room Create(Room room);
    }
}
