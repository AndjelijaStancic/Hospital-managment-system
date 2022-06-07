using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface StatRepository
    {
        public string ConvertCsv(Statistics stat);
        public Statistics ConvertToStat(string CsvFormat);
        public Statistics GetById(int id);
        public List<Statistics> GetAll();
        public bool Delete(int id);
    }
}
