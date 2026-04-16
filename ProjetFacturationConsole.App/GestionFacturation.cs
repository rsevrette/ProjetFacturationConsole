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
}