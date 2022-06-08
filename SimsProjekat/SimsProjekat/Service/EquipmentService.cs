using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface EquipmentService
    {
        public List<Equipment> GetAll();
        public List<EquipmentMenagment> GetAllEqpMen();
        public List<EquipmentDisplay> GetDynEqpDysplay();
        public List<EquipmentDisplay> GetAllDisplay();
        public List<EquipmentDisplay> GetStaticEqpDisplay();
    }
}
