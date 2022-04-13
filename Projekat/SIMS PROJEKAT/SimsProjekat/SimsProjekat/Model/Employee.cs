// File:    Employee.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:45:22 PM
// Purpose: Definition of Class Employee

using System;
using Model;

namespace Model
{
   public class Employee : User
   {
      private int Salary { get; set; }  
      private TimeInterval WorkingHours { get; set; }
      private string Email { get; set; }
      private string UserName { get; set; }
      private string Password { get; set; }

      public Hospital hospital { get; set; }

        public Employee(int salary, TimeInterval workingHorus,string email, string username,string password,int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, Gender gender, Address address) : base(id, firstName, lastName, jmbg, dateOfBirth, telephoneNumber, gender, address)
        {
            Salary = salary;
            WorkingHours = workingHorus;
            Email = email;
            UserName = username;
            Password = password;
        }

        /// <summary>
        /// Property for Hospital
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Hospital Hospital
      {
         get
         {
            return hospital;
         }
         set
         {
            if (this.hospital == null || !this.hospital.Equals(value))
            {
               if (this.hospital != null)
               {
                  Hospital oldHospital = this.hospital;
                  this.hospital = null;
                  oldHospital.RemoveEmployee(this);
               }
               if (value != null)
               {
                  this.hospital = value;
                  this.hospital.AddEmployee(this);
               }
            }
         }
      }
   
   }
}