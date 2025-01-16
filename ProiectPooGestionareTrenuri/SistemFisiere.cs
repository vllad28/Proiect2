namespace ProiectPooGestionareTrenuri;

using Newtonsoft.Json;

public class SistemFisiere
{
    private const string FisierUtilizatori = "utilizatori.json";
    private const string FisierRute = "rute.json";

    public static void SalveazaUtilizatori(List<Utilizator> utilizatori)
    {
        string json = JsonConvert.SerializeObject(utilizatori, Formatting.Indented);
        File.WriteAllText(FisierUtilizatori, json);
    }

    public static List<Utilizator> IncarcaUtilizatori()
    {
        if (File.Exists(FisierUtilizatori))
        {
            string json = File.ReadAllText(FisierUtilizatori);
            return JsonConvert.DeserializeObject<List<Utilizator>>(json) ?? new List<Utilizator>();
        }
        return new List<Utilizator>();
    }

    public static void SalveazaRute(List<Ruta> rute)
    {
        string json = JsonConvert.SerializeObject(rute, Formatting.Indented);
        File.WriteAllText(FisierRute, json);
    }

    public static List<Ruta> IncarcaRute()
    {
        if (File.Exists(FisierRute))
        {
            string json = File.ReadAllText(FisierRute);
            return JsonConvert.DeserializeObject<List<Ruta>>(json) ?? new List<Ruta>();
        }
        return new List<Ruta>();
    }
}