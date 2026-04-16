public abstract class DocumentCommercial
{
    protected string numero;
    protected DateTime dateEmission;
    protected Client client;
    protected Entreprise entreprise;
    protected List<LigneFacture> lignes;

    public DocumentCommercial()
    {
        lignes = new List<LigneFacture>();
    }

    public DocumentCommercial(string numero, DateTime dateEmission, Client client, Entreprise entreprise)
    {
        this.numero = numero;
        this.dateEmission = dateEmission;
        this.client = client;
        this.entreprise = entreprise;
        this.lignes = new List<LigneFacture>();
    }

    public string GetNumero() { return numero; }
    public void SetNumero(string value) { numero = value; }

    public DateTime GetDateEmission() { return dateEmission; }
    public void SetDateEmission(DateTime value) { dateEmission = value; }

    public Client GetClient() { return client; }
    public void SetClient(Client value) { client = value; }

    public Entreprise GetEntreprise() { return entreprise; }
    public void SetEntreprise(Entreprise value) { entreprise = value; }

    public List<LigneFacture> GetLignes() { return lignes; }
    public void SetLignes(List<LigneFacture> value) { lignes = value; }

    public abstract void AfficherFacture();

    public void AjouterLigne(LigneFacture ligne)
    {
        lignes.Add(ligne);
    }

    public decimal CalculerTotalHT()
    {
        decimal total = 0;

        foreach (var ligne in lignes)
        {
            total += ligne.CalculerTotalHT();
        }

        return total;
    }

    public decimal CalculerTotalTVA()
    {
        decimal total = 0;

        foreach (var ligne in lignes)
        {
            total += ligne.CalculerMontantTVA();
        }

        return total;
    }

    public decimal CalculerTotalTTC()
    {
        decimal total = 0;

        foreach (var ligne in lignes)
        {
            total += ligne.CalculerTotalTTC();
        }

        return total;
    }
}