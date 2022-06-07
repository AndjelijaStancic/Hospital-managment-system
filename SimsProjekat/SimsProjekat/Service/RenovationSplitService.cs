using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface RenovationSplitService
    {
        public List<RenovationSplit> GetAll();
        public RenovationSplit Create(RenovationSplit renovationSplit);
        public Boolean SplitRenovationCheck(RenovationSplit renovationSplit);
    }
}
