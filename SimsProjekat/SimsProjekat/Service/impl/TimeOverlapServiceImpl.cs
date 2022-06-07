using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class TimeOverlapServiceImpl : TimeOverlapService
    {
        public readonly RenovationRepository reno_Repository;
        public readonly RenovationMergeRepository renoMerge_Repository;
        public readonly RenovationSplitRepository renoSplit_Repository;

        public TimeOverlapServiceImpl(RenovationSplitRepository renoSplitRepository, RenovationRepository renoRepository, RenovationMergeRepository renoMergeRepository)
        {
            reno_Repository = renoRepository;
            renoMerge_Repository = renoMergeRepository;
            renoSplit_Repository = renoSplitRepository;
        }

        //checks if there is renovation that is already scheduled fot that time for that specific room
        public Boolean TimeOverlapCheck(DateTime Start, DateTime Finish, List<Renovation> renos, List<RenovationMerge> renmer, List<RenovationSplit> rensplit)
        {
            Boolean Check = false;

            foreach (RenovationMerge renoMerge in renmer)
            {
                if ((Start <= renoMerge.Start && Finish <= renoMerge.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start < renoMerge.Finish && Finish >= renoMerge.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start > renoMerge.Start && renoMerge.Finish > Finish))
                {
                    Check = true;
                }

            }

            foreach (Renovation reno in renos)
            {
                if ((Start <= reno.Start && Finish <= reno.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start < reno.Finish && Finish >= reno.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start > reno.Start && reno.Finish > Finish))
                {
                    Check = true;
                }

            }

            foreach (RenovationSplit renoSplit in rensplit)
            {
                if ((Start <= renoSplit.Start && Finish <= renoSplit.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start < renoSplit.Finish && Finish >= renoSplit.Finish) == true)
                {
                    Check = true;
                }
                else if ((Start > renoSplit.Start && renoSplit.Finish > Finish))
                {
                    Check = true;
                }

            }

            return Check;
        }

        


        
    }
}
