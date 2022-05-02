using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class UserController
    {
        private readonly UserService user_Service;

        public UserController(UserService service)
        {
            user_Service = service;
        }
        public User GetById(int id)
        {
            return user_Service.GetById(id);
        }

        public List<User> GetAll()
        {
            return user_Service.GetAll();
        }

        public User  CheckExistence(LogInUser logInUser)
        {
            return user_Service.CheckExistence(logInUser);
        }
    }
}
