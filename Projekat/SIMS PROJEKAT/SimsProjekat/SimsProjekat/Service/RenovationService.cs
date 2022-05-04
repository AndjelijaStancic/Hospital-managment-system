using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class RenovationService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;

        public RenovationService(RenovationRepository renoRepository, RoomRepository roomRepository)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
        }
        public List<Renovation> GetAll()
        {
            return reno_Repository.GetAll();
        }
        public Renovation Create(Renovation renovation)
        {
            return reno_Repository.Create(renovation);
        }
    }
}
