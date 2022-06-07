using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface StatHospitalRepository
    {   
        public string ConvertCsv(StatisticsHospital stat);
        public StatisticsHospital ConvertToStat(string CsvFormat);
        public List<StatisticsHospital> GetAll();
        public bool Delete(int id);
    }
}
