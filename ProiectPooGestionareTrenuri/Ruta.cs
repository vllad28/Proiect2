namespace ProiectPooGestionareTrenuri;

public class Ruta
{
    public string IdRuta { get; set; }
    public string NumeRuta { get; set; }
    public List<Statie> Statii { get; set; }
    public TimeSpan DurataTotala { get; set; }
    public decimal PretClasa1 { get; set; }
    public decimal PretClasa2 { get; set; }
    public decimal PretCompartiment { get; set; }
    public decimal PretVagonRestaurant { get; set; }
    public Tren Tren { get; set; }
    public TimeSpan Intarziere { get; set; }

    public Ruta(string idRuta, string numeRuta, Tren tren)
    {
        IdRuta = idRuta;
        NumeRuta = numeRuta;
        Tren = tren;
        Statii = new List<Statie>();
        Intarziere = TimeSpan.Zero;
    }
}

