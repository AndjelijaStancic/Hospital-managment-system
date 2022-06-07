using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class RenovationMergeServiceImpl : RenovationMergeService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RoomRepository room_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;
        public readonly TimeOverlapService timeOverlap_Service;

        public RenovationMergeServiceImpl(RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository, TimeOverlapService timeOverlapService)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
            timeOverlap_Service = timeOverlapService;
        }
        public List<RenovationMerge> GetAll()
        {
            return renoMerge_Repository.GetAll();
        }
        public RenovationMerge Create(RenovationMerge renovationMerge)
        {
            return renoMerge_Repository.Create(renovationMerge);
        }

        public Boolean MergeRenovationCheck(RenovationMerge renovationMerge)
        {
            
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();

            foreach (RenovationMerge renMer in renovationMerges)
            {
                if(renMer.RoomId1 == renovationMerge.RoomId1 || renMer.RoomId1 == renovationMerge.RoomId2)
                {
                    PickedRenoMerges.Add(renMer);
                }else if(renMer.RoomId2 == renovationMerge.RoomId1 || renMer.RoomId2 == renovationMerge.RoomId2)
                {
                    PickedRenoMerges.Add(renMer); 
                }
            }

            List<Renovation> renovations = reno_Repository.GetAll();
            List<Renovation> PickedBasicReno = new List<Renovation>();

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovationMerge.RoomId1 || ren.IdRoom == renovationMerge.RoomId2)
                {
                    PickedBasicReno.Add(ren);
                }
            }

            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();
            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovationMerge.RoomId1 || renSplit.RoomId == renovationMerge.RoomId2)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }

            bool Check = false;
            Check = timeOverlap_Service.TimeOverlapCheck(renovationMerge.Start, renovationMerge.Finish, PickedBasicReno, PickedRenoMerges, PickedRenoSplit);

            if (Check == false)
            {
                renoMerge_Repository.Create(renovationMerge);
            }
            return Check;
        }

    }
}
