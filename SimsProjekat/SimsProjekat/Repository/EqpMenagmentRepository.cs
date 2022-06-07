using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface EqpMenagmentRepository
    {
        public string ConvertCsv(EquipmentMenagment equipmentMenagment);
        public EquipmentMenagment ConvertEqpMenagment(string CsvFormat);
        public List<EquipmentMenagment> GetAll();
        protected int NewId();
        public EquipmentMenagment Create(EquipmentMenagment equipmentMenagment);
        public EquipmentMenagment GetById(int id);
        public bool DeleteEqpMen(int id);
    }
}
