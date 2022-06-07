using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface EqpMenagmentService
    {
        public List<EquipmentMenagment> GetAll();
        public EquipmentMenagment Create(EquipmentMenagment equipment);
    }
}
