using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class RenovationMergeController
    {
        private readonly RenovationMergeService renoMerge_Service;

        public RenovationMergeController(RenovationMergeService service)
        {
            renoMerge_Service = service;
        }
        public List<RenovationMerge> GetAll()
        {
            return renoMerge_Service.GetAll();
        }

        public RenovationMerge Create(RenovationMerge renovationMerge)
        {
            return renoMerge_Service.Create(renovationMerge);
        }
        public Boolean MergeRenovationCheck(RenovationMerge renovationMerge)
        {
            return renoMerge_Service.MergeRenovationCheck(renovationMerge);
        }
    }
}
