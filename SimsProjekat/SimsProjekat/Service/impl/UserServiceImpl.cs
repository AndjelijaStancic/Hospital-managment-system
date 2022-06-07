using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;
namespace Service
{
    public class UserServiceImpl : UserService
    {
        public readonly UserRepository user_Repository;

        public UserServiceImpl(UserRepository userRepository)
        {
            user_Repository = userRepository;
        }

        public User GetById(int id)
        {
            return user_Repository.GetById(id);
        }

        
        public List<User> GetAll()
        {
            return user_Repository.GetAll();
        }
        public User CheckExistence(LogInUser logInUser)
        {
            List<User> users = user_Repository.GetAll().ToList();
            foreach (User user in users)
            {
                if ((user.UserName.Equals(logInUser.EmailOrUserName) && user.Password.Equals(logInUser.Password)) || (user.Email.Equals(logInUser.EmailOrUserName) && user.Password.Equals(logInUser.Password)))
                {
                    return user;
                }
            }
            User user1 = new User(-1, "", "", "", DateTime.Parse("1 / 1 / 1000 12:00:00 AM"), "", "", "", "", "", "");
            return user1;
        }
        
    }
}
