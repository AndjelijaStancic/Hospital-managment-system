using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class StatService
    {
        public readonly StatRepository stat_Repository;
        public readonly StatHospitalRepository statHospital_Repository;
        public readonly UserRepository user_Repository;

        public StatService(StatRepository statRepository, StatHospitalRepository statHospitalRepository, UserRepository userRepository)
        {
            stat_Repository = statRepository;
            statHospital_Repository = statHospitalRepository;
            user_Repository = userRepository;
        }
        
        public List<User> FindDoctors(List<User> users)
        {
            List<User> doctors = new List<User>();
            foreach (User user in users)
            {
                if (user.Role.Equals("Doctor"))
                {
                    doctors.Add(user);
                }
            }
            return doctors;
        }

        

        public List<StatDisplay> GetAllStatDoctor()
        {
            List<StatDisplay> statistics = new List<StatDisplay>();
            List<User> users = user_Repository.GetAll();
            List<User> doctors = new List<User>();
            List<Statistics> stats = stat_Repository.GetAll();

            doctors = FindDoctors(users);

            foreach (User doctor in doctors)
            {
                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                int num = 0;
                double grade1 = 0.0;
                double grade2 = 0.0;
                double grade3 = 0.0;
                double grade = 0.0;
                List<String> comments = new List<string>();
                foreach (Statistics stat in stats)
                {
                    if (stat.Id == doctor.Id)
                    {
                        sum1 = sum1 + stat.GradeOne;
                        sum2 = sum2 + stat.GradeTwo;
                        sum3 = sum3 + stat.GradeThree;
                        num++;
                    }

                }
                int sum = sum1 + sum2 + sum3;
                int numGrade = num * 3;
                if (num > 0)
                {
                    grade1 = Math.Round(((double)sum1 / (double)num), 4);
                    grade2 = Math.Round(((double)sum2 / (double)num), 4);
                    grade3 = Math.Round(((double)sum3 / (double)num), 4);
                    grade = Math.Round(((double)sum / (double)numGrade), 4);
                }



                String FirstAndLast = doctor.FirstName + " " + doctor.LastName;
                StatDisplay statDisplay = new StatDisplay(doctor.Id, FirstAndLast, grade1, grade2, grade3, grade);
                statistics.Add(statDisplay);
            }
            return statistics;


            
        }
        public List<GradeCount> CountGradesDoctor(int id)
        {
            List<GradeCount> grades = new List<GradeCount>();
            List<Statistics> stats = stat_Repository.GetAll();
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            foreach (Statistics sh in stats)
            {
                if (sh.Id == id)
                {
                    if (sh.GradeOne == 1) { count1++; }
                    if (sh.GradeOne == 2) { count2++; }
                    if (sh.GradeOne == 3) { count3++; }
                    if (sh.GradeOne == 4) { count4++; }
                    if (sh.GradeOne == 5) { count5++; }
                }
            }
            GradeCount QuestionOne = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionOne);

            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;

            foreach (Statistics sh in stats)
            {
                if (sh.Id == id)
                {
                    if (sh.GradeTwo == 1) { count1++; }
                    if (sh.GradeTwo == 2) { count2++; }
                    if (sh.GradeTwo == 3) { count3++; }
                    if (sh.GradeTwo == 4) { count4++; }
                    if (sh.GradeTwo == 5) { count5++; }
                }
            }
            GradeCount QuestionTwo = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionTwo);

            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;

            foreach (Statistics sh in stats)
            {
                if (sh.Id == id)
                {
                    if (sh.GradeThree == 1) { count1++; }
                    if (sh.GradeThree == 2) { count2++; }
                    if (sh.GradeThree == 3) { count3++; }
                    if (sh.GradeThree == 4) { count4++; }
                    if (sh.GradeThree == 5) { count5++; }
                }
            }
            GradeCount QuestionThree = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionThree);
            return grades;

        }

        public List<GradeCount> CountGradesHospital()
        {
            //in grades we return number of specific grade per question
            List<GradeCount> grades = new List<GradeCount>();
            List<StatisticsHospital> stats = statHospital_Repository.GetAll();
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            foreach (StatisticsHospital sh in stats)
            {
                if(sh.GradeOne == 1) { count1++; }
                if(sh.GradeOne == 2) { count2++; }
                if(sh.GradeOne == 3) { count3++; }
                if(sh.GradeOne == 4) { count4++; }
                if(sh.GradeOne == 5) { count5++; }
            }
            GradeCount QuestionOne = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionOne);

            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;

            foreach (StatisticsHospital sh in stats)
            {
                if (sh.GradeTwo == 1) { count1++; }
                if (sh.GradeTwo == 2) { count2++; }
                if (sh.GradeTwo == 3) { count3++; }
                if (sh.GradeTwo == 4) { count4++; }
                if (sh.GradeTwo == 5) { count5++; }
            }
            GradeCount QuestionTwo = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionTwo);

            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;

            foreach (StatisticsHospital sh in stats)
            {
                if (sh.GradeThree == 1) { count1++; }
                if (sh.GradeThree == 2) { count2++; }
                if (sh.GradeThree == 3) { count3++; }
                if (sh.GradeThree == 4) { count4++; }
                if (sh.GradeThree == 5) { count5++; }
            }
            GradeCount QuestionThree = new GradeCount(count1, count2, count3, count4, count5);
            grades.Add(QuestionThree);

            return grades;

        }

        public StatHospitalDisplay GetStatHospital()
        {
            StatHospitalDisplay statisticsHospital = new StatHospitalDisplay(0, 0, 0, 0);
            List<StatisticsHospital> stats = statHospital_Repository.GetAll();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            
            int num = 0;
            double grade1 = 0.0;
            double grade2 = 0.0;
            double grade3 = 0.0;
            double grade = 0.0;
            foreach (StatisticsHospital stat in stats)
            {
                
                sum1 = sum1 + stat.GradeOne;
                sum2 = sum2 + stat.GradeTwo;
                sum3 = sum3 + stat.GradeThree;
                num++;
                

            }

            int sum = sum1 + sum2 + sum3;
            int numGrade = num * 3;
            if (num > 0)
            {
                grade1 = Math.Round(((double)sum1 / (double)num), 4);
                grade2 = Math.Round(((double)sum2 / (double)num), 4);
                grade3 = Math.Round(((double)sum3 / (double)num), 4);
                grade = Math.Round(((double)sum / (double)numGrade), 4);
            }

            StatHospitalDisplay statHospitalDisplay = new StatHospitalDisplay(grade1, grade2, grade3, grade);
            statisticsHospital = statHospitalDisplay;


        return statisticsHospital;



        }


    }
}
