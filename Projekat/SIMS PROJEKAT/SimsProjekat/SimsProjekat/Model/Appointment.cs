// File:    Appointment.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 3:55:13 PM
// Purpose: Definition of Class Appointment

using System;

namespace Model
{
   public class Appointment
   {
        public int Id { get; set; }
        public DateTime Beggining { get; set; }
        public DateTime Ending { get; set; }
        public Boolean Urgent { get; set; }

        //public Patient patient;
        //public Guest guest;
        //public Doctor doctor;
        //public Room room;

        public Appointment(int id, DateTime beggining, DateTime ending, Boolean urgent)
        {
            Id = id;
            Beggining = beggining;
            Ending = ending;
            Urgent = urgent;
        }

        public Appointment(int id, DateTime beggining, DateTime ending)
        {
            Id = id;
            Beggining = beggining;
            Ending = ending;

        }


    }
}