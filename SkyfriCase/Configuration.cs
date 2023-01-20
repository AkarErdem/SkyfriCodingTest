namespace SkyfriCase
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Directory.GetCurrentDirectory());
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MSSQL");
            }
        }
    }
}
