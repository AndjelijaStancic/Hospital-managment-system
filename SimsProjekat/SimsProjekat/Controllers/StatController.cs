using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class StatController
    {
        private readonly StatService stat_Service;
        public StatController(StatService Statservice)
        {
            stat_Service = Statservice;
        }

        public List<StatDisplay> GetAllStatDoctor()
        {
            return stat_Service.GetAllStatDoctor();
        }
        public StatHospitalDisplay GetStatHospital()
        {
            return stat_Service.GetStatHospital();
        }
        public List<GradeCount> CountGradesHospital()
        {
            return stat_Service.CountGradesHospital();
        }
        public List<GradeCount> CountGradesDoctor(int id)
        {
            return stat_Service.CountGradesDoctor(id);
        }


    }
}
