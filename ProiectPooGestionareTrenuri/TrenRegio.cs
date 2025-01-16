namespace ProiectPooGestionareTrenuri;


public abstract class TrenRegio :Pret
{
    public override double CalculeazaPret(double pretBaza)
    {
        return pretBaza * 0.8; // Reducere de 20%
    }
}