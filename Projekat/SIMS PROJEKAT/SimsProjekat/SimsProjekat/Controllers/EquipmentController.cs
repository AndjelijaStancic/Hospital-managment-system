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
        public List<EquipmentDisplay> GetAllFilteredDynamic(String Filter)
        {
            return equipment_Service.GetAllFilteredDynamic(Filter);
        }
        public List<EquipmentDisplay> GetAllFilteredStatic(String Filter)
        {
            return equipment_Service.GetAllFilteredStatic(Filter);
        }

        public List<EquipmentDisplay> GetAllDisplayDin()
        {
            return equipment_Service.GetDynEqpDysplay();
        }
        public List<EquipmentDisplay> GetAllDisplay()
        {
            return equipment_Service.GetAllDisplay();
        }
        public List<EquipmentDisplay> GetEqpDisplay()
        {
            return equipment_Service.GetStaticEqpDisplay();
        }
    }
}
