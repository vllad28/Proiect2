namespace ProiectPooGestionareTrenuri;

public abstract class Pret
{
    public abstract double CalculeazaPret(double pretBaza);
}
TrenRegio:
namespace ConsoleApp4;

public abstract class TrenRegio :Pret
{
    public override double CalculeazaPret(double pretBaza)
    {
        return pretBaza * 0.8; // Reducere de 20%
    }
}