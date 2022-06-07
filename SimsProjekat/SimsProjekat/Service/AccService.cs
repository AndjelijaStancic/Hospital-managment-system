using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Service
{
    public interface AccService
    {
        public User GetOne();
        public User GetById(int id);
        public List<User> GetAll();
    }
}
