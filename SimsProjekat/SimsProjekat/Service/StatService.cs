using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface StatService
    {
        public List<User> FindDoctors(List<User> users);
        public List<StatDisplay> GetAllStatDoctor();
        public List<GradeCount> CountGradesDoctor(int id);
        public List<GradeCount> CountGradesHospital();
        public StatHospitalDisplay GetStatHospital();
    }
}
