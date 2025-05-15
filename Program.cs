class Program
{
    static async Task Main()
    {
        Services services = new Services();
        HTML html = new HTML();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le royaume SpellCaster\nQue souhaitez vous réaliser ?\n");
            Console.WriteLine("1. Rectifier un propos en la noble langue de France.\n2. Transposer un écrit de la noble langue françoise en celle de l'illustre royaume d'Angleterre.");
            Console.WriteLine("3. Féconder l'émergence d'un grimoire HTML\n4. Quitter");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Entrez le texte à corriger :");
                    string correctionText = Console.ReadLine();
                    string correctedText = await services.Correct(correctionText);
                    Console.WriteLine(correctedText);

                    if (services.continueProgram()) break; else return;
                    
                case "2":
                    Console.Clear();
                    Console.WriteLine("Entrez le texte à traduire :");
                    string textToTranslate = Console.ReadLine();
                    string translatedText = await services.Translate(textToTranslate);
                    Console.WriteLine(translatedText);

                    if (services.continueProgram()) break; else return;

                case "3":
                    Console.Clear();
                    List<string> result = await services.Story();
                    html.HTMLGenerator(result[0], result[1], result[2]);
                    
                    string Story = await services.Story();
                    Console.WriteLine("Comment souhaitez-vous nommer le HTML ? (sans .html)");
                    string FileTag = Console.ReadLine();
                    html.HTMLGenerator(FileTag, Story);
                    if (services.continueProgram()) break; else return;

                case "4":
                    return;
                    
                default:
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    break;
            }
        }
    }
}