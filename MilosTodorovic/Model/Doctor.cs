// File:    Doctor.cs
// Author:  Korisnik
// Created: Tuesday, April 5, 2022 3:58:46 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
public class Doctor
{
   private String ime;
   private String prezime;
   private String jmbg;
   private long doctorid;
   
   public Doctor()
   {
      
   }
   
   public Doctor(Doctor oldDoctor)
   {
      this.ime = oldDoctor.ime;
      this.prezime = oldDoctor.prezime;
      this.jmbg = oldDoctor.jmbg;
      this.doctorid = oldDoctor.doctorid;
   }
   
   public List<Termin> termini;
   
   /// <summary>
   /// Property for collection of Termin
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public List<Termin> Termini
   {
      get
      {
         if (termini == null)
            termini = new List<Termin>();
         return termini;
      }
      set
      {
         RemoveAllTermini();
         if (value != null)
         {
            foreach (Termin oTermin in value)
               AddTermini(oTermin);
         }
      }
   }

    public string Ime { get => ime; set => ime = value; }
    public string Prezime { get => prezime; set => prezime = value; }
    public string Jmbg { get => jmbg; set => jmbg = value; }
    public long Doctorid { get => doctorid; set => doctorid = value; }

    public long generateiddoktora()
    {


        return ++doctorid;


    }
    public void AddTermini(Termin newTermin)
   {
      if (newTermin == null)
         return;
      if (this.termini == null)
         this.termini = new List<Termin>();
      if (!this.termini.Contains(newTermin))
      {
         this.termini.Add(newTermin);
         newTermin.Doctor = this;
      }
   }
   
   /// <summary>
   /// Remove an existing Termin from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveTermini(Termin oldTermin)
   {
      if (oldTermin == null)
         return;
      if (this.termini != null)
         if (this.termini.Contains(oldTermin))
         {
            this.termini.Remove(oldTermin);
            oldTermin.Doctor = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of Termin from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllTermini()
   {
      if (termini != null)
      {
         System.Collections.ArrayList tmpTermini = new System.Collections.ArrayList();
         foreach (Termin oldTermin in termini)
            tmpTermini.Add(oldTermin);
         termini.Clear();
         foreach (Termin oldTermin in tmpTermini)
            oldTermin.Doctor = null;
         tmpTermini.Clear();
      }
   }

}