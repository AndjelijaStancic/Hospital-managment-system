using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface RenovationService
    {
        public List<Renovation> GetAll();
        public Renovation Create(Renovation renovation);
        public Boolean RenovationCheck(Renovation renovation);
    }
}
