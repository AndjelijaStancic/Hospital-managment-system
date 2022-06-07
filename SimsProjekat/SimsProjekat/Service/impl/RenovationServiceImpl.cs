using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class RenovationServiceImpl : RenovationService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;
        public readonly TimeOverlapService timeOverlap_Service;

        public RenovationServiceImpl(RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository, TimeOverlapService timeOverlapService)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
            timeOverlap_Service = timeOverlapService;
        }
        public List<Renovation> GetAll()
        {
            return reno_Repository.GetAll();
        }
        public Renovation Create(Renovation renovation)
        {
            return reno_Repository.Create(renovation);
        }

        public Boolean RenovationCheck(Renovation renovation)
        {
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();
            
            foreach (RenovationMerge renMer in renovationMerges)
            {
                if (renMer.RoomId1 == renovation.IdRoom)
                {
                    PickedRenoMerges.Add(renMer);
                }
                else if (renMer.RoomId2 == renovation.IdRoom)
                {
                    PickedRenoMerges.Add(renMer);
                }
            }

            List<Renovation> renovations = reno_Repository.GetAll();
            List<Renovation> PickedBasicReno = new List<Renovation>();

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovation.IdRoom)
                {
                    PickedBasicReno.Add(ren);
                }

            }

            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();
            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovation.IdRoom)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }

            bool Check = false;
            Check = timeOverlap_Service.TimeOverlapCheck(renovation.Start, renovation.Finish, PickedBasicReno, PickedRenoMerges, PickedRenoSplit);

            if (Check == false)
            {
                reno_Repository.Create(renovation);
            }
            return Check;
        }
    }
}
