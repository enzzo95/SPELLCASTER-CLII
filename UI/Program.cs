class Program
{
    static async Task Main()
    {
        Services services = new Services();
        HTML html = new HTML();

        while (true)
        {
            Console.WriteLine("\nBienvenue dans Spellcaster CLI !\nQue souhaitez-vous faire ?");
            Console.WriteLine("1. Corriger un texte en français\n2. Traduire un texte en français vers anglais");
            Console.WriteLine("3. Générer un fichier HTML\n4. Quitter");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("\nEntrez le texte à corriger :");
                    string correctionText = Console.ReadLine();
                    string correctedText = await services.Correct(correctionText);
                    Console.WriteLine(correctedText);
                    break;
                    
                case "2":
                    Console.WriteLine("\nEntrez le texte à traduire :");
                    string translateText = Console.ReadLine();
                    string translatedText = await services.Translate(translateText);
                    Console.WriteLine(translatedText);
                    break;

                case "3":
                    html.HTMLGenerator("ENZIZIZIZITO");
                    break;

                case "4":
                    return;
                    
                default:
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    break;
            }
        }
    }
}
