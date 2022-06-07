using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface UserRepository
    {
        public string ConvertToCsvDirector(User u);
        public User ConvertUser(string CsvFormat);
        public List<User> GetAll();
        public User GetById(int id);
    }
}
