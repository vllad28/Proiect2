namespace ProiectPooGestionareTrenuri;
public enum TipUtilizator
{
    Administrator,
    Pasager
}

public class Utilizator
    {
        public string Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public TipUtilizator Tip { get; set; }
        public List<Calatorie> IstoricCalatorii { get; set; }

        public Utilizator(string id, string nume, string email, TipUtilizator tip)
        {
            Id = id;
            Nume = nume;
            Email = email;
            Tip = tip;
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