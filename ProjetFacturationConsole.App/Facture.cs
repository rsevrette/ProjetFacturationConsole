using System.Text;
public class Facture : DocumentCommercial
{
    private DateTime dateEcheance;
    private string statut;

    public Facture() : base() { }

    public Facture(string numero, DateTime dateEmission, Client client, Entreprise entreprise,DateTime dateEcheance, string statut)
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
        if (lignes.Count < 2)
            throw new Exception("Une facture doit contenir au moins deux lignes");

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("FACTURE");
        sb.AppendLine($"Numéro : {numero}");
        sb.AppendLine($"Date d'émission : {dateEmission:dd/MM/yyyy}");
        sb.AppendLine($"Date d'échéance : {dateEcheance:dd/MM/yyyy}");
        sb.AppendLine($"Statut : {statut}");

        sb.AppendLine("Entreprise :");
        sb.AppendLine($"{entreprise.GetId()} - {entreprise.GetNom()} - {entreprise.GetEmail()} - {entreprise.GetTelephone()} - {entreprise.GetAdresse()} - {entreprise.GetVille()} - {entreprise.GetCodePostal()} - {entreprise.GetSiret()}");

        sb.AppendLine("Client :");
        sb.AppendLine($"{client.GetId()} - {client.GetNom()} - {client.GetEmail()} - {client.GetTelephone()} - {client.GetAdresse()} - {client.GetVille()} - {client.GetCodePostal()} - {client.GetDateInscription():dd/MM/yyyy}");

        sb.AppendLine("Lignes :");

        int i = 1;
        foreach (var ligne in lignes)
        {
            sb.AppendLine($"{i}. {ligne.GetDescription()} - Qté : {ligne.GetQuantite()} - PU HT : {ligne.GetPrixUnitaireHt()} - TVA : {ligne.GetTauxTva()} - Total HT : {ligne.CalculerTotalHT()} - Total TTC : {ligne.CalculerTotalTTC()}");
            i++;
        }

        sb.AppendLine($"Total HT : {CalculerTotalHT()}");
        sb.AppendLine($"Total TVA : {CalculerTotalTVA()}");
        sb.AppendLine($"Total TTC : {CalculerTotalTTC()}");

        Console.WriteLine(sb.ToString());
    }

    public void SetDateEmission(DateTime value)
    {
        dateEmission = value;
        dateEcheance = value.AddDays(30);
    }
}