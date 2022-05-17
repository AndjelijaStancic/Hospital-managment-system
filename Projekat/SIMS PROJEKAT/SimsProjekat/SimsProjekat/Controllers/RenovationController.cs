using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class RenovationController
    {
        private readonly RenovationService reno_Service;

        public RenovationController(RenovationService service)
        {
            reno_Service = service;
        }
        public List<Renovation> GetAll()
        {
            return reno_Service.GetAll();
        }

        public Renovation Create(Renovation renovation)
        {
            return reno_Service.Create(renovation);
        }
        
        public Boolean RenovationCheck(Renovation renovation)
        {
        return reno_Service.RenovationCheck(renovation);
        }
    }
}
