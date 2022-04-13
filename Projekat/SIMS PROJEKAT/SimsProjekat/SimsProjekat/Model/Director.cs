// File:    Director.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 3:45:28 PM
// Purpose: Definition of Class Director

using System;

namespace Model
{
   public class Director : Employee
   {
        Director(int salary, TimeInterval workingHorus, string email, string username, string password, int id, string firstName, string lastName, string jmbg, DateTime dateOfBirth, string telephoneNumber, Gender gender, Address address)
            : base(salary, workingHorus, email, username, password, id, firstName, lastName, jmbg, dateOfBirth, telephoneNumber, gender, address)
        {

        }


   }
}