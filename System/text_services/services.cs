public class Services
{
    private readonly OpenAi openAi;

    public Services()
    {
        openAi = new OpenAi();
    }

    public async Task<string> Correct(string text)
    {
        string prompt = $"Corrige le texte, donne uniquement le texte corrigé, rien d'autre. " +
                        $"Si tu ne reconnais pas le sens du texte, écris 'Erreur: texte non reconnu'. " +
                        $"Si l'orthographe est bonne, réécris le : {text}";
        
        return await openAi.PromptAsync(prompt);
    }

    public async Task<string> Translate(string text)
    {
        Console.WriteLine("\n1. Anglais US\n2. Anglais UK");
        string choice = Console.ReadLine();
        string english = "US";

        switch (choice)
        {
                case "1":
                    english = "US";
                    break;
                case "2":
                    english = "UK";
                    break;
                default:
                    Console.WriteLine("\nChoix invalide, par défaut anglais US");
                    break;  
        }

        string prompt = $"\nTraduis ce texte français en anglais {english}, donne uniquement la traduction : {text}";
        return await openAi.PromptAsync(prompt);
    }
}
