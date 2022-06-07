using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface AccRepository
    {
        public User GetById(int id);
        public string ConvertToCsvUser(User u);
        public User ConvertUser(string CsvFormat);
        public List<User> GetAll();
        public User GetOne();
    }
}
