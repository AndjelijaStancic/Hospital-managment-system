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

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }
        public List<Appointment> ShowAppointments(int userId)
        {
            throw new NotImplementedException();
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public Appointment Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            return _appointmentRepository.Delete(appointmentId);
        }


    }
}