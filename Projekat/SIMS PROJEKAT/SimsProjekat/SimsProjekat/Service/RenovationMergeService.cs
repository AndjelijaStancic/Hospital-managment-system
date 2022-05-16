using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class RenovationMergeService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;

        public RenovationMergeService(RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
        }
        public List<RenovationMerge> GetAll()
        {
            return renoMerge_Repository.GetAll();
        }
        public RenovationMerge Create(RenovationMerge renovationMerge)
        {
            return renoMerge_Repository.Create(renovationMerge);
        }
    }
}
