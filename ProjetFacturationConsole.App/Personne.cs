public abstract class Personne
{
    protected int id;
    protected string nom;
    protected string email;
    protected string telephone;
    protected string adresse;
    protected string ville;
    protected string codePostal;

    public Personne() { }

    public Personne(int id, string nom, string email, string telephone,
                    string adresse, string ville, string codePostal)
    {
        this.id = id;
        this.nom = nom;
        this.email = email;
        this.telephone = telephone;
        this.adresse = adresse;
        this.ville = ville;
        this.codePostal = codePostal;
    }

    public int GetId() { return id; }
    public void SetId(int value) { id = value; }

    public string GetNom() { return nom; }
    public void SetNom(string value) { nom = value; }

    public string GetEmail() { return email; }
    public void SetEmail(string value) { email = value; }

    public string GetTelephone() { return telephone; }
    public void SetTelephone(string value) { telephone = value; }

    public string GetAdresse() { return adresse; }
    public void SetAdresse(string value) { adresse = value; }

    public string GetVille() { return ville; }
    public void SetVille(string value) { ville = value; }

    public string GetCodePostal() { return codePostal; }
    public void SetCodePostal(string value) { codePostal = value; }

    public abstract void AfficherInfos();
}