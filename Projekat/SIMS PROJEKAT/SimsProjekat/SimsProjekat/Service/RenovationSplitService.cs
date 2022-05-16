using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Service
{
    public class RenovationSplitService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;

        public RenovationSplitService(RenovationSplitRepository renoSplitRepository,RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renoSplitRepository;
        }
    }
}
