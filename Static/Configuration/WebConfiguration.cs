namespace Static.Configuration
{
    public static class WebConfiguration
    {
        private static IConfiguration ConfigurationInstance = new ConfigurationBuilder().Build();

        public static void Register(IConfiguration configuration) =>
            ConfigurationInstance = configuration;

        public static IConfigurationSection GetSection(string section) =>
            ConfigurationInstance.GetSection(section);

        public static T GetValue<T>(string path)
        {
            T? value = ConfigurationInstance.GetValue<T>(path);

            if(value == null)
            {
                throw new ArgumentException("No such configuration property path {path}!");
            }

            return value!;
        }

        public static IList<T> GetList<T>(string path)
        {
            List<T>? value = GetSection(path).Get<List<T>>();

            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("No such configuration property path {path}!");
            }

            return value!;
        }
    }
}
