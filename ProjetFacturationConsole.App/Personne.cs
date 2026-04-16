public abstract class Personne
{
    public int id { get; set; }
    public string nom { get; set; }
    public string email { get; set; }
    public string telephone { get; set; }
    public string adresse { get; set; }
    public string ville { get; set; }
    public string codePostal { get; set; }

    public Personne() { }

    public Personne(int id, string nom, string email, string telephone,string adresse, string ville, string codePostal)
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