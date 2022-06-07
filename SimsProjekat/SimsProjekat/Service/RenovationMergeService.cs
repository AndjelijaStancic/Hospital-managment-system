using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface RenovationMergeService
    {
        public List<RenovationMerge> GetAll();
        public RenovationMerge Create(RenovationMerge renovationMerge);
        public Boolean MergeRenovationCheck(RenovationMerge renovationMerge);

    }
}
