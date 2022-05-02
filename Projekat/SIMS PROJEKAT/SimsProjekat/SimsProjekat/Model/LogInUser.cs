using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LogInUser
    {
        public string EmailOrUserName { get; set; }

        public string Password { get; set; }

        public LogInUser(string emailOrUserName, string pass)
        {
            EmailOrUserName = emailOrUserName;
            Password = pass;
        }



    }
}
