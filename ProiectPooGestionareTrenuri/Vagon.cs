namespace ProiectPooGestionareTrenuri;

public enum TipLoc
{
    Clasa1,
    Clasa2,
    Compartiment,
    VagonRestaurant
}
public class Vagon
{
    public TipLoc TipVagon { get; set; }
    public int NumarLocuriDisponibile { get; set; }

    public Vagon(TipLoc tipVagon, int locuri)
    {
        TipVagon = tipVagon;
        NumarLocuriDisponibile = locuri;
    }
}