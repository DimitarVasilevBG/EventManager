namespace EventManager.Database.Configuration
{
    public class Configuration
    {
        public static string ConnectionString;
        public Configuration(string newConnectionString)
        {
            ConnectionString = newConnectionString;
        }
    }
}

