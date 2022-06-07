using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface DrugRepository
    {
        public string ConvertCsv(Drug drug);
        public Drug ConvertDrug(string CsvFormat);
        public Drug GetById(int id);
        public List<Drug> GetAllDrugs();
        public bool DeleteDrug(int id);
        public Drug UpdateDrug(Drug drugUpdate);
        protected int NewId();
        public Drug CreateDrug(Drug drug);
    }
}
