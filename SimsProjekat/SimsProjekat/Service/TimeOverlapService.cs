using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface TimeOverlapService
    {
        public Boolean TimeOverlapCheck(DateTime Start, DateTime Finish, List<Renovation> renos, List<RenovationMerge> renmer, List<RenovationSplit> rensplit);
    }
}
