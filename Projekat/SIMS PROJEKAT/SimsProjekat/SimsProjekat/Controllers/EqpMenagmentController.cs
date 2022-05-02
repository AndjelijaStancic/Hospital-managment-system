using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Service;
using Model;


namespace Controller
{
    public class EqpMenagmentController
    {
        private readonly EqpMenagmentService eqpMenagment_Service;

        public EqpMenagmentController(EqpMenagmentService service)
        {
            eqpMenagment_Service = service;
        }
        public List<EquipmentMenagment> GetAll()
        {
            return eqpMenagment_Service.GetAll();
        }

        public EquipmentMenagment Create(EquipmentMenagment equipmentMenagment)
        {
            return eqpMenagment_Service.Create(equipmentMenagment);
        }
    }
}
