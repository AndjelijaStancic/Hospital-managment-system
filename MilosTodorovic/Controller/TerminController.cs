// File:    TerminController.cs
// Author:  Korisnik
// Created: Monday, April 4, 2022 6:01:28 PM
// Purpose: Definition of Class TerminController

using System;
using System.Collections.Generic;

public class TerminController
{

    TerminServiceImpl terminService1 = new TerminServiceImpl();
    

public TerminController()
{
        

}

    

    public Termin createtermin(Termin termin)
   {

        Termin termin1 = new Termin();
         termin1 = terminService1.createtermin(termin);
        return termin1;
        
   }
   
   public List<Termin> nadjisvetermine(long iddoktora)
   {
        List<Termin> termini1 = terminService1.findallbydoctorid(iddoktora);
        return termini1;
   }



    public Termin nadjitermin(long idtermina)
    {
        Termin termin = terminService1.nadjitermin(idtermina);
        return termin;
    }

    public Termin izmenitermin(Termin termin)
   {

        terminService1.izmenitermin(termin);
        return termin;


   }
   
   public void izbrisitermine(List<Termin> termini)
   {
        List <long> idterminazabrisanje = new List<long>();

        foreach(Termin tr in termini)
        {
            idterminazabrisanje.Add(tr.Idtermina);
        }
        terminService1.izbrisitermine(idterminazabrisanje);

   }





    public List<String> pronadjiprostorije(DateTime vremepocetkatermina1, long iddoktora)
    {
        List<String> slobodneprostorije = terminService1.pronadjiprostorije(vremepocetkatermina1, iddoktora);


        return slobodneprostorije;




    }

    public List<String> pronadjisalezaoperaciju(DateTime vremepocetkatermina, DateTime vremekrajatermina, long iddoktora)
    {
       List<String> salezaoperaciju = terminService1.pronadjisalezaoperaciju(vremepocetkatermina, vremekrajatermina, iddoktora);
        return salezaoperaciju;
    }

    




}