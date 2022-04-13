// File:    AppointmentRepository2.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 4:04:42 PM
// Purpose: Definition of Class AppointmentRepository2

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class AppointmentRepository
   {
        private string Path;
        private string Delimiter;

        public Appointment GetById(int appointmentId)
      {
         throw new NotImplementedException();
      }

        public AppointmentRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public List<Appointment> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public Appointment Update(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(int id)
      {
         throw new NotImplementedException();
      }
      
      public Appointment Create()
      {
         throw new NotImplementedException();
      }
   
   }
}