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
}