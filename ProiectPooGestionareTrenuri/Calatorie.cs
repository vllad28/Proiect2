namespace ProiectPooGestionareTrenuri;

public class Calatorie
{
    public Ruta Ruta { get; set; }
    public int LocuriRezervate { get; set; }
    public TipLoc TipLoc { get; set; }
    public DateTime DataPlecare { get; set; }
    public bool Anulata { get; set; }
    public List<Calatorie> IstoricCalatorii { get; set; }

    public Calatorie(Ruta ruta, int locuri, TipLoc tipLoc, DateTime dataPlecare)
    {
        Ruta = ruta;
        LocuriRezervate = locuri;
        TipLoc = tipLoc;
        DataPlecare = dataPlecare;
        Anulata = false;
        IstoricCalatorii = new List<Calatorie>();
    }
    
    public void AdaugareCalatorie(Calatorie calatorie)
    {
        IstoricCalatorii.Add(calatorie);
    }

    public void AnulareCalatorie(Calatorie calatorie)
    {
        if (calatorie.DataPlecare > DateTime.Now.AddDays(1))
        {
            calatorie.Anulata = true;
        }
    }
}