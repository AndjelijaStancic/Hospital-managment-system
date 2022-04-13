// File:    Patient.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:45:31 PM
// Purpose: Definition of Class Patient

using System;
using Model;

namespace Model
{
   public class Patient : User
   {
      private String BloodType { get; set; }
      private double Weight { get; set; }
      private double Height { get; set; }
      private String Email { get; set; }
      private String Password { get; set; }

        public Patient(String bloodType, double wieght, double height,String email, String password,int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, Gender gender, Address address) : base(id, firstName, lastName, jmbg, dateOfBirth, telephoneNumber, gender, address)
        {
            BloodType = bloodType;
            Weight = wieght;
            Height = height;
            Email = email;
            Password = password;
        }
    }
}