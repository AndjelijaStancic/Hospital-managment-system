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

        public List<Appointment> GetAll()
        {
            return _appointmentService.GetAll();
        }

        public Appointment AddAppointment(Appointment newAppointment)
        {
            return _appointmentService.AddAppointment(newAppointment);
        }

        public Appointment ChangeAppointment(Appointment appointment)
        {
            return _appointmentService.Update(appointment);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            return _appointmentService.DeleteAppointment(appointmentId);
        }

        public Service.AppointmentService appointmentService;
   
   }
}