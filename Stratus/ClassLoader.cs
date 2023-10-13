using System.IO;

namespace Stratus
{
    public class ClassLoader
    {
        public static void Load(string classPath) {

            if (!File.Exists(classPath))
            {
                throw new FileNotFoundException($"Class was not found for {classPath}");
            }
        }

        private static string LoadAsText(string classPath)
        {
            using (var streamReader = new StreamReader(classPath))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
