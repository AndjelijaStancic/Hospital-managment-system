using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface EquipmentRepository
    {
        public string ConvertCsv(Equipment equipment);
        public Equipment ConvertEqp(string CsvFormat);
        public List<Equipment> GetAll();
        public Equipment GetById(int id);
        protected int NewId();
        public Equipment Create(Equipment eqp);
        public Equipment Update(Equipment eqp);
        public bool DeleteEqp(int id);
    }
}
