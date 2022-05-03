// File:    AppointmentRepository2.cs
// Author:  Djole
// Created: Tuesday, April 12, 2022 4:04:42 PM
// Purpose: Definition of Class AppointmentRepository2

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public string ConvertCsv(Appointment appointment)
        {
            return string.Join(Delimiter,
                appointment.Id,
                appointment.Beggining,
                appointment.Ending);

        }

        public Appointment ConvertAppointment(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int Id = int.Parse(tokens[0]);
            DateTime Beggining = DateTime.Parse(tokens[1]);
            DateTime Ending = DateTime.Parse(tokens[2]);
            return new Appointment(Id, Beggining, Ending);
        }

        public List<Appointment> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertAppointment).ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            List<Appointment> appointments = GetAll().ToList();
            List<string> updated = new List<string>();
            foreach (Appointment appointment1 in appointments)
            {
                if (appointment1.Id == appointment.Id)
                {
                    appointment1.Beggining = appointment.Beggining;
                    appointment1.Ending = appointment.Ending;
                }
                updated.Add(ConvertCsv(appointment1));
            }
            File.WriteAllLines(Path, updated);
            return appointment;
        }

        public bool Delete(int id)
        {
            List<Appointment> appointments = GetAll().ToList();
            bool delete = false;
            List<string> updated = new List<string>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id != id)
                {
                    delete = true;
                    updated.Add(ConvertCsv(appointment));

                }
            }
            File.WriteAllLines(Path, updated);
            return delete;
        }

        protected int NewId(List<Appointment> appointments)
        {
            int id = 0;
            List<Appointment> appointments1 = GetAll().ToList();
            foreach (Appointment appointment in appointments1)
            {
                if (appointment.Id > id)
                {
                    id = appointment.Id;
                }
            }
            return id;
        }

        public Appointment Create(Appointment appointment)
        {
            List<Appointment> appointments = GetAll().ToList();
            int id = (NewId(appointments));
            appointment.Id = ++id;
            File.AppendAllText(Path, ConvertCsv(appointment) + Environment.NewLine);
            return appointment;
        }

    }
}