using System.Text;
public class GestionFacturation
{
    private List<Client> clients;
    private List<Entreprise> entreprises;
    private Dictionary<int, Client> dictionnaireClients;
    private Dictionary<int, Entreprise> dictionnaireEntreprises;

    public GestionFacturation()
    {
        clients = new List<Client>();
        entreprises = new List<Entreprise>();
        dictionnaireClients = new Dictionary<int, Client>();
        dictionnaireEntreprises = new Dictionary<int, Entreprise>();
    }

    public List<Client> GetClients() { return clients; }
    public void SetClients(List<Client> value) { clients = value; }

    public List<Entreprise> GetEntreprises() { return entreprises; }
    public void SetEntreprises(List<Entreprise> value) { entreprises = value; }

    public Dictionary<int, Client> GetDictionnaireClients() { return dictionnaireClients; }
    public void SetDictionnaireClients(Dictionary<int, Client> value) { dictionnaireClients = value; }

    public Dictionary<int, Entreprise> GetDictionnaireEntreprises() { return dictionnaireEntreprises; }
    public void SetDictionnaireEntreprises(Dictionary<int, Entreprise> value) { dictionnaireEntreprises = value; }

    public void ImporterClientsDepuisCsv()
    {
        try
        {
            clients.Clear();
            dictionnaireClients.Clear();

            string[] lignesFichier = File.ReadAllLines("clients.csv");

            for (int i = 1; i < lignesFichier.Length; i++)
            {
                string ligne = lignesFichier[i];

                if (string.IsNullOrWhiteSpace(ligne))
                    continue;

                string[] colonnes = ligne.Split(';');

                int id = int.Parse(colonnes[0]);
                string nom = colonnes[1];
                string email = colonnes[2];
                string telephone = colonnes[3];
                string adresse = colonnes[4];
                string ville = colonnes[5];
                string codePostal = colonnes[6];
                DateTime dateInscription = DateTime.Parse(colonnes[7]);

                if (dateInscription > DateTime.Now)
                    throw new Exception("Date d'inscription invalide");

                Client client = new Client(id, nom, email, telephone, adresse, ville, codePostal, dateInscription);

                clients.Add(client);
                dictionnaireClients.Add(id, client);
            }

            string json = System.Text.Json.JsonSerializer.Serialize(
                clients,
                new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("clients.json", json);

            Console.WriteLine("Clients importés avec succès !");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }

    public void ImporterEntreprisesDepuisCsv()
    {
        try
        {
            entreprises.Clear();
            dictionnaireEntreprises.Clear();

            string[] lignesFichier = File.ReadAllLines("entreprises.csv");

            for (int i = 1; i < lignesFichier.Length; i++) 
            {
                string ligne = lignesFichier[i];

                if (string.IsNullOrWhiteSpace(ligne))
                    continue;

                string[] colonnes = ligne.Split(';');

                int id = int.Parse(colonnes[0]);
                string nom = colonnes[1];
                string email = colonnes[2];
                string telephone = colonnes[3];
                string adresse = colonnes[4];
                string ville = colonnes[5];
                string codePostal = colonnes[6];
                string siret = colonnes[7];

                Entreprise entreprise = new Entreprise(id, nom, email, telephone, adresse, ville, codePostal, siret);

                entreprises.Add(entreprise);
                dictionnaireEntreprises.Add(id, entreprise);
            }

            string json = System.Text.Json.JsonSerializer.Serialize(
                entreprises,
                new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("entreprises.json", json);

            Console.WriteLine("Entreprises importées avec succès !");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }
    public void ChargerClientsDepuisJson()
    {
        try
        {
            clients.Clear();
            dictionnaireClients.Clear();
            string json = File.ReadAllText("clients.json");
            List<Client> clientsCharges = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(json);

            foreach (Client client in clientsCharges)
            {
                clients.Add(client);
                dictionnaireClients.Add(client.id, client);
            }
            Console.WriteLine("Clients chargés depuis le JSON avec succès !");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }
    public void ChargerEntreprisesDepuisJson()
    {
        try
        {
            entreprises.Clear();
            dictionnaireEntreprises.Clear();
            string json = File.ReadAllText("entreprises.json");
            List<Entreprise> entreprisesChargees = System.Text.Json.JsonSerializer.Deserialize<List<Entreprise>>(json);

            foreach (Entreprise entreprise in entreprisesChargees)
            {
                entreprises.Add(entreprise);
                dictionnaireEntreprises.Add(entreprise.id, entreprise);
            }
            Console.WriteLine("Entreprises chargées depuis le JSON avec succès !");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }
    public void AfficherClients()
    {
        if (clients.Count == 0)
            ChargerClientsDepuisJson();
        foreach (Client client in clients)
        {
            Console.WriteLine($"{client.id} - {client.nom}");
        }
    }
    public void AfficherEntreprises()
    {
        if (entreprises.Count == 0)
            ChargerEntreprisesDepuisJson();
        foreach (Entreprise entreprise in entreprises)
        {
            Console.WriteLine($"{entreprise.id} - {entreprise.nom}");
        }
    }
    public void GenererFichierTexteFacture(Facture facture)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FACTURE");
            sb.AppendLine($"Numéro : {facture.GetNumero()}");
            sb.AppendLine($"Date d'émission : {facture.GetDateEmission():dd/MM/yyyy}");
            sb.AppendLine($"Date d'échéance : {facture.GetDateEcheance():dd/MM/yyyy}");
            sb.AppendLine($"Statut : {facture.GetStatut()}");

            sb.AppendLine("Entreprise :");
            Entreprise e = facture.GetEntreprise();
            sb.AppendLine($"{e.GetId()} - {e.GetNom()} - {e.GetEmail()} - {e.GetTelephone()} - {e.GetAdresse()} - {e.GetVille()} - {e.GetCodePostal()} - {e.GetSiret()}");

            sb.AppendLine("Client :");
            Client c = facture.GetClient();
            sb.AppendLine($"{c.GetId()} - {c.GetNom()} - {c.GetEmail()} - {c.GetTelephone()} - {c.GetAdresse()} - {c.GetVille()} - {c.GetCodePostal()} - {c.GetDateInscription():dd/MM/yyyy}");

            sb.AppendLine("Lignes :");
            int i = 1;
            foreach (LigneFacture ligne in facture.GetLignes())
            {
                sb.AppendLine($"{i}. {ligne.GetDescription()} - Qté : {ligne.GetQuantite()} - PU HT : {ligne.GetPrixUnitaireHt()} - TVA : {ligne.GetTauxTva()} - Total HT : {ligne.CalculerTotalHT()} - Total TTC : {ligne.CalculerTotalTTC()}");
                i++;
            }

            sb.AppendLine($"Total HT : {facture.CalculerTotalHT()}");
            sb.AppendLine($"Total TVA : {facture.CalculerTotalTVA()}");
            sb.AppendLine($"Total TTC : {facture.CalculerTotalTTC()}");
            string nomFichier = $"facture_{facture.GetNumero()}.txt";
            File.WriteAllText(nomFichier, sb.ToString());
            Console.WriteLine($"Fichier généré : {nomFichier}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }
    public void CreerFacture()
    {
        try
        {
            if (clients.Count == 0)
                ChargerClientsDepuisJson();
            if (entreprises.Count == 0)
                ChargerEntreprisesDepuisJson();
            AfficherEntreprises();
            Console.Write("ID entreprise : ");
            int idEntreprise = int.Parse(Console.ReadLine());
            Entreprise entreprise = dictionnaireEntreprises[idEntreprise];

            AfficherClients();
            Console.Write("ID client : ");
            int idClient = int.Parse(Console.ReadLine());
            Client client = dictionnaireClients[idClient];
            Console.Write("Numéro de facture : ");
            string numero = Console.ReadLine();
            Console.Write("Date d'émission (dd/MM/yyyy) : ");
            DateTime dateEmission = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            DateTime dateEcheance = dateEmission.AddDays(30);

            Facture facture = new Facture(numero, dateEmission, client, entreprise, dateEcheance, "Brouillon");
            string reponse = "oui";
            while (reponse == "oui")
            {
                Console.Write("Description : ");
                string description = Console.ReadLine();

                Console.Write("Quantité : ");
                int quantite = int.Parse(Console.ReadLine());
                if (quantite <= 0)
                    throw new Exception("Quantité invalide.");

                Console.Write("Prix unitaire HT : ");
                decimal prixHT = decimal.Parse(Console.ReadLine());
                if (prixHT < 0)
                    throw new Exception("Prix invalide.");

                Console.Write("Taux TVA : ");
                decimal tva = decimal.Parse(Console.ReadLine());

                facture.AjouterLigne(new LigneFacture(description, quantite, prixHT, tva));

                Console.Write("Voulez-vous ajouter une autre ligne ? (oui/non) : ");
                reponse = Console.ReadLine();
            }
            facture.AfficherFacture();
            Console.Write("Confirmer la génération du fichier texte ? (oui/non) : ");
            if (Console.ReadLine() == "oui")
                GenererFichierTexteFacture(facture);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
        }
    }
}