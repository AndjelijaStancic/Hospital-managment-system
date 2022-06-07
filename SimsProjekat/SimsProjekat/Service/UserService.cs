using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface UserService
    {
        public User GetById(int id);
        public List<User> GetAll();
        public User CheckExistence(LogInUser logInUser);
    }
}
