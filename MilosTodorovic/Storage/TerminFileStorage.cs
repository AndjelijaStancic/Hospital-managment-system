// File:    TerminFileStorage.cs
// Author:  Korisnik
// Created: Wednesday, April 6, 2022 3:11:39 PM
// Purpose: Definition of Class TerminFileStorage

using System;
using System.Collections.Generic;
using System.IO;

public class TerminFileStorage
{
    private String fileloc;
    private List<Termin> termini = new List<Termin>();
    List<Prostorija> slobodneprostorije = new List<Prostorija>();
    List<String> prostorije = new List<String>();
    List<String> lista23 = new List<String>();
    List<String> sale123 = new List<string>();






    List<String> zauzetesale = new List<String>();
    List<String> zauzetesale1 = new List<String>();
    public List<Prostorija> zauzete1 = new List<Prostorija>();
    
    
   
    public TerminFileStorage() { }
   
   public Termin save(Termin termin)
   {

       
        
        
        
            
           
                StreamReader srr = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
                String m;
                long idtermina = 0;
                while (srr.EndOfStream == false)
                {
                     m = srr.ReadLine();
                    String[] podaci = m.Split(';');
            if (long.Parse(podaci[1]) > idtermina)
                {
                idtermina = long.Parse(podaci[1]);
            }
                }

               long  idtermina1 = idtermina + 1;
                srr.Close();
                StreamWriter sr2 = new StreamWriter("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt", true);
                sr2.WriteLine(termin.doctor.Doctorid + ";" + idtermina1 + ";" + termin.pacijent.Idpacijenta + ";" + termin.Brojsale + ";" + termin.Vremepocetkatermina + ";" + termin.Vremekrajatermina + ";" + termin.Tiptermina, true);
                sr2.Close();


            
            termini.Clear();
        
        
        return termin;
    }
   

   
    public Termin izmenitermin(Termin termin)
    {


        Console.WriteLine(termin.Idtermina);

        StreamReader sr6 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        
        String str6;
        long idtermina = termin.Idtermina;
        lista23.Clear();
        while ((str6 = sr6.ReadLine()) != null)
        {
            lista23.Add(str6);




        }

        sr6.Close();


        int broj1 = 0;
        List<String> lista24 = new List<String>(lista23);
       
        foreach (String s in lista24)
        {
            String[] podaci = s.Split(';');
            if (long.Parse(podaci[1]) == idtermina)
            {
                lista23.RemoveAt(broj1);
            }
            broj1++;
        }
        Console.WriteLine(termin.Brojsale);
        String izmenjeni = termin.doctor.Doctorid + ";" + termin.Idtermina + ";" + termin.pacijent.Idpacijenta + ";" + termin.Brojsale + ";" + termin.Vremepocetkatermina + ";" + termin.Vremekrajatermina + ";" + termin.Tiptermina;
        lista23.Add(izmenjeni);
        Console.WriteLine(lista23[3]);

        StreamWriter sw = new StreamWriter("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        foreach (String s in lista23)
        {
            sw.WriteLine(s);
        }

        
        sw.Close();
        return termin;



    }


















    public Termin nadjitermin(long idtermina)
    {


        Termin termin = new Termin();


        StreamReader sr5 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        String str5;
        while ((str5 = sr5.ReadLine()) != null)
        {
            String[] podaci = str5.Split(';');

            if (idtermina == long.Parse(podaci[1]))
            {
               

                termin.Doctor = new Doctor();
                termin.Doctor.Doctorid = long.Parse(podaci[0]);
                termin.Idtermina = long.Parse(podaci[1]);
                termin.Pacijent = new Pacijent();
                termin.Pacijent.Idpacijenta = long.Parse(podaci[2]);
                termin.Brojsale = podaci[3];
                termin.Vremepocetkatermina = DateTime.Parse(podaci[4]);
                termin.Vremekrajatermina = DateTime.Parse(podaci[5]);
                if (podaci[6] == "pregled")
                {
                    termin.Tiptermina = Tiptermina.pregled;
                }
                else
                {
                    termin.Tiptermina = Tiptermina.operacija;
                }
               
            }

        }
        sr5.Close();
        return termin;








    }









   public List<Termin> FindByDoctorid(long doctorid)
   {
        List<Termin> svitermini = new List<Termin>();


        StreamReader sr4 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        String str;
        

        while ((str = sr4.ReadLine()) != null)
        {
            String[] podaci = str.Split(';');

            if (doctorid == long.Parse(podaci[0]))
            {
                Termin termin = new Termin();

                termin.Doctor = new Doctor();
                termin.Doctor.Doctorid = long.Parse(podaci[0]);
                termin.Idtermina = long.Parse(podaci[1]);
                termin.Pacijent = new Pacijent();
                termin.Pacijent.Idpacijenta = long.Parse(podaci[2]);
                termin.Brojsale = podaci[3];
                termin.Vremepocetkatermina = DateTime.Parse(podaci[4]);
                termin.Vremekrajatermina = DateTime.Parse(podaci[5]);
                if (podaci[6] == "pregled")
                {
                    termin.Tiptermina = Tiptermina.pregled;
                }
                else
                {
                    termin.Tiptermina = Tiptermina.operacija;
                }
                svitermini.Add(termin);
            }

        }
        sr4.Close();
        return svitermini;




    }
   
   public void DeleteByIdtermina(List<long> idtermina)
   {
       
        foreach(long terminidd in idtermina)
        {
            Console.WriteLine(terminidd);
        }
        StreamReader sr3 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        List<String> lista1 = new List<String>();
        String str;

        while((str = sr3.ReadLine())!= null)
        {
            lista1.Add(str);
            



        }

        sr3.Close();

        
        int broj1 = 0;
        List<int> zabrisanjeindeksi = new List<int>();
        foreach(String s in lista1)
        {
            String[] a3 = s.Split(';');
            foreach (long id in idtermina)
            {

               

                if (long.Parse(a3[1]) == id)
                {
                    zabrisanjeindeksi.Add(broj1);
                    Console.WriteLine(id);

                }
                


            }
            broj1++;
        }
        int a = zabrisanjeindeksi[0];
        Console.WriteLine(a);
        int i = 0;
        while(i<zabrisanjeindeksi.Count)
        {
            lista1.RemoveAt(a);
            i++;
        }



        
        //foreach(int i in zabrisanjeindeksi)
        //{
        //    Console.WriteLine(i);
        //    lista1.RemoveAt(i);
        //    i = i - 1;
        //}
        

        
        StreamWriter sw = new StreamWriter("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        foreach(String s in lista1)
        {
            sw.WriteLine(s);


        }


        sw.Close();

            


    }











    public List<String> pronadjiprostorije(DateTime vremepocetkatermina, long iddoktora)
    {
        prostorije.Clear();
       StreamReader sr1 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\prostorije.txt");
        String str1;
        while ((str1 = sr1.ReadLine()) != null)
        {
            String[] podaci1 = str1.Split(';');
            String a = podaci1[0];
            String b = podaci1[1];
            String c = podaci1[2];
            String d = podaci1[3];
            String e = podaci1[4];
            prostorije.Add(a);
            prostorije.Add(b);
            prostorije.Add(c);
            prostorije.Add(d);
            prostorije.Add(e);
        }
        sr1.Close();

            StreamReader sr7 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        String str7;





        while ((str7 = sr7.ReadLine()) != null)
        {

            String[] podaci = str7.Split(';');
            long doktorid = long.Parse(podaci[0]);


            DateTime vremepocetka32 = DateTime.Parse(podaci[4]);
            if (iddoktora == doktorid && vremepocetkatermina == vremepocetka32)
            {
                return null;
            }

            else if (vremepocetkatermina == vremepocetka32)
            {
                zauzetesale.Add(podaci[3]);

                Prostorija pr = new Prostorija(long.Parse(podaci[3]));

                zauzete1.Add(pr);

            }

            else
            {
                Prostorija prostorija = new Prostorija();


            }


        }
        foreach(String a in prostorije)
        {
            Console.WriteLine("Prostorija:" + a);
        }

        foreach(String a in zauzetesale)
        {
            Console.WriteLine("Zauzeta prostorija:" + a);
        }


        List<String> prostorije123 = new List<String>(prostorije);
            foreach (String a in prostorije123)
            {
                foreach (String b in zauzetesale)
                {

                    if (a == b)
                    {
                    Console.WriteLine("Usao u if");
                        prostorije.Remove(a);
                    }
                }
            }
            foreach(String a in prostorije)
        {
            Console.WriteLine("Vracenaprostorija:" + a);
        }

            sr7.Close();
            return prostorije;

        }



    public List<String> pronadjisalezaoperaciju(DateTime vremepocetkatermina,DateTime vremekrajatermina, long iddoktora)
    {
        Console.WriteLine(iddoktora);
        sale123.Clear();
        StreamReader sr7 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\sale.txt");
        String str7;
        while ((str7 = sr7.ReadLine()) != null)
        {
            String[] podaci1 = str7.Split(';');
            String a = podaci1[0];
            String b = podaci1[1];
            String c = podaci1[2];
            String d = podaci1[3];
            String e = podaci1[4];
            sale123.Add(a);
            sale123.Add(b);
            sale123.Add(c);
            sale123.Add(d);
            sale123.Add(e);
        }
        sr7.Close();

        StreamReader sr8 = new StreamReader("C:\\Users\\Korisnik\\Desktop\\SIMSWPF\\SIMSWPF\\termini.txt");
        String str8;





        while ((str8 = sr8.ReadLine()) != null)
        {

            String[] podaci = str8.Split(';');
            long doktorid = long.Parse(podaci[0]);


            DateTime vremepocetka32 = DateTime.Parse(podaci[4]);
            DateTime vremekraja32 = DateTime.Parse(podaci[5]);
            if (iddoktora == doktorid && vremepocetkatermina <= vremekraja32 && vremekrajatermina >= vremepocetka32 )
            {
                return null;
            }

            else if (vremepocetkatermina <= vremekraja32 && vremekrajatermina >= vremepocetka32)
            {
                zauzetesale1.Add(podaci[3]);

               

            }

            else
            {
                Prostorija prostorija = new Prostorija();


            }


        }





        List<String> sale144 = new List<String>(sale123);
        foreach(String a in sale144)
        { 
            
            foreach (String b in zauzetesale1)
            {

                if (a == b)
                {
                    sale123.Remove(a);
                }
            }
        }

       

        sr8.Close();
        return sale123;











    }





}