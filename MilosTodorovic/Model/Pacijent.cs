// File:    Pacijent.cs
// Author:  Korisnik
// Created: Wednesday, April 6, 2022 2:36:43 PM
// Purpose: Definition of Class Pacijent

using System;
using System.Collections.Generic;
public class Pacijent
{
    private String ime;
    private String prezime;
    private long idpacijenta = 0;

    public Pacijent()
    {
       
    }

    public Pacijent(Pacijent oldPacijent)
    {
        this.ime = oldPacijent.ime;
        this.prezime = oldPacijent.prezime;
        this.idpacijenta = oldPacijent.idpacijenta;
    }

    public List<Termin> termini;


    public long generateidpacijenta(){


        return ++idpacijenta;


        }









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

    
    public long Idpacijenta { get => idpacijenta; set => idpacijenta = value; }
    public string Ime { get => ime; set => ime = value; }
    public string Prezime { get => prezime; set => prezime = value; }
    

    /// <summary>
    /// Add a new Termin in the collection
    /// </summary>
    /// <pdGenerated>Default Add</pdGenerated>
    public void AddTermini(Termin newTermin)
   {
      if (newTermin == null)
         return;
      if (this.termini == null)
         this.termini = new List<Termin>();
      if (!this.termini.Contains(newTermin))
      {
         this.termini.Add(newTermin);
         newTermin.Pacijent = this;
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
            oldTermin.Pacijent = null;
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
            oldTermin.Pacijent = null;
         tmpTermini.Clear();
      }
   }

}