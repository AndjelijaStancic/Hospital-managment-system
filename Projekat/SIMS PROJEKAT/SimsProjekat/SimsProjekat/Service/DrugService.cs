using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class DrugService
    {
        public readonly DrugRepository drug_Repository;
        

        public DrugService(DrugRepository drug_Repository)
        {
            this.drug_Repository = drug_Repository; 
        }

        public List<Drug> GetAllApprovedDrugs()
        {
            List<Drug> drugs = this.drug_Repository.GetAllDrugs();
            List<Drug> approvedDrugs = new List<Drug>();
            foreach (Drug drug in drugs)
            {
                if (drug.Approved == true)
                {
                    approvedDrugs.Add(drug);
                }
            }
            return approvedDrugs;
        }
        public List<Drug> GetAllRejectedDrugs()
        {
            List<Drug> drugs = this.drug_Repository.GetAllDrugs();
            List<Drug> rejectedDrugs = new List<Drug>();
            foreach (Drug drug in drugs)
            {
                if (drug.Approved == false)
                {
                    rejectedDrugs.Add(drug);
                }
            }
            return rejectedDrugs;
        }
        public List<Drug> GetAllDrugs()
        {
            return this.drug_Repository.GetAllDrugs();
        }
        public Drug GetById(int id)
        {
            return this.drug_Repository.GetById(id);
        }

        public Boolean DeleteDrug(int Id)
        {
            return drug_Repository.DeleteDrug(Id);
        }
        public Drug UpdateDrug(Drug drug)
        {
            if (drug.Ingredients.Equals("")) { drug.Ingredients = drug_Repository.GetById(drug.Id).Ingredients; }
            if (drug.Allergens.Equals("")) { drug.Allergens = drug_Repository.GetById(drug.Id).Allergens; }
            if (drug.Name.Equals("")) { drug.Name = drug_Repository.GetById(drug.Id).Name; }
            if (drug.Dose.Equals("")) { drug.Dose = drug_Repository.GetById(drug.Id).Dose; }
            return drug_Repository.UpdateDrug(drug);
        }
        public Drug CreateDrug(Drug drug)
        {
            return drug_Repository.CreateDrug(drug);
        }
    }
}
