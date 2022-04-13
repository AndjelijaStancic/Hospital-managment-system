// File:    Termin.cs
// Author:  Korisnik
// Created: Monday, April 4, 2022 5:12:55 PM
// Purpose: Definition of Class Termin

using System;
using System.ComponentModel;

public class Termin : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    private String brojsale;
    private DateTime vremepocetkatermina;
    private long idtermina;
    private DateTime vremekrajatermina;
    private Tiptermina tiptermina;
    private bool IsChecked;

    

    public Termin()
    {

    }

    public Termin(Termin oldTermin)
    {
        this.brojsale = oldTermin.brojsale;
        this.vremepocetkatermina = oldTermin.vremepocetkatermina;
        this.idtermina = oldTermin.idtermina;
        this.vremekrajatermina = oldTermin.vremekrajatermina;
        this.tiptermina = oldTermin.tiptermina;
    }

    public Doctor doctor;

    public long generateterminid()
    {
        return ++idtermina;

    }
    public Doctor Doctor
    {
        get
        {
            return doctor;
        }
        set
        {
            if (this.doctor == null || !this.doctor.Equals(value))
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveTermini(this);
                }
                if (value != null)
                {
                    this.doctor = value;
                    this.doctor.AddTermini(this);
                }
            }
        }
    }
    public Pacijent pacijent;

    /// <summary>
    /// Property for Pacijent
    /// </summary>
    /// <pdGenerated>Default opposite class property</pdGenerated>
    public Pacijent Pacijent
    {
        get
        {
            return pacijent;
        }
        set
        {
            if (this.pacijent == null || !this.pacijent.Equals(value))
            {
                if (this.pacijent != null)
                {
                    Pacijent oldPacijent = this.pacijent;
                    this.pacijent = null;
                    oldPacijent.RemoveTermini(this);
                }
                if (value != null)
                {
                    this.pacijent = value;
                    this.pacijent.AddTermini(this);
                }
            }
        }
    }


    public DateTime Vremepocetkatermina { get => vremepocetkatermina; set => vremepocetkatermina = value; }
    public long Idtermina { get => idtermina; set => idtermina = value; }
    public DateTime Vremekrajatermina { get => vremekrajatermina; set => vremekrajatermina = value; }
    public Tiptermina Tiptermina { get => tiptermina; set => tiptermina = value; }
    

    public bool IsChecked1 { get => IsChecked; set => IsChecked = value; }
    
    public string Brojsale { get => brojsale; set => brojsale = value; }
}