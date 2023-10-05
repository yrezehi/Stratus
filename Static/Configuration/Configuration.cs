namespace Static.Configuration
{
    public static class Configuration
    {
        private static IConfiguration ConfigurationInstance = new ConfigurationBuilder().Build();

        public static void Register(IConfiguration configuration) =>
            ConfigurationInstance = configuration;

        public static T GetValue<T>(string path)
        {
            T? value = ConfigurationInstance.GetValue<T>(path);

            if(value != null)
            {
                throw new ArgumentException("No such configuration property path {path}!");
            }

            return value!;
        }

    }
}
