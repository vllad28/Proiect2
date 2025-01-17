namespace ProiectPooGestionareTrenuri;
public enum TipTren
{
    Regio,
    InterRegio,
    Express
}

public   class Tren
{
    public string Id { get; set; }
    public int NumarTren { get; set; }
    public TipTren Tip { get; set; }
    public int Capacitate { get; set; }
    public List<Vagon> Vagoane { get; set; }

    public Tren(string id, int numar, TipTren tip, int capacitate)
    {
        Id = id;
        NumarTren = numar;
        Tip = tip;
        Capacitate = capacitate;
        Vagoane = new List<Vagon>();

    }



    public void AdaugareVagon(Vagon vagon)
    {
        Vagoane.Add(vagon);
    }
}
