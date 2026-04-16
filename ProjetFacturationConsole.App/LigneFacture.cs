public class LigneFacture
{
    private string description;
    private int quantite;
    private decimal prixUnitaireHt;
    private decimal tauxTva;

    public LigneFacture() { }

    public LigneFacture(string description, int quantite, decimal prixUnitaireHt, decimal tauxTva)
    {
        this.description = description;
        this.quantite = quantite;
        this.prixUnitaireHt = prixUnitaireHt;
        this.tauxTva = tauxTva;
    }

    public string GetDescription() { return description; }
    public void SetDescription(string value) { description = value; }

    public int GetQuantite() { return quantite; }
    public void SetQuantite(int value) { quantite = value; }

    public decimal GetPrixUnitaireHt() { return prixUnitaireHt; }
    public void SetPrixUnitaireHt(decimal value) { prixUnitaireHt = value; }

    public decimal GetTauxTva() { return tauxTva; }
    public void SetTauxTva(decimal value) { tauxTva = value; }

    public decimal CalculerTotalHT()
    {
        if (quantite <= 0)
            throw new Exception("Quantité invalide");

        if (prixUnitaireHt < 0)
            throw new Exception("Prix invalide");

        return quantite * prixUnitaireHt;
    }

    public decimal CalculerMontantTVA()
    {
        return CalculerTotalHT() * (tauxTva / 100);
    }

    public decimal CalculerTotalTTC()
    {
        return CalculerTotalHT() + CalculerMontantTVA();
    }
}