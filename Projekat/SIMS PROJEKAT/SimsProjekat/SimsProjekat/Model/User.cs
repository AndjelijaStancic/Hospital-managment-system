// File:    User.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:45:19 PM
// Purpose: Definition of Class User

using System;
using static Model.Gender;
using static Model.Address;


namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public User(int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, string gender, string email, string userName, string password, string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;

        }
    }

 }