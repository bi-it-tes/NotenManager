namespace NotenManager.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Port=3308;Database=notenmanager;User=DBUser;Password=Espas8049;AllowUserVariables=True;";

            try
            {
                using var db = new MySqlConnector.MySqlConnection(connectionString);
                db.Open();
                Console.WriteLine("Verbindung erfolgreich!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
            }
        }
    }
}
