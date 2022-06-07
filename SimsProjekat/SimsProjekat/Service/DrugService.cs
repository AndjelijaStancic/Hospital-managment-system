using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface DrugService
    {
        public List<Drug> GetAllApprovedDrugs();
        public List<Drug> GetAllRejectedDrugs();
        public List<Drug> GetAllDrugs();
        public Drug GetById(int id);
        public Boolean DeleteDrug(int Id);
        public Drug UpdateDrug(Drug drug);
        public Drug CreateDrug(Drug drug);

    }
}
