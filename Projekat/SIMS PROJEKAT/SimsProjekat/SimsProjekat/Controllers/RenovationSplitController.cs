using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Controller
{
    public class RenovationSplitController
    {
        private readonly RenovationSplitService renoSplit_Service;

        public RenovationSplitController(RenovationSplitService service)
        {
            renoSplit_Service = service;
        }
    }
}
