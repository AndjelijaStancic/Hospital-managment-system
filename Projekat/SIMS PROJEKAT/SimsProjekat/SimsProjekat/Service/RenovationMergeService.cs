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
        public readonly RenovationSplitRepository renoSplit_Repository;

        public RenovationMergeService(RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
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
            bool check = false;
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<Renovation> renovations = reno_Repository.GetAll();
            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();
            List<Renovation> PickedBasicReno = new List<Renovation>();
            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();

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

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovationMerge.RoomId1 || ren.IdRoom == renovationMerge.RoomId2)
                {
                    PickedBasicReno.Add(ren);
                }
                
            }

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovationMerge.RoomId1 || renSplit.RoomId == renovationMerge.RoomId2)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }


            foreach (RenovationMerge renoMerge in PickedRenoMerges)
            {
                if((renovationMerge.Start <= renoMerge.Start && renovationMerge.Finish <= renoMerge.Finish) == true)
                {
                    check = true;
                }else if((renovationMerge.Start < renoMerge.Finish && renovationMerge.Finish >= renoMerge.Finish) == true)
                {
                    check = true;
                }
                else if((renovationMerge.Start > renoMerge.Start && renoMerge.Finish > renovationMerge.Finish)){
                    check = true;
                } 
            }

            foreach (Renovation reno in PickedBasicReno)
            {
                if ((renovationMerge.Start <= reno.Start && renovationMerge.Finish <= reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationMerge.Start < reno.Finish && renovationMerge.Finish >= reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationMerge.Start > reno.Start && reno.Finish > renovationMerge.Finish))
                {
                    check = true;
                }
            }

            foreach (RenovationSplit renoSplit in PickedRenoSplit)
            {
                if ((renovationMerge.Start <= renoSplit.Start && renovationMerge.Finish <= renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationMerge.Start < renoSplit.Finish && renovationMerge.Finish >= renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationMerge.Start > renoSplit.Start && renoSplit.Finish > renovationMerge.Finish))
                {
                    check = true;
                }
            }

            if (check == false)
            {
                renoMerge_Repository.Create(renovationMerge);
            }
            return check;
        }

    }
}
