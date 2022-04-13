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
      private int Id { get; set; }
      private string FirstName { get; set; }
      private string LastName { get; set; }
      private string Jmbg { get; set; }
      private DateTime DateOfBirth { get; set; }
      private string TelephoneNumber { get; set; }
    
      private Gender Gender { get; set; }

      public Address Address { get; set; }

        public User(int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, Gender gender, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
            TelephoneNumber = telephoneNumber;
            Gender = gender;
            Address = address;
        }
    }

}