// File:    Secretary.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:45:29 PM
// Purpose: Definition of Class Secretary

using System;

namespace Model
{
   public class Secretary 
   {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public Secretary(int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, string gender, int salary, string email, string userName, string password, string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            Salary = salary;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}