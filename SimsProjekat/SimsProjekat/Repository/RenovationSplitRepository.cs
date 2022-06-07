using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface RenovationSplitRepository
    {
        public string ConvertToCsv(RenovationSplit renovationSplit);
        public RenovationSplit ConvertToRenovationSplit(string CsvFormat);
        public List<RenovationSplit> GetAll();
        protected int NewId();
        public RenovationSplit Create(RenovationSplit renovationSplit);
        public bool Delete(int id);
    }
}
