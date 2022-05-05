using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class AccService
    {
        public readonly AccRepository acc_Repository;

        public AccService(AccRepository accRepository)
        {
            acc_Repository = accRepository;
        }

        public User GetOne()
        {
            return acc_Repository.GetOne();
        }

        public List<User> GetAll()
        {
            return acc_Repository.GetAll();
        }
    }
}
