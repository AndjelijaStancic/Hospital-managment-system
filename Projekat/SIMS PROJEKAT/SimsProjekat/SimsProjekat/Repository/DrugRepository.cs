using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq;
using System.IO;
namespace Repository
{
    public class DrugRepository
    {
        private string Path;
        private string Delimiter;

        public DrugRepository(string Path, string Delimiter)
        {
            this.Path = Path;
            this.Delimiter = Delimiter;
        }

        public string ConvertCsv(Drug drug)
        {
            return string.Join(Delimiter,
                drug.Id,
                drug.Name,
                drug.Dose,
                drug.Ingredients,
                drug.Allergens,
                drug.Approved
                );

        }

        public Drug ConvertDrug(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int Id = int.Parse(tokens[0]);
            String Name = tokens[1];
            String Dose = (tokens[2]);
            String Ingredients = tokens[3];
            String Allergens = tokens[4];
            Boolean Approved = bool.Parse(tokens[5]);
            return new Drug(Id, Name, Dose, Ingredients, Allergens, Approved);
        }

        public List<Drug> GetAllDrugs()
        {
            return File.ReadAllLines(Path).Select(ConvertDrug).ToList();
        }

        public bool DeleteDrug(int id)
        {
            List<String> updated = new List<string>();
            List<Drug> drugs = GetAllDrugs().ToList();
            bool deleted = false;
            
            foreach (Drug drug in drugs)
            {
                if (drug.Id != id)
                {
                    deleted = true;
                    updated.Add(ConvertCsv(drug));

                }
            }
            File.WriteAllLines(Path, updated);
            return deleted;
        }

        public Drug UpdateDrug(Drug drugUpdate)
        {
            List<Drug> drugs = GetAllDrugs().ToList();
            List<String> updated = new List<String>();
            foreach (Drug drug in drugs)
            {
                if (drug.Id == drugUpdate.Id)
                {
                    drug.Name = drugUpdate.Name;
                    drug.Dose = drugUpdate.Dose;
                    drug.Ingredients = drugUpdate.Ingredients;
                    drug.Allergens = drugUpdate.Allergens;
                }
                updated.Add(ConvertCsv(drug));
            }
            File.WriteAllLines(Path, updated);
            return drugUpdate;
        }

        protected int NewId()
        {
            int id = 0;
            List<Drug> drugs = GetAllDrugs().ToList();
            foreach (Drug drug in drugs)
            {
                if (drug.Id > id)
                {
                    id = drug.Id;
                }
            }
            if (drugs.Count == 0) { id = 0; }
            return id;
        }
        public Drug CreateDrug(Drug drug)
        {
            List<Drug> drugs = GetAllDrugs().ToList();
            int id = (NewId());
            drug.Id = ++id;
            File.AppendAllText(Path, ConvertCsv(drug) + Environment.NewLine);
            return drug;

        }
    }
}
