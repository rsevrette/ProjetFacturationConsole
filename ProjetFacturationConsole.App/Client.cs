public class Client : Personne
{
    private DateTime dateInscription;

    public Client() : base() { }

    public Client(int id, string nom, string email, string telephone,
                  string adresse, string ville, string codePostal,
                  DateTime dateInscription)
        : base(id, nom, email, telephone, adresse, ville, codePostal)
    {
        this.dateInscription = dateInscription;
    }

    public DateTime GetDateInscription() { return dateInscription; }
    public void SetDateInscription(DateTime value) { dateInscription = value; }

    public override void AfficherInfos()
    {
        Console.WriteLine($"{id} - {nom} - {email} - {telephone} - {adresse} - {ville} - {codePostal} - {dateInscription:dd/MM/yyyy}");
    }
}