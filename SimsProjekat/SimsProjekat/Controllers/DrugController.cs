using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class DrugController
    {
        private readonly DrugService drug_Service;

        public DrugController(DrugService DrugService)
        {
            drug_Service = DrugService;
        }

        public List<Drug> GetAllApprovedDrugs()
        {
            return drug_Service.GetAllApprovedDrugs();
        }
        public Drug GetById(int id)
        {
            return drug_Service.GetById(id);    
        }
      
        public List<Drug> GetAllDrugs()
        {
            return drug_Service.GetAllDrugs();
        }

        public List<Drug> GetAllRejectedDrugs()
        {
            return drug_Service.GetAllRejectedDrugs();
        }

        public Boolean DeleteDrug(int Id)
        {
            return drug_Service.DeleteDrug(Id);
        }
        public Drug UpdateDrug(Drug drug)
        {
            return drug_Service.UpdateDrug(drug);
        }
        public Drug CreateDrug(Drug drug)
        {
            return drug_Service.CreateDrug(drug);
        }

    }
}
