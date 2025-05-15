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

        Console.Clear();
        
        return await openAi.SendRequest(prompt);
    }

    public async Task<string> Translate(string text)
    {
        Console.WriteLine("\n1. Anglais US\n2. Anglais UK");
        string choice = Console.ReadLine();
        string english = "US";

        switch (choice)
        {
                case "1":
                    english = "US(de facon familier)";
                    Console.Clear();
                    break;
                case "2":
                    english = "UK(de facon archaic)";
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("\nChoix invalide, par défaut anglais US");
                    break;  
        }

        string prompt = $"Traduis ce texte français en anglais {english}, si le texte n'est pas en francais ecrit seulement 'Erreur: le texte n'est pas en francais' donne uniquement la traduction : {text}";
        
        return await openAi.SendRequest(prompt);
    }

    public async Task<List<string>> Story()
    {
        Console.WriteLine("Quel est le prénom du premier personnage ?");
        string character1 = Console.ReadLine();
        Console.WriteLine("\nQuel est le prénom du second personnage ?");
        string character2 = Console.ReadLine();

        Console.WriteLine("\nQuel est le genre de l'histoire ? (1-10)");

        Dictionary<int, string> genres = new Dictionary<int, string>
        {
            {1,"Shonen"},
            {2,"Romantique"},
            {3,"Fantasy"},
            {4,"Épopées"},
            {5,"Isekai"},
            {6,"Fable"},
            {7,"Drame"},
            {8,"Mystique"},
            {9,"Policier"},
            {10,"Psychologique"}
        };

        foreach (var genr in genres)
        {
            Console.WriteLine($"{genr.Key}. {genr.Value}");
        }
        
        int genreChoice = int.Parse(Console.ReadLine());

        string prompt = $"Tu es un écrivain d'exception, chargé de créer une histoire courte de facon archaique dans le genre {genres[genreChoice]}. Le récit doit rayonner d'humanité et de spontanéité, avec une narration d'une richesse littéraire inégalée, où chaque mot devient une note de musique      dans une symphonie d'émotions. L'histoire, fluide et intense, doit mêler habilement phrases courtes et longues, un ton poétique et familier,     capturant l'essence même des personnages, {character1} et {character2}, complexes et profonds. Ces derniers évolueront dans un univers aussi       étrange que familier, où l'inconnu devient un terrain fertile pour la réflexion et l'émotion. Le texte doit inviter à la contemplation, à     l'introspection, et offrir au lecteur une expérience aussi bouleversante qu'éblouissante. Ecrit moi l'histoire en html, seulement         l'interieur du body(n'instaure pas <body> </body>)(je souhaite avoir tout cela en version text), utilise bien h1, h2, h3, etc.. donne moi le code et rien         d'autre";

        Console.WriteLine("Comment souhaitez-vous nommer le HTML ? (sans .html)");
        string fileName = Console.ReadLine();
            
        return new List<string> {genres[genreChoice], fileName, await openAi.SendRequest(prompt)};
    }

    public async Task<string> Story() {
   
    Dictionary<int, string> Genres = new Dictionary<int, string> {
        {1,"Shonen"},
        {2,"Romantique"},
        {3,"Fantasy"},
        {4,"Épopées"},
        {5,"Isekai"},
        {6,"Fable"},
        {7,"Drame"},
        {8,"Mystique"},
        {9,"Réalisme magique"},
        {10,"Psychologique"}
    };
    Console.WriteLine("Que sera le Prenom du 1er personnage ? : ");
    string Prenom1 = Console.ReadLine();

    Console.WriteLine("Que sera le Prénom du 2ème personnage ? :");
    string Prenom2 = Console.ReadLine();

    Console.WriteLine("Que sera le genre du texte literraire ? : ");

    foreach (var genr in Genres) {
        Console.WriteLine($"{genr.Key}.{genr.Value}");
    }

    int Choice = int.Parse(Console.ReadLine());

    string prompt = $"Tu es un écrivain d'exception, chargé de créer une histoire courte de facon archaique dans le genre {Genres}. Le récit doit rayonner d'humanité et de spontanéité, avec une narration d'une richesse littéraire inégalée, où chaque mot devient une note de musique dans une symphonie d'émotions. L'histoire, fluide et intense, doit mêler habilement phrases courtes et longues, un ton poétique et familier, capturant l'essence même des personnages, {Prenom1} et {Prenom2}, complexes et profonds. Ces derniers évolueront dans un univers aussi étrange que familier, où l'inconnu devient un terrain fertile pour la réflexion et l'émotion. Le texte doit inviter à la contemplation, à l'introspection, et offrir au lecteur une expérience aussi bouleversante qu'éblouissante. Ecrit moi l'histoire en html, seulement l'interieur du body(n'instaure pas <body> </body>), utilise bien h1, h2, h3, etc.. donne moi le code et rien d'autre";

    return await openAi.SendRequest(prompt);
}

    public bool continueProgram()
    {
        Console.WriteLine("\nVoulez-vous continuer ? (y/n)");

        while(true)
        {
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                return true;
            }
            else if (choice.ToLower() == "n")
            {
                Console.WriteLine("Arret du programme.");
                return false;
            }
            else
            {
                Console.WriteLine("Choix invalide, réessayez (y/n)");
            }
        }
    }
}

