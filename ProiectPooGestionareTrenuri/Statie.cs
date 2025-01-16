namespace ProiectPooGestionareTrenuri;

public class Statie
{
    public string NumeStatie { get; set; }
    public TimeSpan TimpDeStop { get; set; }

    public Statie(string nume, TimeSpan timp)
    {
        NumeStatie = nume;
        TimpDeStop = timp;
    }
}