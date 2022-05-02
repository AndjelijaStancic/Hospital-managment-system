using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace Repository
{
    public class UserRepository
    {
        private string Path;
        private string Delimiter;


        public UserRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public string ConvertToCsvDirector(User u)
        {
            return string.Join(Delimiter,
                u.Id,
                u.FirstName,
                u.LastName,
                u.Jmbg,
                u.DateOfBirth,
                u.TelephoneNumber,
                u.Gender,
                u.Email,
                u.UserName,
                u.Password,
                u.Role
                );

        }


        public User ConvertUser(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            string format = "M/d/yyyy h:mm:ss tt";
            int id = int.Parse(tokens[0]);
            String firstName = tokens[1];
            String lastName = tokens[2];
            String jmbg = tokens[3];
            DateTime dateOfBirth = DateTime.ParseExact(tokens[4], format, System.Globalization.CultureInfo.InvariantCulture);
            String telephone = tokens[5];
            String gender = tokens[6];
            String email = tokens[7];
            String userName = tokens[8];
            String password = tokens[9];
            String role = tokens[10];
            return new User(id, firstName, lastName, jmbg, dateOfBirth, telephone, gender, email, userName, password, role);
        }

        public List<User> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertUser).ToList();
        }
        public User GetOne(int id)
        {
            List<User> users = GetAll().ToList();
            User user1 = new User(-1, "", "", "", DateTime.Parse("1 / 1 / 1000 12:00:00 AM"), "", "", "", "", "", "");
            foreach (User user in users)
            {
                if (user.Id == id)
                    user1 = user;
            }
            return user1;
        }


    }
}
