namespace ProiectPooGestionareTrenuri;

public abstract class TrenInterRegio :Pret
{
    public double TaxaCompartimentPrivat { get; set; } = 50.0;

    public override double CalculeazaPret(double pretBaza)
    {
        return pretBaza; // Fără reducere
    }
}