using System.Text.Json;
using System.Text;
using dotenv.net;
using System.Net.Http;

public class OpenAi
{
    private readonly HttpClient client;
    private readonly string apiKey;
    private const string url = "https://api.openai.com/v1/chat/completions";

    public OpenAi()
    {
        DotEnv.Load();
        apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Erreur : clé API manquante.");
            throw new ArgumentNullException("La clé API OpenAI est requise.");
        }

        client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> SendRequest(string prompt)
    {
        var requestBody = new
        {
            model = "gpt-4o",
            messages = new[] { new { role = "user", content = prompt } },
            max_tokens = 1000,
            temperature = 0.8
        };

        string json = JsonSerializer.Serialize(requestBody);

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseBody);
            var messageContent = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            return $"{messageContent}";
        }

        else
        {
            return $"Erreur lors de l'appel à l'API : {response.StatusCode}";
        }
    }
}
