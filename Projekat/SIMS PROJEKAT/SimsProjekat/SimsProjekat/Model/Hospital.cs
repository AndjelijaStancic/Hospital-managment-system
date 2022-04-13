// File:    Hospital.cs
// Author:  Andjelija
// Created: Monday, April 11, 2022 5:05:48 PM
// Purpose: Definition of Class Hospital

using System;

namespace Model
{
   public class Hospital
   {
      private string name;
      
      public Address address;
      public System.Collections.Generic.List<Employee> employee;
      
      /// <summary>
      /// Property for collection of Employee
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Employee> Employee
      {
         get
         {
            if (employee == null)
               employee = new System.Collections.Generic.List<Employee>();
            return employee;
         }
         set
         {
            RemoveAllEmployee();
            if (value != null)
            {
               foreach (Employee oEmployee in value)
                  AddEmployee(oEmployee);
            }
         }
      }
      
      /// <summary>
      /// Add a new Employee in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddEmployee(Employee newEmployee)
      {
         if (newEmployee == null)
            return;
         if (this.employee == null)
            this.employee = new System.Collections.Generic.List<Employee>();
         if (!this.employee.Contains(newEmployee))
         {
            this.employee.Add(newEmployee);
            newEmployee.Hospital = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Employee from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveEmployee(Employee oldEmployee)
      {
         if (oldEmployee == null)
            return;
         if (this.employee != null)
            if (this.employee.Contains(oldEmployee))
            {
               this.employee.Remove(oldEmployee);
               oldEmployee.Hospital = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Employee from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllEmployee()
      {
         if (employee != null)
         {
            System.Collections.ArrayList tmpEmployee = new System.Collections.ArrayList();
            foreach (Employee oldEmployee in employee)
               tmpEmployee.Add(oldEmployee);
            employee.Clear();
            foreach (Employee oldEmployee in tmpEmployee)
               oldEmployee.Hospital = null;
            tmpEmployee.Clear();
         }
      }
   
   }
}