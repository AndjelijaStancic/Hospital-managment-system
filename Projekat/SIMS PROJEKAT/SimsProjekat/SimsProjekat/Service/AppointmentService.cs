// File:    AppointmentService.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 4:03:48 PM
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class AppointmentService
   {

        public readonly AppointmentRepository _appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<Appointment> ShowAppointments(int userId)
      {
         throw new NotImplementedException();
      }
      
      public Appointment AddAppointment(Appointment newAppointment)
      {
         throw new NotImplementedException();
      }
      
      public Appointment ChangeAppointment(Appointment movedAppointment, int oldAppointmentId)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public Repository.AppointmentRepository appointmentRepository2;
   
   }
}