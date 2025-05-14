using System.Text.Json;
using System.Text;
using dotenv.net;

public static class Correction
{
    public static async Task TextCorrection()
    {
        DotEnv.Load();
        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Erreur : clé API manquante. Vérifie ton fichier .env.");
            return;
        }

        Console.WriteLine("Entrez le texte à corriger :");
        string text = Console.ReadLine();

        string url = "https://api.openai.com/v1/chat/completions";

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var requestBody = new
        {
            model = "gpt-4o",
            messages = new[]
            {
            new { role = "user", content = $"Corrige le texte, donne uniquement le texte corrigé, rien d'autre, si l'orthographe est bonne réécrit le : {text}" }
            },
            max_tokens = 100,
            temperature = 0.7,
        };

        string json = JsonSerializer.Serialize(requestBody);

        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(responseBody);
            var messageContent = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            Console.WriteLine(messageContent);
        }
        else
        {
            Console.WriteLine($"Erreur lors de l'appel à l'API : {response.StatusCode}");
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine(error);
        }
    }
}
