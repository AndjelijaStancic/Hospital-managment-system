// File:    Guest.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 3:54:23 PM
// Purpose: Definition of Class Guest

using System;

namespace Model
{
   public class Guest : User
   {
      private String BloodType { get; set; }
      private double Weight { get; set; }
      private double Height { get; set; }

        public Guest(String bloodType, double wieght, double height, String email, String password, int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, Gender gender, Address address) : base(id, firstName, lastName, jmbg, dateOfBirth, telephoneNumber, gender, address)
        {
            BloodType = bloodType;
            Weight = wieght;
            Height = height;
        }
    }
}