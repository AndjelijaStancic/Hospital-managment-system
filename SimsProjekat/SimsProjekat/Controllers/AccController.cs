using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class AccController
    {
        private readonly AccService acc_Service;

        public AccController(AccService AccService)
        {
            acc_Service = AccService;
        }
        public User GetOne()
        {
            return acc_Service.GetOne();
        }

        public List<User> GetAll()
        {
            return acc_Service.GetAll();
        }
        public User GetById(int id)
        {
            return acc_Service.GetById(id);
        }
    }
}
