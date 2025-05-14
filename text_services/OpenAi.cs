using System.Text.Json;
using System.Text;
using dotenv.net;
using System.Net.Http;

public class OpenAi
{
    private readonly HttpClient client;
    private readonly string apiKey;

    public OpenAi()
    {
        DotEnv.Load();
        apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Erreur : clé API manquante.");
        }

        client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> PromptAsync(string prompt)
    {
        var requestBody = new
        {
            model = "gpt-4o",
            messages = new[] { new { role = "user", content = prompt } },
            max_tokens = 100,
            temperature = 0.7
        };

        string json = JsonSerializer.Serialize(requestBody);

        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseBody);
            var messageContent = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return messageContent;
        }

        else
        {
            return $"Erreur lors de l'appel à l'API : {response.StatusCode}";
        }
    }
}
