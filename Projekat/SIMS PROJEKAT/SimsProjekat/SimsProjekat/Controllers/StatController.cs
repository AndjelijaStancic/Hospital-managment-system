using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class StatController
    {
        private readonly StatService stat_Service;
        private readonly UserService user_Service;
        public StatController(StatService Statservice, UserService UserService)
        {
            stat_Service = Statservice;
            user_Service = UserService;
        }

        public List<StatDisplay> GetAll()
        {
            List<StatDisplay> statistics = new List<StatDisplay>();
            List<User> doctors = user_Service.GetAllDoctors();
            List<Statistics> stats = stat_Service.GetAll();
         
            foreach(User doctor in doctors)
            {
                int sum = 0;
                int num = 0;
                double grade = 0.0;
                List<String> comments = new List<string>();
                foreach (Statistics stat in stats)
                {
                    if(stat.Id == doctor.Id)
                    {
                        sum = sum + stat.Grade;
                        comments.Add(stat.Comment);
                        num++;
                    }    
                }
                if(num > 0) 
                { 
                    grade = Math.Round(((double)sum / (double)num), 4);
                }
                String FirstAndLast = doctor.FirstName + " " + doctor.LastName;
                StatDisplay statDisplay = new StatDisplay(FirstAndLast, grade, comments);
                statistics.Add(statDisplay);
            }
            return statistics;
        }
    }
}
