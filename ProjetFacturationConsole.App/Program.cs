namespace ProjetFacturationConsole.App;

class Program
{
    static void Main(string[] args)
    {
        // Test de chaque classe
        Client client = new Client();
        client.SetNom("test");

        Entreprise entreprise = new Entreprise();
        entreprise.SetNom("Amazon");

        LigneFacture ligne = new LigneFacture();
        ligne.SetDescription("Produit 1");
        ligne.SetQuantite(2);

        Facture facture = new Facture();
        facture.SetNumero("001");
        facture.SetClient(client);
        facture.SetEntreprise(entreprise);

        GestionFacturation gestion = new GestionFacturation();
        gestion.GetClients().Add(client);

        Console.WriteLine(client.GetNom());
        Console.WriteLine(entreprise.GetNom());
        Console.WriteLine(ligne.GetDescription());
        Console.WriteLine(facture.GetNumero());
        Console.WriteLine(gestion.GetClients().Count);
    }
}
