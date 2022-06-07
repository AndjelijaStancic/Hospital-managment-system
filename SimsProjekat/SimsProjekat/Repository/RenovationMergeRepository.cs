using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface RenovationMergeRepository
    {
        public string ConvertToCsv(RenovationMerge renovationMerge);
        public RenovationMerge ConvertToRenovationMerge(string CsvFormat);
        public List<RenovationMerge> GetAll();
        protected int NewId();
        public RenovationMerge Create(RenovationMerge renovationMerge);
        public bool Delete(int id);

    }
}
