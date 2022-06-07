using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;
using Service;

namespace Service
{
    public class RenovationSplitServiceImpl : RenovationSplitService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;
        public readonly TimeOverlapService timeOverlap_Service;

        public RenovationSplitServiceImpl(RenovationSplitRepository renoSplitRepository,RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository, TimeOverlapService timeOverlapService)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renoSplitRepository;
            timeOverlap_Service = timeOverlapService;
        }
        public List<RenovationSplit> GetAll()
        {
            return renoSplit_Repository.GetAll();
        }
        public RenovationSplit Create(RenovationSplit renovationSplit)
        {
            return renoSplit_Repository.Create(renovationSplit);
        }

        public Boolean SplitRenovationCheck(RenovationSplit renovationSplit)
        {
            
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();
            
            foreach (RenovationMerge renMer in renovationMerges)
            {
                if (renMer.RoomId1 == renovationSplit.RoomId)
                {
                    PickedRenoMerges.Add(renMer);
                }
                else if (renMer.RoomId2 == renovationSplit.RoomId)
                {
                    PickedRenoMerges.Add(renMer);
                }
            }

            List<Renovation> PickedBasicReno = new List<Renovation>();
            List<Renovation> renovations = reno_Repository.GetAll();

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovationSplit.RoomId)
                {
                    PickedBasicReno.Add(ren);
                }

            }

            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();
            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovationSplit.RoomId)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }

            bool Check = false;
            Check = timeOverlap_Service.TimeOverlapCheck(renovationSplit.Start, renovationSplit.Finish, PickedBasicReno, PickedRenoMerges, PickedRenoSplit);

            if (Check == false)
            {
                renoSplit_Repository.Create(renovationSplit);
            }
            
            return Check;
        }


    }
}
