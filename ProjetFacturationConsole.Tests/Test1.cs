namespace ProjetFacturationConsole.Tests;

[TestClass]
public class Test1
{
    [TestMethod]
    public void Test_CalculerTotalHT()
    {
        LigneFacture ligne = new LigneFacture("Test", 2, 150, 20);
        decimal result = ligne.CalculerTotalHT();
        Assert.AreEqual(300, result);
    }

    [TestMethod]
    public void Test_CalculerTotalTTC()
    {
        LigneFacture ligne = new LigneFacture("Test", 2, 150, 20);
        decimal result = ligne.CalculerTotalTTC();
        Assert.AreEqual(360, result);
    }

    [TestMethod]
    public void Test_CalculerTotalTTC_Facture()
    {
        Client c = new Client(1, "aa", "aa@mail.fr", "0611223344", "rue test", "Amiens", "80000", DateTime.Parse("19/05/2024"));
        Entreprise e = new Entreprise(1, "entreprise", "contact@entreprise.fr", "0322000001", "rue test", "Amiens", "80000", "12345678900011");

        Facture f = new Facture("F001", DateTime.Now, c, e, DateTime.Now.AddDays(30), "test");
        f.AjouterLigne(new LigneFacture("Ligne 1", 2, 150, 20)); 
        f.AjouterLigne(new LigneFacture("Ligne 2", 1, 80, 10));  

        decimal result = f.CalculerTotalTTC();
        Assert.AreEqual(448, result);
    }
}