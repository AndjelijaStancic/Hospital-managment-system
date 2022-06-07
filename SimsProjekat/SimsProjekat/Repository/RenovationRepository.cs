using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface RenovationRepository
    {
        public string ConvertCsv(Renovation renovation);
        public Renovation ConvertReno(string CsvFormat);
        public List<Renovation> GetAll();
        protected int NewId();
        public Renovation Create(Renovation reno);
    }
}
