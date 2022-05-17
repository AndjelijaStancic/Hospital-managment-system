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
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;

        public RenovationService(RenovationRepository renoRepository, RoomRepository roomRepository, RenovationMergeRepository renoMergeRepository, RenovationSplitRepository renovationSplitRepository)
        {
            reno_Repository = renoRepository;
            room_Repository = roomRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renovationSplitRepository;
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
            bool check = false;
            List<RenovationMerge> renovationMerges = renoMerge_Repository.GetAll();
            List<Renovation> renovations = reno_Repository.GetAll();
            List<RenovationSplit> renovationSplits = renoSplit_Repository.GetAll();
            List<RenovationMerge> PickedRenoMerges = new List<RenovationMerge>();
            List<Renovation> PickedBasicReno = new List<Renovation>();
            List<RenovationSplit> PickedRenoSplit = new List<RenovationSplit>();

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

            foreach (Renovation ren in renovations)
            {
                if (ren.IdRoom == renovation.IdRoom)
                {
                    PickedBasicReno.Add(ren);
                }

            }

            foreach (RenovationSplit renSplit in renovationSplits)
            {
                if (renSplit.RoomId == renovation.IdRoom)
                {
                    PickedRenoSplit.Add(renSplit);
                }

            }


            foreach (RenovationMerge renoMerge in PickedRenoMerges)
            {
                if ((renovation.Start < renoMerge.Start && renovation.Finish < renoMerge.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start < renoMerge.Finish && renovation.Finish >= renoMerge.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start > renoMerge.Start && renoMerge.Finish > renovation.Finish))
                {
                    check = true;
                }
            }

            foreach (Renovation reno in PickedBasicReno)
            {
                if ((renovation.Start < reno.Start && renovation.Finish < reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start < reno.Finish && renovation.Finish >= reno.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start > reno.Start && reno.Finish > renovation.Finish))
                {
                    check = true;
                }
            }

            foreach (RenovationSplit renoSplit in PickedRenoSplit)
            {
                if ((renovation.Start < renoSplit.Start && renovation.Finish < renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start < renoSplit.Finish && renovation.Finish >= renoSplit.Finish) == true)
                {
                    check = true;
                }
                else if ((renovation.Start > renoSplit.Start && renoSplit.Finish > renovation.Finish))
                {
                    check = true;
                }
            }

            if (check == false)
            {
                reno_Repository.Create(renovation);
            }
            return check;
        }


    }
}
