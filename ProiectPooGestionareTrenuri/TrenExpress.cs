namespace ProiectPooGestionareTrenuri;

public abstract class TrenExpress :Pret
{

    public double TaxaServiciuMasa { get; set; } = 75.0;

    public override double CalculeazaPret(double pretBaza)
    {
        return pretBaza; // Fără reducere
    }

}