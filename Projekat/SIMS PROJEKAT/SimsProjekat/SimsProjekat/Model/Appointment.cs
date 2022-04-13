// File:    Appointment.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 3:55:13 PM
// Purpose: Definition of Class Appointment

using System;

namespace Model
{
   public class Appointment
   {
      private int id;
      private DateTime beggining;
      private DateTime ending;
      private Boolean urgent;
      
      public Patient patient;
      public Guest guest;
      public Doctor doctor;
      public Room room;
   
   }
}