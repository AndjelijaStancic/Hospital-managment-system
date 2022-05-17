using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

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
            bool check = false;
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<Renovation> renovations = reno_Repository.GetAll();
            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();
            List<Renovation> PickedBasicReno = new List<Renovation>();
            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();

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

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovationSplit.RoomId)
                {
                    PickedBasicReno.Add(ren);
                }

            }

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovationSplit.RoomId)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }


            foreach (RenovationMerge renoMerge in PickedRenoMerges)
            {
                if ((renovationSplit.Start < renoMerge.Start && renovationSplit.Finish < renoMerge.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start < renoMerge.Finish && renovationSplit.Finish >= renoMerge.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start > renoMerge.Start && renoMerge.Finish > renovationSplit.Finish))
                {
                    check = true;
                }
            }

            foreach (Renovation reno in PickedBasicReno)
            {
                if ((renovationSplit.Start < reno.Start && renovationSplit.Finish < reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start < reno.Finish && renovationSplit.Finish >= reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start > reno.Start && reno.Finish > renovationSplit.Finish))
                {
                    check = true;
                }
            }

            foreach (RenovationSplit renoSplit in PickedRenoSplit)
            {
                if ((renovationSplit.Start < renoSplit.Start && renovationSplit.Finish < renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start < renoSplit.Finish && renovationSplit.Finish >= renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovationSplit.Start > renoSplit.Start && renoSplit.Finish > renovationSplit.Finish))
                {
                    check = true;
                }
            }

            if (check == false)
            {
                renoSplit_Repository.Create(renovationSplit);
            }
            return check;
        }


    }
}
