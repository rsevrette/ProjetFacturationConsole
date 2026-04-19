namespace ProjetFacturationConsole.App;

class Program
{
    static void Main(string[] args)
    {
        // Test de chaque classe  (Etape 2)
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

        // Test des methodes  (Etape 3)
        Client c = new Client(2, "Paul", "paul@mail.fr", "0611223344", "12 rue ..", "Amiens", "80000", DateTime.Parse("12/03/2024"));
        Entreprise e = new Entreprise(1, "TechNova", "contact@technova.fr", "0322000001","25 rue ..", "Amiens", "80000", "12345678900011");

        LigneFacture l1 = new LigneFacture("Développement ", 2, 150, 20);
        LigneFacture l2 = new LigneFacture("Maintenance", 1, 80, 10);

        Facture f = new Facture();
        f.SetNumero("2026-001");
        f.SetClient(c);
        f.SetEntreprise(e);
        f.SetDateEmission(DateTime.Parse("15/05/2026"));
        f.SetStatut("Brouillon");

        f.AjouterLigne(l1);
        f.AjouterLigne(l2);

        Console.WriteLine("__________Facture________");
        f.AfficherFacture();

        // Test Importer les données depuis les CSV et générer les JSON  (Etape 4)
        GestionFacturation g = new GestionFacturation();
        g.ImporterClientsDepuisCsv();
        g.ImporterEntreprisesDepuisCsv();
        Console.WriteLine(g.GetClients().Count);
        Console.WriteLine(g.GetEntreprises().Count);

        //Test charger et afficher les donnees depuis le JSON  (Etape 5)
        Console.WriteLine("--- Clients ---");
        g.AfficherClients();
        Console.WriteLine("--- Entreprises ---");
        g.AfficherEntreprises();

        //etape 6
        g.ImporterClientsDepuisCsv();
        g.ImporterEntreprisesDepuisCsv();

        Client c6 = g.GetDictionnaireClients()[1];
        Entreprise e6 = g.GetDictionnaireEntreprises()[1];

        Facture f6 = new Facture("F2026-001", DateTime.Parse("15/04/2026"), c6, e6, DateTime.Parse("15/05/2026"), "Brouillon");
        f6.AjouterLigne(new LigneFacture("Développement", 2, 150, 20));
        f6.AjouterLigne(new LigneFacture("Maintenance", 1, 80, 10));

        f6.AfficherFacture();
        g.GenererFichierTexteFacture(f6);
    }
}
