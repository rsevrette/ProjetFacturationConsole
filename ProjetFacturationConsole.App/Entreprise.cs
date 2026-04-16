public class Entreprise : Personne
{
    private string siret;

    public Entreprise() : base() { }

    public Entreprise(int id, string nom, string email, string telephone,
                      string adresse, string ville, string codePostal,
                      string siret)
        : base(id, nom, email, telephone, adresse, ville, codePostal)
    {
        this.siret = siret;
    }

    public string GetSiret() { return siret; }
    public void SetSiret(string value) { siret = value; }

    public override void AfficherInfos()
    {
    }
}