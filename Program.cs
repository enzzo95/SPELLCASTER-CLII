using dotenv.net;


class Program
{
    static void Main(string[] args)
    {
        DotEnv.Load();

        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("❌ Erreur : clé API manquante. Vérifie ton fichier .env.");
            return;
        }

        Console.WriteLine($"Clé API : {apiKey}");
    }
}