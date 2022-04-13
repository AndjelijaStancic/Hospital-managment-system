// File:    AppointmentController.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 4:02:56 PM
// Purpose: Definition of Class AppointmentController

using Model;
using System;
using Service;
using System.Collections.Generic;
namespace Controller
{
    public class AppointmentController
    {
        private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService service)
    {
        _appointmentService = service;
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
      
      public Service.AppointmentService appointmentService;
   
   }
}