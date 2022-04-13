// File:    TerminServiceImpl.cs
// Author:  Korisnik
// Created: Monday, April 4, 2022 6:32:37 PM
// Purpose: Definition of Class TerminServiceImpl

using System;
using System.Collections.Generic;
public class TerminServiceImpl 
{
    private TerminFileStorage tfs = new TerminFileStorage();
   
   


    public TerminServiceImpl() { }
   
   public Termin createtermin(Termin termin)
   {
        Termin termin1 = tfs.save(termin);
        return termin1;
   }
   
   public List<Termin> findallbydoctorid(long doctorid)
   {
       List<Termin> termini1 =  tfs.FindByDoctorid(doctorid);
        return termini1;
   }
   
   public Termin izmenitermin(Termin termin)
   {
        tfs.izmenitermin(termin);
        return termin;
   }
   
   public void izbrisitermine(List<long> idtermina)
   {
        tfs.DeleteByIdtermina(idtermina);
   }

    public Termin nadjitermin(long idtermina)
    {
        Termin termin = tfs.nadjitermin(idtermina);
        return termin;

    }
    





    public List<String> pronadjiprostorije(DateTime vremepocetkatermina1, long iddoktora)
    {

        List<String> slobodneprostorije = tfs.pronadjiprostorije(vremepocetkatermina1, iddoktora);

        return slobodneprostorije;






    }


    public List<String> pronadjisalezaoperaciju(DateTime vremepocetkatermina,DateTime vremekrajatermina, long iddoktora)
    {
        List<String> salezaoperaciju = tfs.pronadjisalezaoperaciju(vremepocetkatermina, vremekrajatermina, iddoktora);
        return salezaoperaciju;

    }











}