public class Facture : DocumentCommercial
{
    private DateTime dateEcheance;
    private string statut;

    public Facture() : base() { }

    public Facture(string numero, DateTime dateEmission, Client client, Entreprise entreprise,
                   DateTime dateEcheance, string statut)
        : base(numero, dateEmission, client, entreprise)
    {
        this.dateEcheance = dateEcheance;
        this.statut = statut;
    }

    public DateTime GetDateEcheance() { return dateEcheance; }
    public void SetDateEcheance(DateTime value) { dateEcheance = value; }

    public string GetStatut() { return statut; }
    public void SetStatut(string value) { statut = value; }

    public override void AfficherFacture()
    {
        // vide
    }
}