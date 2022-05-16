using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;


namespace Controller
{
    public class EquipmentController
    {
        private readonly EquipmentService equipment_Service;

        public EquipmentController(EquipmentService service)
        {
            equipment_Service = service;
        }
        public List<Equipment> GetAll()
        {
            return equipment_Service.GetAll();
        }
        public List<EquipmentDisplay> GetAllFiltered(String Filter)
        {
            return equipment_Service.GetAllFiltered(Filter);
        }
        public List<EquipmentDisplay> GetAllDisplay()
        {
            return equipment_Service.GetAllDis();
        }
        public List<EquipmentDisplay> DinEqpDisplay()
        {
            return equipment_Service.DinEqpDisplay();
        }
        public List<EquipmentDisplay> GetEqpDisplay()
        {
            return equipment_Service.GetEqpDisplay();
        }
        
    }
}
